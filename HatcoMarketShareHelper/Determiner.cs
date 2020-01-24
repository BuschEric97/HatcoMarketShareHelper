using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace HatcoMarketShareHelper
{
    public class Determiner
    {
        /// <summary>
        /// run through each file in MLSFileName and check against AIMFileName files
        /// to determine whether the files in MLSFileName closed with hatco.
        /// </summary>
        /// <param name="MLSFileName"></param>
        /// <param name="AIMFileName"></param>
        /// <param name="addressThreshold"></param>
        /// <param name="ownerThreshold"></param>
        public void mainDeterminer(string MLSFileName, string AIMFileName, double addressThreshold,
            double addressThresholdWeak, double ownerThreshold, double ownerThresholdWeak,
            Form1 form)
        {
            Application.UseWaitCursor = true; // set the cursor to waiting symbol

            // open all excel files for use
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbookMLS = null;
            //Excel.Workbook xlWorkbookAIM = null;
            Program.xlApp = new Excel.Application();
            try
            {
                Program.xlWorkbookMLS = Program.xlApp.Workbooks.Open(MLSFileName);
                Program.xlWorkbookAIM = Program.xlApp.Workbooks.Open(AIMFileName);
            }
            catch (Exception ex) // catch possible "file could not open" exception
            {
                throw ex;
            }

            if (Program.xlWorkbookAIM != null && Program.xlWorkbookMLS != null) // check that excel files opened properly
            {
                // open worksheets and range in excel files for use
                Program.xlWorksheetMLS = Program.xlWorkbookMLS.Sheets[1];
                Program.xlWorksheetAIM = Program.xlWorkbookAIM.Sheets[1];
                Program.xlRangeMLS = Program.xlWorksheetMLS.UsedRange;
                Program.xlRangeAIM = Program.xlWorksheetAIM.UsedRange;

                Dictionary<string, int> rangeCount = new Dictionary<string, int>();
                Dictionary<string, int> relevantCols = new Dictionary<string, int>();
                Dictionary<string, double> thresholds = new Dictionary<string, double>();
                thresholds.Add("addressThreshold", addressThreshold);
                thresholds.Add("addressThresholdWeak", addressThresholdWeak);
                thresholds.Add("ownerThreshold", ownerThreshold);
                thresholds.Add("ownerThresholdWeak", ownerThresholdWeak);

                try
                {
                    // do the main processing on the excel files and catch any exceptions that are thrown
                    // get the range of rows and columns for AIM excel file
                    rangeCount.Add("rowCountMLS", Program.xlRangeMLS.Rows.Count);
                    rangeCount.Add("colCountMLS", Program.xlRangeMLS.Columns.Count);
                    rangeCount.Add("rowCountAIM", Program.xlRangeAIM.Rows.Count);
                    rangeCount.Add("colCountAIM", Program.xlRangeAIM.Columns.Count);

                    // relevant columns indeces
                    relevantCols.Add("MLSOwnerCol", 0);
                    relevantCols.Add("MLSAddressCol", 0);
                    relevantCols.Add("MLSCloseDateCol", 0);
                    relevantCols.Add("MLSGFCol", 0);
                    relevantCols.Add("MLSZipCol", 0);
                    relevantCols.Add("AIMFileNoCol", 0);
                    relevantCols.Add("AIMCloseDateCol", 0);
                    relevantCols.Add("AIMAddressCol", 0);
                    relevantCols.Add("AIMSellerCol", 0);
                    relevantCols.Add("AIMEscrowCol", 0);
                    relevantCols.Add("AIMZipCol", 0);

                    // determine the columns in MLS file that have relevant information
                    for (int i = 1; i <= rangeCount["colCountMLS"]; i++)
                    {
                        if (Program.xlRangeMLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            if (Program.xlRangeMLS.Cells[1, i].Value2.ToString().Contains("Owner"))
                                relevantCols["MLSOwnerCol"] = i;
                            else if (Program.xlRangeMLS.Cells[1, i].Value2.ToString().Contains("Address"))
                                relevantCols["MLSAddressCol"] = i;
                            else if (Program.xlRangeMLS.Cells[1, i].Value2.ToString().Contains("Close Date"))
                                relevantCols["MLSCloseDateCol"] = i;
                            else if (Program.xlRangeMLS.Cells[1, i].Value2.ToString().Contains("GF"))
                                relevantCols["MLSGFCol"] = i;
                            else if (Program.xlRangeMLS.Cells[1, i].Value2.ToString().Contains("Zip"))
                                relevantCols["MLSZipCol"] = i;
                        }
                    }

                    // determine the columns in AIM file that have relevant information
                    for (int i = 1; i <= rangeCount["colCountAIM"]; i++)
                    {
                        if (Program.xlRangeAIM.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("File Number"))
                                relevantCols["AIMFileNoCol"] = i;
                            else if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("Date"))
                                relevantCols["AIMCloseDateCol"] = i;
                            else if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("Property Address"))
                                relevantCols["AIMAddressCol"] = i;
                            else if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("Seller"))
                                relevantCols["AIMSellerCol"] = i;
                            else if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("Escrow"))
                                relevantCols["AIMEscrowCol"] = i;
                            else if (Program.xlRangeAIM.Cells[1, i].Value2.ToString().Contains("Zip"))
                                relevantCols["AIMZipCol"] = i;
                        }
                    }

                    // add new columns to MLS file
                    relevantCols.Add("MLSLikelyCloseCol", rangeCount["colCountMLS"] + 1);
                    relevantCols.Add("MLSEscrowOfficerCol", rangeCount["colCountMLS"] + 2);
                    Program.xlRangeMLS.Cells[1, relevantCols["MLSLikelyCloseCol"]].Value = "Likely Closed";
                    Program.xlRangeMLS.Cells[1, relevantCols["MLSEscrowOfficerCol"]].Value = "Escrow Officer";

                    // set up the progress bar
                    MethodInvoker inv = delegate
                    {
                        form.determinerProgressBar.Maximum = rangeCount["rowCountMLS"];
                    };
                    form.Invoke(inv);

                    // run the determiner work
                    DeterminerWork det = new DeterminerWork();
                    int statusCode = det.determinerDoWork(rangeCount, relevantCols, thresholds, form);
                    if (statusCode > 0)
                        throw new Exception("Determiner work returned status code " + statusCode);
                }
                catch (Exception ex) // if an exception is caught, close the excel files so they aren't held hostage
                {
                    Console.WriteLine("Problem with determiner processing. Closing excel files.");

                    try
                    {
                        // cleanup
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        // release com objects if they exist so the excel processes
                        // are fully killed from running in the background
                        Marshal.ReleaseComObject(Program.xlRangeMLS);
                        Marshal.ReleaseComObject(Program.xlRangeAIM);
                        Marshal.ReleaseComObject(Program.xlWorksheetMLS);
                        Marshal.ReleaseComObject(Program.xlWorksheetAIM);

                        // save, close, and release workbooks if they exist
                        Program.xlWorkbookMLS.Close();
                        Console.WriteLine("closed MLS workbook");
                        Marshal.ReleaseComObject(Program.xlWorkbookMLS);
                        Program.xlWorkbookAIM.Close();
                        Console.WriteLine("closed AIM workbook");
                        Marshal.ReleaseComObject(Program.xlWorkbookAIM);

                        // quit and release excel app if it exists
                        Program.xlApp.Quit();
                        Console.WriteLine("quit Excel app");
                        Marshal.ReleaseComObject(Program.xlApp);
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee);
                    }

                    MessageBox.Show(ex.ToString());
                    return;
                }

                // cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // release com objects so the excel processes are
                // fully killed from running in the background
                Marshal.ReleaseComObject(Program.xlRangeMLS);
                Marshal.ReleaseComObject(Program.xlRangeAIM);
                Marshal.ReleaseComObject(Program.xlWorksheetMLS);
                Marshal.ReleaseComObject(Program.xlWorksheetAIM);

                // save, close, and release workbooks
                Program.xlWorkbookMLS.Save();
                Console.WriteLine("saved MLS workbook");
                Program.xlWorkbookMLS.Close();
                Console.WriteLine("closed MLS workbook");
                Program.xlWorkbookAIM.Close();
                Console.WriteLine("closed AIM workbook");
                Marshal.ReleaseComObject(Program.xlWorkbookMLS);
                Marshal.ReleaseComObject(Program.xlWorkbookAIM);

                // quit and release excel app
                Program.xlApp.Quit();
                Marshal.ReleaseComObject(Program.xlApp);
            }

            Application.UseWaitCursor = false; // set cursor back to default
        }
    }
}