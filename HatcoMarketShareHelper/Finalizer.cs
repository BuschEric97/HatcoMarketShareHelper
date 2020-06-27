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
    class Finalizer
    {
        public void mainFinalizer(string MLSFileName, int closingThreshold, double closingPercent,
            bool runAsCapstone, Dictionary<string, string[]> specificAreas, IProgress<int> progress,
            Form1 form)
        {
            Application.UseWaitCursor = true; // set the cursor to waiting symbol

            int numAgentsSheets = specificAreas.Count; // get the number of additional Agents sheets that need to be generated

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
                Excel._Worksheet xlWorksheet2MLS = xlWorkbookMLS.Sheets[2];
                Excel._Worksheet xlWorksheet3MLS = xlWorkbookMLS.Sheets[3];
                int initialSheetCount = xlWorkbookMLS.Sheets.Count;
                xlWorkbookMLS.Sheets.Add(After: xlWorkbookMLS.Sheets[xlWorkbookMLS.Sheets.Count],
                    Count: 6);
                xlWorkbookMLS.Sheets[initialSheetCount + 1].Name = "Agents";
                xlWorkbookMLS.Sheets[initialSheetCount + 2].Name = "Agents - Alpha";
                xlWorkbookMLS.Sheets[initialSheetCount + 3].Name = "Brokers";
                xlWorkbookMLS.Sheets[initialSheetCount + 4].Name = "Brokers - Alpha";
                xlWorkbookMLS.Sheets[initialSheetCount + 5].Name = "NonCust";
                xlWorkbookMLS.Sheets[initialSheetCount + 6].Name = "NonCust - Alpha";

                if (runAsCapstone)
                {
                    xlWorkbookMLS.Sheets.Add(After: xlWorkbookMLS.Sheets[xlWorkbookMLS.Sheets.Count],
                        Count: numAgentsSheets * 2);
                    for (int i = 1; i <= numAgentsSheets; i++)
                    {
                        string sheetName = "Agents (" + specificAreas.Keys.ElementAt(i - 1) +
                            ")"; // create the name of the specified worksheet
                        xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Name = sheetName;
                    }
                    for (int i = 1; i <= numAgentsSheets; i++)
                    {
                        string sheetName = "NonCust (" + specificAreas.Keys.ElementAt(i - 1) +
                            ")"; // create the name of the specified worksheet
                        xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Name = sheetName;
                    }
                }

                // open range for 2nd and 3rd excel spreadsheets
                Excel.Range xlRange2MLS = xlWorksheet2MLS.UsedRange;
                Excel.Range xlRange3MLS = xlWorksheet3MLS.UsedRange;

                Dictionary<string, int> rangeCount = new Dictionary<string, int>();
                Dictionary<string, int> relevantCols = new Dictionary<string, int>();

                try
                {
                    rangeCount.Add("rowCount2MLS", xlRange2MLS.Rows.Count);
                    rangeCount.Add("colCount2MLS", xlRange2MLS.Columns.Count);
                    rangeCount.Add("rowCount3MLS", xlRange3MLS.Rows.Count);
                    rangeCount.Add("colCount3MLS", xlRange3MLS.Columns.Count);

                    // relevant columns indeces for sheet 2
                    relevantCols.Add("AgentAgentCol", 0);
                    relevantCols.Add("AgentOfficeCol", 0);
                    relevantCols.Add("AgentOwnerCol", 0);
                    relevantCols.Add("AgentCityCol", 0);
                    relevantCols.Add("AgentZipCol", 0);
                    relevantCols.Add("AgentAddressCol", 0);
                    relevantCols.Add("AgentCloseDateCol", 0);
                    relevantCols.Add("AgentPriceCol", 0);
                    relevantCols.Add("AgentGFCol", 0);
                    relevantCols.Add("AgentEscrowCol", 0);
                    relevantCols.Add("AgentRegionCol", 0);
                    relevantCols.Add("AgentTitleCoCol", 0);
                    relevantCols.Add("AgentAsSACol", 0);
                    relevantCols.Add("AgentClosingsCol", 0);
                    relevantCols.Add("AgentTCCloseCol", 0);
                    relevantCols.Add("AgentBSCloseCol", 0);
                    relevantCols.Add("AgentBSTCCloseCol", 0);
                    // relevant columns indeces for sheet 3
                    relevantCols.Add("BrokerAgentCol", 0);
                    relevantCols.Add("BrokerOfficeCol", 0);
                    relevantCols.Add("BrokerOwnerCol", 0);
                    relevantCols.Add("BrokerCityCol", 0);
                    relevantCols.Add("BrokerZipCol", 0);
                    relevantCols.Add("BrokerAddressCol", 0);
                    relevantCols.Add("BrokerCloseDateCol", 0);
                    relevantCols.Add("BrokerPriceCol", 0);
                    relevantCols.Add("BrokerGFCol", 0);
                    relevantCols.Add("BrokerEscrowCol", 0);
                    relevantCols.Add("BrokerRegionCol", 0);
                    relevantCols.Add("BrokerTitleCoCol", 0);
                    relevantCols.Add("BrokerAsSACol", 0);
                    relevantCols.Add("BrokerClosingsCol", 0);
                    relevantCols.Add("BrokerTCCloseCol", 0);
                    relevantCols.Add("BrokerBSCloseCol", 0);
                    relevantCols.Add("BrokerBSTCCloseCol", 0);
                    // relevant columns indeces for the new sheets
                    relevantCols.Add("FinRank1Col", 1);
                    relevantCols.Add("FinRank2Col", 2);
                    relevantCols.Add("FinData1Col", 3);
                    relevantCols.Add("FinData2Col", 4);
                    relevantCols.Add("FinPriceCol", 5);
                    relevantCols.Add("FinAsSACol", 6);
                    relevantCols.Add("FinAsSAPercCol", 7);
                    relevantCols.Add("FinClosingsCol", 8);
                    relevantCols.Add("FinHatcoCol", 9);
                    relevantCols.Add("FinPercClosedCol", 10);
                    relevantCols.Add("FinClosingsBothCol", 11);
                    relevantCols.Add("FinHatcoBothCol", 12);
                    relevantCols.Add("FinPercClosedBothCol", 13);

                    // determine the columns in MLS file sheet 2 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount2MLS"]; i++)
                    {
                        if (xlRange2MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            string currHeaderCell = xlRange2MLS.Cells[1, i].Value2.ToString().ToLower();

                            if (currHeaderCell.Contains("agent name"))
                                relevantCols["AgentAgentCol"] = i;
                            else if (currHeaderCell.Contains("agent office"))
                                relevantCols["AgentOfficeCol"] = i;
                            else if (currHeaderCell.Contains("owner"))
                                relevantCols["AgentOwnerCol"] = i;
                            else if (currHeaderCell.Contains("city"))
                                relevantCols["AgentCityCol"] = i;
                            else if (currHeaderCell.Contains("zip"))
                                relevantCols["AgentZipCol"] = i;
                            else if (currHeaderCell.Contains("address"))
                                relevantCols["AgentAddressCol"] = i;
                            else if (currHeaderCell.Contains("closing date"))
                                relevantCols["AgentCloseDateCol"] = i;
                            else if (currHeaderCell.Contains("price"))
                                relevantCols["AgentPriceCol"] = i;
                            else if (currHeaderCell.Contains("gf"))
                                relevantCols["AgentGFCol"] = i;
                            else if (currHeaderCell.Contains("escrow"))
                                relevantCols["AgentEscrowCol"] = i;
                            else if (currHeaderCell.Contains("region"))
                                relevantCols["AgentRegionCol"] = i;
                            else if (currHeaderCell.Contains("title"))
                                relevantCols["AgentTitleCoCol"] = i;
                            else if (currHeaderCell.Contains("as sa"))
                                relevantCols["AgentAsSACol"] = i;
                            else if (currHeaderCell.Contains("bs tc clos"))
                                relevantCols["AgentBSTCCloseCol"] = i;
                            else if (currHeaderCell.Contains("tc clos"))
                                relevantCols["AgentTCCloseCol"] = i;
                            else if (currHeaderCell.Contains("bs clos"))
                                relevantCols["AgentBSCloseCol"] = i;
                            else if (currHeaderCell.Contains("closings"))
                                relevantCols["AgentClosingsCol"] = i;
                        }
                    }
                    // determine the columns in MLS file sheet 2 that have relevant information
                    for (int i = 1; i <= rangeCount["colCount3MLS"]; i++)
                    {
                        if (xlRange3MLS.Cells[1, i].Value2 != null) // check that the cell is not empty
                        {
                            string currHeaderCell = xlRange3MLS.Cells[1, i].Value2.ToString().ToLower();

                            if (currHeaderCell.Contains("agent name"))
                                relevantCols["BrokerAgentCol"] = i;
                            else if (currHeaderCell.Contains("agent office"))
                                relevantCols["BrokerOfficeCol"] = i;
                            else if (currHeaderCell.Contains("owner"))
                                relevantCols["BrokerOwnerCol"] = i;
                            else if (currHeaderCell.Contains("city"))
                                relevantCols["BrokerCityCol"] = i;
                            else if (currHeaderCell.Contains("zip"))
                                relevantCols["BrokerZipCol"] = i;
                            else if (currHeaderCell.Contains("address"))
                                relevantCols["BrokerAddressCol"] = i;
                            else if (currHeaderCell.Contains("closing date"))
                                relevantCols["BrokerCloseDateCol"] = i;
                            else if (currHeaderCell.Contains("price"))
                                relevantCols["BrokerPriceCol"] = i;
                            else if (currHeaderCell.Contains("gf"))
                                relevantCols["BrokerGFCol"] = i;
                            else if (currHeaderCell.Contains("escrow"))
                                relevantCols["BrokerEscrowCol"] = i;
                            else if (currHeaderCell.Contains("region"))
                                relevantCols["BrokerRegionCol"] = i;
                            else if (currHeaderCell.Contains("title"))
                                relevantCols["BrokerTitleCoCol"] = i;
                            else if (currHeaderCell.Contains("as sa"))
                                relevantCols["BrokerAsSACol"] = i;
                            else if (currHeaderCell.Contains("bs tc clos"))
                                relevantCols["BrokerBSTCCloseCol"] = i;
                            else if (currHeaderCell.Contains("tc clos"))
                                relevantCols["BrokerTCCloseCol"] = i;
                            else if (currHeaderCell.Contains("bs clos"))
                                relevantCols["BrokerBSCloseCol"] = i;
                            else if (currHeaderCell.Contains("closings"))
                                relevantCols["BrokerClosingsCol"] = i;
                        }
                    }

                    // Set up the headers for all of the new sheets
                    // Set up header for Agents sheet
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 1].Value = "Rank";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 2].Value = "Temp";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 3].Value = "Agent Name";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 4].Value = "Agent Office";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[1, 5].Value = "Total as Listing & Selling Agent";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 5].Value = "Price";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 6].Value = "As SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 7].Value = "% SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 8].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 9].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 10].Value = "% Closed";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[1, 11].Value = "Closings on Both Sides";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 11].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 12].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[2, 13].Value = "% Closed";
                    // Set up header for Brokers sheet
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 1].Value = "Rank";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 2].Value = "Temp";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 3].Value = "Mkt Share";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 4].Value = "Broker Name";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[1, 5].Value = "Total as Listing & Selling Agent";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 5].Value = "Price";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 6].Value = "As SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 7].Value = "% SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 8].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 9].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 10].Value = "% Closed";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[1, 11].Value = "Closings on Both Sides";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 11].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 12].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 3].Cells[2, 13].Value = "% Closed";
                    // Set up header for NonCust sheet
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 1].Value = "Rank";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 2].Value = "Rank";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 3].Value = "Agent Name";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 4].Value = "Agent Office";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[1, 5].Value = "Total as Listing & Selling Agent";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 5].Value = "Price";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 6].Value = "As SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 7].Value = "% SA";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 8].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 9].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 10].Value = "% Closed";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[1, 11].Value = "Closings on Both Sides";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 11].Value = "Closings";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 12].Value = "Hatco";
                    xlWorkbookMLS.Sheets[initialSheetCount + 5].Cells[2, 13].Value = "% Closed";

                    if (runAsCapstone)
                    {
                        // Set up headers for extra Agents sheets
                        for (int i = 1; i <= numAgentsSheets; i++)
                        {
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 1].Value = "Rank";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 2].Value = "Temp";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 3].Value = "Agent Name";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 4].Value = "Agent Office";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[1, 5].Value = "Total as Listing & Selling Agent";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 5].Value = "Price";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 6].Value = "As SA";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 7].Value = "% SA";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 8].Value = "Closings";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 9].Value = "Hatco";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 10].Value = "% Closed";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[1, 11].Value = "Closings on Both Sides";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 11].Value = "Closings";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 12].Value = "Hatco";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[2, 13].Value = "% Closed";
                        }
                        // Set up headers for extra NonCust sheets
                        for (int i = 1; i <= numAgentsSheets; i++)
                        {
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 1].Value = "Rank";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 2].Value = "Rank";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 3].Value = "Agent Name";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 4].Value = "Agent Office";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[1, 5].Value = "Total as Listing & Selling Agent";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 5].Value = "Price";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 6].Value = "As SA";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 7].Value = "% SA";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 8].Value = "Closings";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 9].Value = "Hatco";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 10].Value = "% Closed";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[1, 11].Value = "Closings on Both Sides";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 11].Value = "Closings";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 12].Value = "Hatco";
                            xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i].Cells[2, 13].Value = "% Closed";
                        }
                    }

                    // set up the progress bar
                    MethodInvoker inv = delegate
                    {
                        form.finalizerProgressBar.Maximum = 7 + (numAgentsSheets * 4);
                    };
                    form.Invoke(inv);

                    FinalizerWork fin = new FinalizerWork();
                    fin.finalizerWork(xlWorkbookMLS, initialSheetCount, closingThreshold,
                        closingPercent, relevantCols, runAsCapstone, specificAreas, progress, form);

                    // create "Agents - Alpha" sheet
                    Excel.Range AgentsRange = xlWorkbookMLS.Sheets[initialSheetCount + 1].UsedRange;
                    Excel.Range AgentsAlphaRange = xlWorkbookMLS.Sheets[initialSheetCount + 2].UsedRange;
                    AgentsRange.Copy(AgentsAlphaRange);

                    // sort "Agents - Alpha" alphabetically
                    Excel.Range dataRange = AgentsAlphaRange.Range[
                            AgentsAlphaRange.Cells[4, 1],
                            AgentsAlphaRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                        ];
                    xlWorkbookMLS.Sheets[initialSheetCount + 2].Sort.SetRange(dataRange);
                    xlWorkbookMLS.Sheets[initialSheetCount + 2].Sort.SortFields.Add(
                            dataRange.Columns[relevantCols["FinData1Col"] - 1],
                            Excel.XlSortOn.xlSortOnValues,
                            Excel.XlSortOrder.xlAscending
                        );
                    xlWorkbookMLS.Sheets[initialSheetCount + 2].Sort.Apply();

                    // create "Brokers - Alpha" sheet
                    Excel.Range BrokersRange = xlWorkbookMLS.Sheets[initialSheetCount + 3].UsedRange;
                    Excel.Range BrokersAlphaRange = xlWorkbookMLS.Sheets[initialSheetCount + 4].UsedRange;
                    BrokersRange.Copy(BrokersAlphaRange);

                    // sort "Brokers - Alpha" alphabetically
                    dataRange = BrokersAlphaRange.Range[
                            BrokersAlphaRange.Cells[4, 1],
                            BrokersAlphaRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                        ];
                    xlWorkbookMLS.Sheets[initialSheetCount + 4].Sort.SetRange(dataRange);
                    xlWorkbookMLS.Sheets[initialSheetCount + 4].Sort.SortFields.Add(
                            dataRange.Columns[relevantCols["FinData2Col"] - 1],
                            Excel.XlSortOn.xlSortOnValues,
                            Excel.XlSortOrder.xlAscending
                        );
                    xlWorkbookMLS.Sheets[initialSheetCount + 4].Sort.Apply();

                    // create "NonCust - Alpha" sheet
                    Excel.Range NonCustRange = xlWorkbookMLS.Sheets[initialSheetCount + 5].UsedRange;
                    Excel.Range NonCustAlphaRange = xlWorkbookMLS.Sheets[initialSheetCount + 6].UsedRange;
                    NonCustRange.Copy(NonCustAlphaRange);

                    // sort "NonCust - Alpha" alphabetically
                    dataRange = NonCustAlphaRange.Range[
                            NonCustAlphaRange.Cells[3, 1],
                            NonCustAlphaRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                        ];
                    xlWorkbookMLS.Sheets[initialSheetCount + 6].Sort.SetRange(dataRange);
                    xlWorkbookMLS.Sheets[initialSheetCount + 6].Sort.SortFields.Add(
                            dataRange.Columns[relevantCols["FinData1Col"]],
                            Excel.XlSortOn.xlSortOnValues,
                            Excel.XlSortOrder.xlAscending
                        );
                    xlWorkbookMLS.Sheets[initialSheetCount + 6].Sort.Apply();
                }
                catch (Exception e)
                {
                    // cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Marshal.ReleaseComObject(xlWorksheet2MLS);
                    Marshal.ReleaseComObject(xlWorksheet3MLS);

                    // save, close, and release workbooks
                    xlWorkbookMLS.Close();
                    Console.WriteLine("closed MLS workbook");
                    Marshal.ReleaseComObject(xlWorkbookMLS);

                    // quit and release excel app
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                    Console.WriteLine(e);
                    throw e;
                }

                // cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

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

            Application.UseWaitCursor = false; // set the cursor back to normal
        }
    }
}
