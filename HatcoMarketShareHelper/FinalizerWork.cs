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
    class FinalizerWork
    {
        public void finalizerWork(Excel.Workbook xlWorkbookMLS, int initialSheetCount, int closingThreshold,
            double closingPercent, Dictionary<string, int> relevantCols, bool runAsCapstone,
            Dictionary<string, string[]> specificAreas, IProgress<int> progress, Form1 form)
        {
            Excel.Range xlRange2MLS = xlWorkbookMLS.Sheets[2].UsedRange;
            Excel.Range xlRange3MLS = xlWorkbookMLS.Sheets[3].UsedRange;
            int numAgentsSheets = specificAreas.Count; // get the number of additional Agents sheets that need to be generated

            // set up a method to update the progress bar after every major event
            MethodInvoker updateProgress = delegate
            {
                form.finalizerProgressBar.Increment(1);
            };

            form.Invoke(updateProgress);

            // iterate through AgentCombined sheet to build new Agents sheet
            int rankIndex = 1;
            Excel.Worksheet sheet = xlWorkbookMLS.Sheets[initialSheetCount + 1];
            for (int currSheetRow = 2; currSheetRow <= xlRange2MLS.Rows.Count; currSheetRow++)
            {
                // get all of the relevant information from the AgentCombined sheet
                string name = "";
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentAgentCol"]].Value != null)
                    name = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentAgentCol"]].Value.ToString();
                string office = "";
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow - 1, relevantCols["AgentOfficeCol"]].Value != null)
                    office = xlWorkbookMLS.Sheets[2].Cells[currSheetRow - 1, relevantCols["AgentOfficeCol"]].Value.ToString();

                // skip the current row if it is not a subtotal row
                if (!name.Contains("Total"))
                    continue;

                string price = "";
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentPriceCol"]].Value != null)
                    price = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentPriceCol"]].Value.ToString();
                double asSA = 0;
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentAsSACol"]].Value != null)
                    asSA = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentAsSACol"]].Value;
                double closings = 0;
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentClosingsCol"]].Value != null)
                    closings = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentClosingsCol"]].Value;
                double TCClose = 0;
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentTCCloseCol"]].Value != null)
                    TCClose = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentTCCloseCol"]].Value;
                double BSClosings = 0;
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentBSCloseCol"]].Value != null)
                   BSClosings = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentBSCloseCol"]].Value;
                double BSTCClose = 0;
                if (xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentBSTCCloseCol"]].Value != null)
                    BSTCClose = xlWorkbookMLS.Sheets[2].Cells[currSheetRow, relevantCols["AgentBSTCCloseCol"]].Value;

                // build the new Agents sheet
                sheet.Cells[rankIndex + 2, relevantCols["FinRank1Col"]].Value = rankIndex;
                sheet.Cells[rankIndex + 2, relevantCols["FinData1Col"]].Value = name;
                sheet.Cells[rankIndex + 2, relevantCols["FinData2Col"]].Value = office;
                sheet.Cells[rankIndex + 2, relevantCols["FinPriceCol"]].Value = price;
                sheet.Cells[rankIndex + 2, relevantCols["FinPriceCol"]].NumberFormat = "$###,###.00";
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSACol"]].Value = asSA;
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].Value = asSA / closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].NumberFormat = "###.00%;;0.00%;";
                sheet.Cells[rankIndex + 2, relevantCols["FinClosingsCol"]].Value = closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinHatcoCol"]].Value = TCClose;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].Value = TCClose / closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].NumberFormat = "###.00%;;0.00%;";
                sheet.Cells[rankIndex + 2, relevantCols["FinClosingsBothCol"]].Value = BSClosings;
                sheet.Cells[rankIndex + 2, relevantCols["FinHatcoBothCol"]].Value = BSTCClose;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].Value = BSClosings == 0.0 ? 0.0 : (BSTCClose / BSClosings);
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].NumberFormat = "###.00%;;0.00%;";

                MethodInvoker inv = delegate
                {
                    form.debugScreen.AppendText(Environment.NewLine + "Created row " + rankIndex + " in Agents sheet");
                };
                form.Invoke(inv);
                Console.WriteLine("Created row " + rankIndex + " in Agents sheet");
                rankIndex++;
            }

            form.Invoke(updateProgress);

            // sort all rows by price then recalculate Rank column
            Excel.Range range = sheet.Range[
                    sheet.Cells[3, 1],
                    sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                ];
            sheet.Sort.SetRange(range);
            sheet.Sort.SortFields.Add(
                    range.Columns[relevantCols["FinPriceCol"]],
                    Excel.XlSortOn.xlSortOnValues,
                    Excel.XlSortOrder.xlDescending
                );
            sheet.Sort.Apply();
            for (int i = 4; i <= sheet.UsedRange.Rows.Count; i++) // recalculate Rank column
                sheet.Cells[i, relevantCols["FinRank1Col"]].Value = i - 3;
            sheet.Cells[3, relevantCols["FinRank1Col"]].Value = "";

            form.Invoke(updateProgress);


            // iterate through BrokerCombined sheet to build new Brokers sheet
            rankIndex = 1;
            sheet = xlWorkbookMLS.Sheets[initialSheetCount + 3];
            for (int currSheetRow = 2; currSheetRow <= xlRange3MLS.Rows.Count; currSheetRow++)
            {
                string name = "";
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerAgentCol"]].Value != null)
                    name = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerAgentCol"]].Value.ToString();
                string office = "";
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerOfficeCol"]].Value != null)
                    office = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerOfficeCol"]].Value.ToString();

                // skip the current row if it is not a subtotal row
                if (!office.Contains("Total"))
                    continue;

                string price = "";
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerPriceCol"]].Value != null)
                    price = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerPriceCol"]].Value.ToString();
                double asSA = 0;
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerAsSACol"]].Value != null)
                    asSA = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerAsSACol"]].Value;
                double closings = 0;
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerClosingsCol"]].Value != null)
                    closings = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerClosingsCol"]].Value;
                double TCClose = 0;
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerTCCloseCol"]].Value != null)
                    TCClose = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerTCCloseCol"]].Value;
                double BSClosings = 0;
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerBSCloseCol"]].Value != null)
                    BSClosings = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerBSCloseCol"]].Value;
                double BSTCClose = 0;
                if (xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerBSTCCloseCol"]].Value != null)
                    BSTCClose = xlWorkbookMLS.Sheets[3].Cells[currSheetRow, relevantCols["BrokerBSTCCloseCol"]].Value;

                // build the new Agents sheet
                sheet.Cells[rankIndex + 2, relevantCols["FinRank1Col"]].Value = rankIndex;
                sheet.Cells[rankIndex + 2, relevantCols["FinData1Col"]].Value = "temp";
                sheet.Cells[rankIndex + 2, relevantCols["FinData2Col"]].Value = office;
                sheet.Cells[rankIndex + 2, relevantCols["FinPriceCol"]].Value = price;
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSACol"]].Value = asSA;
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].Value = asSA / closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].NumberFormat = "###.00%;;0.00%;";
                sheet.Cells[rankIndex + 2, relevantCols["FinClosingsCol"]].Value = closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinHatcoCol"]].Value = TCClose;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].Value = TCClose / closings;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].NumberFormat = "###.00%;;0.00%;";
                sheet.Cells[rankIndex + 2, relevantCols["FinClosingsBothCol"]].Value = BSClosings;
                sheet.Cells[rankIndex + 2, relevantCols["FinHatcoBothCol"]].Value = BSTCClose;
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].Value = BSClosings == 0.0 ? 0.0 : (BSTCClose / BSClosings);
                sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].NumberFormat = "###.00%;;0.00%;";

                MethodInvoker inv = delegate
                {
                    form.debugScreen.AppendText(Environment.NewLine + "Created row " + rankIndex + " in Brokers sheet");
                };
                form.Invoke(inv);
                Console.WriteLine("Created row " + rankIndex + " in Brokers sheet");
                rankIndex++;
            }

            form.Invoke(updateProgress);

            // sort all rows by price then recalculate Rank and Data1 columns
            range = sheet.Range[
                    sheet.Cells[3, 1],
                    sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                ];
            sheet.Sort.SetRange(range);
            sheet.Sort.SortFields.Add(
                    range.Columns[relevantCols["FinPriceCol"]],
                    Excel.XlSortOn.xlSortOnValues,
                    Excel.XlSortOrder.xlDescending
                );
            sheet.Sort.Apply();
            double totalPrice = sheet.Cells[3, relevantCols["FinPriceCol"]].Value;
            for (int i = 4; i <= sheet.UsedRange.Rows.Count; i++) // recalculate Rank and Data1 columns
            {
                sheet.Cells[i, relevantCols["FinRank1Col"]].Value = i - 3; // recalculate Rank column

                double price = sheet.Cells[i, relevantCols["FinPriceCol"]].Value;
                sheet.Cells[i, relevantCols["FinData1Col"]].Value = price / totalPrice; // recalculate Data1 column

                // reformat Data1 and Price columns
                sheet.Cells[i, relevantCols["FinData1Col"]].NumberFormat = "###.00%;;0.00%;";
                sheet.Cells[i, relevantCols["FinPriceCol"]].NumberFormat = "$###,###.00";
            }
            sheet.Cells[3, relevantCols["FinRank1Col"]].Value = "";
            sheet.Cells[3, relevantCols["FinData1Col"]].Value = "";
            sheet.Cells[3, relevantCols["FinPriceCol"]].NumberFormat = "$###,###.00";

            // get rid of temp columns in Agents and Brokers sheets
            Excel.Worksheet sh1 = xlWorkbookMLS.Sheets[initialSheetCount + 1];
            Excel.Range r1 = sh1.Range[
                    sh1.Cells[1, relevantCols["FinRank2Col"]],
                    sh1.Cells[2, relevantCols["FinRank2Col"]]
                ];
            r1.EntireColumn.Delete();
            Excel.Worksheet sh2 = xlWorkbookMLS.Sheets[initialSheetCount + 3];
            Excel.Range r2 = sh2.Range[
                    sh2.Cells[1, relevantCols["FinRank2Col"]],
                    sh2.Cells[2, relevantCols["FinRank2Col"]]
                ];
            r2.EntireColumn.Delete();

            form.Invoke(updateProgress);

            // iterate through new Agents sheet to build new NonCust sheet
            Excel.Range xlRangeAgentsMLS = xlWorkbookMLS.Sheets[initialSheetCount + 1].UsedRange;
            rankIndex = 1;
            sheet = xlWorkbookMLS.Sheets[initialSheetCount + 5];
            for (int currSheetRow = 3; currSheetRow <= xlRangeAgentsMLS.Rows.Count; currSheetRow++)
            {
                // get the number of closings and percent closed for current row of Agents sheet
                double closings = 0.0;
                if (xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[currSheetRow, relevantCols["FinClosingsCol"] - 1].Value != null)
                    closings = xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[currSheetRow, relevantCols["FinClosingsCol"] - 1].Value;
                double percClosed = 0.0;
                if (xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[currSheetRow, relevantCols["FinPercClosedCol"] - 1].Value != null)
                    percClosed = xlWorkbookMLS.Sheets[initialSheetCount + 1].Cells[currSheetRow, relevantCols["FinPercClosedCol"] - 1].Value2;

                // copy the row of Agents sheet to NonCust sheet if closings and percClosed satisfy the requirements
                if (closings >= closingThreshold && percClosed <= closingPercent)
                {
                    // create new "secondary" rank for current row
                    sheet.Cells[rankIndex + 2, relevantCols["FinRank1Col"]].Value = rankIndex;

                    // copy current row of Agents sheet to NonCust sheet
                    Excel.Range fullRange = xlWorkbookMLS.Sheets[initialSheetCount + 1].UsedRange;
                    Excel.Range fromRange = fullRange.Range[
                            fullRange.Cells[currSheetRow, relevantCols["FinRank1Col"]],
                            fullRange.Cells[currSheetRow, fullRange.Columns.Count]
                        ];
                    Excel.Range toRange = sheet.Range[
                            sheet.Cells[rankIndex + 2, relevantCols["FinRank2Col"]],
                            sheet.Cells[rankIndex + 2, relevantCols["FinRank2Col"]]
                        ];
                    fromRange.Copy(toRange);

                    MethodInvoker inv = delegate
                    {
                        form.debugScreen.AppendText(Environment.NewLine + "Created row " + rankIndex + " in NonCust sheet");
                    };
                    form.Invoke(inv);
                    Console.WriteLine("Created row " + rankIndex + " in NonCust sheet");
                    rankIndex++;
                }
            }

            form.Invoke(updateProgress);


            if (runAsCapstone)
            {
                // iterate through each specific area sheet to build new Agents sheets
                for (int i = 1; i <=numAgentsSheets; i++)
                {
                    rankIndex = 1;
                    sheet = xlWorkbookMLS.Sheets[initialSheetCount + 6 + i];
                    for (int currSheetRow = 2; currSheetRow <= xlWorkbookMLS.Sheets[4 + i].UsedRange.Rows.Count; currSheetRow++)
                    {
                        // get all of the relevant information from the AgentCombined sheet
                        string name = "";
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentAgentCol"]].Value != null)
                            name = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentAgentCol"]].Value.ToString();
                        string office = "";
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow - 1, relevantCols["AgentOfficeCol"]].Value != null)
                            office = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow - 1, relevantCols["AgentOfficeCol"]].Value.ToString();

                        // skip the current row if it is not a subtotal row
                        if (!name.Contains("Total"))
                            continue;

                        string price = "";
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentPriceCol"]].Value != null)
                            price = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentPriceCol"]].Value.ToString();
                        double asSA = 0;
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentAsSACol"]].Value != null)
                            asSA = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentAsSACol"]].Value;
                        double closings = 0;
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentClosingsCol"]].Value != null)
                            closings = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentClosingsCol"]].Value;
                        double TCClose = 0;
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentTCCloseCol"]].Value != null)
                            TCClose = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentTCCloseCol"]].Value;
                        double BSClosings = 0;
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentBSCloseCol"]].Value != null)
                            BSClosings = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentBSCloseCol"]].Value;
                        double BSTCClose = 0;
                        if (xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentBSTCCloseCol"]].Value != null)
                            BSTCClose = xlWorkbookMLS.Sheets[4 + i].Cells[currSheetRow, relevantCols["AgentBSTCCloseCol"]].Value;

                        // build the new Agents sheet
                        sheet.Cells[rankIndex + 2, relevantCols["FinRank1Col"]].Value = rankIndex;
                        sheet.Cells[rankIndex + 2, relevantCols["FinData1Col"]].Value = name;
                        sheet.Cells[rankIndex + 2, relevantCols["FinData2Col"]].Value = office;
                        sheet.Cells[rankIndex + 2, relevantCols["FinPriceCol"]].Value = price;
                        sheet.Cells[rankIndex + 2, relevantCols["FinPriceCol"]].NumberFormat = "$###,###.00";
                        sheet.Cells[rankIndex + 2, relevantCols["FinAsSACol"]].Value = asSA;
                        sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].Value = asSA / closings;
                        sheet.Cells[rankIndex + 2, relevantCols["FinAsSAPercCol"]].NumberFormat = "###.00%;;0.00%;";
                        sheet.Cells[rankIndex + 2, relevantCols["FinClosingsCol"]].Value = closings;
                        sheet.Cells[rankIndex + 2, relevantCols["FinHatcoCol"]].Value = TCClose;
                        sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].Value = TCClose / closings;
                        sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedCol"]].NumberFormat = "###.00%;;0.00%;";
                        sheet.Cells[rankIndex + 2, relevantCols["FinClosingsBothCol"]].Value = BSClosings;
                        sheet.Cells[rankIndex + 2, relevantCols["FinHatcoBothCol"]].Value = BSTCClose;
                        sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].Value = BSClosings == 0.0 ? 0.0 : (BSTCClose / BSClosings);
                        sheet.Cells[rankIndex + 2, relevantCols["FinPercClosedBothCol"]].NumberFormat = "###.00%;;0.00%;";

                        MethodInvoker inv = delegate
                        {
                            form.debugScreen.AppendText(Environment.NewLine + "Created row " + rankIndex + " in Agents (" +
                                specificAreas.Keys.ElementAt(i - 1) + ") sheet");
                        };
                        form.Invoke(inv);
                        Console.WriteLine("Created row " + rankIndex + " in Agents (" +
                                specificAreas.Keys.ElementAt(i - 1) + ") sheet");
                        rankIndex++;
                    }

                    form.Invoke(updateProgress);

                    // sort all rows by price then recalculate Rank column
                    range = sheet.Range[
                            sheet.Cells[3, 1],
                            sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                        ];
                    sheet.Sort.SetRange(range);
                    sheet.Sort.SortFields.Add(
                            range.Columns[relevantCols["FinPriceCol"]],
                            Excel.XlSortOn.xlSortOnValues,
                            Excel.XlSortOrder.xlDescending
                        );
                    sheet.Sort.Apply();
                    for (int j = 4; j <= sheet.UsedRange.Rows.Count; j++) // recalculate Rank column
                        sheet.Cells[j, relevantCols["FinRank1Col"]].Value = j - 3;
                    sheet.Cells[3, relevantCols["FinRank1Col"]].Value = "";

                    form.Invoke(updateProgress);

                    // get rid of temp columns in Agents sheets
                    Excel.Range r = sheet.Range[
                            sheet.Cells[1, relevantCols["FinRank2Col"]],
                            sheet.Cells[2, relevantCols["FinRank2Col"]]
                        ];
                    r.EntireColumn.Delete();
                }
                

                for (int i = 1; i <= numAgentsSheets; i++)
                {
                    xlRangeAgentsMLS = xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].UsedRange;
                    rankIndex = 1;
                    sheet = xlWorkbookMLS.Sheets[initialSheetCount + 6 + numAgentsSheets + i];
                    for (int currSheetRow = 3; currSheetRow <= xlRangeAgentsMLS.Rows.Count; currSheetRow++)
                    {
                        // get the number of closings and percent closed for current row of Agents sheet
                        double closings = 0.0;
                        if (xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[currSheetRow, relevantCols["FinClosingsCol"] - 1].Value != null)
                            closings = xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[currSheetRow, relevantCols["FinClosingsCol"] - 1].Value;
                        double percClosed = 0.0;
                        if (xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[currSheetRow, relevantCols["FinPercClosedCol"] - 1].Value != null)
                            percClosed = xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].Cells[currSheetRow, relevantCols["FinPercClosedCol"] - 1].Value2;

                        // copy the row of Agents sheet to NonCust sheet if closings and percClosed satisfy the requirements
                        if (closings >= closingThreshold && percClosed <= closingPercent)
                        {
                            // create new "secondary" rank for current row
                            sheet.Cells[rankIndex + 2, relevantCols["FinRank1Col"]].Value = rankIndex;

                            // copy current row of Agents sheet to NonCust sheet
                            Excel.Range fullRange = xlWorkbookMLS.Sheets[initialSheetCount + 6 + i].UsedRange;
                            Excel.Range fromRange = fullRange.Range[
                                    fullRange.Cells[currSheetRow, relevantCols["FinRank1Col"]],
                                    fullRange.Cells[currSheetRow, fullRange.Columns.Count]
                                ];
                            Excel.Range toRange = sheet.Range[
                                    sheet.Cells[rankIndex + 2, relevantCols["FinRank2Col"]],
                                    sheet.Cells[rankIndex + 2, relevantCols["FinRank2Col"]]
                                ];
                            fromRange.Copy(toRange);

                            MethodInvoker inv = delegate
                            {
                                form.debugScreen.AppendText(Environment.NewLine + "Created row " + rankIndex + " in NonCust (" +
                                    specificAreas.Keys.ElementAt(i - 1) + ") sheet");
                            };
                            form.Invoke(inv);
                            Console.WriteLine("Created row " + rankIndex + " in NonCust (" +
                                    specificAreas.Keys.ElementAt(i - 1) + ") sheet");
                            rankIndex++;
                        }
                    }

                    form.Invoke(updateProgress);
                }
            }
        }
    }
}
