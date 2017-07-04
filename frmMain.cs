using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace config1v1
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

        private string rxDataBuff = "";
        private const string commandTerminator = "END>\r\n";
        private const string crlf = "\r\n";

        private enum TRXState
        {
            Running, // device is running (resumed operation)
            Comm, // device is in uart communication state, waiting for our command
            Comm_Setting, // device is in uart communication mode, we initiated SET command and now we are working it
        }

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
                for (int i = 0; i < 2; i++)
                {
                    freq.Add(0.0);
                    err.Add(-1);
                    lastEvent.Add("");
                    dips.Add(0x00);
                }
                mode = -1;
            }
            public List<double> freq { get; set; }
            public List<int> err { get; set; }
            public List<string> lastEvent { get; set; }
            public int mode { get; set; }
            public List<byte> dips { get; set; }
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
            string comPort = ConfigurationManager.AppSettings["comport‌​"];
            s.setFormData(comPort);

            DialogResult r = s.ShowDialog();
            if (r == DialogResult.OK)
            {
                // snimi u settingse izmjene sa forme
                comPort = s.getFormData();

                ConfigurationManager.AppSettings["comport‌​"] = comPort;
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
                { "1", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "ASB for loop A and B", "PPC 2 for loop A and B" } },
                // dual directional
                { "2", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "ASB for loop A and B", "Extended pulse for relay A and B" } },
                // speed trap
                { "3", new List<string>() { "Mode 1", "Mode 2", "Reserved", "Alternative oscillator frequency for loop A", "Alternative oscillator frequency for loop B", "Additional signal filtering for loop A and B", "Extended pulse for relay A and B", "Speed is in mph" } },
            };

            Dictionary<string, List<string>> DIP2texts = new Dictionary<string, List<string>>()
            {
                // single loop
                { "0", new List<string>() { "Relay A presence type", "Relay A extended pulse", "Relay A pulse on detect", "Relay B presence type", "Relay B extended pulse", "Relay B pulse on detect", "PPC 1", "PPC 2" } },
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

                seriesChart.Points.AddXY(freq, bps);

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
            return (((256.0 - reloader) * prescVal * _TMR1_FREQ_KHZ) / tmr1Val);
        }

        private int freq2tmr1(double freq, int prescVal, byte reloader)
        {
            return (int)(((256.0 - reloader) * prescVal * _TMR1_FREQ_KHZ) / freq);
        }

        private double calcFreqResolution(double freq, int tmr1Best)
        {
            // Djelimicno portano iz PIC-a
            // 1. prvo trazimo odgovarajuci prescaler
            byte prescaler = _TMR0_PRESCALER_MAX;
            int prescaler_value = (int)Math.Pow(2, prescaler);
            double tmr1_max_rp = (_TMR1_FREQ_KHZ * ((256 - _TMR0_RELOADER_MAX) * prescaler_value)) / freq;
            while (tmr1_max_rp > tmr1Best)
            {
                if (prescaler == 0)
                {
                    return -1; // previse niska frekvencija za ovaj tmr1Best
                }

                tmr1_max_rp /= 2;
                prescaler--;
                prescaler_value /= 2;
            }
            // 2. onda trazimo reloader da bi dobili TMR1_BEST sa maloprije pronadjenim prescalerom
            double reloader = 256 - ((1.0 / prescaler_value) * tmr1Best * freq) / _TMR1_FREQ_KHZ;
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
                    MessageBox.Show("Error reading profile file.");
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
                    MessageBox.Show("Error saving profile file.");
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
                MessageBox.Show("Error parsing data received from device!");
                return null;
            }

            return parsedConfigPacket;
        }

        private void readFromDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // send GET command
            if(!sendDataToDevice("G"))
            {
                MessageBox.Show("Failed to send command G to device. Please try again.");
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
            sendDataToDevice("W");
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cs = "";
            rxDataBuff = ""; // flush buffer for new session
            rxState = TRXState.Running; // reset to this
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
                    sp.PortName = "COM" + ConfigurationManager.AppSettings["comport‌​"];
                    sp.Open();
                    cs = "Connected to " + sp.PortName;
                    tsbConnectDisconnect.BackColor = System.Drawing.Color.LightGreen;
                    tssConnectionStatus.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error accessing COM port (COM" + ConfigurationManager.AppSettings["comport‌​"] + "). Please check settings and try again.");
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
            // https://code.msdn.microsoft.com/windowsdesktop/SerialPort-brief-Example-ac0d5004

            //Initialize a buffer to hold the received data 
            byte[] buffer = new byte[sp.ReadBufferSize];

            //There is no accurate method for checking how many bytes are read 
            //unless you check the return from the Read method 
            int bytesRead = sp.Read(buffer, 0, buffer.Length);
            rxDataBuff += System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // we need to parse stuff in main ui thread, not here, so we will use TaskFactory to signal main thread to do the job
            // https://stackoverflow.com/a/14129252
            var task = uiFactory.StartNew(() => workCommandsFromRxDataBuffer());
        }

        /**
         * Parsing received data from serial port/device.
         * Something was received, and is appended to global rxDataBuff variable.
         **/
        private bool workCommandsFromRxDataBuffer()
        {
            // incomplete command in buffer! (we are expecting to see END>\r\n as a "command terminator"
            if (!rxDataBuff.Contains(commandTerminator)) return false; // nothing currently/more pending for processing

            List<string> commands = new List<string>();
            do
            {
                // extract all commands into list
                string[] temp = rxDataBuff.Split(new string[] { commandTerminator }, StringSplitOptions.RemoveEmptyEntries);
                commands = new List<string>(temp);

                // fetch first command from buffer
                string cmd = "";
                if (commands.Count > 0)
                {
                    cmd = commands[0];
                    // remove it from the list
                    commands.RemoveAt(0);
                }

                // reconstruct the buffer without it
                rxDataBuff = String.Join(commandTerminator, commands);

                // process received command!
                processCommand(cmd);
            } while (commands.Count > 0);

            return true;
        }

        private void processCommand(string cmd)
        {
            if (string.IsNullOrEmpty(cmd)) return;

            // state machine
            switch (rxState)
            {
                // at startup, we will assume that device is running
                case TRXState.Running:
                    // here we can get some running data, such as event logging, realtime frequency as it changes.
                    // event
                    if(cmd.Contains("EVENT["))
                    {

                    }
                    // realtime freq analysis
                    else if(cmd.Contains("FREQ["))
                    {
                        // ovdje smo dobili dva freq responsa, jer imamo 2 petlje u device-u
                        // FREQ[%u]>%0.5f\r\nFREQ[%u]>%0.5f\r\n
                        string[] tmp = cmd.Split(new string[] { crlf }, StringSplitOptions.None);
                        List<string> freqs = new List<string>(tmp);
                        foreach (string loopFreq in freqs)
                        {
                            int loopId = extractLoopIdFromResponse(loopFreq);
                            string paramVal = extractParamValueFromResponse(loopFreq);
                            try
                            {
                                deviceStuff.freq[loopId] = int.Parse(paramVal);
                            }
                            catch (Exception)
                            {
                                // fail silently...
                            }
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
                                MessageBox.Show("Logging is now ON!");
                                break;
                            // logging is turned off
                            case "LOG>0\r\n":
                                MessageBox.Show("Logging is now OFF!");
                                break;
                            // realtime freq analysis is turned on
                            case "FREQ>1\r\n":
                                MessageBox.Show("Realtime frequency analysis is now ON!");
                                break;
                            // realtime freq analysis is turned off
                            case "FREQ>0\r\n":
                                MessageBox.Show("Realtime frequency analysis is now OFF!");
                                break;
                            // resumed to normal operation
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
                                        MessageBox.Show("Device performed factory reset and answered with: " + paramVal);
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
                                        MessageBox.Show("Device accepted soft-restart command.");
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
                                                MessageBox.Show("Error in received configuration data. Number of bytes received is not correct (" + eeSize + "/" + EE_SIZE + ")!");
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
                                            MessageBox.Show("Error in received configuration data. Something is not right!");
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
                                            MessageBox.Show("Error in attempting to send configuration data. Number of bytes device is expecting is not correct (" + eeSize + "/" + EE_SIZE + ")!");
                                            return;
                                        }

                                        // restart index
                                        commSettingIndex = 0;
                                        tssProgress.Maximum = EE_SIZE * 2;
                                        tssProgress.Value = 0;

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
                MessageBox.Show("Please first connect to device!");
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
                    throw new Exception("");
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
            }
        }

        private void btnReadDIPsFromDevice_Click(object sender, EventArgs e)
        {
            sendDataToDevice("T");
        }
    }
}
