﻿namespace DLDConfig1v1
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbMenu = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.readFromDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToRunningModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.restartCPUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.factoryResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFrequencyLoopA = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFrequencyLoopB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCurrentOPMODE = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDeviceState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbConnectDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReadFromDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.sp = new System.IO.Ports.SerialPort(this.components);
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.pnlOperatingMode = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.btnReadDIPsFromDevice = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ckUseSoftDIPs = new System.Windows.Forms.CheckBox();
            this.gbDIP2 = new System.Windows.Forms.GroupBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.gbDIP1 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ckMode1 = new System.Windows.Forms.CheckBox();
            this.ckMode0 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOperatingMode = new System.Windows.Forms.ComboBox();
            this.pnlSamplingSpeed = new System.Windows.Forms.Panel();
            this.chartFreqVsSens = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.tblSensitivityExamples = new System.Windows.Forms.DataGridView();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sensitivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTmr1SamplingSpeed = new System.Windows.Forms.Label();
            this.uctbSamplingSpeed = new DLDConfig1v1.ucTrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrSensitivitiesExampleGenerator = new System.Windows.Forms.Timer(this.components);
            this.pnlSensitivity = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uctbSensitivityUndetectThresholdB = new DLDConfig1v1.ucTrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.uctbSensitivityDetectThresholdB = new DLDConfig1v1.ucTrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.cbSensitivityB = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uctbSensitivityUndetectThresholdA = new DLDConfig1v1.ucTrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.uctbSensitivityDetectThresholdA = new DLDConfig1v1.ucTrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSensitivityA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.uctbFilteringAveraging = new DLDConfig1v1.ucTrackBar();
            this.lblFilteringPositive = new System.Windows.Forms.Label();
            this.uctbFilteringPositive = new DLDConfig1v1.ucTrackBar();
            this.lblFilteringNegative = new System.Windows.Forms.Label();
            this.uctbFilteringNegative = new DLDConfig1v1.ucTrackBar();
            this.cbFilteringLevel = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRelayBPulseNormal = new System.Windows.Forms.Label();
            this.uctbRelayBPulseExtended = new DLDConfig1v1.ucTrackBar();
            this.uctbRelayBPulseNormal = new DLDConfig1v1.ucTrackBar();
            this.lblRelayBPulseExtended = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRelayAPulseNormal = new System.Windows.Forms.Label();
            this.uctbRelayAPulseExtended = new DLDConfig1v1.ucTrackBar();
            this.uctbRelayAPulseNormal = new DLDConfig1v1.ucTrackBar();
            this.lblRelayAPulseExtended = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.uctbPPCDetLeftThreshold = new DLDConfig1v1.ucTrackBar();
            this.label21 = new System.Windows.Forms.Label();
            this.uctbPPCDetLeftTimer = new DLDConfig1v1.ucTrackBar();
            this.lblPPCDetLeaveTimer = new System.Windows.Forms.Label();
            this.uctbPPCLong = new DLDConfig1v1.ucTrackBar();
            this.lblPPCLong = new System.Windows.Forms.Label();
            this.uctbPPCMedium = new DLDConfig1v1.ucTrackBar();
            this.lblPPCMedium = new System.Windows.Forms.Label();
            this.uctbPPCShort = new DLDConfig1v1.ucTrackBar();
            this.lblPPCShort = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDetectStopSlowCheckTimer = new System.Windows.Forms.Label();
            this.uctbDetStopSlowCheckerTimer = new DLDConfig1v1.ucTrackBar();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDetectStopTimer = new System.Windows.Forms.Label();
            this.uctbDetStopThreshold = new DLDConfig1v1.ucTrackBar();
            this.uctbDetStopTimer = new DLDConfig1v1.ucTrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.uctbDCDDThreshold = new DLDConfig1v1.ucTrackBar();
            this.label25 = new System.Windows.Forms.Label();
            this.uctbDCDDTimer = new DLDConfig1v1.ucTrackBar();
            this.lblDCDDTimer = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pnlSpeedTrap = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.tblMaximumSpeedErrors = new System.Windows.Forms.DataGridView();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorstPossibleMeasurement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximumErrorKMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximumErrorPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uctbSpeedDistance = new DLDConfig1v1.ucTrackBar();
            this.lblSpeedLoopDistance = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tmrUpdateConfigPacket = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pnlEventViewer = new System.Windows.Forms.Panel();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLastJointEvent = new System.Windows.Forms.Label();
            this.lblLastEventLoopB = new System.Windows.Forms.Label();
            this.lblLastEventLoopA = new System.Windows.Forms.Label();
            this.lblLoggingState = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.pnlSignalAnalysis = new System.Windows.Forms.Panel();
            this.ckAutoSaveAnalysisLoopB = new System.Windows.Forms.CheckBox();
            this.ckAutoSaveAnalysisLoopA = new System.Windows.Forms.CheckBox();
            this.btnSaveAnalysisLoopB = new System.Windows.Forms.Button();
            this.btnSaveAnalysisLoopA = new System.Windows.Forms.Button();
            this.chAnalysisLoopB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chAnalysisLoopA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSignalAnalysis = new System.Windows.Forms.Label();
            this.btnSignalAnalysis = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.saveAnalysisDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveChartImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveLogDialog = new System.Windows.Forms.SaveFileDialog();
            this.tmrSpeedTrapErrorGenerator = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlOperatingMode.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.gbDIP2.SuspendLayout();
            this.gbDIP1.SuspendLayout();
            this.pnlSamplingSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFreqVsSens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSensitivityExamples)).BeginInit();
            this.pnlSensitivity.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.pnlSpeedTrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaximumSpeedErrors)).BeginInit();
            this.pnlEventViewer.SuspendLayout();
            this.pnlSignalAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysisLoopB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysisLoopA)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMenu
            // 
            this.lbMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.ItemHeight = 16;
            this.lbMenu.Items.AddRange(new object[] {
            "Operating mode",
            "Sampling speed",
            "Sensitivity levels",
            "Filtering levels",
            "Relay pulse durations",
            "Permanent presence cancellation",
            "Detect stop",
            "Drift compensation during detection",
            "Speed trap",
            "Event viewer",
            "Signal analysis"});
            this.lbMenu.Location = new System.Drawing.Point(0, 49);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(224, 639);
            this.lbMenu.TabIndex = 0;
            this.lbMenu.SelectedIndexChanged += new System.EventHandler(this.lbMenu_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProfileToolStripMenuItem,
            this.openProfileToolStripMenuItem,
            this.saveProfileToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProfileToolStripMenuItem
            // 
            this.newProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newProfileToolStripMenuItem.Image")));
            this.newProfileToolStripMenuItem.Name = "newProfileToolStripMenuItem";
            this.newProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newProfileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.newProfileToolStripMenuItem.Text = "New profile";
            this.newProfileToolStripMenuItem.Click += new System.EventHandler(this.newProfileToolStripMenuItem_Click);
            // 
            // openProfileToolStripMenuItem
            // 
            this.openProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openProfileToolStripMenuItem.Image")));
            this.openProfileToolStripMenuItem.Name = "openProfileToolStripMenuItem";
            this.openProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openProfileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openProfileToolStripMenuItem.Text = "Open profile";
            this.openProfileToolStripMenuItem.Click += new System.EventHandler(this.openProfileToolStripMenuItem_Click);
            // 
            // saveProfileToolStripMenuItem
            // 
            this.saveProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProfileToolStripMenuItem.Image")));
            this.saveProfileToolStripMenuItem.Name = "saveProfileToolStripMenuItem";
            this.saveProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProfileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveProfileToolStripMenuItem.Text = "Save profile";
            this.saveProfileToolStripMenuItem.Click += new System.EventHandler(this.saveProfileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.settingsToolStripMenuItem.Text = "Connection settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.toolStripSeparator3,
            this.readFromDeviceToolStripMenuItem,
            this.programDeviceToolStripMenuItem,
            this.returnToRunningModeToolStripMenuItem,
            this.toolStripSeparator5,
            this.restartCPUToolStripMenuItem,
            this.toolStripSeparator4,
            this.factoryResetToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectToolStripMenuItem.Image")));
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.connectToolStripMenuItem.Text = "Connect/Disconnect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // readFromDeviceToolStripMenuItem
            // 
            this.readFromDeviceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("readFromDeviceToolStripMenuItem.Image")));
            this.readFromDeviceToolStripMenuItem.Name = "readFromDeviceToolStripMenuItem";
            this.readFromDeviceToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.readFromDeviceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.readFromDeviceToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.readFromDeviceToolStripMenuItem.Text = "Read from device";
            this.readFromDeviceToolStripMenuItem.Click += new System.EventHandler(this.readFromDeviceToolStripMenuItem_Click);
            // 
            // programDeviceToolStripMenuItem
            // 
            this.programDeviceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programDeviceToolStripMenuItem.Image")));
            this.programDeviceToolStripMenuItem.Name = "programDeviceToolStripMenuItem";
            this.programDeviceToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.programDeviceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.programDeviceToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.programDeviceToolStripMenuItem.Text = "Program device";
            this.programDeviceToolStripMenuItem.Click += new System.EventHandler(this.programDeviceToolStripMenuItem_Click);
            // 
            // returnToRunningModeToolStripMenuItem
            // 
            this.returnToRunningModeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("returnToRunningModeToolStripMenuItem.Image")));
            this.returnToRunningModeToolStripMenuItem.Name = "returnToRunningModeToolStripMenuItem";
            this.returnToRunningModeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.returnToRunningModeToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.returnToRunningModeToolStripMenuItem.Text = "Return to running mode";
            this.returnToRunningModeToolStripMenuItem.Click += new System.EventHandler(this.returnToRunningModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(218, 6);
            // 
            // restartCPUToolStripMenuItem
            // 
            this.restartCPUToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartCPUToolStripMenuItem.Image")));
            this.restartCPUToolStripMenuItem.Name = "restartCPUToolStripMenuItem";
            this.restartCPUToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.restartCPUToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.restartCPUToolStripMenuItem.Text = "Restart CPU";
            this.restartCPUToolStripMenuItem.Click += new System.EventHandler(this.restartCPUToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(218, 6);
            // 
            // factoryResetToolStripMenuItem
            // 
            this.factoryResetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("factoryResetToolStripMenuItem.Image")));
            this.factoryResetToolStripMenuItem.Name = "factoryResetToolStripMenuItem";
            this.factoryResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.factoryResetToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.factoryResetToolStripMenuItem.Text = "Factory reset";
            this.factoryResetToolStripMenuItem.Click += new System.EventHandler(this.factoryResetToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem1.Image")));
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssDateTime,
            this.tssConnectionStatus,
            this.tssFrequencyLoopA,
            this.tssFrequencyLoopB,
            this.tssCurrentOPMODE,
            this.tssDeviceState,
            this.tssProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 688);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "ss1";
            // 
            // tssDateTime
            // 
            this.tssDateTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssDateTime.Name = "tssDateTime";
            this.tssDateTime.Size = new System.Drawing.Size(16, 17);
            this.tssDateTime.Text = "...";
            // 
            // tssConnectionStatus
            // 
            this.tssConnectionStatus.BackColor = System.Drawing.Color.PeachPuff;
            this.tssConnectionStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssConnectionStatus.Name = "tssConnectionStatus";
            this.tssConnectionStatus.Size = new System.Drawing.Size(117, 17);
            this.tssConnectionStatus.Tag = "Status: %";
            this.tssConnectionStatus.Text = "Status: Disconnected";
            // 
            // tssFrequencyLoopA
            // 
            this.tssFrequencyLoopA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssFrequencyLoopA.IsLink = true;
            this.tssFrequencyLoopA.Name = "tssFrequencyLoopA";
            this.tssFrequencyLoopA.Size = new System.Drawing.Size(102, 17);
            this.tssFrequencyLoopA.Tag = "Loop A: % kHz";
            this.tssFrequencyLoopA.Text = "Loop A: Unknown";
            this.tssFrequencyLoopA.Click += new System.EventHandler(this.tssFrequencyLoopA_Click);
            // 
            // tssFrequencyLoopB
            // 
            this.tssFrequencyLoopB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssFrequencyLoopB.IsLink = true;
            this.tssFrequencyLoopB.Name = "tssFrequencyLoopB";
            this.tssFrequencyLoopB.Size = new System.Drawing.Size(101, 17);
            this.tssFrequencyLoopB.Tag = "Loop B: % kHz";
            this.tssFrequencyLoopB.Text = "Loop B: Unknown";
            this.tssFrequencyLoopB.Click += new System.EventHandler(this.tssFrequencyLoopB_Click);
            // 
            // tssCurrentOPMODE
            // 
            this.tssCurrentOPMODE.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tssCurrentOPMODE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssCurrentOPMODE.Name = "tssCurrentOPMODE";
            this.tssCurrentOPMODE.Size = new System.Drawing.Size(95, 17);
            this.tssCurrentOPMODE.Tag = "Mode: %";
            this.tssCurrentOPMODE.Text = "Mode: Unknown";
            // 
            // tssDeviceState
            // 
            this.tssDeviceState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssDeviceState.Name = "tssDeviceState";
            this.tssDeviceState.Size = new System.Drawing.Size(90, 17);
            this.tssDeviceState.Tag = "State: %";
            this.tssDeviceState.Text = "State: Unknown";
            // 
            // tssProgress
            // 
            this.tssProgress.Name = "tssProgress";
            this.tssProgress.Size = new System.Drawing.Size(100, 16);
            this.tssProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tssProgress.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnectDisconnect,
            this.toolStripSeparator6,
            this.btnReadFromDevice,
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripSeparator7,
            this.toolStripButton4,
            this.toolStripSeparator8,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbConnectDisconnect
            // 
            this.tsbConnectDisconnect.BackColor = System.Drawing.Color.PeachPuff;
            this.tsbConnectDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnectDisconnect.Image")));
            this.tsbConnectDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnectDisconnect.Name = "tsbConnectDisconnect";
            this.tsbConnectDisconnect.Size = new System.Drawing.Size(159, 22);
            this.tsbConnectDisconnect.Text = "Connect/Disconnect (F1)";
            this.tsbConnectDisconnect.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReadFromDevice
            // 
            this.btnReadFromDevice.Image = ((System.Drawing.Image)(resources.GetObject("btnReadFromDevice.Image")));
            this.btnReadFromDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReadFromDevice.Name = "btnReadFromDevice";
            this.btnReadFromDevice.Size = new System.Drawing.Size(142, 22);
            this.btnReadFromDevice.Text = "Read from device (F2)";
            this.btnReadFromDevice.Click += new System.EventHandler(this.readFromDeviceToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(133, 22);
            this.toolStripButton1.Text = "Program device (F3)";
            this.toolStripButton1.Click += new System.EventHandler(this.programDeviceToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(178, 22);
            this.toolStripButton5.Text = "Return to running mode (F4)";
            this.toolStripButton5.Click += new System.EventHandler(this.returnToRunningModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.Color.Moccasin;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(112, 22);
            this.toolStripButton4.Text = "Restart CPU (F5)";
            this.toolStripButton4.Click += new System.EventHandler(this.restartCPUToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(123, 22);
            this.toolStripButton3.Text = "Factory reset (F10)";
            this.toolStripButton3.Click += new System.EventHandler(this.factoryResetToolStripMenuItem_Click);
            // 
            // sp
            // 
            this.sp.BaudRate = 115200;
            this.sp.PortName = "COM3";
            this.sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sp_DataReceived);
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 500;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // pnlOperatingMode
            // 
            this.pnlOperatingMode.Controls.Add(this.tabControl1);
            this.pnlOperatingMode.Controls.Add(this.groupBox6);
            this.pnlOperatingMode.Controls.Add(this.btnReadDIPsFromDevice);
            this.pnlOperatingMode.Controls.Add(this.label27);
            this.pnlOperatingMode.Controls.Add(this.label26);
            this.pnlOperatingMode.Controls.Add(this.ckUseSoftDIPs);
            this.pnlOperatingMode.Controls.Add(this.gbDIP2);
            this.pnlOperatingMode.Controls.Add(this.gbDIP1);
            this.pnlOperatingMode.Controls.Add(this.label2);
            this.pnlOperatingMode.Controls.Add(this.label1);
            this.pnlOperatingMode.Controls.Add(this.cbOperatingMode);
            this.pnlOperatingMode.Location = new System.Drawing.Point(224, 49);
            this.pnlOperatingMode.Name = "pnlOperatingMode";
            this.pnlOperatingMode.Size = new System.Drawing.Size(728, 639);
            this.pnlOperatingMode.TabIndex = 5;
            this.pnlOperatingMode.Tag = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 308);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(201, 238);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(193, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "v1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(193, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "v2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 206);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.cbBaudRate);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Location = new System.Drawing.Point(9, 552);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(707, 74);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "UART speed";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 51);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(655, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "After changing UART port speed in device and resetting it, do not forget to open " +
    "File -> Connection settings, and set the same port speed.";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "19200",
            "9600"});
            this.cbBaudRate.Location = new System.Drawing.Point(149, 22);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudRate.TabIndex = 12;
            this.cbBaudRate.Tag = "UPDATE_CONFIG_PACKET";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 25);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(137, 13);
            this.label32.TabIndex = 11;
            this.label32.Text = "Device\'s UART port speed:";
            // 
            // btnReadDIPsFromDevice
            // 
            this.btnReadDIPsFromDevice.Location = new System.Drawing.Point(218, 367);
            this.btnReadDIPsFromDevice.Name = "btnReadDIPsFromDevice";
            this.btnReadDIPsFromDevice.Size = new System.Drawing.Size(105, 23);
            this.btnReadDIPsFromDevice.TabIndex = 9;
            this.btnReadDIPsFromDevice.Text = "Read from device";
            this.btnReadDIPsFromDevice.UseVisualStyleBackColor = true;
            this.btnReadDIPsFromDevice.Click += new System.EventHandler(this.btnReadDIPsFromDevice_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(217, 342);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(422, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "If you want to read device\'s current operating mode and options, click the button" +
    " bellow:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(217, 306);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(461, 26);
            this.label26.TabIndex = 7;
            this.label26.Text = "Use this panel to configure the device operating mode when hardware DIP settings " +
    "are disabled.\r\nThese settings are ignored if you are using DIP switches on devic" +
    "e!";
            // 
            // ckUseSoftDIPs
            // 
            this.ckUseSoftDIPs.AutoSize = true;
            this.ckUseSoftDIPs.Location = new System.Drawing.Point(370, 38);
            this.ckUseSoftDIPs.Name = "ckUseSoftDIPs";
            this.ckUseSoftDIPs.Size = new System.Drawing.Size(262, 17);
            this.ckUseSoftDIPs.TabIndex = 6;
            this.ckUseSoftDIPs.Tag = "UPDATE_CONFIG_PACKET";
            this.ckUseSoftDIPs.Text = "Use software DIPs (ignore DIP settings on device)";
            this.ckUseSoftDIPs.UseVisualStyleBackColor = true;
            // 
            // gbDIP2
            // 
            this.gbDIP2.Controls.Add(this.checkBox9);
            this.gbDIP2.Controls.Add(this.checkBox10);
            this.gbDIP2.Controls.Add(this.checkBox11);
            this.gbDIP2.Controls.Add(this.checkBox12);
            this.gbDIP2.Controls.Add(this.checkBox13);
            this.gbDIP2.Controls.Add(this.checkBox14);
            this.gbDIP2.Controls.Add(this.checkBox15);
            this.gbDIP2.Controls.Add(this.checkBox16);
            this.gbDIP2.Location = new System.Drawing.Point(365, 72);
            this.gbDIP2.Name = "gbDIP2";
            this.gbDIP2.Size = new System.Drawing.Size(350, 227);
            this.gbDIP2.TabIndex = 4;
            this.gbDIP2.TabStop = false;
            this.gbDIP2.Text = "DIP 2 (blue)";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(16, 195);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(80, 17);
            this.checkBox9.TabIndex = 7;
            this.checkBox9.Tag = "7";
            this.checkBox9.Text = "checkBox9";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(16, 172);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(86, 17);
            this.checkBox10.TabIndex = 6;
            this.checkBox10.Tag = "6";
            this.checkBox10.Text = "checkBox10";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(16, 148);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(86, 17);
            this.checkBox11.TabIndex = 5;
            this.checkBox11.Tag = "5";
            this.checkBox11.Text = "checkBox11";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(16, 125);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(86, 17);
            this.checkBox12.TabIndex = 4;
            this.checkBox12.Tag = "4";
            this.checkBox12.Text = "checkBox12";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(16, 102);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(86, 17);
            this.checkBox13.TabIndex = 3;
            this.checkBox13.Tag = "3";
            this.checkBox13.Text = "checkBox13";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(16, 79);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(86, 17);
            this.checkBox14.TabIndex = 2;
            this.checkBox14.Tag = "2";
            this.checkBox14.Text = "checkBox14";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(16, 56);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(86, 17);
            this.checkBox15.TabIndex = 1;
            this.checkBox15.Tag = "1";
            this.checkBox15.Text = "checkBox15";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(16, 32);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(86, 17);
            this.checkBox16.TabIndex = 0;
            this.checkBox16.Tag = "0";
            this.checkBox16.Text = "checkBox16";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // gbDIP1
            // 
            this.gbDIP1.Controls.Add(this.checkBox8);
            this.gbDIP1.Controls.Add(this.checkBox7);
            this.gbDIP1.Controls.Add(this.checkBox6);
            this.gbDIP1.Controls.Add(this.checkBox5);
            this.gbDIP1.Controls.Add(this.checkBox4);
            this.gbDIP1.Controls.Add(this.checkBox3);
            this.gbDIP1.Controls.Add(this.ckMode1);
            this.gbDIP1.Controls.Add(this.ckMode0);
            this.gbDIP1.Location = new System.Drawing.Point(9, 72);
            this.gbDIP1.Name = "gbDIP1";
            this.gbDIP1.Size = new System.Drawing.Size(350, 227);
            this.gbDIP1.TabIndex = 3;
            this.gbDIP1.TabStop = false;
            this.gbDIP1.Text = "DIP 1 (red)";
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(16, 195);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(80, 17);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.Tag = "7";
            this.checkBox8.Text = "checkBox8";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(16, 172);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(80, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Tag = "6";
            this.checkBox7.Text = "checkBox7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(16, 148);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(80, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Tag = "5";
            this.checkBox6.Text = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(16, 125);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(80, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Tag = "4";
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(16, 102);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Tag = "3";
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 79);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "2";
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ckMode1
            // 
            this.ckMode1.AutoSize = true;
            this.ckMode1.Enabled = false;
            this.ckMode1.Location = new System.Drawing.Point(16, 56);
            this.ckMode1.Name = "ckMode1";
            this.ckMode1.Size = new System.Drawing.Size(71, 17);
            this.ckMode1.TabIndex = 1;
            this.ckMode1.Tag = "1";
            this.ckMode1.Text = "ckMode1";
            this.ckMode1.UseVisualStyleBackColor = true;
            // 
            // ckMode0
            // 
            this.ckMode0.AutoSize = true;
            this.ckMode0.Enabled = false;
            this.ckMode0.Location = new System.Drawing.Point(16, 32);
            this.ckMode0.Name = "ckMode0";
            this.ckMode0.Size = new System.Drawing.Size(71, 17);
            this.ckMode0.TabIndex = 0;
            this.ckMode0.Tag = "0";
            this.ckMode0.Text = "ckMode0";
            this.ckMode0.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(728, 27);
            this.label2.TabIndex = 2;
            this.label2.Tag = "title";
            this.label2.Text = "op modes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operating mode:";
            // 
            // cbOperatingMode
            // 
            this.cbOperatingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperatingMode.FormattingEnabled = true;
            this.cbOperatingMode.Items.AddRange(new object[] {
            "Single Channel (A)",
            "Dual Channel Independent (A) and (B)",
            "Dual Channel Directional Logic (A + B)",
            "Speed Trap (A + B)"});
            this.cbOperatingMode.Location = new System.Drawing.Point(97, 35);
            this.cbOperatingMode.Name = "cbOperatingMode";
            this.cbOperatingMode.Size = new System.Drawing.Size(262, 21);
            this.cbOperatingMode.TabIndex = 0;
            this.cbOperatingMode.SelectedIndexChanged += new System.EventHandler(this.cbOperatingMode_SelectedIndexChanged);
            // 
            // pnlSamplingSpeed
            // 
            this.pnlSamplingSpeed.Controls.Add(this.chartFreqVsSens);
            this.pnlSamplingSpeed.Controls.Add(this.label5);
            this.pnlSamplingSpeed.Controls.Add(this.tblSensitivityExamples);
            this.pnlSamplingSpeed.Controls.Add(this.lblTmr1SamplingSpeed);
            this.pnlSamplingSpeed.Controls.Add(this.uctbSamplingSpeed);
            this.pnlSamplingSpeed.Controls.Add(this.label4);
            this.pnlSamplingSpeed.Controls.Add(this.label3);
            this.pnlSamplingSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSamplingSpeed.Location = new System.Drawing.Point(224, 49);
            this.pnlSamplingSpeed.Name = "pnlSamplingSpeed";
            this.pnlSamplingSpeed.Size = new System.Drawing.Size(728, 639);
            this.pnlSamplingSpeed.TabIndex = 6;
            this.pnlSamplingSpeed.Tag = "1";
            // 
            // chartFreqVsSens
            // 
            this.chartFreqVsSens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea10.Name = "ChartArea1";
            this.chartFreqVsSens.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chartFreqVsSens.Legends.Add(legend10);
            this.chartFreqVsSens.Location = new System.Drawing.Point(290, 173);
            this.chartFreqVsSens.Name = "chartFreqVsSens";
            this.chartFreqVsSens.Size = new System.Drawing.Size(426, 456);
            this.chartFreqVsSens.TabIndex = 10;
            this.chartFreqVsSens.Text = "Frequency vs Sensitivity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Best possible sensitivities for chosen sampling speed:";
            // 
            // tblSensitivityExamples
            // 
            this.tblSensitivityExamples.AllowUserToAddRows = false;
            this.tblSensitivityExamples.AllowUserToDeleteRows = false;
            this.tblSensitivityExamples.AllowUserToResizeColumns = false;
            this.tblSensitivityExamples.AllowUserToResizeRows = false;
            this.tblSensitivityExamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tblSensitivityExamples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblSensitivityExamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblSensitivityExamples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Frequency,
            this.Sensitivity});
            this.tblSensitivityExamples.Location = new System.Drawing.Point(9, 174);
            this.tblSensitivityExamples.MultiSelect = false;
            this.tblSensitivityExamples.Name = "tblSensitivityExamples";
            this.tblSensitivityExamples.ReadOnly = true;
            this.tblSensitivityExamples.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tblSensitivityExamples.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblSensitivityExamples.ShowCellErrors = false;
            this.tblSensitivityExamples.ShowEditingIcon = false;
            this.tblSensitivityExamples.ShowRowErrors = false;
            this.tblSensitivityExamples.Size = new System.Drawing.Size(275, 455);
            this.tblSensitivityExamples.TabIndex = 8;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frequency [kHz]";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            // 
            // Sensitivity
            // 
            this.Sensitivity.HeaderText = "Sensitivity [Hz]";
            this.Sensitivity.Name = "Sensitivity";
            this.Sensitivity.ReadOnly = true;
            // 
            // lblTmr1SamplingSpeed
            // 
            this.lblTmr1SamplingSpeed.AutoSize = true;
            this.lblTmr1SamplingSpeed.Location = new System.Drawing.Point(7, 130);
            this.lblTmr1SamplingSpeed.Name = "lblTmr1SamplingSpeed";
            this.lblTmr1SamplingSpeed.Size = new System.Drawing.Size(175, 13);
            this.lblTmr1SamplingSpeed.TabIndex = 7;
            this.lblTmr1SamplingSpeed.Tag = "Sampling speed for each loop: % ms";
            this.lblTmr1SamplingSpeed.Text = "Sampling speed for each loop: ? ms";
            // 
            // uctbSamplingSpeed
            // 
            this.uctbSamplingSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSamplingSpeed.LargeChange = 50;
            this.uctbSamplingSpeed.Location = new System.Drawing.Point(7, 55);
            this.uctbSamplingSpeed.Maximum = 50000;
            this.uctbSamplingSpeed.Minimum = 12000;
            this.uctbSamplingSpeed.Name = "uctbSamplingSpeed";
            this.uctbSamplingSpeed.Size = new System.Drawing.Size(709, 71);
            this.uctbSamplingSpeed.SmallChange = 10;
            this.uctbSamplingSpeed.TabIndex = 6;
            this.uctbSamplingSpeed.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbSamplingSpeed.TickFrequency = 100;
            this.uctbSamplingSpeed.Value = 35000;
            this.uctbSamplingSpeed.TrackbarChanged += new System.EventHandler(this.ucTrackBar1_TrackbarChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sampling speed:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(728, 27);
            this.label3.TabIndex = 3;
            this.label3.Tag = "title";
            this.label3.Text = "sampling speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrSensitivitiesExampleGenerator
            // 
            this.tmrSensitivitiesExampleGenerator.Interval = 350;
            this.tmrSensitivitiesExampleGenerator.Tick += new System.EventHandler(this.tmrSensitivitiesExampleGenerator_Tick);
            // 
            // pnlSensitivity
            // 
            this.pnlSensitivity.Controls.Add(this.label16);
            this.pnlSensitivity.Controls.Add(this.groupBox2);
            this.pnlSensitivity.Controls.Add(this.groupBox1);
            this.pnlSensitivity.Controls.Add(this.label6);
            this.pnlSensitivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSensitivity.Location = new System.Drawing.Point(224, 49);
            this.pnlSensitivity.Name = "pnlSensitivity";
            this.pnlSensitivity.Size = new System.Drawing.Size(728, 639);
            this.pnlSensitivity.TabIndex = 7;
            this.pnlSensitivity.Tag = "2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 491);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(367, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "* Chosen sensitivity bank corresponds to channel\'s current sensitivity setting.";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.uctbSensitivityUndetectThresholdB);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.uctbSensitivityDetectThresholdB);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cbSensitivityB);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(9, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 217);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loop B";
            // 
            // uctbSensitivityUndetectThresholdB
            // 
            this.uctbSensitivityUndetectThresholdB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSensitivityUndetectThresholdB.LargeChange = 5;
            this.uctbSensitivityUndetectThresholdB.Location = new System.Drawing.Point(6, 149);
            this.uctbSensitivityUndetectThresholdB.Maximum = 1000;
            this.uctbSensitivityUndetectThresholdB.Minimum = 1;
            this.uctbSensitivityUndetectThresholdB.Name = "uctbSensitivityUndetectThresholdB";
            this.uctbSensitivityUndetectThresholdB.Size = new System.Drawing.Size(695, 60);
            this.uctbSensitivityUndetectThresholdB.SmallChange = 1;
            this.uctbSensitivityUndetectThresholdB.TabIndex = 6;
            this.uctbSensitivityUndetectThresholdB.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbSensitivityUndetectThresholdB.TickFrequency = 10;
            this.uctbSensitivityUndetectThresholdB.Value = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Undetect threshold:";
            // 
            // uctbSensitivityDetectThresholdB
            // 
            this.uctbSensitivityDetectThresholdB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSensitivityDetectThresholdB.LargeChange = 5;
            this.uctbSensitivityDetectThresholdB.Location = new System.Drawing.Point(6, 70);
            this.uctbSensitivityDetectThresholdB.Maximum = 1000;
            this.uctbSensitivityDetectThresholdB.Minimum = 1;
            this.uctbSensitivityDetectThresholdB.Name = "uctbSensitivityDetectThresholdB";
            this.uctbSensitivityDetectThresholdB.Size = new System.Drawing.Size(695, 60);
            this.uctbSensitivityDetectThresholdB.SmallChange = 1;
            this.uctbSensitivityDetectThresholdB.TabIndex = 4;
            this.uctbSensitivityDetectThresholdB.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbSensitivityDetectThresholdB.TickFrequency = 10;
            this.uctbSensitivityDetectThresholdB.Value = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Detect threshold:";
            // 
            // cbSensitivityB
            // 
            this.cbSensitivityB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSensitivityB.FormattingEnabled = true;
            this.cbSensitivityB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbSensitivityB.Location = new System.Drawing.Point(96, 19);
            this.cbSensitivityB.Name = "cbSensitivityB";
            this.cbSensitivityB.Size = new System.Drawing.Size(47, 21);
            this.cbSensitivityB.TabIndex = 1;
            this.cbSensitivityB.Tag = "UPDATE_CONFIG_PACKET";
            this.cbSensitivityB.SelectedIndexChanged += new System.EventHandler(this.cbSensitivityB_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Sensitivity bank:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.uctbSensitivityUndetectThresholdA);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.uctbSensitivityDetectThresholdA);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbSensitivityA);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(9, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 217);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loop A";
            // 
            // uctbSensitivityUndetectThresholdA
            // 
            this.uctbSensitivityUndetectThresholdA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSensitivityUndetectThresholdA.LargeChange = 5;
            this.uctbSensitivityUndetectThresholdA.Location = new System.Drawing.Point(6, 149);
            this.uctbSensitivityUndetectThresholdA.Maximum = 1000;
            this.uctbSensitivityUndetectThresholdA.Minimum = 1;
            this.uctbSensitivityUndetectThresholdA.Name = "uctbSensitivityUndetectThresholdA";
            this.uctbSensitivityUndetectThresholdA.Size = new System.Drawing.Size(695, 60);
            this.uctbSensitivityUndetectThresholdA.SmallChange = 1;
            this.uctbSensitivityUndetectThresholdA.TabIndex = 6;
            this.uctbSensitivityUndetectThresholdA.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbSensitivityUndetectThresholdA.TickFrequency = 10;
            this.uctbSensitivityUndetectThresholdA.Value = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Undetect threshold:";
            // 
            // uctbSensitivityDetectThresholdA
            // 
            this.uctbSensitivityDetectThresholdA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSensitivityDetectThresholdA.LargeChange = 5;
            this.uctbSensitivityDetectThresholdA.Location = new System.Drawing.Point(6, 70);
            this.uctbSensitivityDetectThresholdA.Maximum = 1000;
            this.uctbSensitivityDetectThresholdA.Minimum = 1;
            this.uctbSensitivityDetectThresholdA.Name = "uctbSensitivityDetectThresholdA";
            this.uctbSensitivityDetectThresholdA.Size = new System.Drawing.Size(695, 60);
            this.uctbSensitivityDetectThresholdA.SmallChange = 1;
            this.uctbSensitivityDetectThresholdA.TabIndex = 4;
            this.uctbSensitivityDetectThresholdA.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbSensitivityDetectThresholdA.TickFrequency = 10;
            this.uctbSensitivityDetectThresholdA.Value = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Detect threshold:";
            // 
            // cbSensitivityA
            // 
            this.cbSensitivityA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSensitivityA.FormattingEnabled = true;
            this.cbSensitivityA.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbSensitivityA.Location = new System.Drawing.Point(96, 19);
            this.cbSensitivityA.Name = "cbSensitivityA";
            this.cbSensitivityA.Size = new System.Drawing.Size(47, 21);
            this.cbSensitivityA.TabIndex = 1;
            this.cbSensitivityA.Tag = "UPDATE_CONFIG_PACKET";
            this.cbSensitivityA.SelectedIndexChanged += new System.EventHandler(this.cbSensitivityA_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sensitivity bank:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(728, 27);
            this.label6.TabIndex = 4;
            this.label6.Tag = "title";
            this.label6.Text = "sensitivity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.uctbFilteringAveraging);
            this.panel3.Controls.Add(this.lblFilteringPositive);
            this.panel3.Controls.Add(this.uctbFilteringPositive);
            this.panel3.Controls.Add(this.lblFilteringNegative);
            this.panel3.Controls.Add(this.uctbFilteringNegative);
            this.panel3.Controls.Add(this.cbFilteringLevel);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(230, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 148);
            this.panel3.TabIndex = 8;
            this.panel3.Tag = "3";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 239);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Signal averaging:";
            // 
            // uctbFilteringAveraging
            // 
            this.uctbFilteringAveraging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbFilteringAveraging.LargeChange = 1;
            this.uctbFilteringAveraging.Location = new System.Drawing.Point(6, 255);
            this.uctbFilteringAveraging.Maximum = 8;
            this.uctbFilteringAveraging.Minimum = 1;
            this.uctbFilteringAveraging.Name = "uctbFilteringAveraging";
            this.uctbFilteringAveraging.Size = new System.Drawing.Size(157, 59);
            this.uctbFilteringAveraging.SmallChange = 1;
            this.uctbFilteringAveraging.TabIndex = 12;
            this.uctbFilteringAveraging.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbFilteringAveraging.TickFrequency = 1;
            this.uctbFilteringAveraging.Value = 1;
            // 
            // lblFilteringPositive
            // 
            this.lblFilteringPositive.AutoSize = true;
            this.lblFilteringPositive.Location = new System.Drawing.Point(6, 154);
            this.lblFilteringPositive.Name = "lblFilteringPositive";
            this.lblFilteringPositive.Size = new System.Drawing.Size(117, 13);
            this.lblFilteringPositive.TabIndex = 11;
            this.lblFilteringPositive.Tag = "Positive drift timer: % ms";
            this.lblFilteringPositive.Text = "Positive drift timer: ? ms";
            // 
            // uctbFilteringPositive
            // 
            this.uctbFilteringPositive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbFilteringPositive.LargeChange = 5;
            this.uctbFilteringPositive.Location = new System.Drawing.Point(6, 170);
            this.uctbFilteringPositive.Maximum = 255;
            this.uctbFilteringPositive.Minimum = 1;
            this.uctbFilteringPositive.Name = "uctbFilteringPositive";
            this.uctbFilteringPositive.Size = new System.Drawing.Size(157, 60);
            this.uctbFilteringPositive.SmallChange = 1;
            this.uctbFilteringPositive.TabIndex = 10;
            this.uctbFilteringPositive.Tag = "TMR1BEST_CHANGE;UPDATE_CONFIG_PACKET";
            this.uctbFilteringPositive.TickFrequency = 5;
            this.uctbFilteringPositive.Value = 1;
            this.uctbFilteringPositive.TrackbarChanged += new System.EventHandler(this.uctbFilteringPositive_TrackbarChanged);
            // 
            // lblFilteringNegative
            // 
            this.lblFilteringNegative.AutoSize = true;
            this.lblFilteringNegative.Location = new System.Drawing.Point(6, 70);
            this.lblFilteringNegative.Name = "lblFilteringNegative";
            this.lblFilteringNegative.Size = new System.Drawing.Size(123, 13);
            this.lblFilteringNegative.TabIndex = 9;
            this.lblFilteringNegative.Tag = "Negative drift timer: % ms";
            this.lblFilteringNegative.Text = "Negative drift timer: ? ms";
            // 
            // uctbFilteringNegative
            // 
            this.uctbFilteringNegative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbFilteringNegative.LargeChange = 5;
            this.uctbFilteringNegative.Location = new System.Drawing.Point(6, 86);
            this.uctbFilteringNegative.Maximum = 255;
            this.uctbFilteringNegative.Minimum = 1;
            this.uctbFilteringNegative.Name = "uctbFilteringNegative";
            this.uctbFilteringNegative.Size = new System.Drawing.Size(157, 60);
            this.uctbFilteringNegative.SmallChange = 1;
            this.uctbFilteringNegative.TabIndex = 8;
            this.uctbFilteringNegative.Tag = "TMR1BEST_CHANGE;UPDATE_CONFIG_PACKET";
            this.uctbFilteringNegative.TickFrequency = 5;
            this.uctbFilteringNegative.Value = 1;
            this.uctbFilteringNegative.TrackbarChanged += new System.EventHandler(this.uctbFilteringNegative_TrackbarChanged);
            // 
            // cbFilteringLevel
            // 
            this.cbFilteringLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilteringLevel.FormattingEnabled = true;
            this.cbFilteringLevel.Items.AddRange(new object[] {
            "Normal filtering",
            "Additional signal filtering"});
            this.cbFilteringLevel.Location = new System.Drawing.Point(83, 35);
            this.cbFilteringLevel.Name = "cbFilteringLevel";
            this.cbFilteringLevel.Size = new System.Drawing.Size(173, 21);
            this.cbFilteringLevel.TabIndex = 7;
            this.cbFilteringLevel.Tag = "";
            this.cbFilteringLevel.SelectedIndexChanged += new System.EventHandler(this.cbFilteringLevel_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Filtering level:";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 27);
            this.label13.TabIndex = 5;
            this.label13.Tag = "title";
            this.label13.Text = "filtering";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(412, 192);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 146);
            this.panel4.TabIndex = 9;
            this.panel4.Tag = "4";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lblRelayBPulseNormal);
            this.groupBox4.Controls.Add(this.uctbRelayBPulseExtended);
            this.groupBox4.Controls.Add(this.uctbRelayBPulseNormal);
            this.groupBox4.Controls.Add(this.lblRelayBPulseExtended);
            this.groupBox4.Location = new System.Drawing.Point(6, 260);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 219);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Relay B";
            // 
            // lblRelayBPulseNormal
            // 
            this.lblRelayBPulseNormal.AutoSize = true;
            this.lblRelayBPulseNormal.Location = new System.Drawing.Point(6, 24);
            this.lblRelayBPulseNormal.Name = "lblRelayBPulseNormal";
            this.lblRelayBPulseNormal.Size = new System.Drawing.Size(137, 13);
            this.lblRelayBPulseNormal.TabIndex = 6;
            this.lblRelayBPulseNormal.Tag = "Normal pulse duration: % ms";
            this.lblRelayBPulseNormal.Text = "Normal pulse duration: ? ms";
            // 
            // uctbRelayBPulseExtended
            // 
            this.uctbRelayBPulseExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbRelayBPulseExtended.LargeChange = 5;
            this.uctbRelayBPulseExtended.Location = new System.Drawing.Point(6, 139);
            this.uctbRelayBPulseExtended.Maximum = 255;
            this.uctbRelayBPulseExtended.Minimum = 1;
            this.uctbRelayBPulseExtended.Name = "uctbRelayBPulseExtended";
            this.uctbRelayBPulseExtended.Size = new System.Drawing.Size(145, 71);
            this.uctbRelayBPulseExtended.SmallChange = 1;
            this.uctbRelayBPulseExtended.TabIndex = 9;
            this.uctbRelayBPulseExtended.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbRelayBPulseExtended.TickFrequency = 5;
            this.uctbRelayBPulseExtended.Value = 1;
            this.uctbRelayBPulseExtended.TrackbarChanged += new System.EventHandler(this.uctbRelayBPulseExtended_TrackbarChanged);
            // 
            // uctbRelayBPulseNormal
            // 
            this.uctbRelayBPulseNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbRelayBPulseNormal.LargeChange = 5;
            this.uctbRelayBPulseNormal.Location = new System.Drawing.Point(6, 43);
            this.uctbRelayBPulseNormal.Maximum = 255;
            this.uctbRelayBPulseNormal.Minimum = 1;
            this.uctbRelayBPulseNormal.Name = "uctbRelayBPulseNormal";
            this.uctbRelayBPulseNormal.Size = new System.Drawing.Size(148, 69);
            this.uctbRelayBPulseNormal.SmallChange = 1;
            this.uctbRelayBPulseNormal.TabIndex = 7;
            this.uctbRelayBPulseNormal.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbRelayBPulseNormal.TickFrequency = 5;
            this.uctbRelayBPulseNormal.Value = 1;
            this.uctbRelayBPulseNormal.TrackbarChanged += new System.EventHandler(this.uctbRelayBPulseNormal_TrackbarChanged);
            // 
            // lblRelayBPulseExtended
            // 
            this.lblRelayBPulseExtended.AutoSize = true;
            this.lblRelayBPulseExtended.Location = new System.Drawing.Point(6, 117);
            this.lblRelayBPulseExtended.Name = "lblRelayBPulseExtended";
            this.lblRelayBPulseExtended.Size = new System.Drawing.Size(149, 13);
            this.lblRelayBPulseExtended.TabIndex = 8;
            this.lblRelayBPulseExtended.Tag = "Extended pulse duration: % ms";
            this.lblRelayBPulseExtended.Text = "Extended pulse duration: ? ms";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblRelayAPulseNormal);
            this.groupBox3.Controls.Add(this.uctbRelayAPulseExtended);
            this.groupBox3.Controls.Add(this.uctbRelayAPulseNormal);
            this.groupBox3.Controls.Add(this.lblRelayAPulseExtended);
            this.groupBox3.Location = new System.Drawing.Point(6, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 219);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Relay A";
            // 
            // lblRelayAPulseNormal
            // 
            this.lblRelayAPulseNormal.AutoSize = true;
            this.lblRelayAPulseNormal.Location = new System.Drawing.Point(6, 24);
            this.lblRelayAPulseNormal.Name = "lblRelayAPulseNormal";
            this.lblRelayAPulseNormal.Size = new System.Drawing.Size(137, 13);
            this.lblRelayAPulseNormal.TabIndex = 6;
            this.lblRelayAPulseNormal.Tag = "Normal pulse duration: % ms";
            this.lblRelayAPulseNormal.Text = "Normal pulse duration: ? ms";
            // 
            // uctbRelayAPulseExtended
            // 
            this.uctbRelayAPulseExtended.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbRelayAPulseExtended.LargeChange = 5;
            this.uctbRelayAPulseExtended.Location = new System.Drawing.Point(6, 139);
            this.uctbRelayAPulseExtended.Maximum = 255;
            this.uctbRelayAPulseExtended.Minimum = 1;
            this.uctbRelayAPulseExtended.Name = "uctbRelayAPulseExtended";
            this.uctbRelayAPulseExtended.Size = new System.Drawing.Size(145, 71);
            this.uctbRelayAPulseExtended.SmallChange = 1;
            this.uctbRelayAPulseExtended.TabIndex = 9;
            this.uctbRelayAPulseExtended.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbRelayAPulseExtended.TickFrequency = 5;
            this.uctbRelayAPulseExtended.Value = 1;
            this.uctbRelayAPulseExtended.TrackbarChanged += new System.EventHandler(this.uctbRelayPulseExtended_TrackbarChanged);
            // 
            // uctbRelayAPulseNormal
            // 
            this.uctbRelayAPulseNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbRelayAPulseNormal.LargeChange = 5;
            this.uctbRelayAPulseNormal.Location = new System.Drawing.Point(6, 43);
            this.uctbRelayAPulseNormal.Maximum = 255;
            this.uctbRelayAPulseNormal.Minimum = 1;
            this.uctbRelayAPulseNormal.Name = "uctbRelayAPulseNormal";
            this.uctbRelayAPulseNormal.Size = new System.Drawing.Size(148, 69);
            this.uctbRelayAPulseNormal.SmallChange = 1;
            this.uctbRelayAPulseNormal.TabIndex = 7;
            this.uctbRelayAPulseNormal.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbRelayAPulseNormal.TickFrequency = 5;
            this.uctbRelayAPulseNormal.Value = 1;
            this.uctbRelayAPulseNormal.TrackbarChanged += new System.EventHandler(this.uctbRelayPulseNormal_TrackbarChanged);
            // 
            // lblRelayAPulseExtended
            // 
            this.lblRelayAPulseExtended.AutoSize = true;
            this.lblRelayAPulseExtended.Location = new System.Drawing.Point(6, 117);
            this.lblRelayAPulseExtended.Name = "lblRelayAPulseExtended";
            this.lblRelayAPulseExtended.Size = new System.Drawing.Size(149, 13);
            this.lblRelayAPulseExtended.TabIndex = 8;
            this.lblRelayAPulseExtended.Tag = "Extended pulse duration: % ms";
            this.lblRelayAPulseExtended.Text = "Extended pulse duration: ? ms";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 27);
            this.label15.TabIndex = 5;
            this.label15.Tag = "title";
            this.label15.Text = "relay pulse durations";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox5);
            this.panel5.Controls.Add(this.uctbPPCLong);
            this.panel5.Controls.Add(this.lblPPCLong);
            this.panel5.Controls.Add(this.uctbPPCMedium);
            this.panel5.Controls.Add(this.lblPPCMedium);
            this.panel5.Controls.Add(this.uctbPPCShort);
            this.panel5.Controls.Add(this.lblPPCShort);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(588, 200);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 138);
            this.panel5.TabIndex = 10;
            this.panel5.Tag = "5";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.uctbPPCDetLeftThreshold);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.uctbPPCDetLeftTimer);
            this.groupBox5.Controls.Add(this.lblPPCDetLeaveTimer);
            this.groupBox5.Location = new System.Drawing.Point(6, 316);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 204);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detect-leave algorithm parameters";
            // 
            // uctbPPCDetLeftThreshold
            // 
            this.uctbPPCDetLeftThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbPPCDetLeftThreshold.LargeChange = 5;
            this.uctbPPCDetLeftThreshold.Location = new System.Drawing.Point(8, 126);
            this.uctbPPCDetLeftThreshold.Maximum = 255;
            this.uctbPPCDetLeftThreshold.Minimum = 1;
            this.uctbPPCDetLeftThreshold.Name = "uctbPPCDetLeftThreshold";
            this.uctbPPCDetLeftThreshold.Size = new System.Drawing.Size(149, 71);
            this.uctbPPCDetLeftThreshold.SmallChange = 1;
            this.uctbPPCDetLeftThreshold.TabIndex = 16;
            this.uctbPPCDetLeftThreshold.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbPPCDetLeftThreshold.TickFrequency = 5;
            this.uctbPPCDetLeftThreshold.Value = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(117, 13);
            this.label21.TabIndex = 15;
            this.label21.Tag = "Detect leave threshold:";
            this.label21.Text = "Detect leave threshold:";
            // 
            // uctbPPCDetLeftTimer
            // 
            this.uctbPPCDetLeftTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbPPCDetLeftTimer.LargeChange = 5;
            this.uctbPPCDetLeftTimer.Location = new System.Drawing.Point(8, 36);
            this.uctbPPCDetLeftTimer.Maximum = 255;
            this.uctbPPCDetLeftTimer.Minimum = 1;
            this.uctbPPCDetLeftTimer.Name = "uctbPPCDetLeftTimer";
            this.uctbPPCDetLeftTimer.Size = new System.Drawing.Size(149, 70);
            this.uctbPPCDetLeftTimer.SmallChange = 1;
            this.uctbPPCDetLeftTimer.TabIndex = 14;
            this.uctbPPCDetLeftTimer.Tag = "TMR1BEST_CHANGE;UPDATE_CONFIG_PACKET";
            this.uctbPPCDetLeftTimer.TickFrequency = 5;
            this.uctbPPCDetLeftTimer.Value = 1;
            this.uctbPPCDetLeftTimer.TrackbarChanged += new System.EventHandler(this.uctbPPCDetLeftTimer_TrackbarChanged);
            // 
            // lblPPCDetLeaveTimer
            // 
            this.lblPPCDetLeaveTimer.AutoSize = true;
            this.lblPPCDetLeaveTimer.Location = new System.Drawing.Point(8, 20);
            this.lblPPCDetLeaveTimer.Name = "lblPPCDetLeaveTimer";
            this.lblPPCDetLeaveTimer.Size = new System.Drawing.Size(121, 13);
            this.lblPPCDetLeaveTimer.TabIndex = 13;
            this.lblPPCDetLeaveTimer.Tag = "Detect leave timer: % ms";
            this.lblPPCDetLeaveTimer.Text = "Detect leave timer: ? ms";
            // 
            // uctbPPCLong
            // 
            this.uctbPPCLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbPPCLong.LargeChange = 5;
            this.uctbPPCLong.Location = new System.Drawing.Point(9, 240);
            this.uctbPPCLong.Maximum = 255;
            this.uctbPPCLong.Minimum = 1;
            this.uctbPPCLong.Name = "uctbPPCLong";
            this.uctbPPCLong.Size = new System.Drawing.Size(160, 71);
            this.uctbPPCLong.SmallChange = 1;
            this.uctbPPCLong.TabIndex = 16;
            this.uctbPPCLong.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbPPCLong.TickFrequency = 5;
            this.uctbPPCLong.Value = 1;
            this.uctbPPCLong.TrackbarChanged += new System.EventHandler(this.uctbPPCLong_TrackbarChanged);
            // 
            // lblPPCLong
            // 
            this.lblPPCLong.AutoSize = true;
            this.lblPPCLong.Location = new System.Drawing.Point(9, 220);
            this.lblPPCLong.Name = "lblPPCLong";
            this.lblPPCLong.Size = new System.Drawing.Size(240, 13);
            this.lblPPCLong.TabIndex = 15;
            this.lblPPCLong.Tag = "Permanent presence cancellation long: % (hh:mm)";
            this.lblPPCLong.Text = "Permanent presence cancellation long: ? (hh:mm)";
            // 
            // uctbPPCMedium
            // 
            this.uctbPPCMedium.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbPPCMedium.LargeChange = 5;
            this.uctbPPCMedium.Location = new System.Drawing.Point(9, 149);
            this.uctbPPCMedium.Maximum = 255;
            this.uctbPPCMedium.Minimum = 1;
            this.uctbPPCMedium.Name = "uctbPPCMedium";
            this.uctbPPCMedium.Size = new System.Drawing.Size(160, 71);
            this.uctbPPCMedium.SmallChange = 1;
            this.uctbPPCMedium.TabIndex = 14;
            this.uctbPPCMedium.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbPPCMedium.TickFrequency = 5;
            this.uctbPPCMedium.Value = 1;
            this.uctbPPCMedium.TrackbarChanged += new System.EventHandler(this.uctbPPCMedium_TrackbarChanged);
            // 
            // lblPPCMedium
            // 
            this.lblPPCMedium.AutoSize = true;
            this.lblPPCMedium.Location = new System.Drawing.Point(9, 129);
            this.lblPPCMedium.Name = "lblPPCMedium";
            this.lblPPCMedium.Size = new System.Drawing.Size(256, 13);
            this.lblPPCMedium.TabIndex = 13;
            this.lblPPCMedium.Tag = "Permanent presence cancellation medium: % (hh:mm)";
            this.lblPPCMedium.Text = "Permanent presence cancellation medium: ? (hh:mm)";
            // 
            // uctbPPCShort
            // 
            this.uctbPPCShort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbPPCShort.LargeChange = 5;
            this.uctbPPCShort.Location = new System.Drawing.Point(9, 58);
            this.uctbPPCShort.Maximum = 255;
            this.uctbPPCShort.Minimum = 1;
            this.uctbPPCShort.Name = "uctbPPCShort";
            this.uctbPPCShort.Size = new System.Drawing.Size(160, 71);
            this.uctbPPCShort.SmallChange = 1;
            this.uctbPPCShort.TabIndex = 8;
            this.uctbPPCShort.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbPPCShort.TickFrequency = 5;
            this.uctbPPCShort.Value = 1;
            this.uctbPPCShort.TrackbarChanged += new System.EventHandler(this.uctbPPC_TrackbarChanged);
            // 
            // lblPPCShort
            // 
            this.lblPPCShort.AutoSize = true;
            this.lblPPCShort.Location = new System.Drawing.Point(9, 38);
            this.lblPPCShort.Name = "lblPPCShort";
            this.lblPPCShort.Size = new System.Drawing.Size(243, 13);
            this.lblPPCShort.TabIndex = 7;
            this.lblPPCShort.Tag = "Permanent presence cancellation short: % (hh:mm)";
            this.lblPPCShort.Text = "Permanent presence cancellation short: ? (hh:mm)";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 27);
            this.label18.TabIndex = 6;
            this.label18.Tag = "title";
            this.label18.Text = "ppc";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblDetectStopSlowCheckTimer);
            this.panel6.Controls.Add(this.uctbDetStopSlowCheckerTimer);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.lblDetectStopTimer);
            this.panel6.Controls.Add(this.uctbDetStopThreshold);
            this.panel6.Controls.Add(this.uctbDetStopTimer);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Location = new System.Drawing.Point(233, 356);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(168, 148);
            this.panel6.TabIndex = 11;
            this.panel6.Tag = "6";
            // 
            // lblDetectStopSlowCheckTimer
            // 
            this.lblDetectStopSlowCheckTimer.AutoSize = true;
            this.lblDetectStopSlowCheckTimer.Location = new System.Drawing.Point(6, 216);
            this.lblDetectStopSlowCheckTimer.Name = "lblDetectStopSlowCheckTimer";
            this.lblDetectStopSlowCheckTimer.Size = new System.Drawing.Size(116, 13);
            this.lblDetectStopSlowCheckTimer.TabIndex = 13;
            this.lblDetectStopSlowCheckTimer.Tag = "Slow check timer: % ms";
            this.lblDetectStopSlowCheckTimer.Text = "Slow check timer: ? ms";
            // 
            // uctbDetStopSlowCheckerTimer
            // 
            this.uctbDetStopSlowCheckerTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbDetStopSlowCheckerTimer.LargeChange = 5;
            this.uctbDetStopSlowCheckerTimer.Location = new System.Drawing.Point(6, 232);
            this.uctbDetStopSlowCheckerTimer.Maximum = 255;
            this.uctbDetStopSlowCheckerTimer.Minimum = 1;
            this.uctbDetStopSlowCheckerTimer.Name = "uctbDetStopSlowCheckerTimer";
            this.uctbDetStopSlowCheckerTimer.Size = new System.Drawing.Size(155, 71);
            this.uctbDetStopSlowCheckerTimer.SmallChange = 1;
            this.uctbDetStopSlowCheckerTimer.TabIndex = 12;
            this.uctbDetStopSlowCheckerTimer.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbDetStopSlowCheckerTimer.TickFrequency = 5;
            this.uctbDetStopSlowCheckerTimer.Value = 1;
            this.uctbDetStopSlowCheckerTimer.TrackbarChanged += new System.EventHandler(this.uctbDetStopSlowCheckerTimer_TrackbarChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 121);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(111, 13);
            this.label22.TabIndex = 11;
            this.label22.Text = "Detect stop threshold:";
            // 
            // lblDetectStopTimer
            // 
            this.lblDetectStopTimer.AutoSize = true;
            this.lblDetectStopTimer.Location = new System.Drawing.Point(3, 34);
            this.lblDetectStopTimer.Name = "lblDetectStopTimer";
            this.lblDetectStopTimer.Size = new System.Drawing.Size(115, 13);
            this.lblDetectStopTimer.TabIndex = 10;
            this.lblDetectStopTimer.Tag = "Detect stop timer: % ms";
            this.lblDetectStopTimer.Text = "Detect stop timer: ? ms";
            // 
            // uctbDetStopThreshold
            // 
            this.uctbDetStopThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbDetStopThreshold.LargeChange = 5;
            this.uctbDetStopThreshold.Location = new System.Drawing.Point(6, 141);
            this.uctbDetStopThreshold.Maximum = 255;
            this.uctbDetStopThreshold.Minimum = 1;
            this.uctbDetStopThreshold.Name = "uctbDetStopThreshold";
            this.uctbDetStopThreshold.Size = new System.Drawing.Size(155, 71);
            this.uctbDetStopThreshold.SmallChange = 1;
            this.uctbDetStopThreshold.TabIndex = 9;
            this.uctbDetStopThreshold.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbDetStopThreshold.TickFrequency = 5;
            this.uctbDetStopThreshold.Value = 1;
            // 
            // uctbDetStopTimer
            // 
            this.uctbDetStopTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbDetStopTimer.LargeChange = 5;
            this.uctbDetStopTimer.Location = new System.Drawing.Point(6, 50);
            this.uctbDetStopTimer.Maximum = 255;
            this.uctbDetStopTimer.Minimum = 1;
            this.uctbDetStopTimer.Name = "uctbDetStopTimer";
            this.uctbDetStopTimer.Size = new System.Drawing.Size(155, 71);
            this.uctbDetStopTimer.SmallChange = 1;
            this.uctbDetStopTimer.TabIndex = 8;
            this.uctbDetStopTimer.Tag = "TMR1BEST_CHANGE;UPDATE_CONFIG_PACKET";
            this.uctbDetStopTimer.TickFrequency = 5;
            this.uctbDetStopTimer.Value = 1;
            this.uctbDetStopTimer.TrackbarChanged += new System.EventHandler(this.uctbDetStopTimer_TrackbarChanged);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(168, 27);
            this.label19.TabIndex = 7;
            this.label19.Tag = "title";
            this.label19.Text = "detect stop";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.uctbDCDDThreshold);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Controls.Add(this.uctbDCDDTimer);
            this.panel7.Controls.Add(this.lblDCDDTimer);
            this.panel7.Controls.Add(this.label23);
            this.panel7.Controls.Add(this.label20);
            this.panel7.Location = new System.Drawing.Point(407, 357);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(157, 147);
            this.panel7.TabIndex = 12;
            this.panel7.Tag = "7";
            // 
            // uctbDCDDThreshold
            // 
            this.uctbDCDDThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbDCDDThreshold.LargeChange = 5;
            this.uctbDCDDThreshold.Location = new System.Drawing.Point(6, 148);
            this.uctbDCDDThreshold.Maximum = 255;
            this.uctbDCDDThreshold.Minimum = 1;
            this.uctbDCDDThreshold.Name = "uctbDCDDThreshold";
            this.uctbDCDDThreshold.Size = new System.Drawing.Size(143, 71);
            this.uctbDCDDThreshold.SmallChange = 1;
            this.uctbDCDDThreshold.TabIndex = 13;
            this.uctbDCDDThreshold.Tag = "UPDATE_CONFIG_PACKET";
            this.uctbDCDDThreshold.TickFrequency = 5;
            this.uctbDCDDThreshold.Value = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 129);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(169, 13);
            this.label25.TabIndex = 12;
            this.label25.Text = "No movement detection threshold:";
            // 
            // uctbDCDDTimer
            // 
            this.uctbDCDDTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbDCDDTimer.LargeChange = 5;
            this.uctbDCDDTimer.Location = new System.Drawing.Point(6, 55);
            this.uctbDCDDTimer.Maximum = 65535;
            this.uctbDCDDTimer.Minimum = 1;
            this.uctbDCDDTimer.Name = "uctbDCDDTimer";
            this.uctbDCDDTimer.Size = new System.Drawing.Size(144, 71);
            this.uctbDCDDTimer.SmallChange = 1;
            this.uctbDCDDTimer.TabIndex = 11;
            this.uctbDCDDTimer.Tag = "TMR1BEST_CHANGE;UPDATE_CONFIG_PACKET";
            this.uctbDCDDTimer.TickFrequency = 512;
            this.uctbDCDDTimer.Value = 1;
            this.uctbDCDDTimer.TrackbarChanged += new System.EventHandler(this.uctbDCDDTimer_TrackbarChanged);
            // 
            // lblDCDDTimer
            // 
            this.lblDCDDTimer.AutoSize = true;
            this.lblDCDDTimer.Location = new System.Drawing.Point(6, 38);
            this.lblDCDDTimer.Name = "lblDCDDTimer";
            this.lblDCDDTimer.Size = new System.Drawing.Size(157, 13);
            this.lblDCDDTimer.TabIndex = 10;
            this.lblDCDDTimer.Tag = "No movement detection timer: %";
            this.lblDCDDTimer.Text = "No movement detection timer: ?";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 38);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 13);
            this.label23.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(157, 27);
            this.label20.TabIndex = 8;
            this.label20.Tag = "title";
            this.label20.Text = "DCDD";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSpeedTrap
            // 
            this.pnlSpeedTrap.Controls.Add(this.label31);
            this.pnlSpeedTrap.Controls.Add(this.tblMaximumSpeedErrors);
            this.pnlSpeedTrap.Controls.Add(this.uctbSpeedDistance);
            this.pnlSpeedTrap.Controls.Add(this.lblSpeedLoopDistance);
            this.pnlSpeedTrap.Controls.Add(this.label24);
            this.pnlSpeedTrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpeedTrap.Location = new System.Drawing.Point(224, 49);
            this.pnlSpeedTrap.Name = "pnlSpeedTrap";
            this.pnlSpeedTrap.Size = new System.Drawing.Size(728, 639);
            this.pnlSpeedTrap.TabIndex = 13;
            this.pnlSpeedTrap.Tag = "8";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 130);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(205, 13);
            this.label31.TabIndex = 14;
            this.label31.Text = "Maximum possible error at various speeds:";
            // 
            // tblMaximumSpeedErrors
            // 
            this.tblMaximumSpeedErrors.AllowUserToAddRows = false;
            this.tblMaximumSpeedErrors.AllowUserToDeleteRows = false;
            this.tblMaximumSpeedErrors.AllowUserToResizeColumns = false;
            this.tblMaximumSpeedErrors.AllowUserToResizeRows = false;
            this.tblMaximumSpeedErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMaximumSpeedErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblMaximumSpeedErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblMaximumSpeedErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Speed,
            this.WorstPossibleMeasurement,
            this.MaximumErrorKMH,
            this.MaximumErrorPercent});
            this.tblMaximumSpeedErrors.Location = new System.Drawing.Point(9, 151);
            this.tblMaximumSpeedErrors.MultiSelect = false;
            this.tblMaximumSpeedErrors.Name = "tblMaximumSpeedErrors";
            this.tblMaximumSpeedErrors.ReadOnly = true;
            this.tblMaximumSpeedErrors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tblMaximumSpeedErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblMaximumSpeedErrors.ShowCellErrors = false;
            this.tblMaximumSpeedErrors.ShowEditingIcon = false;
            this.tblMaximumSpeedErrors.ShowRowErrors = false;
            this.tblMaximumSpeedErrors.Size = new System.Drawing.Size(712, 478);
            this.tblMaximumSpeedErrors.TabIndex = 13;
            // 
            // Speed
            // 
            this.Speed.HeaderText = "Speed [km/h]";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            // 
            // WorstPossibleMeasurement
            // 
            this.WorstPossibleMeasurement.HeaderText = "Worst possible measurement [km/h]";
            this.WorstPossibleMeasurement.Name = "WorstPossibleMeasurement";
            this.WorstPossibleMeasurement.ReadOnly = true;
            // 
            // MaximumErrorKMH
            // 
            this.MaximumErrorKMH.HeaderText = "Maximum Error [km/h]";
            this.MaximumErrorKMH.Name = "MaximumErrorKMH";
            this.MaximumErrorKMH.ReadOnly = true;
            // 
            // MaximumErrorPercent
            // 
            this.MaximumErrorPercent.HeaderText = "Maximum error [%]";
            this.MaximumErrorPercent.Name = "MaximumErrorPercent";
            this.MaximumErrorPercent.ReadOnly = true;
            // 
            // uctbSpeedDistance
            // 
            this.uctbSpeedDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctbSpeedDistance.LargeChange = 5;
            this.uctbSpeedDistance.Location = new System.Drawing.Point(6, 58);
            this.uctbSpeedDistance.Maximum = 1000;
            this.uctbSpeedDistance.Minimum = 1;
            this.uctbSpeedDistance.Name = "uctbSpeedDistance";
            this.uctbSpeedDistance.Size = new System.Drawing.Size(715, 71);
            this.uctbSpeedDistance.SmallChange = 1;
            this.uctbSpeedDistance.TabIndex = 11;
            this.uctbSpeedDistance.Tag = "UPDATE_CONFIG_PACKET;TMR1BEST_CHANGE";
            this.uctbSpeedDistance.TickFrequency = 5;
            this.uctbSpeedDistance.Value = 1;
            this.uctbSpeedDistance.TrackbarChanged += new System.EventHandler(this.uctbSpeedDistance_TrackbarChanged);
            // 
            // lblSpeedLoopDistance
            // 
            this.lblSpeedLoopDistance.AutoSize = true;
            this.lblSpeedLoopDistance.Location = new System.Drawing.Point(7, 40);
            this.lblSpeedLoopDistance.Name = "lblSpeedLoopDistance";
            this.lblSpeedLoopDistance.Size = new System.Drawing.Size(133, 13);
            this.lblSpeedLoopDistance.TabIndex = 10;
            this.lblSpeedLoopDistance.Tag = "Distance between loops: %";
            this.lblSpeedLoopDistance.Text = "Distance between loops: ?";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label24.Dock = System.Windows.Forms.DockStyle.Top;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(728, 27);
            this.label24.TabIndex = 9;
            this.label24.Tag = "title";
            this.label24.Text = "speed trap";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrUpdateConfigPacket
            // 
            this.tmrUpdateConfigPacket.Interval = 350;
            this.tmrUpdateConfigPacket.Tick += new System.EventHandler(this.tmrUpdateConfigPacket_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.FileName = "profile.xml";
            this.openFileDialog.Filter = "DLD Profiles|*.xml";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xml";
            this.saveFileDialog.FileName = "profile.xml";
            this.saveFileDialog.Filter = "DLD Profiles|*.xml";
            // 
            // pnlEventViewer
            // 
            this.pnlEventViewer.Controls.Add(this.btnSaveLog);
            this.pnlEventViewer.Controls.Add(this.btnClearLog);
            this.pnlEventViewer.Controls.Add(this.label29);
            this.pnlEventViewer.Controls.Add(this.txtLog);
            this.pnlEventViewer.Controls.Add(this.lblLastJointEvent);
            this.pnlEventViewer.Controls.Add(this.lblLastEventLoopB);
            this.pnlEventViewer.Controls.Add(this.lblLastEventLoopA);
            this.pnlEventViewer.Controls.Add(this.lblLoggingState);
            this.pnlEventViewer.Controls.Add(this.button1);
            this.pnlEventViewer.Controls.Add(this.label28);
            this.pnlEventViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventViewer.Location = new System.Drawing.Point(224, 49);
            this.pnlEventViewer.Name = "pnlEventViewer";
            this.pnlEventViewer.Size = new System.Drawing.Size(728, 639);
            this.pnlEventViewer.TabIndex = 14;
            this.pnlEventViewer.Tag = "9";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveLog.Location = new System.Drawing.Point(539, 603);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(85, 23);
            this.btnSaveLog.TabIndex = 17;
            this.btnSaveLog.Text = "Save log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(630, 603);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(85, 23);
            this.btnClearLog.TabIndex = 16;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 138);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 13);
            this.label29.TabIndex = 15;
            this.label29.Text = "Event logger:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(9, 154);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(707, 442);
            this.txtLog.TabIndex = 14;
            this.txtLog.WordWrap = false;
            // 
            // lblLastJointEvent
            // 
            this.lblLastJointEvent.AutoSize = true;
            this.lblLastJointEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastJointEvent.Location = new System.Drawing.Point(9, 112);
            this.lblLastJointEvent.Name = "lblLastJointEvent";
            this.lblLastJointEvent.Size = new System.Drawing.Size(157, 16);
            this.lblLastJointEvent.TabIndex = 13;
            this.lblLastJointEvent.Tag = "Last joint event: %";
            this.lblLastJointEvent.Text = "Last joint event: None";
            // 
            // lblLastEventLoopB
            // 
            this.lblLastEventLoopB.AutoSize = true;
            this.lblLastEventLoopB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastEventLoopB.Location = new System.Drawing.Point(9, 88);
            this.lblLastEventLoopB.Name = "lblLastEventLoopB";
            this.lblLastEventLoopB.Size = new System.Drawing.Size(173, 16);
            this.lblLastEventLoopB.TabIndex = 12;
            this.lblLastEventLoopB.Tag = "Last event loop B: %";
            this.lblLastEventLoopB.Text = "Last event loop B: None";
            // 
            // lblLastEventLoopA
            // 
            this.lblLastEventLoopA.AutoSize = true;
            this.lblLastEventLoopA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastEventLoopA.Location = new System.Drawing.Point(9, 64);
            this.lblLastEventLoopA.Name = "lblLastEventLoopA";
            this.lblLastEventLoopA.Size = new System.Drawing.Size(173, 16);
            this.lblLastEventLoopA.TabIndex = 11;
            this.lblLastEventLoopA.Tag = "Last event loop A: %";
            this.lblLastEventLoopA.Text = "Last event loop A: None";
            // 
            // lblLoggingState
            // 
            this.lblLoggingState.AutoSize = true;
            this.lblLoggingState.Location = new System.Drawing.Point(143, 37);
            this.lblLoggingState.Name = "lblLoggingState";
            this.lblLoggingState.Size = new System.Drawing.Size(118, 13);
            this.lblLoggingState.TabIndex = 10;
            this.lblLoggingState.Tag = "Logging is currently: %";
            this.lblLoggingState.Text = "Logging is currently: Off";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Event logging on/off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(728, 27);
            this.label28.TabIndex = 8;
            this.label28.Tag = "title";
            this.label28.Text = "event viewer";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSignalAnalysis
            // 
            this.pnlSignalAnalysis.Controls.Add(this.ckAutoSaveAnalysisLoopB);
            this.pnlSignalAnalysis.Controls.Add(this.ckAutoSaveAnalysisLoopA);
            this.pnlSignalAnalysis.Controls.Add(this.btnSaveAnalysisLoopB);
            this.pnlSignalAnalysis.Controls.Add(this.btnSaveAnalysisLoopA);
            this.pnlSignalAnalysis.Controls.Add(this.chAnalysisLoopB);
            this.pnlSignalAnalysis.Controls.Add(this.chAnalysisLoopA);
            this.pnlSignalAnalysis.Controls.Add(this.lblSignalAnalysis);
            this.pnlSignalAnalysis.Controls.Add(this.btnSignalAnalysis);
            this.pnlSignalAnalysis.Controls.Add(this.label30);
            this.pnlSignalAnalysis.Location = new System.Drawing.Point(224, 49);
            this.pnlSignalAnalysis.Name = "pnlSignalAnalysis";
            this.pnlSignalAnalysis.Size = new System.Drawing.Size(432, 629);
            this.pnlSignalAnalysis.TabIndex = 15;
            this.pnlSignalAnalysis.Tag = "10";
            // 
            // ckAutoSaveAnalysisLoopB
            // 
            this.ckAutoSaveAnalysisLoopB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAutoSaveAnalysisLoopB.AutoSize = true;
            this.ckAutoSaveAnalysisLoopB.Location = new System.Drawing.Point(264, 603);
            this.ckAutoSaveAnalysisLoopB.Name = "ckAutoSaveAnalysisLoopB";
            this.ckAutoSaveAnalysisLoopB.Size = new System.Drawing.Size(74, 17);
            this.ckAutoSaveAnalysisLoopB.TabIndex = 18;
            this.ckAutoSaveAnalysisLoopB.Text = "Auto save";
            this.ckAutoSaveAnalysisLoopB.UseVisualStyleBackColor = true;
            // 
            // ckAutoSaveAnalysisLoopA
            // 
            this.ckAutoSaveAnalysisLoopA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAutoSaveAnalysisLoopA.AutoSize = true;
            this.ckAutoSaveAnalysisLoopA.Location = new System.Drawing.Point(264, 318);
            this.ckAutoSaveAnalysisLoopA.Name = "ckAutoSaveAnalysisLoopA";
            this.ckAutoSaveAnalysisLoopA.Size = new System.Drawing.Size(74, 17);
            this.ckAutoSaveAnalysisLoopA.TabIndex = 17;
            this.ckAutoSaveAnalysisLoopA.Text = "Auto save";
            this.ckAutoSaveAnalysisLoopA.UseVisualStyleBackColor = true;
            // 
            // btnSaveAnalysisLoopB
            // 
            this.btnSaveAnalysisLoopB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAnalysisLoopB.Location = new System.Drawing.Point(344, 599);
            this.btnSaveAnalysisLoopB.Name = "btnSaveAnalysisLoopB";
            this.btnSaveAnalysisLoopB.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAnalysisLoopB.TabIndex = 16;
            this.btnSaveAnalysisLoopB.Text = "Save";
            this.btnSaveAnalysisLoopB.UseVisualStyleBackColor = true;
            this.btnSaveAnalysisLoopB.Click += new System.EventHandler(this.btnSaveAnalysisLoopB_Click);
            // 
            // btnSaveAnalysisLoopA
            // 
            this.btnSaveAnalysisLoopA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAnalysisLoopA.Location = new System.Drawing.Point(344, 315);
            this.btnSaveAnalysisLoopA.Name = "btnSaveAnalysisLoopA";
            this.btnSaveAnalysisLoopA.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAnalysisLoopA.TabIndex = 15;
            this.btnSaveAnalysisLoopA.Text = "Save";
            this.btnSaveAnalysisLoopA.UseVisualStyleBackColor = true;
            this.btnSaveAnalysisLoopA.Click += new System.EventHandler(this.btnSaveAnalysisLoopA_Click);
            // 
            // chAnalysisLoopB
            // 
            this.chAnalysisLoopB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea11.Name = "ChartArea1";
            this.chAnalysisLoopB.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chAnalysisLoopB.Legends.Add(legend11);
            this.chAnalysisLoopB.Location = new System.Drawing.Point(6, 352);
            this.chAnalysisLoopB.Name = "chAnalysisLoopB";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chAnalysisLoopB.Series.Add(series7);
            this.chAnalysisLoopB.Size = new System.Drawing.Size(414, 241);
            this.chAnalysisLoopB.TabIndex = 14;
            this.chAnalysisLoopB.Text = "LOOP B";
            this.chAnalysisLoopB.Click += new System.EventHandler(this.chAnalysisLoopB_Click);
            // 
            // chAnalysisLoopA
            // 
            this.chAnalysisLoopA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea12.Name = "ChartArea1";
            this.chAnalysisLoopA.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chAnalysisLoopA.Legends.Add(legend12);
            this.chAnalysisLoopA.Location = new System.Drawing.Point(6, 67);
            this.chAnalysisLoopA.Name = "chAnalysisLoopA";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chAnalysisLoopA.Series.Add(series8);
            this.chAnalysisLoopA.Size = new System.Drawing.Size(414, 241);
            this.chAnalysisLoopA.TabIndex = 13;
            this.chAnalysisLoopA.Text = "LOOP A";
            this.chAnalysisLoopA.DoubleClick += new System.EventHandler(this.chAnalysisLoopA_DoubleClick);
            // 
            // lblSignalAnalysis
            // 
            this.lblSignalAnalysis.AutoSize = true;
            this.lblSignalAnalysis.Location = new System.Drawing.Point(143, 37);
            this.lblSignalAnalysis.Name = "lblSignalAnalysis";
            this.lblSignalAnalysis.Size = new System.Drawing.Size(149, 13);
            this.lblSignalAnalysis.TabIndex = 12;
            this.lblSignalAnalysis.Tag = "Signal analysis is currently: %";
            this.lblSignalAnalysis.Text = "Signal analysis is currently: Off";
            // 
            // btnSignalAnalysis
            // 
            this.btnSignalAnalysis.Location = new System.Drawing.Point(6, 32);
            this.btnSignalAnalysis.Name = "btnSignalAnalysis";
            this.btnSignalAnalysis.Size = new System.Drawing.Size(129, 23);
            this.btnSignalAnalysis.TabIndex = 11;
            this.btnSignalAnalysis.Text = "Signal analysis on/off";
            this.btnSignalAnalysis.UseVisualStyleBackColor = true;
            this.btnSignalAnalysis.Click += new System.EventHandler(this.btnSignalAnalysis_Click);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label30.Dock = System.Windows.Forms.DockStyle.Top;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(0, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(432, 27);
            this.label30.TabIndex = 10;
            this.label30.Tag = "title";
            this.label30.Text = "signal analysis";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveAnalysisDialog
            // 
            this.saveAnalysisDialog.DefaultExt = "txt";
            this.saveAnalysisDialog.Filter = "Text File|*.txt";
            // 
            // saveChartImageDialog
            // 
            this.saveChartImageDialog.DefaultExt = "jpg";
            this.saveChartImageDialog.Filter = "Images|*.jpg";
            // 
            // saveLogDialog
            // 
            this.saveLogDialog.DefaultExt = "txt";
            this.saveLogDialog.Filter = "Log file|*.txt";
            // 
            // tmrSpeedTrapErrorGenerator
            // 
            this.tmrSpeedTrapErrorGenerator.Interval = 350;
            this.tmrSpeedTrapErrorGenerator.Tick += new System.EventHandler(this.tmrSpeedTrapErrorGenerator_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 710);
            this.Controls.Add(this.pnlOperatingMode);
            this.Controls.Add(this.pnlEventViewer);
            this.Controls.Add(this.pnlSpeedTrap);
            this.Controls.Add(this.pnlSamplingSpeed);
            this.Controls.Add(this.pnlSensitivity);
            this.Controls.Add(this.pnlSignalAnalysis);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dual Channel Inductive Loop Vehicle Detector - www.elektronika.ba";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlOperatingMode.ResumeLayout(false);
            this.pnlOperatingMode.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.gbDIP2.ResumeLayout(false);
            this.gbDIP2.PerformLayout();
            this.gbDIP1.ResumeLayout(false);
            this.gbDIP1.PerformLayout();
            this.pnlSamplingSpeed.ResumeLayout(false);
            this.pnlSamplingSpeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFreqVsSens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSensitivityExamples)).EndInit();
            this.pnlSensitivity.ResumeLayout(false);
            this.pnlSensitivity.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.pnlSpeedTrap.ResumeLayout(false);
            this.pnlSpeedTrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblMaximumSpeedErrors)).EndInit();
            this.pnlEventViewer.ResumeLayout(false);
            this.pnlEventViewer.PerformLayout();
            this.pnlSignalAnalysis.ResumeLayout(false);
            this.pnlSignalAnalysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysisLoopB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysisLoopA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnReadFromDevice;
        private System.IO.Ports.SerialPort sp;
        private System.Windows.Forms.ToolStripStatusLabel tssDateTime;
        private System.Windows.Forms.ToolStripStatusLabel tssConnectionStatus;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.ToolStripProgressBar tssProgress;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel pnlOperatingMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbOperatingMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDIP1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox ckMode1;
        private System.Windows.Forms.CheckBox ckMode0;
        private System.Windows.Forms.GroupBox gbDIP2;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbConnectDisconnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel pnlSamplingSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ucTrackBar uctbSamplingSpeed;
        private System.Windows.Forms.Label lblTmr1SamplingSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView tblSensitivityExamples;
        private System.Windows.Forms.Timer tmrSensitivitiesExampleGenerator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sensitivity;
        private System.Windows.Forms.Panel pnlSensitivity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSensitivityA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private ucTrackBar uctbSensitivityDetectThresholdA;
        private System.Windows.Forms.Label label9;
        private ucTrackBar uctbSensitivityUndetectThresholdA;
        private System.Windows.Forms.GroupBox groupBox2;
        private ucTrackBar uctbSensitivityUndetectThresholdB;
        private System.Windows.Forms.Label label10;
        private ucTrackBar uctbSensitivityDetectThresholdB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbSensitivityB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbFilteringLevel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFilteringNegative;
        private ucTrackBar uctbFilteringNegative;
        private System.Windows.Forms.Label label17;
        private ucTrackBar uctbFilteringAveraging;
        private System.Windows.Forms.Label lblFilteringPositive;
        private ucTrackBar uctbFilteringPositive;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private ucTrackBar uctbRelayAPulseExtended;
        private System.Windows.Forms.Label lblRelayAPulseExtended;
        private ucTrackBar uctbRelayAPulseNormal;
        private System.Windows.Forms.Label lblRelayAPulseNormal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblPPCShort;
        private ucTrackBar uctbPPCShort;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFreqVsSens;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblDetectStopTimer;
        private ucTrackBar uctbDetStopThreshold;
        private ucTrackBar uctbDetStopTimer;
        private System.Windows.Forms.Label lblDetectStopSlowCheckTimer;
        private ucTrackBar uctbDetStopSlowCheckerTimer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private ucTrackBar uctbDCDDThreshold;
        private System.Windows.Forms.Label label25;
        private ucTrackBar uctbDCDDTimer;
        private System.Windows.Forms.Label lblDCDDTimer;
        private System.Windows.Forms.Panel pnlSpeedTrap;
        private System.Windows.Forms.Label label24;
        private ucTrackBar uctbSpeedDistance;
        private System.Windows.Forms.Label lblSpeedLoopDistance;
        private System.Windows.Forms.ToolStripStatusLabel tssFrequencyLoopA;
        private System.Windows.Forms.ToolStripStatusLabel tssFrequencyLoopB;
        private System.Windows.Forms.ToolStripStatusLabel tssCurrentOPMODE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem factoryResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem restartCPUToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Timer tmrUpdateConfigPacket;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblRelayBPulseNormal;
        private ucTrackBar uctbRelayBPulseExtended;
        private ucTrackBar uctbRelayBPulseNormal;
        private System.Windows.Forms.Label lblRelayBPulseExtended;
        private System.Windows.Forms.CheckBox ckUseSoftDIPs;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem newProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssDeviceState;
        private System.Windows.Forms.GroupBox groupBox5;
        private ucTrackBar uctbPPCDetLeftThreshold;
        private System.Windows.Forms.Label label21;
        private ucTrackBar uctbPPCDetLeftTimer;
        private System.Windows.Forms.Label lblPPCDetLeaveTimer;
        private ucTrackBar uctbPPCLong;
        private System.Windows.Forms.Label lblPPCLong;
        private ucTrackBar uctbPPCMedium;
        private System.Windows.Forms.Label lblPPCMedium;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripMenuItem returnToRunningModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Button btnReadDIPsFromDevice;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel pnlEventViewer;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblLoggingState;
        private System.Windows.Forms.Label lblLastEventLoopA;
        private System.Windows.Forms.Label lblLastEventLoopB;
        private System.Windows.Forms.Label lblLastJointEvent;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Panel pnlSignalAnalysis;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnSignalAnalysis;
        private System.Windows.Forms.Label lblSignalAnalysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAnalysisLoopB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAnalysisLoopA;
        private System.Windows.Forms.Button btnSaveAnalysisLoopB;
        private System.Windows.Forms.Button btnSaveAnalysisLoopA;
        private System.Windows.Forms.CheckBox ckAutoSaveAnalysisLoopB;
        private System.Windows.Forms.CheckBox ckAutoSaveAnalysisLoopA;
        private System.Windows.Forms.SaveFileDialog saveAnalysisDialog;
        private System.Windows.Forms.SaveFileDialog saveChartImageDialog;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.SaveFileDialog saveLogDialog;
        private System.Windows.Forms.DataGridView tblMaximumSpeedErrors;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Timer tmrSpeedTrapErrorGenerator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorstPossibleMeasurement;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaximumErrorKMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaximumErrorPercent;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

