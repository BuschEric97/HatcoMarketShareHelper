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
        public void mainProcessor(string MLSFileName, bool includeNonMLS,
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
                Excel._Worksheet xlWorksheet2MLS = xlWorkbookMLS.Sheets[2];
                Excel._Worksheet xlWorksheet3MLS = xlWorkbookMLS.Sheets[3];
                Excel.Range xlRange1MLS = xlWorksheet1MLS.UsedRange;
                Excel.Range xlRange2MLS = xlWorksheet2MLS.UsedRange;
                Excel.Range xlRange3MLS = xlWorksheet3MLS.UsedRange;

                Dictionary<string, int> rangeCount = new Dictionary<string, int>();
                Dictionary<string, int> relevantCols = new Dictionary<string, int>();

                try
                {
                    rangeCount.Add("rowCount1MLS", xlRange1MLS.Rows.Count);
                    rangeCount.Add("rowCount2MLS", xlRange2MLS.Rows.Count);
                    rangeCount.Add("rowCount3MLS", xlRange3MLS.Rows.Count);
                    rangeCount.Add("colCount1MLS", xlRange1MLS.Columns.Count);
                    rangeCount.Add("colCount2MLS", xlRange2MLS.Columns.Count);
                    rangeCount.Add("colCount3MLS", xlRange3MLS.Columns.Count);

                    Console.WriteLine("Worksheet 1: " + rangeCount["colCount1MLS"] + "x" + rangeCount["rowCount1MLS"]);
                    Console.WriteLine("Worksheet 2: " + rangeCount["colCount2MLS"] + "x" + rangeCount["rowCount2MLS"]);
                    Console.WriteLine("Worksheet 3: " + rangeCount["colCount3MLS"] + "x" + rangeCount["rowCount3MLS"]);

                    // relevant columns indeces for sheet 1
                    relevantCols.Add("MLSSellAgentCol1", 0);
                    relevantCols.Add("MLSSellOfficeCol1", 0);
                    relevantCols.Add("MLSListAgentCol1", 0);
                    relevantCols.Add("MLSListOfficeCol1", 0);
                    relevantCols.Add("MLSOwnerCol1", 0);
                    relevantCols.Add("MLSCityCol1", 0);
                    relevantCols.Add("MLSAddressCol1", 0);
                    relevantCols.Add("MLSCloseDateCol1", 0);
                    relevantCols.Add("MLSPriceCol1", 0);
                    relevantCols.Add("MLSGFCol1", 0);
                    relevantCols.Add("MLSEscrowCol1", 0);
                    // relevant columns indeces for sheet 2
                    relevantCols.Add("MLSAgentCol2", 0);
                    relevantCols.Add("MLSOfficeCol2", 0);
                    relevantCols.Add("MLSOtherAgentCol2", 0);
                    relevantCols.Add("MLSOtherOfficeCol2", 0);
                    relevantCols.Add("MLSOwnerCol2", 0);
                    relevantCols.Add("MLSCityCol2", 0);
                    relevantCols.Add("MLSAddressCol2", 0);
                    relevantCols.Add("MLSCloseDateCol2", 0);
                    relevantCols.Add("MLSPriceCol2", 0);
                    relevantCols.Add("MLSGFCol2", 0);
                    relevantCols.Add("MLSEscrowCol2", 0);
                    relevantCols.Add("MLSAsSACol2", 0);
                    relevantCols.Add("MLSClosingsCol2", 0);
                    relevantCols.Add("MLSTCCloseCol2", 0);
                    relevantCols.Add("MLSBSClosingCol2", 0);
                    relevantCols.Add("MLSBSTCCloseCol2", 0);
                    // relevant columns indeces for sheet 3
                    relevantCols.Add("MLSAgentCol3", 0);
                    relevantCols.Add("MLSOfficeCol3", 0);
                    relevantCols.Add("MLSOwnerCol3", 0);
                    relevantCols.Add("MLSCityCol3", 0);
                    relevantCols.Add("MLSAddressCol3", 0);
                    relevantCols.Add("MLSCloseDateCol3", 0);
                    relevantCols.Add("MLSPriceCol3", 0);
                    relevantCols.Add("MLSGFCol3", 0);
                    relevantCols.Add("MLSEscrowCol3", 0);
                    relevantCols.Add("MLSAsSACol3", 0);
                    relevantCols.Add("MLSClosingsCol3", 0);
                    relevantCols.Add("MLSTCCloseCol3", 0);
                    relevantCols.Add("MLSBSClosingCol3", 0);
                    relevantCols.Add("MLSBSTCCloseCol3", 0);

                    // determine the columns in MLS file sheet 1 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount1MLS"]; i++)
                    {
                        if (xlRange1MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Selling"))
                                relevantCols["MLSSellAgentCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("SA "))
                                relevantCols["MLSSellOfficeCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Listing"))
                                relevantCols["MLSListAgentCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("LA "))
                                relevantCols["MLSListOfficeCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Owner"))
                                relevantCols["MLSOwnerCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("City"))
                                relevantCols["MLSCityCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Address"))
                                relevantCols["MLSAddressCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Close Date"))
                                relevantCols["MLSCloseDateCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Price"))
                                relevantCols["MLSPriceCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("GF"))
                                relevantCols["MLSGFCol1"] = i;
                            else if (xlRange1MLS.Cells[1, i].Value2.ToString().Contains("Escrow"))
                                relevantCols["MLSEscrowCol1"] = i;
                        }
                    }
                    // determine the columns in MLS file sheet 1 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount2MLS"]; i++)
                    {
                        if (xlRange2MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Agent Name") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Other"))
                                relevantCols["MLSAgentCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Agent Office") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Other"))
                                relevantCols["MLSOfficeCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Other Agent Name"))
                                relevantCols["MLSOtherAgentCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Other Agent Office"))
                                relevantCols["MLSOtherOfficeCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Owner"))
                                relevantCols["MLSOwnerCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("City"))
                                relevantCols["MLSCityCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Address"))
                                relevantCols["MLSAddressCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Close Date"))
                                relevantCols["MLSCloseDateCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Price"))
                                relevantCols["MLSPriceCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("GF"))
                                relevantCols["MLSGFCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Escrow"))
                                relevantCols["MLSEscrowCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("As SA"))
                                relevantCols["MLSAsSACol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("Closings") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS"))
                                relevantCols["MLSClosingsCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("TC Close") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS"))
                                relevantCols["MLSTCCloseCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS Closings"))
                                relevantCols["MLSBSClosingCol2"] = i;
                            else if (xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS TC Close"))
                                relevantCols["MLSBSTCCloseCol2"] = i;
                        }
                    }
                    // determine the columns in MLS file sheet 1 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount3MLS"]; i++)
                    {
                        if (xlRange3MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Agent Name"))
                                relevantCols["MLSAgentCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Agent Office"))
                                relevantCols["MLSOfficeCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Owner"))
                                relevantCols["MLSOwnerCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("City"))
                                relevantCols["MLSCityCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Address"))
                                relevantCols["MLSAddressCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Close Date"))
                                relevantCols["MLSCloseDateCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Price"))
                                relevantCols["MLSPriceCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("GF"))
                                relevantCols["MLSGFCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Escrow"))
                                relevantCols["MLSEscrowCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("As SA"))
                                relevantCols["MLSAsSACol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("Closings") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS"))
                                relevantCols["MLSClosingsCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("TC Close") &&
                                !xlRange2MLS.Cells[1, i].Value2.ToString().Contains("BS"))
                                relevantCols["MLSTCCloseCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("BS Closings"))
                                relevantCols["MLSBSClosingCol3"] = i;
                            else if (xlRange3MLS.Cells[1, i].Value2.ToString().Contains("BS TC Close"))
                                relevantCols["MLSBSTCCloseCol3"] = i;
                        }
                    }

                    ProcessorWork proc = new ProcessorWork();
                    proc.processorWork(xlWorksheet1MLS, xlWorksheet2MLS, xlWorksheet3MLS,
                        xlRange1MLS, xlRange2MLS, xlRange3MLS, rangeCount, relevantCols,
                        includeNonMLS, progress, form);
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
