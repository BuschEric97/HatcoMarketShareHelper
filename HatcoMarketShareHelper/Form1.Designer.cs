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
            this.label1 = new System.Windows.Forms.Label();
            this.runDeterminer = new System.Windows.Forms.Button();
            this.determinerProgressDetailed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.processorProgressDetailed = new System.Windows.Forms.Label();
            this.runProcessor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label10 = new System.Windows.Forms.Label();
            this.sameMLSFiles = new System.Windows.Forms.CheckBox();
            this.openFileDialogMLS = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogAIM = new System.Windows.Forms.OpenFileDialog();
            this.determinerProgressBar = new System.Windows.Forms.ProgressBar();
            this.processorProgressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl1.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.homeTab);
            this.tabControl1.Controls.Add(this.optionsTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.panel4);
            this.homeTab.Controls.Add(this.panel5);
            this.homeTab.Location = new System.Drawing.Point(4, 22);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(767, 399);
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
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(755, 185);
            this.panel4.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Determiner";
            // 
            // runDeterminer
            // 
            this.runDeterminer.Location = new System.Drawing.Point(3, 69);
            this.runDeterminer.Name = "runDeterminer";
            this.runDeterminer.Size = new System.Drawing.Size(103, 23);
            this.runDeterminer.TabIndex = 0;
            this.runDeterminer.Text = "Run Determiner";
            this.runDeterminer.UseVisualStyleBackColor = true;
            this.runDeterminer.Click += new System.EventHandler(this.runDeterminer_Click);
            // 
            // determinerProgressDetailed
            // 
            this.determinerProgressDetailed.AutoSize = true;
            this.determinerProgressDetailed.Location = new System.Drawing.Point(60, 95);
            this.determinerProgressDetailed.Name = "determinerProgressDetailed";
            this.determinerProgressDetailed.Size = new System.Drawing.Size(24, 13);
            this.determinerProgressDetailed.TabIndex = 2;
            this.determinerProgressDetailed.Text = "0/0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
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
            this.panel5.Location = new System.Drawing.Point(6, 194);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(755, 199);
            this.panel5.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Processor";
            // 
            // processorProgressDetailed
            // 
            this.processorProgressDetailed.AutoSize = true;
            this.processorProgressDetailed.Location = new System.Drawing.Point(60, 94);
            this.processorProgressDetailed.Name = "processorProgressDetailed";
            this.processorProgressDetailed.Size = new System.Drawing.Size(24, 13);
            this.processorProgressDetailed.TabIndex = 4;
            this.processorProgressDetailed.Text = "0/0";
            // 
            // runProcessor
            // 
            this.runProcessor.Location = new System.Drawing.Point(3, 68);
            this.runProcessor.Name = "runProcessor";
            this.runProcessor.Size = new System.Drawing.Size(103, 23);
            this.runProcessor.TabIndex = 5;
            this.runProcessor.Text = "Run Processor";
            this.runProcessor.UseVisualStyleBackColor = true;
            this.runProcessor.Click += new System.EventHandler(this.runProcessor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Progress:";
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.panel1);
            this.optionsTab.Controls.Add(this.panel2);
            this.optionsTab.Controls.Add(this.panel3);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(767, 399);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.MLSInputFile_Determiner);
            this.panel1.Controls.Add(this.openMLSFile_Determiner);
            this.panel1.Controls.Add(this.openAIMFile);
            this.panel1.Controls.Add(this.AIMInputFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 147);
            this.panel1.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Determiner Settings";
            // 
            // MLSInputFile_Determiner
            // 
            this.MLSInputFile_Determiner.Location = new System.Drawing.Point(3, 57);
            this.MLSInputFile_Determiner.Name = "MLSInputFile_Determiner";
            this.MLSInputFile_Determiner.Size = new System.Drawing.Size(543, 20);
            this.MLSInputFile_Determiner.TabIndex = 0;
            this.MLSInputFile_Determiner.Text = "C:\\Users\\Origami1105\\source\\repos\\HatcoMarketShareHelper\\Testing Files\\Determiner" +
    " Test Files\\MLSData.xlsx";
            // 
            // openMLSFile_Determiner
            // 
            this.openMLSFile_Determiner.Location = new System.Drawing.Point(552, 55);
            this.openMLSFile_Determiner.Name = "openMLSFile_Determiner";
            this.openMLSFile_Determiner.Size = new System.Drawing.Size(75, 23);
            this.openMLSFile_Determiner.TabIndex = 7;
            this.openMLSFile_Determiner.Text = "Open";
            this.openMLSFile_Determiner.UseVisualStyleBackColor = true;
            this.openMLSFile_Determiner.Click += new System.EventHandler(this.openMLSFile_Determiner_Click);
            // 
            // openAIMFile
            // 
            this.openAIMFile.Location = new System.Drawing.Point(552, 114);
            this.openAIMFile.Name = "openAIMFile";
            this.openAIMFile.Size = new System.Drawing.Size(75, 23);
            this.openAIMFile.TabIndex = 8;
            this.openAIMFile.Text = "Open";
            this.openAIMFile.UseVisualStyleBackColor = true;
            this.openAIMFile.Click += new System.EventHandler(this.openAIMFile_Click);
            // 
            // AIMInputFile
            // 
            this.AIMInputFile.Location = new System.Drawing.Point(3, 116);
            this.AIMInputFile.Name = "AIMInputFile";
            this.AIMInputFile.Size = new System.Drawing.Size(543, 20);
            this.AIMInputFile.TabIndex = 2;
            this.AIMInputFile.Text = "C:\\Users\\Origami1105\\source\\repos\\HatcoMarketShareHelper\\Testing Files\\Determiner" +
    " Test Files\\AIMData.xlsx";
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
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.MLSInputFile_Processor);
            this.panel2.Controls.Add(this.includeNonMLSAgent);
            this.panel2.Controls.Add(this.openMLSFile_Processor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(6, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 124);
            this.panel2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Processor Settings";
            // 
            // MLSInputFile_Processor
            // 
            this.MLSInputFile_Processor.Location = new System.Drawing.Point(3, 59);
            this.MLSInputFile_Processor.Name = "MLSInputFile_Processor";
            this.MLSInputFile_Processor.Size = new System.Drawing.Size(543, 20);
            this.MLSInputFile_Processor.TabIndex = 4;
            this.MLSInputFile_Processor.Text = "C:\\Users\\Origami1105\\source\\repos\\HatcoMarketShareHelper\\Testing Files\\Processor " +
    "Test Files\\MLSDataSmallTesting.xlsx";
            // 
            // includeNonMLSAgent
            // 
            this.includeNonMLSAgent.AutoSize = true;
            this.includeNonMLSAgent.Checked = true;
            this.includeNonMLSAgent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeNonMLSAgent.Location = new System.Drawing.Point(3, 102);
            this.includeNonMLSAgent.Name = "includeNonMLSAgent";
            this.includeNonMLSAgent.Size = new System.Drawing.Size(140, 17);
            this.includeNonMLSAgent.TabIndex = 6;
            this.includeNonMLSAgent.Text = "Include Non-MLS Agent";
            this.includeNonMLSAgent.UseVisualStyleBackColor = true;
            // 
            // openMLSFile_Processor
            // 
            this.openMLSFile_Processor.Location = new System.Drawing.Point(552, 57);
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
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.sameMLSFiles);
            this.panel3.Location = new System.Drawing.Point(6, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(755, 120);
            this.panel3.TabIndex = 13;
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
            this.sameMLSFiles.Location = new System.Drawing.Point(3, 43);
            this.sameMLSFiles.Name = "sameMLSFiles";
            this.sameMLSFiles.Size = new System.Drawing.Size(159, 17);
            this.sameMLSFiles.TabIndex = 10;
            this.sameMLSFiles.Text = "MLS input files are the same";
            this.sameMLSFiles.UseVisualStyleBackColor = true;
            this.sameMLSFiles.CheckedChanged += new System.EventHandler(this.sameMLSFiles_CheckedChanged);
            // 
            // openFileDialogMLS
            // 
            this.openFileDialogMLS.FileName = "openFileDialog1";
            // 
            // openFileDialogAIM
            // 
            this.openFileDialogAIM.FileName = "openFileDialog1";
            // 
            // determinerProgressBar
            // 
            this.determinerProgressBar.Location = new System.Drawing.Point(3, 157);
            this.determinerProgressBar.Name = "determinerProgressBar";
            this.determinerProgressBar.Size = new System.Drawing.Size(747, 23);
            this.determinerProgressBar.TabIndex = 4;
            // 
            // processorProgressBar
            // 
            this.processorProgressBar.Location = new System.Drawing.Point(3, 171);
            this.processorProgressBar.Name = "processorProgressBar";
            this.processorProgressBar.Size = new System.Drawing.Size(747, 23);
            this.processorProgressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.ProgressBar determinerProgressBar;
        private System.Windows.Forms.ProgressBar processorProgressBar;
    }
}

