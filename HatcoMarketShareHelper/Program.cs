using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace HatcoMarketShareHelper
{
    static class Program
    {
        // global variables used for determiner processing.
        // these variables are global in order to prevent memory leak issue.
        public static Excel.Application xlApp = null;
        public static Excel.Workbook xlWorkbookMLS = null;
        public static Excel.Workbook xlWorkbookAIM = null;
        public static Excel.Worksheet xlWorksheetMLS = null;
        public static Excel.Worksheet xlWorksheetAIM = null;
        public static Excel.Range xlRangeMLS = null;
        public static Excel.Range xlRangeAIM = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();

            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(form);
        }

        /// <summary>
        /// Close all Excel processes running on the MLS, and AIM files on application exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnApplicationExit(object sender, EventArgs e)
        {
            //Process[] procs = Process.GetProcessesByName("EXCEL"); // get all excel processes on the system
            //Console.WriteLine(procs);
            //Form1 app = (Form1)sender;
            //string[] files = { "mls", "aim" };

            //foreach (var proc in procs)
            //{
            //    proc.Kill(); // close all excel processes on the system
            //}

            // release com objects if they exist so the excel processes
            // are fully killed from running in the background
            if (xlRangeMLS != null) Marshal.ReleaseComObject(xlRangeMLS);
            if (xlRangeAIM != null) Marshal.ReleaseComObject(xlRangeAIM);
            if (xlWorksheetMLS != null) Marshal.ReleaseComObject(xlWorksheetMLS);
            if (xlWorksheetAIM != null) Marshal.ReleaseComObject(xlWorksheetAIM);

            // save, close, and release workbooks if they exist
            if (xlWorkbookMLS != null)
            {
                xlWorkbookMLS.Close();
                Console.WriteLine("closed MLS workbook");
                Marshal.ReleaseComObject(xlWorkbookMLS);
            }
            if (xlWorkbookAIM != null)
            {
                xlWorkbookAIM.Close();
                Console.WriteLine("closed AIM workbook");
                Marshal.ReleaseComObject(xlWorkbookAIM);
            }

            // quit and release excel app if it exists
            if (xlApp != null)
            {
                xlApp.Quit();
                Console.WriteLine("quit Excel app");
                Marshal.ReleaseComObject(xlApp);
            }

            xlApp = null;
            xlWorkbookMLS = null;
            xlWorkbookAIM = null;
            xlWorksheetMLS = null;
            xlWorksheetAIM = null;
            xlRangeMLS = null;
            xlRangeAIM = null;

            Console.WriteLine("Exiting Winform App.");
        }
    }
}
