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
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.advancedTab = new System.Windows.Forms.TabPage();
            this.processorOpen = new System.Windows.Forms.Button();
            this.determinerOpen = new System.Windows.Forms.Button();
            this.processorFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.determinerFile = new System.Windows.Forms.TextBox();
            this.openFileDialogDeterminer = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogProcessor = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.advancedTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.homeTab);
            this.tabControl1.Controls.Add(this.optionsTab);
            this.tabControl1.Controls.Add(this.advancedTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // homeTab
            // 
            this.homeTab.Location = new System.Drawing.Point(4, 22);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(767, 399);
            this.homeTab.TabIndex = 0;
            this.homeTab.Text = "Launcher";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // optionsTab
            // 
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(767, 399);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // advancedTab
            // 
            this.advancedTab.Controls.Add(this.processorOpen);
            this.advancedTab.Controls.Add(this.determinerOpen);
            this.advancedTab.Controls.Add(this.processorFile);
            this.advancedTab.Controls.Add(this.label2);
            this.advancedTab.Controls.Add(this.label1);
            this.advancedTab.Controls.Add(this.determinerFile);
            this.advancedTab.Location = new System.Drawing.Point(4, 22);
            this.advancedTab.Name = "advancedTab";
            this.advancedTab.Size = new System.Drawing.Size(767, 399);
            this.advancedTab.TabIndex = 2;
            this.advancedTab.Text = "Advanced";
            this.advancedTab.UseVisualStyleBackColor = true;
            // 
            // processorOpen
            // 
            this.processorOpen.Location = new System.Drawing.Point(565, 96);
            this.processorOpen.Name = "processorOpen";
            this.processorOpen.Size = new System.Drawing.Size(75, 23);
            this.processorOpen.TabIndex = 5;
            this.processorOpen.Text = "Open";
            this.processorOpen.UseVisualStyleBackColor = true;
            this.processorOpen.Click += new System.EventHandler(this.processorOpen_Click);
            // 
            // determinerOpen
            // 
            this.determinerOpen.Location = new System.Drawing.Point(565, 34);
            this.determinerOpen.Name = "determinerOpen";
            this.determinerOpen.Size = new System.Drawing.Size(75, 23);
            this.determinerOpen.TabIndex = 4;
            this.determinerOpen.Text = "Open";
            this.determinerOpen.UseVisualStyleBackColor = true;
            this.determinerOpen.Click += new System.EventHandler(this.determinerOpen_Click);
            // 
            // processorFile
            // 
            this.processorFile.Location = new System.Drawing.Point(17, 98);
            this.processorFile.Name = "processorFile";
            this.processorFile.Size = new System.Drawing.Size(542, 20);
            this.processorFile.TabIndex = 3;
            this.processorFile.Text = "./HatcoFilesClosedProcessor.exe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Processor Program File Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Determiner Program File Location";
            // 
            // determinerFile
            // 
            this.determinerFile.Location = new System.Drawing.Point(17, 36);
            this.determinerFile.Name = "determinerFile";
            this.determinerFile.Size = new System.Drawing.Size(542, 20);
            this.determinerFile.TabIndex = 0;
            this.determinerFile.Text = "./HatcoFilesClosedDeterminer.exe";
            // 
            // openFileDialogDeterminer
            // 
            this.openFileDialogDeterminer.FileName = "openFileDialog1";
            // 
            // openFileDialogProcessor
            // 
            this.openFileDialogProcessor.FileName = "openFileDialog1";
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
            this.advancedTab.ResumeLayout(false);
            this.advancedTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.TabPage advancedTab;
        private System.Windows.Forms.Button processorOpen;
        private System.Windows.Forms.Button determinerOpen;
        private System.Windows.Forms.TextBox processorFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox determinerFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogDeterminer;
        private System.Windows.Forms.OpenFileDialog openFileDialogProcessor;
    }
}

