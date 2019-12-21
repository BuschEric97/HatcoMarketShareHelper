using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HatcoMarketShareHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openMLSFile_Determiner_Click(object sender, EventArgs e)
        {
            openFileDialogMLS.ShowHelp = true;
            openFileDialogMLS.ShowDialog();
            MLSInputFile_Determiner.Text = openFileDialogMLS.FileName;
            if (sameMLSFiles.Checked)
                MLSInputFile_Processor.Text = openFileDialogMLS.FileName;
        }

        private void openAIMFile_Click(object sender, EventArgs e)
        {
            openFileDialogAIM.ShowHelp = true;
            openFileDialogAIM.ShowDialog();
            AIMInputFile.Text = openFileDialogAIM.FileName;
        }

        private void openMLSFile_Processor_Click(object sender, EventArgs e)
        {
            openFileDialogMLS.ShowHelp = true;
            openFileDialogMLS.ShowDialog();
            MLSInputFile_Processor.Text = openFileDialogMLS.FileName;
            if (sameMLSFiles.Checked)
                MLSInputFile_Determiner.Text = openFileDialogMLS.FileName;
        }

        private void sameMLSFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (sameMLSFiles.Checked)
                MLSInputFile_Processor.Text = MLSInputFile_Determiner.Text;
        }

        private async void runDeterminer_Click(object sender, EventArgs e)
        {
            Determiner det = new Determiner();
            var watch = new System.Diagnostics.Stopwatch();
            determinerProgressBar.Maximum = 100;
            determinerProgressBar.Minimum = 0;
            var progress = new Progress<int>(v =>
            {
                determinerProgressBar.Increment(v);
            });

            try
            {
                // run main determiner function to perform the main function of the program
                determinerProgressBar.Value = determinerProgressBar.Minimum;
                watch.Start();
                await Task.Run(() => det.mainDeterminer(MLSInputFile_Determiner.Text, AIMInputFile.Text,
                    0.25, 0.4, 0.25, 0.4, progress, this));
                watch.Stop();
                determinerProgressBar.Value = determinerProgressBar.Maximum;
                MessageBox.Show("Complete!\nTime elapsed: " + watch.Elapsed);
            }
            catch (Exception ex)
            {
                // display any exceptions that are thrown as a popup message box
                MessageBox.Show(ex.ToString());
            }
        }

        private async void runProcessor_Click(object sender, EventArgs e)
        {
            Processor proc = new Processor();
            var watch = new System.Diagnostics.Stopwatch();
            processorProgressBar.Visible = true;
            processorProgressBar.Maximum = 100;
            processorProgressBar.Minimum = 0;
            var progress = new Progress<int>(v =>
            {
                processorProgressBar.Increment(v);
            });

            try
            {
                watch.Start();
                await Task.Run(() => proc.mainProcessor(MLSInputFile_Processor.Text,
                    includeNonMLSAgent.Checked, progress, this));
                watch.Stop();
                MessageBox.Show("Complete!\nTime elapsed: " + watch.Elapsed);
            }
            catch (Exception ex)
            {
                // display any exceptions that are thrown as a popup message box
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
