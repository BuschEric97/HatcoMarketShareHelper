using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HatcoMarketShareHelper
{
    class Processor
    {
        public void mainProcessor(string MLSFileName, bool includeNonMLS, bool runAsCapstone, bool doSubtotals,
            IProgress<int> progress, Form1 form)
        {
            Application.UseWaitCursor = true; // set the cursor to waiting symbol

            // open all excel files for use
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbookMLS = null;
            try
            {
                xlWorkbookMLS = xlApp.Workbooks.Open(MLSFileName);
            }
            catch (Exception ex) // catch possible "file could not open" exception
            {
                throw ex;
            }

            if (xlWorkbookMLS != null)
            {
                // open worksheets and range in excel files for use
                Excel._Worksheet xlWorksheet1MLS = xlWorkbookMLS.Sheets[1];
                xlWorksheet1MLS.Name = "RawMLSData";
                xlWorkbookMLS.Sheets.Add(After:xlWorkbookMLS.Sheets[xlWorkbookMLS.Sheets.Count], Count:2);
                Excel._Worksheet xlWorksheet2MLS = xlWorkbookMLS.Sheets[2];
                xlWorksheet2MLS.Name = "AgentCombined";
                Excel._Worksheet xlWorksheet3MLS = xlWorkbookMLS.Sheets[3];
                xlWorksheet3MLS.Name = "BrokerCombined";
                Excel.Range xlRange1MLS = xlWorksheet1MLS.UsedRange;
                Excel.Range xlRange2MLS = xlApp.Range[xlWorksheet2MLS.Cells[1, 1], xlWorksheet2MLS.Cells[1, 1]];
                Excel.Range xlRange3MLS = xlApp.Range[xlWorksheet3MLS.Cells[1, 1], xlWorksheet3MLS.Cells[1, 1]];

                Dictionary<string, int> rangeCount = new Dictionary<string, int>();
                Dictionary<string, int> relevantCols = new Dictionary<string, int>();

                try
                {
                    rangeCount.Add("rowCount1MLS", xlRange1MLS.Rows.Count);
                    rangeCount.Add("colCount1MLS", xlRange1MLS.Columns.Count);

                    Console.WriteLine("rowCount1MLS: " + rangeCount["rowCount1MLS"]);
                    Console.WriteLine("colCount1MLS: " + rangeCount["colCount1MLS"]);

                    // relevant columns indeces for sheet 1
                    relevantCols.Add("MLSSellAgentCol1", 0);
                    relevantCols.Add("MLSSellOfficeCol1", 0);
                    relevantCols.Add("MLSListAgentCol1", 0);
                    relevantCols.Add("MLSListOfficeCol1", 0);
                    relevantCols.Add("MLSOwnerCol1", 0);
                    relevantCols.Add("MLSCityCol1", 0);
                    relevantCols.Add("MLSZipCol1", 0);
                    relevantCols.Add("MLSAddressCol1", 0);
                    relevantCols.Add("MLSCloseDateCol1", 0);
                    relevantCols.Add("MLSPriceCol1", 0);
                    relevantCols.Add("MLSGFCol1", 0);
                    relevantCols.Add("MLSEscrowCol1", 0);
                    relevantCols.Add("MLSRegionCol1", 0);
                    relevantCols.Add("MLSHighSchoolCol1", 0);
                    relevantCols.Add("MLSTitleCoCol1", 0);
                    // relevant columns indeces for sheet 2
                    relevantCols.Add("MLSAgentCol2", 1);
                    relevantCols.Add("MLSOfficeCol2", 2);
                    relevantCols.Add("MLSOwnerCol2", 3);
                    relevantCols.Add("MLSCityCol2", 4);
                    relevantCols.Add("MLSZipCol2", 5);
                    relevantCols.Add("MLSAddressCol2", 6);
                    relevantCols.Add("MLSCloseDateCol2", 7);
                    relevantCols.Add("MLSPriceCol2", 8);
                    relevantCols.Add("MLSGFCol2", 9);
                    relevantCols.Add("MLSEscrowCol2", 10);
                    relevantCols.Add("MLSRegionCol2", 11);
                    relevantCols.Add("MLSHighSchoolCol2", 12);
                    relevantCols.Add("MLSTitleCoCol2", 13);
                    relevantCols.Add("MLSAsSACol2", 14);
                    relevantCols.Add("MLSClosingsCol2", 15);
                    relevantCols.Add("MLSTCCloseCol2", 16);
                    relevantCols.Add("MLSBSClosingCol2", 17);
                    relevantCols.Add("MLSBSTCCloseCol2", 18);
                    // relevant columns indeces for sheet 3
                    relevantCols.Add("MLSAgentCol3", 1);
                    relevantCols.Add("MLSOfficeCol3", 2);
                    relevantCols.Add("MLSOwnerCol3", 3);
                    relevantCols.Add("MLSCityCol3", 4);
                    relevantCols.Add("MLSZipCol3", 5);
                    relevantCols.Add("MLSAddressCol3", 6);
                    relevantCols.Add("MLSCloseDateCol3", 7);
                    relevantCols.Add("MLSPriceCol3", 8);
                    relevantCols.Add("MLSGFCol3", 9);
                    relevantCols.Add("MLSEscrowCol3", 10);
                    relevantCols.Add("MLSRegionCol3", 11);
                    relevantCols.Add("MLSHighSchoolCol3", 12);
                    relevantCols.Add("MLSTitleCoCol3", 13);
                    relevantCols.Add("MLSAsSACol3", 14);
                    relevantCols.Add("MLSClosingsCol3", 15);
                    relevantCols.Add("MLSTCCloseCol3", 16);
                    relevantCols.Add("MLSBSClosingCol3", 17);
                    relevantCols.Add("MLSBSTCCloseCol3", 18);

                    // determine the columns in MLS file sheet 1 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount1MLS"]; i++)
                    {
                        if (xlRange1MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            string currHeaderCell = xlRange1MLS.Cells[1, i].Value2.ToString().ToLower();

                            if (currHeaderCell.Contains("selling agent"))
                                relevantCols["MLSSellAgentCol1"] = i;
                            else if (currHeaderCell.Contains("selling office"))
                                relevantCols["MLSSellOfficeCol1"] = i;
                            else if (currHeaderCell.Contains("listing agent"))
                                relevantCols["MLSListAgentCol1"] = i;
                            else if (currHeaderCell.Contains("listing office"))
                                relevantCols["MLSListOfficeCol1"] = i;
                            else if (currHeaderCell.Contains("owner"))
                                relevantCols["MLSOwnerCol1"] = i;
                            else if (currHeaderCell.Contains("city"))
                                relevantCols["MLSCityCol1"] = i;
                            else if (currHeaderCell.Contains("zip"))
                                relevantCols["MLSZipCol1"] = i;
                            else if (currHeaderCell.Contains("address"))
                                relevantCols["MLSAddressCol1"] = i;
                            else if (currHeaderCell.Contains("close date"))
                                relevantCols["MLSCloseDateCol1"] = i;
                            else if (currHeaderCell.Contains("price"))
                                relevantCols["MLSPriceCol1"] = i;
                            else if (currHeaderCell.Contains("gf"))
                                relevantCols["MLSGFCol1"] = i;
                            else if (currHeaderCell.Contains("escrow"))
                                relevantCols["MLSEscrowCol1"] = i;
                            else if (currHeaderCell.Contains("region"))
                                relevantCols["MLSRegionCol1"] = i;
                            else if (currHeaderCell.Contains("school"))
                                relevantCols["MLSHighSchoolCol1"] = i;
                            else if (currHeaderCell.Contains("title"))
                                relevantCols["MLSTitleCoCol1"] = i;
                        }
                    }

                    // Create column headers for additional worksheets
                    xlRange2MLS.Cells[1, 1].Value = "Agent Name";
                    xlRange2MLS.Cells[1, 2].Value = "Agent Office";
                    xlRange2MLS.Cells[1, 3].Value = "Owner";
                    xlRange2MLS.Cells[1, 4].Value = "City";
                    xlRange2MLS.Cells[1, 5].Value = "Zip";
                    xlRange2MLS.Cells[1, 6].Value = "Address";
                    xlRange2MLS.Cells[1, 7].Value = "Closing Date";
                    xlRange2MLS.Cells[1, 8].Value = "Price";
                    xlRange2MLS.Cells[1, 9].Value = "GF #";
                    xlRange2MLS.Cells[1, 10].Value = "Escrow Officer";
                    xlRange2MLS.Cells[1, 11].Value = "Region";
                    xlRange2MLS.Cells[1, 12].Value = "High School";
                    xlRange2MLS.Cells[1, 13].Value = "Title Company";
                    xlRange2MLS.Cells[1, 14].Value = "As SA";
                    xlRange2MLS.Cells[1, 15].Value = "Closings";
                    xlRange2MLS.Cells[1, 16].Value = "TC Close";
                    xlRange2MLS.Cells[1, 17].Value = "BS Closings";
                    xlRange2MLS.Cells[1, 18].Value = "BS TC Close";

                    xlRange3MLS.Cells[1, 1].Value = "Agent Name";
                    xlRange3MLS.Cells[1, 2].Value = "Agent Office";
                    xlRange3MLS.Cells[1, 3].Value = "Owner";
                    xlRange3MLS.Cells[1, 4].Value = "City";
                    xlRange3MLS.Cells[1, 5].Value = "Zip";
                    xlRange3MLS.Cells[1, 6].Value = "Address";
                    xlRange3MLS.Cells[1, 7].Value = "Closing Date";
                    xlRange3MLS.Cells[1, 8].Value = "Price";
                    xlRange3MLS.Cells[1, 9].Value = "GF #";
                    xlRange3MLS.Cells[1, 10].Value = "Escrow Officer";
                    xlRange3MLS.Cells[1, 11].Value = "Region";
                    xlRange3MLS.Cells[1, 12].Value = "High School";
                    xlRange3MLS.Cells[1, 13].Value = "Title Company";
                    xlRange3MLS.Cells[1, 14].Value = "As SA";
                    xlRange3MLS.Cells[1, 15].Value = "Closings";
                    xlRange3MLS.Cells[1, 16].Value = "TC Close";
                    xlRange3MLS.Cells[1, 17].Value = "BS Closings";
                    xlRange3MLS.Cells[1, 18].Value = "BS TC Close";

                    ProcessorWork proc = new ProcessorWork();
                    proc.processorWork(xlWorksheet1MLS, xlWorksheet2MLS, xlWorksheet3MLS,
                        xlRange1MLS, xlRange2MLS, xlRange3MLS, rangeCount, relevantCols,
                        includeNonMLS, runAsCapstone, doSubtotals, progress, form);
                }
                catch (Exception ex) // if an exception is caught, close the excel files so they aren't held hostage
                {
                    Console.WriteLine("Problem with determiner processing. Closing excel files.");
                    Console.WriteLine(ex);

                    // cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // release com objects so the excel processes are
                    // fully killed from running in the background
                    Marshal.ReleaseComObject(xlRange1MLS);
                    Marshal.ReleaseComObject(xlRange2MLS);
                    Marshal.ReleaseComObject(xlRange3MLS);
                    Marshal.ReleaseComObject(xlWorksheet1MLS);
                    Marshal.ReleaseComObject(xlWorksheet2MLS);
                    Marshal.ReleaseComObject(xlWorksheet3MLS);

                    // save, close, and release workbooks
                    xlWorkbookMLS.Close();
                    Console.WriteLine("closed MLS workbook");
                    Marshal.ReleaseComObject(xlWorkbookMLS);

                    // quit and release excel app
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                    throw ex;
                }

                // cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                // release com objects so the excel processes are
                // fully killed from running in the background
                Marshal.ReleaseComObject(xlRange1MLS);
                Marshal.ReleaseComObject(xlRange2MLS);
                Marshal.ReleaseComObject(xlRange3MLS);
                Marshal.ReleaseComObject(xlWorksheet1MLS);
                Marshal.ReleaseComObject(xlWorksheet2MLS);
                Marshal.ReleaseComObject(xlWorksheet3MLS);

                // save, close, and release workbooks
                xlWorkbookMLS.Save();
                Console.WriteLine("saved MLS workbook");
                xlWorkbookMLS.Close();
                Console.WriteLine("closed MLS workbook");
                Marshal.ReleaseComObject(xlWorkbookMLS);

                // quit and release excel app
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }

            Application.UseWaitCursor = false; // set the cursor back to default
        }
    }
}
