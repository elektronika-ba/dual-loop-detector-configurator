using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace DLDConfig1v1
{
    public partial class frmMain : Form
    {
        const int _XTAL_FREQ = 32000000; // 8MHz crystal * PLL(4) = 32MHz
        const int _XTAL_FREQ_KHZ = (_XTAL_FREQ / 1000);
        const int _TMR1_FREQ = (_XTAL_FREQ / 4 / 2); // TMR1 je Fosc/4 i ima jos prescaled 1:2 pa je zato /4/2
        const int _TMR1_FREQ_KHZ = (_TMR1_FREQ / 1000);
        const int _TMR0_RELOADER_MAX = 130;
        const int _TMR0_PRESCALER_MAX = 0b00000100;
        const int _UART_COMM_MODE_ENTER_DELAY_MS = 3000; // 3 seconds max wait for entering into comm uart mode
        const char _UART_START_CHAR = (char)26;	// 26 = CTRL+Z
        const int EE_SIZE = 95; // 95 bytes, *2 in hexa
        const int FREQ_ANA_BUFFER_SIZE = 4096;
        const int SHORTEST_SPEED_TIME_MS = 2500; // ms

        private List<byte> spData = new List<byte>();
        private const string commandTerminator = "END>\r\n";
        private const string crlf = "\r\n";

        private string saveAnalysisFolder = "";

        private enum TRXState
        {
            Running, // device is running (resumed operation)
            Comm, // device is in uart communication state, waiting for our command
            Comm_Setting, // device is in uart communication mode, we initiated SET command and now we are working it
        }

        /*
            Event code	Event description
            ---------------------------------
            01,xxx.yyy	Undetect, xxx.yyy=strength of detection in percentages in fixed format 000.000
            02,xxx.yyy	Rollaway, did not stop, xxx.yyy=strength of detection in percentages in fixed format 000.000
            03,xxx.yyy	Undetect because of PPC, xxx.yyy=strength of detection in percentages in fixed format 000.000
            04,xxxxx	Movement while stopped, x=change in fixed format 00000
            05,xxxxx	Movement before stopped, x=change in fixed format 00000
            06,xxx.yyy	Repeated stop detected, xxx.yyy=strength of detection in percentages in fixed format 000.000
            07,xxx.yyy	Initial stop detected, xxx.yyy=strength of detection in percentages in fixed format 000.000
            08		    Detect! (detection strength can't be calculated yet)
            09		    Movement after-PPC
            10,xxx		Speed in km/h or mile/h in fixed 000 format
            11		    Canceled A->B direction
            12		    Going back B->A direction
            13		    Passed B->A
            14		    Cancelled B->A direction
            15		    Going back A->B
            16		    Passed A->B
            17,xxx		Speed over limit with difference in km/h or mile/h in fixed 000 format
            18,xxx		Speed under or equal to limit with difference in km/h or mile/h in fixed 000 format
            19,xxx		Entry speed in km/h or mile/h in fixed 000 format
            20,xxx		Exit speed in km/h or mile/h in fixed 000 format
            21,xxx		Vehicle length in centimeters in fixed 000 format
        */

        /*private enum TEventCode
        {
            Undetect = 1,
            Rollaway = 2,
            UndetectPPC = 3,
            MovementWhileStopped = 4,
            MovementBeforeStopped = 5,
            RepeatedStopDetected = 6,
            InitialStopDetected = 7,
            Detect = 8,
            MovementAfterPPC = 9,
            SpeedReportMean = 10,
            DirectionA2BCancel = 11,
            DirectionB2AGoingBack = 12,
            DirectionB2APassed = 13,
            DirectionB2ACancel = 14,
            DirectionA2BGoingBack = 15,
            DirectionA2BPassed = 16,
            SpeedWasOverLimit = 17,
            SpeedWasUnderOrEqualToLimit = 18,
            SpeedReportEntry = 19,
            SpeedReportExit = 20,
            VehicleLengthReport = 21,
        }*/

        Dictionary<int, string> EventName = new Dictionary<int, string>()
        {
            { 1, "Undetect, strength: $%" },
            { 2, "Rollaway without stopping, strength: $%" },
            { 3, "Undetect because of PPC, strength: $%" },
            { 4, "Movement while stop detected, change: $" },
            { 5, "Movement before stopping, change: $" },
            { 6, "Repeated stop detected, strength: $%" },
            { 7, "Initial stop detected, strength: $%" },
            { 8, "Detect" },
            { 9, "Movement after PPC" },
            { 10, "Speed report (mean): $" },
            { 11, "A->B pass cancelled" },
            { 12, "B->A going back" },
            { 13, "B->A passed" },
            { 14, "B->A pass cancel" },
            { 15, "A->B going back" },
            { 16, "A->B passed" },
            { 17, "Overspeeding detected, excess: $" },
            { 18, "Underspeeding, with: $" },
            { 19, "Speed report (entry): $" },
            { 20, "Speed report (exit): $" },
            { 21, "Vehicle length: $cm" },
        };

        // used during programming (sending data to device)
        private int commSettingIndex = 0;
        private string hex2send = "";

        private TRXState rxState = TRXState.Running; // running at app startup (we assume)

        private class TDeviceStuff
        {
            public TDeviceStuff()
            {
                freq = new List<double>(2);
                err = new List<int>(2);
                lastEvent = new List<string>(2);
                dips = new List<byte>(2);
                freqAna = new List<CirBuff<double>>(2);
                detectState = new List<bool>(2);
                freqAna4Save = new List<List<double>>(2);
                for (int i = 0; i < 2; i++)
                {
                    freq.Add(0.0);
                    err.Add(-1);
                    lastEvent.Add("");
                    dips.Add(0x00);
                    detectState.Add(false);
                    freqAna.Add(new CirBuff<double>(FREQ_ANA_BUFFER_SIZE));
                    freqAna4Save.Add(new List<double>());
                }
                mode = -1;
            }
            public List<double> freq { get; set; }
            public List<int> err { get; set; }
            public List<string> lastEvent { get; set; }
            public int mode { get; set; }
            public List<byte> dips { get; set; }
            public List<bool> detectState { get; set; }
            public List<CirBuff<double>> freqAna { get; set; }
            public List<List<double>> freqAna4Save { get; set; }
        };

        private TDeviceStuff deviceStuff = new TDeviceStuff();

        private TaskFactory uiFactory;

        [Serializable]
        public class TConfigPacket
        {
            public TConfigPacket()
            {

            }

            public TConfigPacket(bool initSensitivities)
            {
                // TODO: Ovdje defaultne vrijednosti stavi, iz Firmware-a iste !
                this.filterNormal = new TFiltering(100, 90, 4);
                this.filterMore = new TFiltering(50, 40, 8);
                this.sensitivitiesLoopA = new List<TSensitivity>(8);
                this.sensitivitiesLoopB = new List<TSensitivity>(8);
                for (int i = 0; i < 8; i++)
                {
                    this.sensitivitiesLoopA.Add(new TSensitivity(1, 1));
                    this.sensitivitiesLoopB.Add(new TSensitivity(1, 1));
                }
                this.softDIPA = 0x00;
                this.softDIPB = 0x00;
                this.dcddThreshold = 1;
                this.dcddTmr = 1;
                this.detectStopSlowCheckerTmr = 1;
                this.detectStopThreshold = 1;
                this.detectStopTmr = 1;
                this.ppcDetectLeftThreshold = 1;
                this.ppcDetectLeftTmr = 1;
                this.ppcTimeShort = 1;
                this.ppcTimeMedium = 1;
                this.ppcTimeLong = 1;
                this.relADurExtended = 1;
                this.relADurNormal = 1;
                this.relBDurExtended = 1;
                this.relBDurNormal = 1;
                this.sensitivityLoopA = 1;
                this.sensitivityLoopB = 1;
                this.speedDistanceCm = 200;
                this.tmr1Best = 40000;
                this.useSoftDIPs = 0x00;
                this.validVal = 0xAA;
            }

            public class TFiltering
            {
                public TFiltering()
                {
                    this.negativeDriftTmr = 1;
                    this.positiveDriftTmr = 1;
                    this.counterArrayLength = 1;
                }

                public TFiltering(byte negativeDriftTmr, byte positiveDriftTmr, byte counterArrayLength)
                {
                    this.negativeDriftTmr = negativeDriftTmr;
                    this.positiveDriftTmr = positiveDriftTmr;
                    this.counterArrayLength = counterArrayLength;
                }
                public byte counterArrayLength { get; set; }
                public byte negativeDriftTmr { get; set; }
                public byte positiveDriftTmr { get; set; }
            }

            public class TSensitivity
            {
                public TSensitivity()
                {
                    this.onThreshold = 1;
                    this.offThreshold = 1;
                }
                public TSensitivity(ushort onThreshold, ushort offThreshold)
                {
                    this.onThreshold = onThreshold;
                    this.offThreshold = offThreshold;
                }
                public ushort onThreshold { get; set; }
                public ushort offThreshold { get; set; }
            }

            public byte validVal { get; set; }
            public byte sensitivityLoopA { get; set; }
            public byte sensitivityLoopB { get; set; }
            public TFiltering filterNormal { get; set; }
            public TFiltering filterMore { get; set; }
            public List<TSensitivity> sensitivitiesLoopA { get; set; }
            public List<TSensitivity> sensitivitiesLoopB { get; set; }
            public byte detectStopTmr { get; set; }
            public byte detectStopThreshold { get; set; }
            public ushort dcddTmr { get; set; }
            public byte dcddThreshold { get; set; }
            public byte useSoftDIPs { get; set; }
            public byte softDIPA { get; set; }
            public byte softDIPB { get; set; }
            public byte ppcTimeShort { get; set; }
            public byte ppcTimeMedium { get; set; }
            public byte ppcTimeLong { get; set; }
            public byte ppcDetectLeftTmr { get; set; }
            public byte ppcDetectLeftThreshold { get; set; }
            public byte relADurNormal { get; set; }
            public byte relADurExtended { get; set; }
            public byte relBDurNormal { get; set; }
            public byte relBDurExtended { get; set; }
            public ushort tmr1Best { get; set; }
            public ushort speedDistanceCm { get; set; }
            public byte detectStopSlowCheckerTmr { get; set; }
        }

        private TConfigPacket configPacket = new TConfigPacket(true);

        /**
         * Updates current config packet with data from form.
         **/
        public void updateConfigPacket()
        {
            // tmr1 best
            configPacket.tmr1Best = (ushort)uctbSamplingSpeed.Value;

            // DIPs
            configPacket.softDIPA = 0x00;
            foreach (Control c in gbDIP1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int bitWeight = int.Parse(cb.Tag.ToString());
                    if (cb.Checked)
                    {
                        configPacket.softDIPA += (byte)Math.Pow(2, bitWeight);
                    }
                }
            }
            configPacket.softDIPB = 0x00;
            foreach (Control c in gbDIP2.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int bitWeight = int.Parse(cb.Tag.ToString());
                    if (cb.Checked)
                    {
                        configPacket.softDIPB += (byte)Math.Pow(2, bitWeight);
                    }
                }
            }

            // using soft dips?
            configPacket.useSoftDIPs = ckUseSoftDIPs.Checked ? (byte)0xFF : (byte)0x00;

            // sensitivity stuff
            configPacket.sensitivityLoopA = (byte)(cbSensitivityA.SelectedIndex + 1);
            configPacket.sensitivityLoopB = (byte)(cbSensitivityB.SelectedIndex + 1);
            if (cbSensitivityA.SelectedIndex > -1)
            {
                configPacket.sensitivitiesLoopA[cbSensitivityA.SelectedIndex] = new TConfigPacket.TSensitivity((ushort)uctbSensitivityDetectThresholdA.Value, (ushort)uctbSensitivityUndetectThresholdA.Value);
            }
            if (cbSensitivityB.SelectedIndex > -1)
            {
                configPacket.sensitivitiesLoopB[cbSensitivityB.SelectedIndex] = new TConfigPacket.TSensitivity((ushort)uctbSensitivityDetectThresholdB.Value, (ushort)uctbSensitivityUndetectThresholdB.Value);
            }

            // filtering stuff
            if (cbFilteringLevel.SelectedIndex == 0)
            {
                configPacket.filterNormal = new TConfigPacket.TFiltering((byte)uctbFilteringNegative.Value, (byte)uctbFilteringPositive.Value, (byte)uctbFilteringAveraging.Value);
            }
            else if (cbFilteringLevel.SelectedIndex == 1)
            {
                configPacket.filterMore = new TConfigPacket.TFiltering((byte)uctbFilteringNegative.Value, (byte)uctbFilteringPositive.Value, (byte)uctbFilteringAveraging.Value);
            }

            // relay pulse durations
            configPacket.relADurNormal = (byte)uctbRelayAPulseNormal.Value;
            configPacket.relADurExtended = (byte)uctbRelayAPulseExtended.Value;
            configPacket.relBDurNormal = (byte)uctbRelayBPulseNormal.Value;
            configPacket.relBDurExtended = (byte)uctbRelayBPulseExtended.Value;

            // ppc related
            configPacket.ppcTimeShort = (byte)uctbPPCShort.Value;
            configPacket.ppcTimeMedium = (byte)uctbPPCMedium.Value;
            configPacket.ppcTimeLong = (byte)uctbPPCLong.Value;
            configPacket.ppcDetectLeftTmr = (byte)uctbPPCDetLeftTimer.Value;
            configPacket.ppcDetectLeftThreshold = (byte)uctbPPCDetLeftThreshold.Value;

            // detect stop
            configPacket.detectStopTmr = (byte)uctbDetStopTimer.Value;
            configPacket.detectStopThreshold = (byte)uctbDetStopThreshold.Value;
            configPacket.detectStopSlowCheckerTmr = (byte)uctbDetStopSlowCheckerTimer.Value;

            // dcdd
            configPacket.dcddTmr = (ushort)uctbDCDDTimer.Value;
            configPacket.dcddThreshold = (byte)uctbDCDDThreshold.Value;

            // speed trap
            configPacket.speedDistanceCm = (ushort)uctbSpeedDistance.Value;
        }

        /**
         * Puts current config packet to screen/form.
         **/
        public void configPacketToScreen(bool onlyDIPsAndOpMode = false)
        {
            // decode operating mode
            byte opmode = (byte)(configPacket.softDIPA & 0b00000011);
            cbOperatingMode.SelectedIndex = opmode;

            // DIPs
            foreach (Control c in gbDIP1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int bitWeight = int.Parse(cb.Tag.ToString());
                    cb.Checked = false;
                    if ((configPacket.softDIPA & (byte)Math.Pow(2, bitWeight)) > 0)
                    {
                        cb.Checked = true;
                    }
                }
            }
            foreach (Control c in gbDIP2.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    int bitWeight = int.Parse(cb.Tag.ToString());
                    cb.Checked = false;
                    if ((configPacket.softDIPB & (byte)Math.Pow(2, bitWeight)) > 0)
                    {
                        cb.Checked = true;
                    }
                }
            }

            // if only DIPs should be updated on screen, end here
            if (onlyDIPsAndOpMode)
            {
                return;
            }

            // tmr1 best
            uctbSamplingSpeed.Value = configPacket.tmr1Best;

            // using soft dips?
            ckUseSoftDIPs.Checked = configPacket.useSoftDIPs == 0xFF;

            // sensitivity stuff
            // A
            cbSensitivityA.SelectedIndex = configPacket.sensitivityLoopA - 1;
            uctbSensitivityDetectThresholdA.Value = configPacket.sensitivitiesLoopA[cbSensitivityA.SelectedIndex].onThreshold;
            uctbSensitivityUndetectThresholdA.Value = configPacket.sensitivitiesLoopA[cbSensitivityA.SelectedIndex].offThreshold;
            // B
            cbSensitivityB.SelectedIndex = configPacket.sensitivityLoopB - 1;
            uctbSensitivityDetectThresholdB.Value = configPacket.sensitivitiesLoopB[cbSensitivityB.SelectedIndex].onThreshold;
            uctbSensitivityUndetectThresholdB.Value = configPacket.sensitivitiesLoopB[cbSensitivityB.SelectedIndex].offThreshold;

            // filtering stuff
            cbFilteringLevel.SelectedIndex = 0; // show first option on screen, others will be loaded on user-change
            uctbFilteringNegative.Value = configPacket.filterNormal.negativeDriftTmr;
            uctbFilteringPositive.Value = configPacket.filterNormal.positiveDriftTmr;
            uctbFilteringAveraging.Value = configPacket.filterNormal.counterArrayLength;

            // relay pulse durations
            uctbRelayAPulseNormal.Value = configPacket.relADurNormal;
            uctbRelayAPulseNormal.TriggerChange(null, null);
            uctbRelayAPulseExtended.Value = configPacket.relADurExtended;
            uctbRelayAPulseExtended.TriggerChange(null, null);
            uctbRelayBPulseNormal.Value = configPacket.relBDurNormal;
            uctbRelayBPulseNormal.TriggerChange(null, null);
            uctbRelayBPulseExtended.Value = configPacket.relBDurExtended;
            uctbRelayBPulseExtended.TriggerChange(null, null);

            // ppc related
            uctbPPCShort.Value = configPacket.ppcTimeShort;
            uctbPPCShort.TriggerChange(null, null);
            uctbPPCMedium.Value = configPacket.ppcTimeMedium;
            uctbPPCMedium.TriggerChange(null, null);
            uctbPPCLong.Value = configPacket.ppcTimeLong;
            uctbPPCLong.TriggerChange(null, null);

            uctbPPCDetLeftTimer.Value = configPacket.ppcDetectLeftTmr;
            uctbPPCDetLeftThreshold.Value = configPacket.ppcDetectLeftThreshold;

            // detect stop
            uctbDetStopTimer.Value = configPacket.detectStopTmr;
            uctbDetStopThreshold.Value = configPacket.detectStopThreshold;
            uctbDetStopSlowCheckerTimer.Value = configPacket.detectStopSlowCheckerTmr;
            uctbDetStopSlowCheckerTimer.TriggerChange(null, null);

            // dcdd
            uctbDCDDTimer.Value = configPacket.dcddTmr;
            uctbDCDDThreshold.Value = configPacket.dcddThreshold;

            // speed trap
            uctbSpeedDistance.Value = configPacket.speedDistanceCm;
            uctbSpeedDistance.TriggerChange(null, null);

            // trigger change event on sampling speed, so that everything that depends on it gets updated
            uctbSamplingSpeed.TriggerChange(null, null);
        }

        public frmMain()
        {
            InitializeComponent();

            // make all components trigger updateConfigPacket()
            List<Control> c2check = findControlRecursively(this, "UPDATE_CONFIG_PACKET");
            foreach (Control c in c2check)
            {
                if (c is ucTrackBar)
                {
                    ((ucTrackBar)c).TrackbarChanged += new System.EventHandler(delegate (object sender, EventArgs e)
                    {
                        if (sender == null && e == null) return; // on our programmatic change, don't do this

                        tmrUpdateConfigPacket.Enabled = false;
                        tmrUpdateConfigPacket.Enabled = true;
                    });
                }
                else if (c is ComboBox)
                {
                    // https://stackoverflow.com/a/13452659
                    ((ComboBox)c).SelectionChangeCommitted += new System.EventHandler(delegate (object sender, EventArgs e)
                    {
                        if (sender == null && e == null) return; // on our programmatic change, don't do this

                        tmrUpdateConfigPacket.Enabled = false;
                        tmrUpdateConfigPacket.Enabled = true;
                    });
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).CheckedChanged += new System.EventHandler(delegate (object sender, EventArgs e)
                    {
                        if (sender == null && e == null) return; // on our programmatic change, don't do this

                        tmrUpdateConfigPacket.Enabled = false;
                        tmrUpdateConfigPacket.Enabled = true;
                    });
                }
            }

            // also make opmode checkboxes on-change trigger the updating of config packet. on both group boxes containing DIPs
            List<Control> cl = new List<Control>();
            cl.Add(gbDIP1);
            cl.Add(gbDIP2);
            foreach (Control ch in cl)
            {
                foreach (Control c in ch.Controls)
                {
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).CheckedChanged += new System.EventHandler(delegate (object sender, EventArgs e)
                        {
                            if (sender == null && e == null) return; // on our programmatic change, don't do this

                            tmrUpdateConfigPacket.Enabled = false;
                            tmrUpdateConfigPacket.Enabled = true;
                        });
                    }
                }
            }

            // https://stackoverflow.com/a/14129252
            uiFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            tssDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // use this timer also for displaying current loops frequencies in the statusbar
            tssFrequencyLoopA.Text = tssFrequencyLoopA.Tag.ToString().Replace("%", deviceStuff.freq[0].ToString("0.00"));
            tssFrequencyLoopB.Text = tssFrequencyLoopB.Tag.ToString().Replace("%", deviceStuff.freq[1].ToString("0.00"));

            // also display state device is in
            string state = "Unknown";
            switch(rxState)
            {
                case TRXState.Comm:
                case TRXState.Comm_Setting:
                    state = "Communicating";
                    break;
                case TRXState.Running:
                    state = "Running";
                    break;
            }
            tssDeviceState.Text = tssDeviceState.Tag.ToString().Replace("%", state);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings s = new frmSettings();

            // popuni formu sa trneutnim podesenjima
            string comPort = Properties.Settings.Default.ComPort;
            s.setFormData(comPort);

            DialogResult r = s.ShowDialog();
            if (r == DialogResult.OK)
            {
                // snimi u settingse izmjene sa forme
                comPort = s.getFormData();

                Properties.Settings.Default.ComPort = comPort;
                Properties.Settings.Default.Save();
            }
        }

        /**
         * Selecting an item from the listbox menu on the left.
         * */
        private void lbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Panel)
                {
                    if (c.Tag != null && c.Tag.Equals(lbMenu.SelectedIndex.ToString()))
                    {
                        c.Visible = true;
                        c.Dock = DockStyle.Fill;
                        // find title label to copy the title from listbox menu
                        foreach (Control cl in ((Panel)c).Controls)
                        {
                            if (cl is Label && cl.Tag != null && ((Label)cl).Tag.Equals("title"))
                            {
                                ((Label)cl).Text = (string)lbMenu.SelectedItem;
                                break;
                            }
                        }
                    }
                    else c.Visible = false;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lbMenu.SelectedIndex = 0; // this will tigger lbMenu_SelectedIndexChanged

            // put default config packet to screen
            configPacketToScreen();
        }

        /**
         * Changing the operating mode adjusts texts for checkboxes.
         * */
        private void cbOperatingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> DIP1texts = new Dictionary<string, List<string>>()
            {
                // single loop
                { "0", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency", "Additional signal filtering", "Fail Safe", "ASB", "Detect Stop on relay A" } },
                // dual independent
                { "1", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "ASB for loop A and B", "PPC (max) for loop A and B" } },
                // dual directional
                { "2", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "ASB for loop A and B", "Extended pulse for relay A and B" } },
                // speed trap
                { "3", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "Extended pulse for relay A and B", "Speed is in mph" } },
            };

            Dictionary<string, List<string>> DIP2texts = new Dictionary<string, List<string>>()
            {
                // single loop
                { "0", new List<string>() { "Relay A presence type", "Relay A extended pulse", "Relay A pulse on detect", "Relay B presence type", "Relay B extended pulse", "Relay B pulse on detect", "PPC 7", "PPC 8" } },
                // dual independent
                { "1", new List<string>() { "Detect Stop for loop A", "Detect Stop for loop B", "Fail Safe for loop A", "Fail Safe for loop B", "Relay A presence type", "Relay B presence type", "Extended pulse for relay A and relay B", "Pulse on detect for relay A and relay B" } },
                // dual directional
                { "2", new List<string>() { "Detect cancellation of A->B", "Detect cancellaton of B->A", "not in use", "not in use", "not in use", "not in use", "not in use", "not in use" } },
                // speed trap
                { "3", new List<string>() { "+5", "+10", "+20", "+30", "+40", "+50", "+60", "+70" } },
            };

            // do check appropriate Mode checkboxes
            ckMode0.Checked = (cbOperatingMode.SelectedIndex == 1 || cbOperatingMode.SelectedIndex == 3);
            ckMode1.Checked = (cbOperatingMode.SelectedIndex == 2 || cbOperatingMode.SelectedIndex == 3);

            tssCurrentOPMODE.Text = tssCurrentOPMODE.Tag.ToString().Replace("%", cbOperatingMode.Text);

            // adjust DIP1 texts
            foreach (Control c in gbDIP1.Controls)
            {
                if (c is CheckBox)
                {
                    List<string> t = DIP1texts[cbOperatingMode.SelectedIndex.ToString()];
                    ((CheckBox)c).Text = t[int.Parse(c.Tag.ToString())];
                }
            }

            // adjust DIP2 texts
            foreach (Control c in gbDIP2.Controls)
            {
                if (c is CheckBox)
                {
                    List<string> t = DIP2texts[cbOperatingMode.SelectedIndex.ToString()];
                    ((CheckBox)c).Text = t[int.Parse(c.Tag.ToString())];
                }
            }
        }

        private void ucTrackBar1_TrackbarChanged(object sender, EventArgs e)
        {
            TMR1BestChanged(uctbSamplingSpeed.Value);
        }

        private void TMR1BestChanged(int tmr1best)
        {
            string info;

            // sampling speed information
            info = lblTmr1SamplingSpeed.Tag.ToString();
            double speed = ((1.0 / _TMR1_FREQ) * tmr1best) * 1000.0; // (1/_TMR1_FREQ) * TMR1_BEST * 1000 da bi pretvorio u ms 
            info = info.Replace("%", speed.ToString("0.00"));
            lblTmr1SamplingSpeed.Text = info;

            // table of best sensitivities for chosen TMR1_BEST value, in timer to work slower
            tmrSensitivitiesExampleGenerator.Stop();
            tmrSensitivitiesExampleGenerator.Start();
            tmrSensitivitiesExampleGenerator.Enabled = true;
        }

        private void tmrSensitivitiesExampleGenerator_Tick(object sender, EventArgs e)
        {
            chartFreqVsSens.Series.Clear();
            var seriesChart = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "FrequencyVsSensitivity",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                BorderWidth = 3,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
            };

            chartFreqVsSens.Series.Add(seriesChart);

            tmrSensitivitiesExampleGenerator.Enabled = false;
            tblSensitivityExamples.Rows.Clear();
            for (double freq = 20; freq <= 145; freq += 5)
            {
                DataGridViewRow r = new DataGridViewRow();

                DataGridViewTextBoxCell c1 = new DataGridViewTextBoxCell();
                c1.Value = freq;
                r.Cells.Add(c1);

                DataGridViewTextBoxCell c2 = new DataGridViewTextBoxCell();
                double bps = calcFreqResolution(freq, uctbSamplingSpeed.Value);
                if (bps == -1)
                {
                    c2.Value = "Freq. too low!";
                }
                else
                {
                    c2.Value = bps.ToString("0.00");
                }
                r.Cells.Add(c2);

                if (bps > 0)
                {
                    seriesChart.Points.AddXY(freq, bps);
                }

                tblSensitivityExamples.Rows.Add(r);
            }

            chartFreqVsSens.Invalidate();

            // trigger all components that depend on us to recalculate their stuff
            List<Control> c2check = findControlRecursively(this, "TMR1BEST_CHANGE");
            foreach (Control c in c2check)
            {
                if (c is ucTrackBar)
                {
                    ((ucTrackBar)c).TriggerChange(null, null);
                }
            }
        }

        public List<Control> findControlRecursively(Control cont, string tag)
        {
            List<Control> ret = new List<Control>();

            foreach (Control c in cont.Controls)
            {
                ret.AddRange(findControlRecursively(c, tag));
            }

            string[] tagListArr = new string[0];
            if (cont.Tag != null)
            {
                tagListArr = ((string)cont.Tag).Split(';');
            }
            List<string> tagList = new List<string>(tagListArr);

            if (tagList.Contains(tag))
            {
                ret.Add(cont);
            }

            return ret;
        }

        private double tmr12freq(int tmr1Val, int prescVal, byte reloader)
        {
            return (((255.0 - reloader) * prescVal * _TMR1_FREQ_KHZ) / tmr1Val);
        }

        private int freq2tmr1(double freq, int prescVal, byte reloader)
        {
            return (int)(((255.0 - reloader) * prescVal * _TMR1_FREQ_KHZ) / freq);
        }

        private double calcFreqResolution(double freq, int tmr1Best)
        {
            // Djelimicno portano iz PIC-a
            // 1. prvo trazimo odgovarajuci prescaler
            byte prescaler = _TMR0_PRESCALER_MAX;
            int prescaler_value = (int)Math.Pow(2, prescaler) * 2;
            double tmr1_max_rp = (_TMR1_FREQ_KHZ * ((255 - _TMR0_RELOADER_MAX) * prescaler_value)) / freq;
            while (tmr1_max_rp > tmr1Best)
            {
                if (prescaler == 0)
                {
                    return -1; // too low frequency for this tmr1Best, will not operate!
                }

                tmr1_max_rp /= 2;
                prescaler--;
                prescaler_value /= 2;
            }
            // 2. onda trazimo reloader da bi dobili TMR1_BEST sa maloprije pronadjenim prescalerom
            double reloader = 255 - ((1.0 / prescaler_value) * tmr1Best * freq) / _TMR1_FREQ_KHZ;
            // end: Portano iz PIC-a

            int freq2tmr1a = freq2tmr1(freq, prescaler_value, (byte)reloader);
            double freqb = tmr12freq(freq2tmr1a - 1, prescaler_value, (byte)reloader);

            return (freqb - freq) * 1000;
        }

        private void uctbFilteringNegative_TrackbarChanged(object sender, EventArgs e)
        {
            displayFilteringTime(lblFilteringNegative, uctbFilteringNegative, uctbSamplingSpeed.Value);
        }

        private void uctbFilteringPositive_TrackbarChanged(object sender, EventArgs e)
        {
            displayFilteringTime(lblFilteringPositive, uctbFilteringPositive, uctbSamplingSpeed.Value);
        }

        private void displayFilteringTime(Label lbl, ucTrackBar uctb, int tmr1best)
        {
            string info = lbl.Tag.ToString();

            double speed = ((1.0 / _TMR1_FREQ) * tmr1best) * 1000.0; // (1/_TMR1_FREQ) * TMR1_BEST * 1000 da bi pretvorio u ms 
            speed = speed * 2 * uctb.Value; // *2 jer u firmware-u ga mnozim sa 2
            info = info.Replace("%", speed.ToString("0.00"));

            lbl.Text = info;
        }

        private void uctbRelayPulseNormal_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblRelayAPulseNormal.Tag.ToString();

            double dura = uctbRelayAPulseNormal.Value * 10;
            info = info.Replace("%", dura.ToString("0.00"));

            lblRelayAPulseNormal.Text = info;
        }

        private void uctbRelayPulseExtended_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblRelayAPulseExtended.Tag.ToString();

            double dura = uctbRelayAPulseExtended.Value * 10;
            info = info.Replace("%", dura.ToString("0.00"));

            lblRelayAPulseExtended.Text = info;
        }

        private void uctbPPC_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblPPCShort.Tag.ToString();

            TimeSpan span = TimeSpan.FromMinutes(uctbPPCShort.Value);
            info = info.Replace("%", span.ToString(@"hh\:mm"));

            lblPPCShort.Text = info;
        }

        private void uctbPPCDetLeftTimer_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblPPCDetLeaveTimer.Tag.ToString();

            double speed = ((1.0 / _TMR1_FREQ) * uctbSamplingSpeed.Value) * 1000.0; // (1/_TMR1_FREQ) * TMR1_BEST * 1000 da bi pretvorio u ms 
            speed = speed * uctbPPCDetLeftTimer.Value;
            info = info.Replace("%", speed.ToString("0.00"));

            lblPPCDetLeaveTimer.Text = info;

        }

        private void uctbDetStopTimer_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblDetectStopTimer.Tag.ToString();

            double speed = ((1.0 / _TMR1_FREQ) * uctbSamplingSpeed.Value) * 1000.0; // (1/_TMR1_FREQ) * TMR1_BEST * 1000 da bi pretvorio u ms 
            speed = speed * uctbDetStopTimer.Value;
            info = info.Replace("%", speed.ToString("0.00"));

            lblDetectStopTimer.Text = info;
        }

        private void uctbDetStopSlowCheckerTimer_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblDetectStopSlowCheckTimer.Tag.ToString();

            double dura = uctbDetStopSlowCheckerTimer.Value * 10;
            info = info.Replace("%", dura.ToString("0.00"));

            lblDetectStopSlowCheckTimer.Text = info;

        }

        private void uctbDCDDTimer_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblDCDDTimer.Tag.ToString();

            double speed = ((1.0 / _TMR1_FREQ) * uctbSamplingSpeed.Value) * 1000.0; // (1/_TMR1_FREQ) * TMR1_BEST * 1000 da bi pretvorio u ms 
            speed = speed * uctbDCDDTimer.Value;
            string sinfo;

            if (speed >= 1000)
            {
                TimeSpan span = TimeSpan.FromMilliseconds(speed);
                sinfo = span.ToString(@"mm\:ss") + " mm:ss";
            }
            else
            {
                sinfo = speed.ToString("0.00") + " ms";
            }
            info = info.Replace("%", sinfo);

            lblDCDDTimer.Text = info;
        }

        private void uctbSpeedDistance_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblSpeedLoopDistance.Tag.ToString();
            string sinfo;
            int distcm = uctbSpeedDistance.Value;

            if (distcm >= 100)
            {
                int distm = distcm / 100;
                int distcmr = distcm % 100;
                sinfo = distm + " m";
                if (distcmr > 0)
                {
                    sinfo += ", " + distcmr + " cm";
                }
            }
            else
            {
                sinfo = distcm + " cm";
            }
            info = info.Replace("%", sinfo);

            lblSpeedLoopDistance.Text = info;

            // (re)start timer to (re)calculate maximum possible speed
            tmrSpeedTrapErrorGenerator.Stop();
            tmrSpeedTrapErrorGenerator.Start();
            tmrSpeedTrapErrorGenerator.Enabled = true;
        }

        private void cbSensitivityA_SelectedIndexChanged(object sender, EventArgs e)
        {
            sensitivityChanged(cbSensitivityA.SelectedIndex, 0);
        }

        private void cbSensitivityB_SelectedIndexChanged(object sender, EventArgs e)
        {
            sensitivityChanged(cbSensitivityB.SelectedIndex, 1);
        }

        /**
         * Load from configPacket this item and put to form.
         * This MUST execute before updateConfigPacket()! This is ensured by dynamically
         * adding additional change listener on both sensitivity comboboxes, in frmMain() constructor.
         **/
        private void sensitivityChanged(int index, int loopIndex)
        {
            TConfigPacket.TSensitivity sensy;
            if (loopIndex == 0)
            {
                sensy = configPacket.sensitivitiesLoopA[index];
                uctbSensitivityDetectThresholdA.Value = sensy.onThreshold;
                uctbSensitivityUndetectThresholdA.Value = sensy.offThreshold;
            }
            else if (loopIndex == 1)
            {
                sensy = configPacket.sensitivitiesLoopB[index];
                uctbSensitivityDetectThresholdB.Value = sensy.onThreshold;
                uctbSensitivityUndetectThresholdB.Value = sensy.offThreshold;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void tmrUpdateConfigPacket_Tick(object sender, EventArgs e)
        {
            tmrUpdateConfigPacket.Enabled = false;
            updateConfigPacket();
        }

        private void cbFilteringLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            filteringLevelChanged(cbFilteringLevel.SelectedIndex);
        }

        private void filteringLevelChanged(int index)
        {
            TConfigPacket.TFiltering filty;
            if (index == 0)
            {
                filty = configPacket.filterNormal;
            }
            else if (index == 1)
            {
                filty = configPacket.filterMore;
            }
            else
            {
                throw new NotImplementedException();
            }

            uctbFilteringNegative.Value = filty.negativeDriftTmr;
            uctbFilteringPositive.Value = filty.positiveDriftTmr;
            uctbFilteringAveraging.Value = filty.counterArrayLength;

            uctbFilteringNegative.TriggerChange(null, null);
            uctbFilteringPositive.TriggerChange(null, null);
            uctbFilteringAveraging.TriggerChange(null, null);
        }

        private void uctbRelayBPulseNormal_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblRelayBPulseNormal.Tag.ToString();

            double dura = uctbRelayBPulseNormal.Value * 10;
            info = info.Replace("%", dura.ToString("0.00"));

            lblRelayBPulseNormal.Text = info;
        }

        private void uctbRelayBPulseExtended_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblRelayBPulseExtended.Tag.ToString();

            double dura = uctbRelayBPulseExtended.Value * 10;
            info = info.Replace("%", dura.ToString("0.00"));

            lblRelayBPulseExtended.Text = info;
        }

        private void openProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    configPacket = customSerializer.Load<TConfigPacket>(fileName);
                    configPacketToScreen();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error reading profile file.", "Error");
                }
            }
        }

        private void saveProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                try
                {
                    customSerializer.Save(fileName, configPacket);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving profile file.", "Error");
                }
            }
        }

        private void newProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configPacket = new TConfigPacket(true);
            configPacketToScreen();
        }

        private TConfigPacket parseHexaConfigPacket(string hexaConfigPacket)
        {
            TConfigPacket parsedConfigPacket = new TConfigPacket(true);

            int index = 0;
            string hex = "";

            try
            {
                // validVal
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.validVal = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // current system sensitivities: 2 bytes, loop a, loop b
                // a
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.sensitivityLoopA = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // b
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.sensitivityLoopB = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // filtering: 3 bytes * 2banks, counter length, negative, positive
                // normal
                // counter
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterNormal.counterArrayLength = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // negative
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterNormal.negativeDriftTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // positive
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterNormal.positiveDriftTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // more
                // counter
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterMore.counterArrayLength = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // negative
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterMore.negativeDriftTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // positive
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.filterMore.positiveDriftTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // sensitivities: 8 * 4 * 2loops
                // a
                for (int i = 0; i < 8; i++)
                {
                    // on threshold
                    hex = hexaConfigPacket.Substring(index, 4);
                    index += hex.Length;
                    parsedConfigPacket.sensitivitiesLoopA[i].onThreshold = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                    // off threshold
                    hex = hexaConfigPacket.Substring(index, 4);
                    index += hex.Length;
                    parsedConfigPacket.sensitivitiesLoopA[i].offThreshold = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                }
                // b
                for (int i = 0; i < 8; i++)
                {
                    // on threshold
                    hex = hexaConfigPacket.Substring(index, 4);
                    index += hex.Length;
                    parsedConfigPacket.sensitivitiesLoopB[i].onThreshold = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                    // off threshold
                    hex = hexaConfigPacket.Substring(index, 4);
                    index += hex.Length;
                    parsedConfigPacket.sensitivitiesLoopB[i].offThreshold = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                }

                // detect stop, prvi dio
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.detectStopTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.detectStopThreshold = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // dcdd
                hex = hexaConfigPacket.Substring(index, 4);
                index += hex.Length;
                parsedConfigPacket.dcddTmr = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.dcddThreshold = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // soft dips
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.useSoftDIPs = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // DIP-A
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.softDIPA = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // DIP-B
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.softDIPB = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // ppc
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.ppcTimeShort = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.ppcTimeMedium = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.ppcTimeLong = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // detect left for PPC
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.ppcDetectLeftTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.ppcDetectLeftThreshold = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // pulse durations
                // relay A
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.relADurNormal = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.relADurExtended = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                // relay B
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.relBDurNormal = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.relBDurExtended = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // TMR1_BEST
                hex = hexaConfigPacket.Substring(index, 4);
                index += hex.Length;
                parsedConfigPacket.tmr1Best = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // speed trap loops distance
                hex = hexaConfigPacket.Substring(index, 4);
                index += hex.Length;
                parsedConfigPacket.speedDistanceCm = ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                // detect stop, drugi dio
                hex = hexaConfigPacket.Substring(index, 2);
                index += hex.Length;
                parsedConfigPacket.detectStopSlowCheckerTmr = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                MessageBox.Show("Error parsing data received from device!", "Error");
                return null;
            }

            return parsedConfigPacket;
        }

        private void readFromDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // send GET command
            if(!sendDataToDevice("G"))
            {
                MessageBox.Show("Failed to send command G to device. Please try again.", "Error");
            }

            // handling of reception of data is in receiver parser
        }

        private string encodeHexaConfigPacket(TConfigPacket configPacket)
        {
            string hex = "";

            // validVal first (it will always be valid...)
            hex += configPacket.validVal.ToString("X2");

            // current system sensitivities: 2 bytes, loop a, loop b
            // a
            hex += configPacket.sensitivityLoopA.ToString("X2");
            // b
            hex += configPacket.sensitivityLoopB.ToString("X2");

            // filtering: 3 bytes * 2banks, counter length, negative, positive
            // normal
            // counter
            hex += configPacket.filterNormal.counterArrayLength.ToString("X2");
            // negative
            hex += configPacket.filterNormal.negativeDriftTmr.ToString("X2");
            // positive
            hex += configPacket.filterNormal.positiveDriftTmr.ToString("X2");
            // more
            // counter
            hex += configPacket.filterMore.counterArrayLength.ToString("X2");
            // negative
            hex += configPacket.filterMore.negativeDriftTmr.ToString("X2");
            // positive
            hex += configPacket.filterMore.positiveDriftTmr.ToString("X2");

            // sensitivities: 8 * 4 * 2loops
            // a
            for (int i = 0; i < 8; i++)
            {
                // on threshold
                hex += configPacket.sensitivitiesLoopA[i].onThreshold.ToString("X4");

                // off threshold
                hex += configPacket.sensitivitiesLoopA[i].offThreshold.ToString("X4");
            }
            // b
            for (int i = 0; i < 8; i++)
            {
                // on threshold
                hex += configPacket.sensitivitiesLoopB[i].onThreshold.ToString("X4");

                // off threshold
                hex += configPacket.sensitivitiesLoopB[i].offThreshold.ToString("X4");
            }

            // detect stop, prvi dio
            hex += configPacket.detectStopTmr.ToString("X2");
            hex += configPacket.detectStopThreshold.ToString("X2");

            // dcdd
            hex += configPacket.dcddTmr.ToString("X4");
            hex += configPacket.dcddThreshold.ToString("X2");

            // soft dips
            hex += configPacket.useSoftDIPs.ToString("X2");

            // DIP-A
            hex += configPacket.softDIPA.ToString("X2");
            // DIP-B
            hex += configPacket.softDIPB.ToString("X2");

            // ppc
            hex += configPacket.ppcTimeShort.ToString("X2");
            hex += configPacket.ppcTimeMedium.ToString("X2");
            hex += configPacket.ppcTimeLong.ToString("X2");
            // detect left for PPC
            hex += configPacket.ppcDetectLeftTmr.ToString("X2");
            hex += configPacket.ppcDetectLeftThreshold.ToString("X2");

            // pulse durations
            // relay A
            hex += configPacket.relADurNormal.ToString("X2");
            hex += configPacket.relADurExtended.ToString("X2");
            // relay B
            hex += configPacket.relBDurNormal.ToString("X2");
            hex += configPacket.relBDurExtended.ToString("X2");

            // TMR1_BEST
            hex += configPacket.tmr1Best.ToString("X4");

            // speed trap loops distance
            hex += configPacket.speedDistanceCm.ToString("X4");

            // detect stop, drugi dio
            hex += configPacket.detectStopSlowCheckerTmr.ToString("X2");

            return hex;
        }

        private void programDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // spakuj configPacket u hexadecimalni string pa da ga posaljemo na uredjaj
            hex2send = encodeHexaConfigPacket(configPacket);

            sendDataToDevice("S"); // this will initiate the programming procedure
        }

        private void restartCPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendDataToDevice("Y");
        }

        private void factoryResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to perform factory reset?", "Factory reset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sendDataToDevice("W");
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cs = "";
            spData.Clear();
            rxState = TRXState.Running; // reset to this
            string comport = Properties.Settings.Default.ComPort;
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    cs = "Disconnected";
                    tsbConnectDisconnect.BackColor = System.Drawing.Color.PeachPuff;
                    tssConnectionStatus.BackColor = System.Drawing.Color.PeachPuff;
                }
                else
                {
                    sp.PortName = "COM" + comport;
                    sp.Open();
                    cs = "Connected to " + sp.PortName;
                    tsbConnectDisconnect.BackColor = System.Drawing.Color.LightGreen;
                    tssConnectionStatus.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error accessing COM port (COM" + comport + "). Please check settings and try again.", "Error");
                settingsToolStripMenuItem_Click(sender, e);
                cs = "Connection error";
            }
            finally
            {
                tssConnectionStatus.Text = tssConnectionStatus.Tag.ToString().Replace("%", cs);
            }
        }

        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // https://stackoverflow.com/a/15124287
            while (sp.BytesToRead > 0)
            {
                var count = sp.BytesToRead;
                var bytes = new byte[count];
                sp.Read(bytes, 0, count);
                spProcessBytes(bytes);
            }
        }

        private void spProcessBytes(byte[] bytes)
        {
            spData.AddRange(bytes);

            // convert array of bytes to string
            string cmds = System.Text.Encoding.ASCII.GetString(spData.ToArray<byte>(), 0, spData.Count());
            
            // while there is a full command available in buffer
            while (cmds.Contains(commandTerminator))
            {
                int eoc = cmds.IndexOf(commandTerminator);
                List<byte> oneCommand = spData.GetRange(0, eoc);

                // convert to string
                string cmd = System.Text.Encoding.ASCII.GetString(oneCommand.ToArray<byte>(), 0, oneCommand.Count());

                // remove from buffer
                spData.RemoveRange(0, eoc + commandTerminator.Length);

                // ucitaj cmd
                var task = uiFactory.StartNew(() => processCommand(cmd));

                // next
                cmds = System.Text.Encoding.ASCII.GetString(spData.ToArray<byte>(), 0, spData.Count());
            }
        }

        private void addToEventLog(string txt, string prependTxt = "", bool useTimeStamp = true)
        {
            if (!string.IsNullOrEmpty(prependTxt))
            {
                txt = prependTxt + " " + txt;
            }

            if (useTimeStamp)
            {
                txt = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + ": " + txt;
            }
            txtLog.AppendText(txt + Environment.NewLine);
        }

        private void processCommand(string cmd)
        {
            if (string.IsNullOrEmpty(cmd)) return;

            // state machine
            switch (rxState)
            {
                // at startup, we will assume that device is running
                case TRXState.Running:
                    // here we can get some running data, such as event logging, realtime frequency as it changes. that is basically it
                    // realtime freq analysis
                    if (cmd.StartsWith("A["))
                    {
                        // A[id]>12.2122,12.2122,12.2122,-15.3212,-15.3213\r\n
                        int loopId = extractLoopIdFromResponse(cmd);
                        string paramVal = extractParamValueFromResponse(cmd);

                        try
                        {
                            if (loopId < 0 || loopId > 1)
                            {
                                throw new Exception();
                            }

                            CirBuff<double> freqAna = deviceStuff.freqAna[loopId];

                            List<string> ar = new List<string>(paramVal.Split(','));
                            bool newDetectState = false;
                            // add all items to our circular buffer
                            ar.ForEach(i =>
                            {
                                double fre = double.Parse(i);
                                // see if there is a positive element in array
                                if (fre > 0)
                                {
                                    newDetectState = true;
                                }
                                freqAna.Add(fre);
                            });

                            // if detection has been found, and not already before
                            if (newDetectState && !deviceStuff.detectState[loopId])
                            {
                                deviceStuff.detectState[loopId] = true;

                                // put marker somewhere here
                                freqAna.MarkerPush();
                            }
                            // if there was a detection, but not anymore, fetch previous marker and start plotting
                            else if(!newDetectState && deviceStuff.detectState[loopId])
                            {
                                deviceStuff.detectState[loopId] = false;

                                // save current data index, so we can restore it after moving it around
                                int backupIndex = freqAna.GetCurrentIndex();

                                int dataStartIndex = freqAna.MarkerPop();
                                dataStartIndex -= 20; // take previous N samples as well

                                // move buffer to marker index
                                freqAna.SetIndex(dataStartIndex);

                                // select chart to draw
                                CheckBox ckToSave = ckAutoSaveAnalysisLoopA;
                                System.Windows.Forms.DataVisualization.Charting.Chart destChart = chAnalysisLoopA;
                                if (loopId == 1)
                                {
                                    destChart = chAnalysisLoopB;
                                    ckToSave = ckAutoSaveAnalysisLoopB;
                                }
                                destChart.Series.Clear();
                                var seriesChart = new System.Windows.Forms.DataVisualization.Charting.Series
                                {
                                    Name = "Signal over time",
                                    Color = System.Drawing.Color.Green,
                                    BorderWidth = 2,
                                    IsVisibleInLegend = false,
                                    IsXValueIndexed = true,
                                    YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double,
                                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                                };
                                destChart.Series.Add(seriesChart);

                                List<double> data4chart = new List<double>();
                                double max = 0;
                                // fetch data from marker index, to backupIndex
                                while (freqAna.GetCurrentIndex() != backupIndex)
                                {
                                    double absVal = Math.Abs(freqAna.GetItem());
                                    data4chart.Add(absVal);
                                    if(absVal > max)
                                    {
                                        max = absVal;
                                    }
                                }

                                // normalizuj
                                List<double> normalized = new List<double>();
                                double maxNorm = 0;
                                foreach (double freq in data4chart)
                                {
                                    double normVal = max - freq;
                                    normalized.Add(normVal);
                                    if(normVal > maxNorm)
                                    {
                                        maxNorm = normVal;
                                    }
                                }

                                // naubacuj sad u chart series, usput invertuj
                                // takodje snimaj u globalnu var da mozemo uraditi SAVE po potrebi
                                deviceStuff.freqAna4Save[loopId].Clear();
                                foreach (double freq in normalized)
                                {
                                    seriesChart.Points.AddY(maxNorm - freq);
                                    deviceStuff.freqAna4Save[loopId].Add(maxNorm - freq);
                                }

                                // save to file if required
                                if(ckToSave.Checked)
                                {
                                    if(!SaveAnalysisToFile(deviceStuff.freqAna4Save[loopId], saveAnalysisFolder, "Loop_" + loopId + "_" + DateTime.Now.ToString("yyyy-MM-dd-H-mm-ss") + ".txt"))
                                    {
                                        ckToSave.Checked = false;
                                    }
                                }

                                // (re)draw
                                destChart.Invalidate();

                                // restore index, just in case it gets important to continue adding samplest from the same position
                                freqAna.SetIndex(backupIndex);
                            }
                        }
                        catch (Exception oh)
                        {
                            // parsing error happens because of uart->usb interface buffer overrun, so just die silently
                            //Console.WriteLine("EXCEPTION PARSING");
                            return;
                        }
                    }
                    // event
                    else if(cmd.StartsWith("EVENT["))
                    {
                        // ovdje smo dobili jedan event u formatu: EVENT[loop_id_ili_X]>EVENT_CODE,_optional_event_parameter_\r\n
                        int loopId = extractLoopIdFromResponse(cmd);
                        string paramVal = extractParamValueFromResponse(cmd);
                        string ev = "";

                        int eventId = -1;
                        string eventParam = "";
                        try
                        {
                            if (paramVal.Contains(","))
                            {
                                List<string> lis = new List<string>(paramVal.Split(','));
                                eventId = int.Parse(lis[0]);
                                eventParam = lis[1];
                            }
                            else
                            {
                                eventId = int.Parse(paramVal);
                            }
                        }
                        catch(Exception)
                        {
                            // failed while parsing...
                            //addToEventLog("Parsing exception!");
                            return;
                        }

                        // unsupported event!?
                        if (!EventName.ContainsKey(eventId)) return;

                        ev = EventName[eventId];
                        ev = ev.Replace("$", eventParam);

                        // ako je dosao loop id -1, znaci da je event nije nije od nijedne petlje nego "spojeni event"
                        if (loopId == -1)
                        {
                            lblLastJointEvent.Text = lblLastJointEvent.Tag.ToString().Replace("%", ev);
                            // log to window
                            addToEventLog(ev);
                        }
                        else if (loopId == 0)
                        {
                            lblLastEventLoopA.Text = lblLastEventLoopA.Tag.ToString().Replace("%", ev);
                            // log to window
                            addToEventLog(ev, "[LOOP A]");
                        }
                        else if (loopId == 1)
                        {
                            lblLastEventLoopB.Text = lblLastEventLoopB.Tag.ToString().Replace("%", ev);
                            // log to window
                            addToEventLog(ev, "[LOOP B]");
                        }
                    }
                    // device answered to our communicatino request?
                    else if(cmd.Contains("READY>v1"))
                    {
                        rxState = TRXState.Comm;
                    }
                    // wrong device state, just wait for it to timeout and return to running state
                    else
                    {
                        // Error, waiting for device to timeout and return to running state.
                    }
                    break;

                // free communicating state, this is a reply on our previous command we sent
                case TRXState.Comm:
                    {
                        switch (cmd)
                        {
                            // ping response
                            case "READY>v1\r\n":
                                // nothing special here
                                break;
                            // logging is turned on
                            case "LOG>1\r\n":
                                lblLoggingState.Text = lblLoggingState.Tag.ToString().Replace("%", "On");
                                sendDataToDevice("Q"); // logging is ON, return to running mode
                                break;
                            // logging is turned off
                            case "LOG>0\r\n":
                                lblLoggingState.Text = lblLoggingState.Tag.ToString().Replace("%", "Off");
                                break;
                            // realtime freq analysis is turned on
                            case "ANA>1\r\n":
                                lblSignalAnalysis.Text = lblSignalAnalysis.Tag.ToString().Replace("%", "On");
                                sendDataToDevice("Q"); // logging is ON, return to running mode
                                break;
                            // realtime freq analysis is turned off
                            case "ANA>0\r\n":
                                lblSignalAnalysis.Text = lblSignalAnalysis.Tag.ToString().Replace("%", "Off");
                                break;
                            // resumed to normal operation
                            // quiting from comm mode
                            case "QUIT>\r\n":
                            case "RESUME>\r\n":
                                rxState = TRXState.Running;
                                break;
                            // other command response processing is here
                            default:
                                {
                                    // response on error history request
                                    if(cmd.Contains("ERROR["))
                                    {
                                        // ovdje smo dobili dva error responsa, jer imamo 2 petlje u device-u
                                        // ERROR[%u]>0\r\nERROR[%u]>0\r\n
                                        string[] tmp = cmd.Split(new string[] { crlf }, StringSplitOptions.None);
                                        List<string> errors = new List<string>(tmp);
                                        foreach (string loopErr in errors)
                                        {
                                            int loopId = extractLoopIdFromResponse(loopErr);
                                            string paramVal = extractParamValueFromResponse(loopErr + "\r\n");
                                            try
                                            {
                                                deviceStuff.err[loopId] = int.Parse(paramVal);
                                            }
                                            catch(Exception)
                                            {
                                                // fail silently...
                                            }
                                        }
                                    }
                                    // response on frequency request
                                    else if(cmd.Contains("FREQ["))
                                    {
                                        // ovdje smo dobili dva freq responsa, jer imamo 2 petlje u device-u
                                        // FREQ[%u]>%0.5f\r\nFREQ[%u]>%0.5f\r\n
                                        string[] tmp = cmd.Split(new string[] { crlf }, StringSplitOptions.None);
                                        List<string> freqs = new List<string>(tmp);
                                        foreach (string loopFreq in freqs)
                                        {
                                            int loopId = extractLoopIdFromResponse(loopFreq);
                                            string paramVal = extractParamValueFromResponse(loopFreq + "\r\n");
                                            try
                                            {
                                                deviceStuff.freq[loopId] = double.Parse(paramVal);
                                            }
                                            catch (Exception)
                                            {
                                                // fail silently...
                                            }
                                        }
                                    }
                                    // response on mode query
                                    else if (cmd.Contains("MODE>"))
                                    {
                                        string paramVal = extractParamValueFromResponse(cmd);
                                        try
                                        {
                                            deviceStuff.mode = int.Parse(paramVal);
                                        }
                                        catch (Exception)
                                        {
                                            // fail silently...
                                        }
                                    }
                                    // response on factory reset
                                    else if (cmd.Contains("FACTORY>"))
                                    {
                                        string paramVal = extractParamValueFromResponse(cmd);
                                        MessageBox.Show("Device performed factory reset and answered with: " + paramVal, "Factory reset");
                                    }
                                    // response on startup DIPs query
                                    else if (cmd.Contains("DIPS["))
                                    {
                                        // ovdje smo dobili dva DIPs responsa, jer imamo 2 DIP-a u device-u
                                        // DIPS[%u]>%02X\r\nDIPS[%u]>%02X\r\n
                                        string[] tmp = cmd.Split(new string[] { crlf }, StringSplitOptions.None);
                                        List<string> dips = new List<string>(tmp);
                                        foreach (string oneDip in dips)
                                        {
                                            int loopId = extractLoopIdFromResponse(oneDip);
                                            string paramVal = extractParamValueFromResponse(oneDip + "\r\n");
                                            try
                                            {
                                                deviceStuff.dips[loopId] = byte.Parse(paramVal, System.Globalization.NumberStyles.HexNumber);

                                                // update the config packet dips also
                                                if (loopId == 0)
                                                {
                                                    configPacket.softDIPA = deviceStuff.dips[loopId];
                                                }
                                                else
                                                {
                                                    configPacket.softDIPB = deviceStuff.dips[loopId];
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                // fail silently...
                                                return;
                                            }

                                            // update only DIPs to screen
                                            configPacketToScreen(true);
                                        }
                                    }
                                    // response on soft-reset
                                    else if (cmd.Contains("RESET>"))
                                    {
                                        MessageBox.Show("Device accepted soft-restart command.", "Soft-restart");
                                    }
                                    // response on communication quitting and communication exiting
                                    else if (cmd.Contains("QUIT>") || cmd.Contains("RESUME>"))
                                    {
                                        // asd...
                                    }
                                    // response to our GET command request
                                    else if (cmd.Contains("GET>"))
                                    {
                                        // ovdje dobijamo npr: GET>93\r\n982734987234987234....982734987234987\r\n
                                        string[] tmp = cmd.Split(new string[] { crlf }, StringSplitOptions.None);
                                        List<string> stuff = new List<string>(tmp);
                                        try
                                        {
                                            string tmp2 = extractParamValueFromResponse(cmd); // this will extract only number after GET> and before first \r\n
                                            int eeSize = int.Parse(tmp2);

                                            // validate, EE_SIZE is expected
                                            if (eeSize != EE_SIZE)
                                            {
                                                MessageBox.Show("Error in received configuration data. Number of bytes received is not correct (" + eeSize + "/" + EE_SIZE + ")!", "Error");
                                                return;
                                            }

                                            string hexaConfig = stuff[1];
                                            
                                            // parse this baby
                                            TConfigPacket parsedConfigPacket = parseHexaConfigPacket(hexaConfig);

                                            // activate it /show on screen
                                            configPacket = parsedConfigPacket;
                                            configPacketToScreen();
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Error in received configuration data. Something is not right!", "Error");
                                        }
                                    }
                                    // response to our SET command
                                    else if (cmd.Contains("SET>"))
                                    {
                                        // ovdje cemo dobiti SET>93\r\n i uredjaj onda ocekuje da mu pocnemo slati config packet
                                        string paramVal = extractParamValueFromResponse(cmd);

                                        int eeSize = 0;
                                        try
                                        {
                                            eeSize = int.Parse(paramVal);
                                            if(eeSize != EE_SIZE)
                                            {
                                                throw new Exception("");
                                            }
                                        }
                                        catch(Exception)
                                        {
                                            MessageBox.Show("Error in attempting to send configuration data. Number of bytes device is expecting is not correct (" + eeSize + "/" + EE_SIZE + ")!", "Error");
                                            return;
                                        }

                                        // restart index
                                        commSettingIndex = 0;
                                        tssProgress.Maximum = EE_SIZE * 2;
                                        tssProgress.Value = 0;
                                        tssProgress.Visible = true;

                                        // all good, switch to "communication SETting" state
                                        // we will now get "<" command that will start "pulling data from us"
                                        rxState = TRXState.Comm_Setting;
                                    }
                                    // else if...
                                }
                                break;
                        }
                    }
                    break;

                case TRXState.Comm_Setting:
                    switch (cmd)
                    {
                        // programming failed because of timeout
                        case "ERR>\r\n":
                            MessageBox.Show("Programming failed because of timeout in device.", "Programming");
                            rxState = TRXState.Comm; // switch back to comm mode
                            break;
                        // programming done OK
                        case "OK>\r\n":
                            MessageBox.Show("Programming done OK!\r\nDo not forget to restart CPU for changes to take effect.", "Programming");
                            rxState = TRXState.Comm; // switch back to comm mode

                            // after short time reset the progressbar
                            delayedUIRun(1000, delegate ()
                            {
                                tssProgress.Value = 0;
                                tssProgress.Visible = false;
                            });
                            break;
                        // flow control character is here
                        // device is pulling more data from us
                        case "SET><\r\n":
                            string oneByte = hex2send.Substring(commSettingIndex, 1);
                            sendDataToDevice(oneByte);
                            commSettingIndex++;
                            tssProgress.Value = commSettingIndex;
                            break;
                    }
                    break;
            }
        }

        private bool sendDataToDevice(string data)
        {
            if(!sp.IsOpen)
            {
                MessageBox.Show("Please first connect to device!", "Communication error");
                return false;
            }

            // enter comm state if not already in it, returns whether anything failed or data sending was OK
            return ensureCommState(delegate (bool success) {
                // try writing to port
                try
                {
                    // if it failed to enter comm state, just return immediatelly with false
                    if (!success)
                    {
                        throw new Exception(""); // did not manage to enter comm state!
                    }

                    sp.Write(data);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            });
        }

        private bool ensureCommState(Func<bool, bool> callback)
        {
            // if device is in running state, first enter comm mode
            if (rxState == TRXState.Running)
            {
                try
                {
                    sp.Write(_UART_START_CHAR.ToString());
                }
                catch (Exception)
                {
                    return false;
                }

                // pricekaj nekako malo da vidimo hoce li uletiti u comm mode, ako ne uleti javi greksu. ako uleti - super, samo nastavi
                Stopwatch sw = new Stopwatch();
                sw.Start();
                tssProgress.Maximum = _UART_COMM_MODE_ENTER_DELAY_MS / 1000;
                tssProgress.Visible = true;
                while(rxState != TRXState.Comm && sw.ElapsedMilliseconds <= _UART_COMM_MODE_ENTER_DELAY_MS)
                {
                    // I am not happy with this, but...
                    Application.DoEvents();
                    tssProgress.Value = (int)(sw.ElapsedMilliseconds / 1000);
                }
                sw.Stop();
                tssProgress.Value = tssProgress.Maximum;
                // after short time reset the progressbar
                delayedUIRun(1000, delegate ()
                {
                    tssProgress.Value = 0;
                    tssProgress.Visible = false;
                });

                // return whatever state we are in currently, we should have succeeded
                return callback(rxState == TRXState.Comm);
            }
            // device is already in communication mode, so just return
            else
            {
                return callback(true);
            }
        }

        private void delayedUIRun(int msTime, Action callback)
        {
            Task.Delay(msTime).ContinueWith((dummy) =>
            {
                uiFactory.StartNew(callback);
            });
        }

        private string extractParamValueFromResponse(string r)
        {
            string pattern = Regex.Escape(">") + "(.*)" + Regex.Escape("\r\n");
            Match match = Regex.Match(r, pattern);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Extracts loop id from parameter: SOMETHING[_loop_id_]>SOMETHING...
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Returns loop id, or -1 if loop id is not a number. It is possible that X enters as loop number and it will be returned as -1</returns>
        private int extractLoopIdFromResponse(string r)
        {
            string pattern = Regex.Escape("[") + "([0-9]*)" + Regex.Escape("]");
            Match match = Regex.Match(r, pattern);
            try
            {
                if (match.Success)
                {
                    return int.Parse(match.Groups[1].Value);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void tssFrequencyLoopA_Click(object sender, EventArgs e)
        {
            sendDataToDevice("F");
        }

        private void tssFrequencyLoopB_Click(object sender, EventArgs e)
        {
            sendDataToDevice("F");
        }

        private void uctbPPCMedium_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblPPCMedium.Tag.ToString();

            TimeSpan span = TimeSpan.FromMinutes(uctbPPCMedium.Value);
            info = info.Replace("%", span.ToString(@"hh\:mm"));

            lblPPCMedium.Text = info;
        }

        private void uctbPPCLong_TrackbarChanged(object sender, EventArgs e)
        {
            string info = lblPPCLong.Tag.ToString();

            TimeSpan span = TimeSpan.FromMinutes(uctbPPCLong.Value);
            info = info.Replace("%", span.ToString(@"hh\:mm"));

            lblPPCLong.Text = info;
        }

        private void returnToRunningModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rxState != TRXState.Running)
            {
                sendDataToDevice("Q");
                rxState = TRXState.Running; // mozemo ovdje slobodno
            }
        }

        private void btnReadDIPsFromDevice_Click(object sender, EventArgs e)
        {
            sendDataToDevice("T");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // toggle logging mode
            sendDataToDevice("L");
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnSignalAnalysis_Click(object sender, EventArgs e)
        {
            sendDataToDevice("A");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are sure you want to close the application?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.Activate();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(sp.IsOpen)
            {
                sp.Close();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For more information please visit:\r\n\r\nwww.elektronika.ba", "About");
        }

        private bool SaveAnalysisToFile(List<double> analysisData, string path, string filename)
        {
            // need to ask user for input?
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(filename) || !Directory.Exists(path))
            {
                DialogResult dr = saveAnalysisDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    string fn = saveAnalysisDialog.FileName;
                    if (string.IsNullOrEmpty(fn))
                    {
                        MessageBox.Show("This is not a valid file!", "File error");
                        return false;
                    }

                    if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                    {
                        path = Path.GetDirectoryName(fn);
                    }

                    if(string.IsNullOrEmpty(filename))
                    {
                        filename = Path.GetFileName(fn);
                    }
                }
                else
                {
                    return false;
                }
            }

            // save global path
            saveAnalysisFolder = path;

            // save to file
            string fullFileName = Path.Combine(path, filename);
            using (StreamWriter file = new StreamWriter(fullFileName))
            {
                foreach(double freq in analysisData)
                {
                    file.WriteLine(freq.ToString("0.0000"));
                }
            }

            return true;
        }

        private void btnSaveAnalysisLoopA_Click(object sender, EventArgs e)
        {
            SaveAnalysisToFile(deviceStuff.freqAna4Save[0], saveAnalysisFolder, null);
        }

        private void btnSaveAnalysisLoopB_Click(object sender, EventArgs e)
        {
            SaveAnalysisToFile(deviceStuff.freqAna4Save[1], saveAnalysisFolder, null);
        }

        private void chAnalysisLoopA_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = saveChartImageDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                chAnalysisLoopA.SaveImage(saveChartImageDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
            }
        }

        private void chAnalysisLoopB_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveChartImageDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                chAnalysisLoopB.SaveImage(saveChartImageDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
            }

        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveLogDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // save to file
                string fullFileName = saveLogDialog.FileName;
                using (StreamWriter file = new StreamWriter(fullFileName))
                {
                    file.Write(txtLog.Text);
                }
            }
        }

        private void tmrSpeedTrapErrorGenerator_Tick(object sender, EventArgs e)
        {
            tmrSpeedTrapErrorGenerator.Enabled = false;
            tblMaximumSpeedErrors.Rows.Clear();

            double samplingSpeedSeconds = ((1.0 / _TMR1_FREQ) * uctbSamplingSpeed.Value);

            int minMeasSpeed = (int)((uctbSpeedDistance.Value / 100.0) / (SHORTEST_SPEED_TIME_MS/1000) * 3600.0);
            int maxMeasSpeed = (int)((uctbSpeedDistance.Value / 100.0) / (4.0 * samplingSpeedSeconds) / 1000.0 * 3600.0);
            for (double speed = 10; speed <= maxMeasSpeed; speed += 10)
            {
                double timeForSpeedMs = (uctbSpeedDistance.Value / 100.0) / (speed * 1000.0 / 3600.0);

                DataGridViewRow r = new DataGridViewRow();

                DataGridViewTextBoxCell c1 = new DataGridViewTextBoxCell();
                c1.Value = speed;
                r.Cells.Add(c1);

                double timeForSpeedWithMaxErrSec = timeForSpeedMs + (4.0 * samplingSpeedSeconds);
                double speedWithMaxError = ((uctbSpeedDistance.Value / 100.0) / timeForSpeedWithMaxErrSec) / 1000.0 * 3600.0;

                DataGridViewTextBoxCell c2 = new DataGridViewTextBoxCell();
                c2.Value = speedWithMaxError.ToString("0.00");
                r.Cells.Add(c2);

                double errorKmh = speed - speedWithMaxError;

                DataGridViewTextBoxCell c3 = new DataGridViewTextBoxCell();
                c3.Value = errorKmh.ToString("0.00");
                r.Cells.Add(c3);

                double errorPercent = ((speed - speedWithMaxError) / speed * 100.0);

                DataGridViewTextBoxCell c4 = new DataGridViewTextBoxCell();
                c4.Value = errorPercent.ToString("0.00");
                r.Cells.Add(c4);

                tblMaximumSpeedErrors.Rows.Add(r);
            }
        }
    }
}
