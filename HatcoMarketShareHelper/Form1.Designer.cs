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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.homeTab = new System.Windows.Forms.TabPage();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.setNumThreads = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.MLSInputFile_Determiner = new System.Windows.Forms.TextBox();
            this.openMLSFile_Determiner = new System.Windows.Forms.Button();
            this.openAIMFile = new System.Windows.Forms.Button();
            this.AIMInputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.MLSInputFile_Processor = new System.Windows.Forms.TextBox();
            this.includeNonMLSAgent = new System.Windows.Forms.CheckBox();
            this.openMLSFile_Processor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.doSubtotals = new System.Windows.Forms.CheckBox();
            this.runAsCapstone = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sameMLSFiles = new System.Windows.Forms.CheckBox();
            this.configTab = new System.Windows.Forms.TabPage();
            this.saveConfigData = new System.Windows.Forms.Button();
            this.refreshConfigData = new System.Windows.Forms.Button();
            this.configData = new System.Windows.Forms.TextBox();
            this.openConfigFile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.configFile = new System.Windows.Forms.TextBox();
            this.openFileDialogMLS = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAIM = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.addressThreshold = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.addressWeakThreshold = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.configTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressWeakThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.homeTab);
            this.tabControl1.Controls.Add(this.optionsTab);
            this.tabControl1.Controls.Add(this.configTab);
            this.tabControl1.Location = new System.Drawing.Point(17, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1033, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.panel4);
            this.homeTab.Controls.Add(this.panel5);
            this.homeTab.Location = new System.Drawing.Point(4, 25);
            this.homeTab.Margin = new System.Windows.Forms.Padding(4);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(4);
            this.homeTab.Size = new System.Drawing.Size(1025, 494);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Launcher";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.determinerProgressBar);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.runDeterminer);
            this.panel4.Controls.Add(this.determinerProgressDetailed);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1017, 240);
            this.panel4.TabIndex = 6;
            // 
            // determinerProgressBar
            // 
            this.determinerProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.determinerProgressBar.Location = new System.Drawing.Point(4, 206);
            this.determinerProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.determinerProgressBar.Name = "determinerProgressBar";
            this.determinerProgressBar.Size = new System.Drawing.Size(1007, 28);
            this.determinerProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Determiner";
            // 
            // runDeterminer
            // 
            this.runDeterminer.Location = new System.Drawing.Point(4, 85);
            this.runDeterminer.Margin = new System.Windows.Forms.Padding(4);
            this.runDeterminer.Name = "runDeterminer";
            this.runDeterminer.Size = new System.Drawing.Size(137, 28);
            this.runDeterminer.TabIndex = 0;
            this.runDeterminer.Text = "Run Determiner";
            this.runDeterminer.UseVisualStyleBackColor = true;
            this.runDeterminer.Click += new System.EventHandler(this.runDeterminer_Click);
            // 
            // determinerProgressDetailed
            // 
            this.determinerProgressDetailed.AutoSize = true;
            this.determinerProgressDetailed.Location = new System.Drawing.Point(80, 117);
            this.determinerProgressDetailed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.determinerProgressDetailed.Name = "determinerProgressDetailed";
            this.determinerProgressDetailed.Size = new System.Drawing.Size(28, 17);
            this.determinerProgressDetailed.TabIndex = 2;
            this.determinerProgressDetailed.Text = "0/0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Progress:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.processorProgressBar);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.processorProgressDetailed);
            this.panel5.Controls.Add(this.runProcessor);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(4, 247);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1017, 243);
            this.panel5.TabIndex = 7;
            // 
            // processorProgressBar
            // 
            this.processorProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processorProgressBar.Location = new System.Drawing.Point(4, 209);
            this.processorProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.processorProgressBar.Name = "processorProgressBar";
            this.processorProgressBar.Size = new System.Drawing.Size(1007, 28);
            this.processorProgressBar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Processor";
            // 
            // processorProgressDetailed
            // 
            this.processorProgressDetailed.AutoSize = true;
            this.processorProgressDetailed.Location = new System.Drawing.Point(80, 116);
            this.processorProgressDetailed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processorProgressDetailed.Name = "processorProgressDetailed";
            this.processorProgressDetailed.Size = new System.Drawing.Size(28, 17);
            this.processorProgressDetailed.TabIndex = 4;
            this.processorProgressDetailed.Text = "0/0";
            // 
            // runProcessor
            // 
            this.runProcessor.Location = new System.Drawing.Point(4, 84);
            this.runProcessor.Margin = new System.Windows.Forms.Padding(4);
            this.runProcessor.Name = "runProcessor";
            this.runProcessor.Size = new System.Drawing.Size(137, 28);
            this.runProcessor.TabIndex = 5;
            this.runProcessor.Text = "Run Processor";
            this.runProcessor.UseVisualStyleBackColor = true;
            this.runProcessor.Click += new System.EventHandler(this.runProcessor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 116);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Progress:";
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.panel1);
            this.optionsTab.Controls.Add(this.panel2);
            this.optionsTab.Controls.Add(this.panel3);
            this.optionsTab.Location = new System.Drawing.Point(4, 25);
            this.optionsTab.Margin = new System.Windows.Forms.Padding(4);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(4);
            this.optionsTab.Size = new System.Drawing.Size(1025, 494);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.addressWeakThreshold);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.addressThreshold);
            this.panel1.Controls.Add(this.setNumThreads);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numThreads);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.MLSInputFile_Determiner);
            this.panel1.Controls.Add(this.openMLSFile_Determiner);
            this.panel1.Controls.Add(this.openAIMFile);
            this.panel1.Controls.Add(this.AIMInputFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 252);
            this.panel1.TabIndex = 11;
            // 
            // setNumThreads
            // 
            this.setNumThreads.Location = new System.Drawing.Point(50, 217);
            this.setNumThreads.Name = "setNumThreads";
            this.setNumThreads.Size = new System.Drawing.Size(163, 23);
            this.setNumThreads.TabIndex = 12;
            this.setNumThreads.Text = "Set to # of CPU Cores";
            this.setNumThreads.UseVisualStyleBackColor = true;
            this.setNumThreads.Click += new System.EventHandler(this.setNumThreads_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Number of threads";
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(4, 217);
            this.numThreads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(40, 22);
            this.numThreads.TabIndex = 10;
            this.numThreads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Determiner Settings";
            // 
            // MLSInputFile_Determiner
            // 
            this.MLSInputFile_Determiner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MLSInputFile_Determiner.Location = new System.Drawing.Point(4, 70);
            this.MLSInputFile_Determiner.Margin = new System.Windows.Forms.Padding(4);
            this.MLSInputFile_Determiner.Name = "MLSInputFile_Determiner";
            this.MLSInputFile_Determiner.Size = new System.Drawing.Size(888, 22);
            this.MLSInputFile_Determiner.TabIndex = 0;
            this.MLSInputFile_Determiner.Text = "C:\\MLSData.xlsx";
            // 
            // openMLSFile_Determiner
            // 
            this.openMLSFile_Determiner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.openMLSFile_Determiner.Location = new System.Drawing.Point(900, 67);
            this.openMLSFile_Determiner.Margin = new System.Windows.Forms.Padding(4);
            this.openMLSFile_Determiner.Name = "openMLSFile_Determiner";
            this.openMLSFile_Determiner.Size = new System.Drawing.Size(100, 28);
            this.openMLSFile_Determiner.TabIndex = 7;
            this.openMLSFile_Determiner.Text = "Open";
            this.openMLSFile_Determiner.UseVisualStyleBackColor = true;
            this.openMLSFile_Determiner.Click += new System.EventHandler(this.openMLSFile_Determiner_Click);
            // 
            // openAIMFile
            // 
            this.openAIMFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.openAIMFile.Location = new System.Drawing.Point(900, 140);
            this.openAIMFile.Margin = new System.Windows.Forms.Padding(4);
            this.openAIMFile.Name = "openAIMFile";
            this.openAIMFile.Size = new System.Drawing.Size(100, 28);
            this.openAIMFile.TabIndex = 8;
            this.openAIMFile.Text = "Open";
            this.openAIMFile.UseVisualStyleBackColor = true;
            this.openAIMFile.Click += new System.EventHandler(this.openAIMFile_Click);
            // 
            // AIMInputFile
            // 
            this.AIMInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AIMInputFile.Location = new System.Drawing.Point(4, 143);
            this.AIMInputFile.Margin = new System.Windows.Forms.Padding(4);
            this.AIMInputFile.Name = "AIMInputFile";
            this.AIMInputFile.Size = new System.Drawing.Size(888, 22);
            this.AIMInputFile.TabIndex = 2;
            this.AIMInputFile.Text = "C:\\AIMData.xlsx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "MLS Input File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "AIM Input File";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.MLSInputFile_Processor);
            this.panel2.Controls.Add(this.includeNonMLSAgent);
            this.panel2.Controls.Add(this.openMLSFile_Processor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(4, 254);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 152);
            this.panel2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Processor Settings";
            // 
            // MLSInputFile_Processor
            // 
            this.MLSInputFile_Processor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MLSInputFile_Processor.Location = new System.Drawing.Point(4, 73);
            this.MLSInputFile_Processor.Margin = new System.Windows.Forms.Padding(4);
            this.MLSInputFile_Processor.Name = "MLSInputFile_Processor";
            this.MLSInputFile_Processor.Size = new System.Drawing.Size(888, 22);
            this.MLSInputFile_Processor.TabIndex = 4;
            this.MLSInputFile_Processor.Text = "C:\\MLSData.xlsx";
            // 
            // includeNonMLSAgent
            // 
            this.includeNonMLSAgent.AutoSize = true;
            this.includeNonMLSAgent.Checked = true;
            this.includeNonMLSAgent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeNonMLSAgent.Location = new System.Drawing.Point(4, 125);
            this.includeNonMLSAgent.Margin = new System.Windows.Forms.Padding(4);
            this.includeNonMLSAgent.Name = "includeNonMLSAgent";
            this.includeNonMLSAgent.Size = new System.Drawing.Size(179, 21);
            this.includeNonMLSAgent.TabIndex = 6;
            this.includeNonMLSAgent.Text = "Include Non-MLS Agent";
            this.includeNonMLSAgent.UseVisualStyleBackColor = true;
            // 
            // openMLSFile_Processor
            // 
            this.openMLSFile_Processor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openMLSFile_Processor.Location = new System.Drawing.Point(900, 70);
            this.openMLSFile_Processor.Margin = new System.Windows.Forms.Padding(4);
            this.openMLSFile_Processor.Name = "openMLSFile_Processor";
            this.openMLSFile_Processor.Size = new System.Drawing.Size(100, 28);
            this.openMLSFile_Processor.TabIndex = 9;
            this.openMLSFile_Processor.Text = "Open";
            this.openMLSFile_Processor.UseVisualStyleBackColor = true;
            this.openMLSFile_Processor.Click += new System.EventHandler(this.openMLSFile_Processor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "MLS Input File";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.doSubtotals);
            this.panel3.Controls.Add(this.runAsCapstone);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.sameMLSFiles);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(4, 404);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1017, 86);
            this.panel3.TabIndex = 13;
            // 
            // doSubtotals
            // 
            this.doSubtotals.AutoSize = true;
            this.doSubtotals.Checked = true;
            this.doSubtotals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doSubtotals.Location = new System.Drawing.Point(377, 53);
            this.doSubtotals.Margin = new System.Windows.Forms.Padding(4);
            this.doSubtotals.Name = "doSubtotals";
            this.doSubtotals.Size = new System.Drawing.Size(184, 21);
            this.doSubtotals.TabIndex = 13;
            this.doSubtotals.Text = "Do sorting and subtotals";
            this.doSubtotals.UseVisualStyleBackColor = true;
            // 
            // runAsCapstone
            // 
            this.runAsCapstone.AutoSize = true;
            this.runAsCapstone.Location = new System.Drawing.Point(224, 53);
            this.runAsCapstone.Margin = new System.Windows.Forms.Padding(4);
            this.runAsCapstone.Name = "runAsCapstone";
            this.runAsCapstone.Size = new System.Drawing.Size(139, 21);
            this.runAsCapstone.TabIndex = 12;
            this.runAsCapstone.Text = "Run as Capstone";
            this.runAsCapstone.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 25);
            this.label10.TabIndex = 11;
            this.label10.Text = "Misc. Settings";
            // 
            // sameMLSFiles
            // 
            this.sameMLSFiles.AutoSize = true;
            this.sameMLSFiles.Location = new System.Drawing.Point(4, 53);
            this.sameMLSFiles.Margin = new System.Windows.Forms.Padding(4);
            this.sameMLSFiles.Name = "sameMLSFiles";
            this.sameMLSFiles.Size = new System.Drawing.Size(209, 21);
            this.sameMLSFiles.TabIndex = 10;
            this.sameMLSFiles.Text = "MLS input files are the same";
            this.sameMLSFiles.UseVisualStyleBackColor = true;
            this.sameMLSFiles.CheckedChanged += new System.EventHandler(this.sameMLSFiles_CheckedChanged);
            // 
            // configTab
            // 
            this.configTab.Controls.Add(this.saveConfigData);
            this.configTab.Controls.Add(this.refreshConfigData);
            this.configTab.Controls.Add(this.configData);
            this.configTab.Controls.Add(this.openConfigFile);
            this.configTab.Controls.Add(this.label11);
            this.configTab.Controls.Add(this.configFile);
            this.configTab.Location = new System.Drawing.Point(4, 25);
            this.configTab.Margin = new System.Windows.Forms.Padding(4);
            this.configTab.Name = "configTab";
            this.configTab.Padding = new System.Windows.Forms.Padding(4);
            this.configTab.Size = new System.Drawing.Size(1025, 494);
            this.configTab.TabIndex = 2;
            this.configTab.Text = "Configurations";
            this.configTab.UseVisualStyleBackColor = true;
            // 
            // saveConfigData
            // 
            this.saveConfigData.Location = new System.Drawing.Point(116, 101);
            this.saveConfigData.Margin = new System.Windows.Forms.Padding(4);
            this.saveConfigData.Name = "saveConfigData";
            this.saveConfigData.Size = new System.Drawing.Size(100, 28);
            this.saveConfigData.TabIndex = 5;
            this.saveConfigData.Text = "Save";
            this.saveConfigData.UseVisualStyleBackColor = true;
            this.saveConfigData.Click += new System.EventHandler(this.saveConfigData_Click);
            // 
            // refreshConfigData
            // 
            this.refreshConfigData.Location = new System.Drawing.Point(8, 101);
            this.refreshConfigData.Margin = new System.Windows.Forms.Padding(4);
            this.refreshConfigData.Name = "refreshConfigData";
            this.refreshConfigData.Size = new System.Drawing.Size(100, 28);
            this.refreshConfigData.TabIndex = 4;
            this.refreshConfigData.Text = "Refresh";
            this.refreshConfigData.UseVisualStyleBackColor = true;
            this.refreshConfigData.Click += new System.EventHandler(this.refreshConfigData_Click);
            // 
            // configData
            // 
            this.configData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configData.Location = new System.Drawing.Point(8, 137);
            this.configData.Margin = new System.Windows.Forms.Padding(4);
            this.configData.Multiline = true;
            this.configData.Name = "configData";
            this.configData.Size = new System.Drawing.Size(1009, 163);
            this.configData.TabIndex = 3;
            // 
            // openConfigFile
            // 
            this.openConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openConfigFile.Location = new System.Drawing.Point(917, 46);
            this.openConfigFile.Margin = new System.Windows.Forms.Padding(4);
            this.openConfigFile.Name = "openConfigFile";
            this.openConfigFile.Size = new System.Drawing.Size(100, 28);
            this.openConfigFile.TabIndex = 2;
            this.openConfigFile.Text = "Open";
            this.openConfigFile.UseVisualStyleBackColor = true;
            this.openConfigFile.Click += new System.EventHandler(this.openConfigFile_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 30);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Configuration File Location";
            // 
            // configFile
            // 
            this.configFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFile.Location = new System.Drawing.Point(8, 49);
            this.configFile.Margin = new System.Windows.Forms.Padding(4);
            this.configFile.Name = "configFile";
            this.configFile.Size = new System.Drawing.Size(901, 22);
            this.configFile.TabIndex = 0;
            this.configFile.Text = ".\\config.txt\r\n";
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
            // addressThreshold
            // 
            this.addressThreshold.DecimalPlaces = 2;
            this.addressThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.addressThreshold.Location = new System.Drawing.Point(224, 217);
            this.addressThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.addressThreshold.Name = "addressThreshold";
            this.addressThreshold.Size = new System.Drawing.Size(125, 22);
            this.addressThreshold.TabIndex = 13;
            this.addressThreshold.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Address Threshold";
            // 
            // addressWeakThreshold
            // 
            this.addressWeakThreshold.DecimalPlaces = 2;
            this.addressWeakThreshold.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.addressWeakThreshold.Location = new System.Drawing.Point(364, 217);
            this.addressWeakThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.addressWeakThreshold.Name = "addressWeakThreshold";
            this.addressWeakThreshold.Size = new System.Drawing.Size(197, 22);
            this.addressWeakThreshold.TabIndex = 15;
            this.addressWeakThreshold.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(200, 17);
            this.label14.TabIndex = 16;
            this.label14.Text = "Address Secondary Threshold";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "HATCo Market Share Helper";
            this.tabControl1.ResumeLayout(false);
            this.homeTab.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.optionsTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.configTab.ResumeLayout(false);
            this.configTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressWeakThreshold)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Button setNumThreads;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown addressWeakThreshold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown addressThreshold;
    }
}

