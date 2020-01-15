using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HatcoMarketShareHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            EventHandlers handlers = new EventHandlers();

            Application.ApplicationExit += new EventHandler(handlers.OnApplicationExit);
            Application.Run(form);
        }
    }

    public class EventHandlers
    {
        /// <summary>
        /// Close all Excel processes running on the MLS, and AIM files on application exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnApplicationExit(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName("EXCEL"); // get all excel processes on the system
            Console.WriteLine(procs);
            Form1 app = (Form1)sender;
            //string[] MLS1 = app.MLSInputFile_Processor.Text.Split('\\');
            //string[] MLS2 = app.MLSInputFile_Determiner.Text.Split('\\');
            //string[] AIM = app.AIMInputFile.Text.Split('\\');
            //string[] files = {MLS1.Last(), MLS2.Last(), AIM.Last()}; 
            string[] files = {"mls", "aim"};
            
            foreach (var proc in procs)
            {
                //string procTitle = proc.MainWindowTitle.ToLower();

                //foreach (string file in files)
                //{
                //    if (procTitle.Contains(file))
                //    {
                //        proc.Close(); // close the excel process if it is operating on one of the three program files
                //        Console.WriteLine("Closing Excel process on file containing: \"" + file + "\"");
                //    }
                //}

                proc.Kill(); // close all excel processes on the system
            }

            Console.WriteLine("Exiting Winform App.");
        }
    }
}
