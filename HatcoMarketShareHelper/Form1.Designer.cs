namespace HatcoMarketShareHelper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.finalizerProgressDetailed = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.runFinalizer = new System.Windows.Forms.Button();
            this.finalizerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.determinerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.runDeterminer = new System.Windows.Forms.Button();
            this.determinerProgressDetailed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.processorProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.processorProgressDetailed = new System.Windows.Forms.Label();
            this.runProcessor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.finalizerSettingsHelp = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.NonCust_ClosingPercent = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.NonCust_ClosingsThreshold = new System.Windows.Forms.NumericUpDown();
            this.openMLSFile_Finalizer = new System.Windows.Forms.Button();
            this.MLSInputFile_Finalizer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.determinerSettingsHelp = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.addressWeakThreshold = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.addressThreshold = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.MLSInputFile_Determiner = new System.Windows.Forms.TextBox();
            this.openMLSFile_Determiner = new System.Windows.Forms.Button();
            this.openAIMFile = new System.Windows.Forms.Button();
            this.AIMInputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.processorSettingsHelp = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.MLSInputFile_Processor = new System.Windows.Forms.TextBox();
            this.includeNonMLSAgent = new System.Windows.Forms.CheckBox();
            this.openMLSFile_Processor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.miscSettingsHelp = new System.Windows.Forms.Button();
            this.doSubtotals = new System.Windows.Forms.CheckBox();
            this.runAsCapstone = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sameMLSFiles = new System.Windows.Forms.CheckBox();
            this.configTab = new System.Windows.Forms.TabPage();
            this.configSettingsHelp = new System.Windows.Forms.Button();
            this.saveConfigData = new System.Windows.Forms.Button();
            this.refreshConfigData = new System.Windows.Forms.Button();
            this.configData = new System.Windows.Forms.TextBox();
            this.openConfigFile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.configFile = new System.Windows.Forms.TextBox();
            this.debugScreen = new System.Windows.Forms.TextBox();
            this.openFileDialogMLS = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAIM = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NonCust_ClosingsThreshold)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressWeakThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressThreshold)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.configTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.homeTab);
            this.tabControl1.Controls.Add(this.optionsTab);
            this.tabControl1.Controls.Add(this.configTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 658);
            this.tabControl1.TabIndex = 0;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.panel6);
            this.homeTab.Controls.Add(this.panel4);
            this.homeTab.Controls.Add(this.panel5);
            this.homeTab.Location = new System.Drawing.Point(4, 22);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(493, 632);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Launcher";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.finalizerProgressDetailed);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.runFinalizer);
            this.panel6.Controls.Add(this.finalizerProgressBar);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(3, 421);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(487, 205);
            this.panel6.TabIndex = 8;
            // 
            // finalizerProgressDetailed
            // 
            this.finalizerProgressDetailed.AutoSize = true;
            this.finalizerProgressDetailed.Location = new System.Drawing.Point(82, 91);
            this.finalizerProgressDetailed.Name = "finalizerProgressDetailed";
            this.finalizerProgressDetailed.Size = new System.Drawing.Size(13, 13);
            this.finalizerProgressDetailed.TabIndex = 8;
            this.finalizerProgressDetailed.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Time Elapsed:";
            // 
            // runFinalizer
            // 
            this.runFinalizer.Location = new System.Drawing.Point(3, 65);
            this.runFinalizer.Name = "runFinalizer";
            this.runFinalizer.Size = new System.Drawing.Size(103, 23);
            this.runFinalizer.TabIndex = 10;
            this.runFinalizer.Text = "Run Finalizer";
            this.runFinalizer.UseVisualStyleBackColor = true;
            this.runFinalizer.Click += new System.EventHandler(this.runFinalizer_Click);
            // 
            // finalizerProgressBar
            // 
            this.finalizerProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finalizerProgressBar.Location = new System.Drawing.Point(2, 177);
            this.finalizerProgressBar.Name = "finalizerProgressBar";
            this.finalizerProgressBar.Size = new System.Drawing.Size(480, 23);
            this.finalizerProgressBar.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Report Finalizer";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.determinerProgressBar);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.runDeterminer);
            this.panel4.Controls.Add(this.determinerProgressDetailed);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(487, 197);
            this.panel4.TabIndex = 6;
            // 
            // determinerProgressBar
            // 
            this.determinerProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.determinerProgressBar.Location = new System.Drawing.Point(3, 169);
            this.determinerProgressBar.Name = "determinerProgressBar";
            this.determinerProgressBar.Size = new System.Drawing.Size(479, 23);
            this.determinerProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Closing Analyzer";
            // 
            // runDeterminer
            // 
            this.runDeterminer.Location = new System.Drawing.Point(3, 69);
            this.runDeterminer.Name = "runDeterminer";
            this.runDeterminer.Size = new System.Drawing.Size(103, 23);
            this.runDeterminer.TabIndex = 0;
            this.runDeterminer.Text = "Run Analyzer";
            this.runDeterminer.UseVisualStyleBackColor = true;
            this.runDeterminer.Click += new System.EventHandler(this.runDeterminer_Click);
            // 
            // determinerProgressDetailed
            // 
            this.determinerProgressDetailed.AutoSize = true;
            this.determinerProgressDetailed.Location = new System.Drawing.Point(82, 95);
            this.determinerProgressDetailed.Name = "determinerProgressDetailed";
            this.determinerProgressDetailed.Size = new System.Drawing.Size(13, 13);
            this.determinerProgressDetailed.TabIndex = 2;
            this.determinerProgressDetailed.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Time Elapsed:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.processorProgressBar);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.processorProgressDetailed);
            this.panel5.Controls.Add(this.runProcessor);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(3, 202);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(487, 217);
            this.panel5.TabIndex = 7;
            // 
            // processorProgressBar
            // 
            this.processorProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processorProgressBar.Location = new System.Drawing.Point(3, 189);
            this.processorProgressBar.Name = "processorProgressBar";
            this.processorProgressBar.Size = new System.Drawing.Size(479, 23);
            this.processorProgressBar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Market Share Analyzer";
            // 
            // processorProgressDetailed
            // 
            this.processorProgressDetailed.AutoSize = true;
            this.processorProgressDetailed.Location = new System.Drawing.Point(82, 94);
            this.processorProgressDetailed.Name = "processorProgressDetailed";
            this.processorProgressDetailed.Size = new System.Drawing.Size(13, 13);
            this.processorProgressDetailed.TabIndex = 4;
            this.processorProgressDetailed.Text = "0";
            // 
            // runProcessor
            // 
            this.runProcessor.Location = new System.Drawing.Point(3, 68);
            this.runProcessor.Name = "runProcessor";
            this.runProcessor.Size = new System.Drawing.Size(103, 23);
            this.runProcessor.TabIndex = 5;
            this.runProcessor.Text = "Run Analyzer";
            this.runProcessor.UseVisualStyleBackColor = true;
            this.runProcessor.Click += new System.EventHandler(this.runProcessor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Time Elapsed:";
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.panel7);
            this.optionsTab.Controls.Add(this.panel1);
            this.optionsTab.Controls.Add(this.panel2);
            this.optionsTab.Controls.Add(this.panel3);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(493, 632);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.finalizerSettingsHelp);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.NonCust_ClosingPercent);
            this.panel7.Controls.Add(this.label18);
            this.panel7.Controls.Add(this.NonCust_ClosingsThreshold);
            this.panel7.Controls.Add(this.openMLSFile_Finalizer);
            this.panel7.Controls.Add(this.MLSInputFile_Finalizer);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Location = new System.Drawing.Point(3, 346);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(487, 169);
            this.panel7.TabIndex = 14;
            // 
            // finalizerSettingsHelp
            // 
            this.finalizerSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finalizerSettingsHelp.Location = new System.Drawing.Point(467, 144);
            this.finalizerSettingsHelp.Margin = new System.Windows.Forms.Padding(2);
            this.finalizerSettingsHelp.Name = "finalizerSettingsHelp";
            this.finalizerSettingsHelp.Size = new System.Drawing.Size(16, 19);
            this.finalizerSettingsHelp.TabIndex = 18;
            this.finalizerSettingsHelp.Text = "?";
            this.finalizerSettingsHelp.UseVisualStyleBackColor = true;
            this.finalizerSettingsHelp.Click += new System.EventHandler(this.finalizerSettingsHelp_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(154, 128);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(143, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "NonCust Closing Percentage";
            // 
            // NonCust_ClosingPercent
            // 
            this.NonCust_ClosingPercent.Location = new System.Drawing.Point(157, 144);
            this.NonCust_ClosingPercent.Name = "NonCust_ClosingPercent";
            this.NonCust_ClosingPercent.Size = new System.Drawing.Size(140, 20);
            this.NonCust_ClosingPercent.TabIndex = 24;
            this.NonCust_ClosingPercent.Text = "0.25";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1, 128);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(140, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "NonCust Closings Threshold";
            // 
            // NonCust_ClosingsThreshold
            // 
            this.NonCust_ClosingsThreshold.Location = new System.Drawing.Point(1, 144);
            this.NonCust_ClosingsThreshold.Name = "NonCust_ClosingsThreshold";
            this.NonCust_ClosingsThreshold.Size = new System.Drawing.Size(140, 20);
            this.NonCust_ClosingsThreshold.TabIndex = 23;
            this.NonCust_ClosingsThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // openMLSFile_Finalizer
            // 
            this.openMLSFile_Finalizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openMLSFile_Finalizer.Location = new System.Drawing.Point(399, 62);
            this.openMLSFile_Finalizer.Name = "openMLSFile_Finalizer";
            this.openMLSFile_Finalizer.Size = new System.Drawing.Size(75, 23);
            this.openMLSFile_Finalizer.TabIndex = 22;
            this.openMLSFile_Finalizer.Text = "Open";
            this.openMLSFile_Finalizer.UseVisualStyleBackColor = true;
            this.openMLSFile_Finalizer.Click += new System.EventHandler(this.openMLSFile_Finalizer_Click);
            // 
            // MLSInputFile_Finalizer
            // 
            this.MLSInputFile_Finalizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MLSInputFile_Finalizer.Location = new System.Drawing.Point(3, 64);
            this.MLSInputFile_Finalizer.Name = "MLSInputFile_Finalizer";
            this.MLSInputFile_Finalizer.Size = new System.Drawing.Size(391, 20);
            this.MLSInputFile_Finalizer.TabIndex = 21;
            this.MLSInputFile_Finalizer.Text = "C:\\MLSData.xlsx";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "MLS Input File";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(184, 20);
            this.label16.TabIndex = 19;
            this.label16.Text = "Report Finalizer Settings";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.determinerSettingsHelp);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.addressWeakThreshold);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.addressThreshold);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.MLSInputFile_Determiner);
            this.panel1.Controls.Add(this.openMLSFile_Determiner);
            this.panel1.Controls.Add(this.openAIMFile);
            this.panel1.Controls.Add(this.AIMInputFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 197);
            this.panel1.TabIndex = 11;
            // 
            // determinerSettingsHelp
            // 
            this.determinerSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.determinerSettingsHelp.Location = new System.Drawing.Point(468, 174);
            this.determinerSettingsHelp.Margin = new System.Windows.Forms.Padding(2);
            this.determinerSettingsHelp.Name = "determinerSettingsHelp";
            this.determinerSettingsHelp.Size = new System.Drawing.Size(16, 19);
            this.determinerSettingsHelp.TabIndex = 17;
            this.determinerSettingsHelp.Text = "?";
            this.determinerSettingsHelp.UseVisualStyleBackColor = true;
            this.determinerSettingsHelp.Click += new System.EventHandler(this.determinerSettingsHelp_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(106, 158);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(143, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Address secondary threshold";
            // 
            // addressWeakThreshold
            // 
            this.addressWeakThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addressWeakThreshold.DecimalPlaces = 2;
            this.addressWeakThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.addressWeakThreshold.Location = new System.Drawing.Point(109, 173);
            this.addressWeakThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.addressWeakThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.addressWeakThreshold.Name = "addressWeakThreshold";
            this.addressWeakThreshold.Size = new System.Drawing.Size(148, 20);
            this.addressWeakThreshold.TabIndex = 15;
            this.addressWeakThreshold.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 158);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Address threshold";
            // 
            // addressThreshold
            // 
            this.addressThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addressThreshold.DecimalPlaces = 2;
            this.addressThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.addressThreshold.Location = new System.Drawing.Point(1, 173);
            this.addressThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.addressThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.addressThreshold.Name = "addressThreshold";
            this.addressThreshold.Size = new System.Drawing.Size(94, 20);
            this.addressThreshold.TabIndex = 13;
            this.addressThreshold.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Closing Analyzer Settings";
            // 
            // MLSInputFile_Determiner
            // 
            this.MLSInputFile_Determiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MLSInputFile_Determiner.Location = new System.Drawing.Point(3, 53);
            this.MLSInputFile_Determiner.Name = "MLSInputFile_Determiner";
            this.MLSInputFile_Determiner.Size = new System.Drawing.Size(391, 20);
            this.MLSInputFile_Determiner.TabIndex = 0;
            this.MLSInputFile_Determiner.Text = "C:\\MLSData.xlsx";
            // 
            // openMLSFile_Determiner
            // 
            this.openMLSFile_Determiner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.openMLSFile_Determiner.Location = new System.Drawing.Point(399, 50);
            this.openMLSFile_Determiner.Name = "openMLSFile_Determiner";
            this.openMLSFile_Determiner.Size = new System.Drawing.Size(75, 23);
            this.openMLSFile_Determiner.TabIndex = 7;
            this.openMLSFile_Determiner.Text = "Open";
            this.openMLSFile_Determiner.UseVisualStyleBackColor = true;
            this.openMLSFile_Determiner.Click += new System.EventHandler(this.openMLSFile_Determiner_Click);
            // 
            // openAIMFile
            // 
            this.openAIMFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.openAIMFile.Location = new System.Drawing.Point(399, 110);
            this.openAIMFile.Name = "openAIMFile";
            this.openAIMFile.Size = new System.Drawing.Size(75, 23);
            this.openAIMFile.TabIndex = 8;
            this.openAIMFile.Text = "Open";
            this.openAIMFile.UseVisualStyleBackColor = true;
            this.openAIMFile.Click += new System.EventHandler(this.openAIMFile_Click);
            // 
            // AIMInputFile
            // 
            this.AIMInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AIMInputFile.Location = new System.Drawing.Point(3, 112);
            this.AIMInputFile.Name = "AIMInputFile";
            this.AIMInputFile.Size = new System.Drawing.Size(391, 20);
            this.AIMInputFile.TabIndex = 2;
            this.AIMInputFile.Text = "C:\\AIMData.xlsx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "MLS Input File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "AIM Input File";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.processorSettingsHelp);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.MLSInputFile_Processor);
            this.panel2.Controls.Add(this.includeNonMLSAgent);
            this.panel2.Controls.Add(this.openMLSFile_Processor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 134);
            this.panel2.TabIndex = 12;
            // 
            // processorSettingsHelp
            // 
            this.processorSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.processorSettingsHelp.Location = new System.Drawing.Point(467, 304);
            this.processorSettingsHelp.Margin = new System.Windows.Forms.Padding(2);
            this.processorSettingsHelp.Name = "processorSettingsHelp";
            this.processorSettingsHelp.Size = new System.Drawing.Size(16, 19);
            this.processorSettingsHelp.TabIndex = 18;
            this.processorSettingsHelp.Text = "?";
            this.processorSettingsHelp.UseVisualStyleBackColor = true;
            this.processorSettingsHelp.Click += new System.EventHandler(this.processorSettingsHelp_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Market Share Analyzer Settings";
            // 
            // MLSInputFile_Processor
            // 
            this.MLSInputFile_Processor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MLSInputFile_Processor.Location = new System.Drawing.Point(3, 59);
            this.MLSInputFile_Processor.Name = "MLSInputFile_Processor";
            this.MLSInputFile_Processor.Size = new System.Drawing.Size(391, 20);
            this.MLSInputFile_Processor.TabIndex = 4;
            this.MLSInputFile_Processor.Text = "C:\\MLSData.xlsx";
            // 
            // includeNonMLSAgent
            // 
            this.includeNonMLSAgent.AutoSize = true;
            this.includeNonMLSAgent.Location = new System.Drawing.Point(3, 102);
            this.includeNonMLSAgent.Name = "includeNonMLSAgent";
            this.includeNonMLSAgent.Size = new System.Drawing.Size(140, 17);
            this.includeNonMLSAgent.TabIndex = 6;
            this.includeNonMLSAgent.Text = "Include Non-MLS Agent";
            this.includeNonMLSAgent.UseVisualStyleBackColor = true;
            // 
            // openMLSFile_Processor
            // 
            this.openMLSFile_Processor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openMLSFile_Processor.Location = new System.Drawing.Point(399, 57);
            this.openMLSFile_Processor.Name = "openMLSFile_Processor";
            this.openMLSFile_Processor.Size = new System.Drawing.Size(75, 23);
            this.openMLSFile_Processor.TabIndex = 9;
            this.openMLSFile_Processor.Text = "Open";
            this.openMLSFile_Processor.UseVisualStyleBackColor = true;
            this.openMLSFile_Processor.Click += new System.EventHandler(this.openMLSFile_Processor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "MLS Input File";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.miscSettingsHelp);
            this.panel3.Controls.Add(this.doSubtotals);
            this.panel3.Controls.Add(this.runAsCapstone);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.sameMLSFiles);
            this.panel3.Location = new System.Drawing.Point(3, 521);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 108);
            this.panel3.TabIndex = 13;
            // 
            // miscSettingsHelp
            // 
            this.miscSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.miscSettingsHelp.Location = new System.Drawing.Point(467, 85);
            this.miscSettingsHelp.Margin = new System.Windows.Forms.Padding(2);
            this.miscSettingsHelp.Name = "miscSettingsHelp";
            this.miscSettingsHelp.Size = new System.Drawing.Size(16, 19);
            this.miscSettingsHelp.TabIndex = 18;
            this.miscSettingsHelp.Text = "?";
            this.miscSettingsHelp.UseVisualStyleBackColor = true;
            this.miscSettingsHelp.Click += new System.EventHandler(this.miscSettingsHelp_Click);
            // 
            // doSubtotals
            // 
            this.doSubtotals.AutoSize = true;
            this.doSubtotals.Checked = true;
            this.doSubtotals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doSubtotals.Location = new System.Drawing.Point(283, 43);
            this.doSubtotals.Name = "doSubtotals";
            this.doSubtotals.Size = new System.Drawing.Size(140, 17);
            this.doSubtotals.TabIndex = 13;
            this.doSubtotals.Text = "Do sorting and subtotals";
            this.doSubtotals.UseVisualStyleBackColor = true;
            // 
            // runAsCapstone
            // 
            this.runAsCapstone.AutoSize = true;
            this.runAsCapstone.Location = new System.Drawing.Point(168, 43);
            this.runAsCapstone.Name = "runAsCapstone";
            this.runAsCapstone.Size = new System.Drawing.Size(108, 17);
            this.runAsCapstone.TabIndex = 12;
            this.runAsCapstone.Text = "Run as Capstone";
            this.runAsCapstone.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Misc. Settings";
            // 
            // sameMLSFiles
            // 
            this.sameMLSFiles.AutoSize = true;
            this.sameMLSFiles.Checked = true;
            this.sameMLSFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameMLSFiles.Location = new System.Drawing.Point(3, 43);
            this.sameMLSFiles.Name = "sameMLSFiles";
            this.sameMLSFiles.Size = new System.Drawing.Size(159, 17);
            this.sameMLSFiles.TabIndex = 10;
            this.sameMLSFiles.Text = "MLS input files are the same";
            this.sameMLSFiles.UseVisualStyleBackColor = true;
            this.sameMLSFiles.CheckedChanged += new System.EventHandler(this.sameMLSFiles_CheckedChanged);
            // 
            // configTab
            // 
            this.configTab.Controls.Add(this.configSettingsHelp);
            this.configTab.Controls.Add(this.saveConfigData);
            this.configTab.Controls.Add(this.refreshConfigData);
            this.configTab.Controls.Add(this.configData);
            this.configTab.Controls.Add(this.openConfigFile);
            this.configTab.Controls.Add(this.label11);
            this.configTab.Controls.Add(this.configFile);
            this.configTab.Location = new System.Drawing.Point(4, 22);
            this.configTab.Name = "configTab";
            this.configTab.Padding = new System.Windows.Forms.Padding(3);
            this.configTab.Size = new System.Drawing.Size(493, 632);
            this.configTab.TabIndex = 2;
            this.configTab.Text = "Configurations";
            this.configTab.UseVisualStyleBackColor = true;
            // 
            // configSettingsHelp
            // 
            this.configSettingsHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.configSettingsHelp.Location = new System.Drawing.Point(472, 606);
            this.configSettingsHelp.Margin = new System.Windows.Forms.Padding(2);
            this.configSettingsHelp.Name = "configSettingsHelp";
            this.configSettingsHelp.Size = new System.Drawing.Size(16, 19);
            this.configSettingsHelp.TabIndex = 18;
            this.configSettingsHelp.Text = "?";
            this.configSettingsHelp.UseVisualStyleBackColor = true;
            this.configSettingsHelp.Click += new System.EventHandler(this.configSettingsHelp_Click);
            // 
            // saveConfigData
            // 
            this.saveConfigData.Location = new System.Drawing.Point(87, 82);
            this.saveConfigData.Name = "saveConfigData";
            this.saveConfigData.Size = new System.Drawing.Size(75, 23);
            this.saveConfigData.TabIndex = 5;
            this.saveConfigData.Text = "Save";
            this.saveConfigData.UseVisualStyleBackColor = true;
            this.saveConfigData.Click += new System.EventHandler(this.saveConfigData_Click);
            // 
            // refreshConfigData
            // 
            this.refreshConfigData.Location = new System.Drawing.Point(6, 82);
            this.refreshConfigData.Name = "refreshConfigData";
            this.refreshConfigData.Size = new System.Drawing.Size(75, 23);
            this.refreshConfigData.TabIndex = 4;
            this.refreshConfigData.Text = "Refresh";
            this.refreshConfigData.UseVisualStyleBackColor = true;
            this.refreshConfigData.Click += new System.EventHandler(this.refreshConfigData_Click);
            // 
            // configData
            // 
            this.configData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configData.Location = new System.Drawing.Point(6, 111);
            this.configData.Multiline = true;
            this.configData.Name = "configData";
            this.configData.Size = new System.Drawing.Size(481, 490);
            this.configData.TabIndex = 3;
            // 
            // openConfigFile
            // 
            this.openConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openConfigFile.Location = new System.Drawing.Point(412, 38);
            this.openConfigFile.Name = "openConfigFile";
            this.openConfigFile.Size = new System.Drawing.Size(75, 23);
            this.openConfigFile.TabIndex = 2;
            this.openConfigFile.Text = "Open";
            this.openConfigFile.UseVisualStyleBackColor = true;
            this.openConfigFile.Click += new System.EventHandler(this.openConfigFile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Configuration File Location";
            // 
            // configFile
            // 
            this.configFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFile.Location = new System.Drawing.Point(6, 40);
            this.configFile.Name = "configFile";
            this.configFile.Size = new System.Drawing.Size(400, 20);
            this.configFile.TabIndex = 0;
            this.configFile.Text = "config.txt";
            // 
            // debugScreen
            // 
            this.debugScreen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.debugScreen.Location = new System.Drawing.Point(501, 426);
            this.debugScreen.Margin = new System.Windows.Forms.Padding(2);
            this.debugScreen.MaxLength = 1000000;
            this.debugScreen.Multiline = true;
            this.debugScreen.Name = "debugScreen";
            this.debugScreen.ReadOnly = true;
            this.debugScreen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugScreen.Size = new System.Drawing.Size(796, 232);
            this.debugScreen.TabIndex = 5;
            // 
            // openFileDialogMLS
            // 
            this.openFileDialogMLS.FileName = ".\\MLSData.xlsx";
            // 
            // openFileDialogAIM
            // 
            this.openFileDialogAIM.FileName = ".\\AIMData.xlsx";
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.FileName = ".\\config.txt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(501, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 425);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 658);
            this.Controls.Add(this.debugScreen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HATCO/Capstone RE Market Share Analyzer";
            this.tabControl1.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.optionsTab.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NonCust_ClosingsThreshold)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressWeakThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressThreshold)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.configTab.ResumeLayout(false);
            this.configTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.Button runProcessor;
        public System.Windows.Forms.Label processorProgressDetailed;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label determinerProgressDetailed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button runDeterminer;
        private System.Windows.Forms.CheckBox sameMLSFiles;
        private System.Windows.Forms.Button openMLSFile_Processor;
        private System.Windows.Forms.Button openAIMFile;
        private System.Windows.Forms.Button openMLSFile_Determiner;
        private System.Windows.Forms.CheckBox includeNonMLSAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MLSInputFile_Processor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AIMInputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MLSInputFile_Determiner;
        private System.Windows.Forms.OpenFileDialog openFileDialogMLS;
        private System.Windows.Forms.OpenFileDialog openFileDialogAIM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ProgressBar determinerProgressBar;
        public System.Windows.Forms.ProgressBar processorProgressBar;
        private System.Windows.Forms.CheckBox runAsCapstone;
        private System.Windows.Forms.CheckBox doSubtotals;
        private System.Windows.Forms.TabPage configTab;
        private System.Windows.Forms.Button openConfigFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox configFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
        private System.Windows.Forms.Button saveConfigData;
        private System.Windows.Forms.Button refreshConfigData;
        private System.Windows.Forms.TextBox configData;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown addressWeakThreshold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown addressThreshold;
        private System.Windows.Forms.Button determinerSettingsHelp;
        private System.Windows.Forms.Button processorSettingsHelp;
        private System.Windows.Forms.Button miscSettingsHelp;
        private System.Windows.Forms.Button configSettingsHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox debugScreen;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Label finalizerProgressDetailed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button runFinalizer;
        public System.Windows.Forms.ProgressBar finalizerProgressBar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox NonCust_ClosingPercent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown NonCust_ClosingsThreshold;
        private System.Windows.Forms.Button openMLSFile_Finalizer;
        private System.Windows.Forms.TextBox MLSInputFile_Finalizer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button finalizerSettingsHelp;
    }
}

