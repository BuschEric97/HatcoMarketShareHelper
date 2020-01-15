﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HatcoMarketShareHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            configFile.Text = Environment.CurrentDirectory + "\\config.txt";
            numThreads.Value = Environment.ProcessorCount;
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

        private void openConfigFile_Click(object sender, EventArgs e)
        {
            openFileDialogConfig.ShowHelp = true;
            openFileDialogConfig.ShowDialog();
            configFile.Text = openFileDialogConfig.FileName;
        }

        private async void runDeterminer_Click(object sender, EventArgs e)
        {
            Determiner det = new Determiner();
            var watch = new System.Diagnostics.Stopwatch();
            determinerProgressBar.Maximum = 100;
            determinerProgressBar.Minimum = 0;

            try
            {
                // run main determiner function to perform the main function of the program
                determinerProgressBar.Value = determinerProgressBar.Minimum;
                watch.Start();
                await Task.Run(() => det.mainDeterminer(MLSInputFile_Determiner.Text, AIMInputFile.Text,
                    (double)addressThreshold.Value, (double)addressWeakThreshold.Value, 0.25, 0.4,
                    this, (int)numThreads.Value));
                watch.Stop();
                determinerProgressBar.Value = determinerProgressBar.Maximum;
                MessageBox.Show("Complete!\nTime elapsed: " + watch.Elapsed);
                determinerProgressDetailed.Text = "0/0";
                determinerProgressBar.Value = determinerProgressBar.Minimum;
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
            Dictionary<string, string[]> specificAreas = getSpecificAreas();

            try
            {
                processorProgressBar.Value = processorProgressBar.Minimum;
                watch.Start();
                await Task.Run(() => proc.mainProcessor(MLSInputFile_Processor.Text,
                    includeNonMLSAgent.Checked, runAsCapstone.Checked, doSubtotals.Checked,
                    specificAreas, progress, this));
                watch.Stop();
                processorProgressBar.Value = processorProgressBar.Maximum;
                MessageBox.Show("Complete!\nTime elapsed: " + watch.Elapsed);
                processorProgressDetailed.Text = "0/0";
                processorProgressBar.Value = processorProgressBar.Minimum;
            }
            catch (Exception ex)
            {
                // display any exceptions that are thrown as a popup message box
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// get the data from the configuration file as a dictionary of string arrays
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string[]> getSpecificAreas()
        {
            Dictionary<string, string[]> specificAreas = new Dictionary<string, string[]>();

            if (File.Exists(configFile.Text))
            {
                using (StreamReader sr = File.OpenText(configFile.Text))
                {
                    string configLine;
                    while ((configLine = sr.ReadLine()) != null)
                    {
                        string[] specificArea = configLine.Split(':');
                        specificAreas.Add(specificArea[0], specificArea[1].Split(','));
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: Configuration file does not exist at given path:\n" +
                    configFile.Text);
            }

            return specificAreas;
        }

        private void refreshConfigData_Click(object sender, EventArgs e)
        {
            if (File.Exists(configFile.Text))
            {
                using (StreamReader sr = File.OpenText(configFile.Text))
                {
                    string configLine = sr.ReadLine();
                    configData.Text = configLine;
                    while ((configLine = sr.ReadLine()) != null)
                    {
                        configData.Text = configData.Text + " " + configLine;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: Configuration file does not exist at given path:\n" +
                    configFile.Text);
            }
        }

        private void saveConfigData_Click(object sender, EventArgs e)
        {
            if (File.Exists(configFile.Text))
            {
                string[] configLines = configData.Text.Split(' ');
                File.WriteAllLines(configFile.Text, configLines);
                MessageBox.Show("Successfully saved configuration file!");
            }
            else
            {
                MessageBox.Show("Error: Configuration file does not exist at given path:\n" +
                    configFile.Text);
            }
        }

        private void setNumThreads_Click(object sender, EventArgs e)
        {
            numThreads.Value = Environment.ProcessorCount;
        }

        private void determinerSettingsHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MLS Input File: This is the input file for MLS data" +
                            "\n\tas well as the output file for determiner results" + "\n\n" +
                            "AIM Input File: This is the input file for AIM data" + "\n\n" +
                            "Number of threads: This is the amount of processor cores" +
                            "\n\tthe determiner will use to process the results. Default" +
                            "\n\tvalue is the maximum number of cores in the system" + "\n\n" +
                            "Address threshold: This is the threshold for string difference" +
                            "\n\twhen comparing addresses between MLS and AIM data. This" +
                            "\n\tshouldn't need to be changed." + "\n\n" +
                            "Address secondary threshold: This is the fallback threshold for" +
                            "\n\tif the main threshold doesn't detect a match. Will mark as" +
                            "\n\tlikely match if matched with this threshold. This shouldn't" +
                            "\n\tneed to be changed.");

        }

        private void processorSettingsHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MLS Input File: This is the input file for MLS data" +
                            "\n\tas well as the output file for processor results" + "\n\n" +
                            "Include Non-MLS Agent: When unchecked, processor will" +
                            "\n\tomit any record with agent as \"Non-MLS Agent\" on" +
                            "\n\tHATCo data and omit any record with agent as" +
                            "\n\t\"Non Member\" on Capstone data");
        }

        private void miscSettingsHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MLS input files are the same: Checking this box will" +
                            "\n\tenforce that the MLS input files are the same" +
                            "\n\tacross both the determiner and processor" + "\n\n" +
                            "Run as Capstone: Checking this box will modify processing" +
                            "\n\tto represent results for Capstone needs" + "\n\n" +
                            "Do sorting and subtotals: When unchecked, processor" +
                            "\n\twill skip sorting and subtotaling");
        }

        private void configSettingsHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The config file holds the zip codes for the specified" +
                            "\nareas for the processor. The processor uses these" +
                            "\nzip codes/areas to generate additional worksheets." +
                            "\n\nPress the \"Refresh\" button to load the contents" +
                            "\nof the config file into the editor if changes need" +
                            "\nto be made. Then click the \"Save\" button to write" +
                            "\nthose changes to the config file" +
                            "\n\nPlease use the following format exactly or else the" +
                            "\nprocessor will crash:" +
                            "\n\tExampleArea1:12345,23456 ExampleArea2:09876,98765,87654 ...");
        }
    }
}
