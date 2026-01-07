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
    class ProcessorWork
    {
        public void processorWork(Excel.Workbook xlWorkbookMLS, Excel._Worksheet xlWorksheet1MLS, Excel._Worksheet xlWorksheet2MLS,
            Excel._Worksheet xlWorksheet3MLS,  Dictionary<string, int> rangeCount, Dictionary<string, int> relevantCols,
            bool includeNonMLS, bool runAsCapstone, bool doSubtotals, Dictionary<string, string[]> specificAreas,
            IProgress<int> progress, Form1 form)
        {
            int sheet2CurrRow = 2;
            int sheet3CurrRow = 2;
            Excel.Range xlRange1MLS = xlWorksheet1MLS.UsedRange;
            Excel.Range xlRange2MLS = xlWorksheet2MLS.UsedRange;
            Excel.Range xlRange3MLS = xlWorksheet3MLS.UsedRange;

            for (int sheet1CurrRow = 2; sheet1CurrRow < rangeCount["rowCount1MLS"]; sheet1CurrRow++)
            {
                MethodInvoker inv2 = delegate
                {
                    form.debugScreen.AppendText(Environment.NewLine + "Working on row " + sheet1CurrRow + " in MLS xl file");
                };
                form.Invoke(inv2);
                Console.WriteLine("Working on row " + sheet1CurrRow + " in MLS xl file");

                // take relevant data from tab 1, taking it as an empty string if it is null
                string sellingAgent = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSSellAgentCol1"]].Value != null)
                    sellingAgent = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSSellAgentCol1"]].Value.ToString();
                string sellingOffice = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSSellOfficeCol1"]].Value != null)
                    sellingOffice = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSSellOfficeCol1"]].Value.ToString();
                string listingAgent = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSListAgentCol1"]].Value != null)
                    listingAgent = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSListAgentCol1"]].Value.ToString();
                string listingOffice = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSListOfficeCol1"]].Value != null)
                    listingOffice = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSListOfficeCol1"]].Value.ToString();
                string owner = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSOwnerCol1"]].Value != null)
                    owner = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSOwnerCol1"]].Value.ToString();
                string city = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSCityCol1"]].Value != null)
                    city = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSCityCol1"]].Value.ToString();
                string address = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSAddressCol1"]].Value != null)
                    address = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSAddressCol1"]].Value.ToString();
                string closeDate = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSCloseDateCol1"]].Value2 != null)
                    closeDate = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSCloseDateCol1"]].Value2.ToString();
                string price = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSPriceCol1"]].Value != null)
                    price = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSPriceCol1"]].Value.ToString();
                string GFNo = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSGFCol1"]].Value != null)
                    GFNo = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSGFCol1"]].Value.ToString();
                string escrowOfficer = "";
                if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSEscrowCol1"]].Value != null)
                    escrowOfficer = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSEscrowCol1"]].Value.ToString();

                string zip = "";
                string region = "";
                string titleCo = "";
                if (runAsCapstone)
                {
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSZipCol1"]].Value != null)
                        zip = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSZipCol1"]].Value.ToString();
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSRegionCol1"]].Value != null)
                        region = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSRegionCol1"]].Value.ToString();
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSTitleCoCol1"]].Value != null)
                        titleCo = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSTitleCoCol1"]].Value.ToString();
                }


                if (StringDistance.GetStringDistance(sellingAgent, listingAgent) <= 1 ||
                    sellingAgent == "")
                {
                    if (includeNonMLS || (sellingAgent != "Non-MLS Agent" && sellingAgent != "Non Member"))
                    {
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAgentCol2"]].Value
                            = sellingAgent;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOfficeCol2"]].Value
                            = sellingOffice;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOwnerCol2"]].Value
                            = owner;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCityCol2"]].Value
                            = city;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAddressCol2"]].Value
                            = address;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCloseDateCol2"]].Value
                            = closeDate;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSPriceCol2"]].Value
                            = price;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSGFCol2"]].Value
                            = GFNo;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSEscrowCol2"]].Value
                            = escrowOfficer;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAsSACol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSClosingsCol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTCCloseCol2"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSClosingCol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSTCCloseCol2"]].Value
                            = xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTCCloseCol2"]].Value; // assign same value as TC Close

                        if (runAsCapstone)
                        {
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol2"]].Value
                                = zip;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol2"]].Value
                                = region;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }
                }
                else
                {
                    if (includeNonMLS || (sellingAgent != "Non-MLS Agent" && sellingAgent != "Non Member"))
                    {
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAgentCol2"]].Value
                            = sellingAgent;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOfficeCol2"]].Value
                            = sellingOffice;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOwnerCol2"]].Value
                            = owner;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCityCol2"]].Value
                            = city;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAddressCol2"]].Value
                            = address;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCloseDateCol2"]].Value
                            = closeDate;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSPriceCol2"]].Value
                            = price;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSGFCol2"]].Value
                            = GFNo;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSEscrowCol2"]].Value
                            = escrowOfficer;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAsSACol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSClosingsCol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTCCloseCol2"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSClosingCol2"]].Value
                            = 0;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSTCCloseCol2"]].Value
                            = 0;

                        if (runAsCapstone)
                        {
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol2"]].Value
                                = zip;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol2"]].Value
                                = region;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }

                    if (includeNonMLS || (listingAgent != "Non-MLS Agent" && listingAgent != "Non Member"))
                    {
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAgentCol2"]].Value
                            = listingAgent;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOfficeCol2"]].Value
                            = listingOffice;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSOwnerCol2"]].Value
                            = owner;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCityCol2"]].Value
                            = city;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAddressCol2"]].Value
                            = address;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSCloseDateCol2"]].Value
                            = closeDate;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSPriceCol2"]].Value
                            = price;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSGFCol2"]].Value
                            = GFNo;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSEscrowCol2"]].Value
                            = escrowOfficer;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSAsSACol2"]].Value
                            = 0;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSClosingsCol2"]].Value
                            = 1;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTCCloseCol2"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSClosingCol2"]].Value
                            = 0;
                        xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSBSTCCloseCol2"]].Value
                            = 0;

                        if (runAsCapstone)
                        {
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol2"]].Value
                                = zip;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol2"]].Value
                                = region;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }
                }

                if (StringDistance.GetStringDistance(sellingOffice, listingOffice) <= 1 ||
                    sellingOffice == "")
                {
                    if (includeNonMLS || (sellingAgent != "Non-MLS Agent" && sellingAgent != "Non Member"))
                    {
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAgentCol3"]].Value
                            = sellingAgent;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOfficeCol3"]].Value
                            = sellingOffice;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOwnerCol3"]].Value
                            = owner;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCityCol3"]].Value
                            = city;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAddressCol3"]].Value
                            = address;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCloseDateCol3"]].Value
                            = closeDate;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSPriceCol3"]].Value
                            = price;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSGFCol3"]].Value
                            = GFNo;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSEscrowCol3"]].Value
                            = escrowOfficer;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAsSACol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSClosingsCol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTCCloseCol3"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSClosingCol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSTCCloseCol3"]].Value
                            = xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTCCloseCol3"]].Value; // assign same value as TC Close

                        if (runAsCapstone)
                        {
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }
                }
                else
                {
                    if (includeNonMLS || (sellingAgent != "Non-MLS Agent" && sellingAgent != "Non Member"))
                    {
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAgentCol3"]].Value
                            = sellingAgent;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOfficeCol3"]].Value
                            = sellingOffice;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOwnerCol3"]].Value
                            = owner;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCityCol3"]].Value
                            = city;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAddressCol3"]].Value
                            = address;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCloseDateCol3"]].Value
                            = closeDate;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSPriceCol3"]].Value
                            = price;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSGFCol3"]].Value
                            = GFNo;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSEscrowCol3"]].Value
                            = escrowOfficer;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAsSACol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSClosingsCol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTCCloseCol3"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSClosingCol3"]].Value
                            = 0;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSTCCloseCol3"]].Value
                            = 0;

                        if (runAsCapstone)
                        {
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }

                    if (includeNonMLS || (listingAgent != "Non-MLS Agent" && listingAgent != "Non Member"))
                    {
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAgentCol3"]].Value
                            = listingAgent;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOfficeCol3"]].Value
                            = listingOffice;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSOwnerCol3"]].Value
                            = owner;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCityCol3"]].Value
                            = city;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAddressCol3"]].Value
                            = address;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSCloseDateCol3"]].Value
                            = closeDate;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSPriceCol3"]].Value
                            = price;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSGFCol3"]].Value
                            = GFNo;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSEscrowCol3"]].Value
                            = escrowOfficer;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSAsSACol3"]].Value
                            = 0;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSClosingsCol3"]].Value
                            = 1;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTCCloseCol3"]].Value
                            = GFNo != "did not close" ? 1 : 0; // assign 1 if the file closed, 0 otherwise
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSClosingCol3"]].Value
                            = 0;
                        xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSBSTCCloseCol3"]].Value
                            = 0;

                        if (runAsCapstone)
                        {
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet3CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }
                }

                // update progress bar after each row of sheet 1
                MethodInvoker inv1 = delegate
                {
                    form.processorProgressBar.Increment(1);
                };
                form.Invoke(inv1);

                // update detailed progress after each row of sheet 1
                //string progressDetailedString = sheet1CurrRow + "/" + (rangeCount["rowCount1MLS"] - 1);
                //MethodInvoker inv2 = delegate
                //{
                //    form.processorProgressDetailed.Text = progressDetailedString;
                //};
                //form.Invoke(inv2);
            }

            Excel._Worksheet xlWorksheet4MLS = null;
            if (runAsCapstone)
            {
                // create ZipAll worksheet as copy of sheet 2
                xlWorksheet2MLS.Copy(After: xlWorksheet3MLS); // copy worksheet 2 and place it after worksheet 3
                xlWorksheet4MLS = xlWorkbookMLS.Sheets[4];
                xlWorksheet4MLS.Name = "ZipAll";

                // fill in all the area sheets based of zip code groups (from config file)
                for (int currAreaSheet = 5, currAreaGroup = 0;
                    currAreaSheet <= xlWorkbookMLS.Sheets.Count; currAreaSheet++, currAreaGroup++)
                {
                    Excel.Range initFrom = xlWorksheet2MLS.Range[xlWorksheet2MLS.Cells[1, 1], // copy-from row location
                        xlWorksheet2MLS.Cells[1, xlWorksheet2MLS.UsedRange.Columns.Count]];
                    Excel.Range initTo = // copy-to row location
                        xlWorkbookMLS.Sheets[currAreaSheet].Range[xlWorkbookMLS.Sheets[currAreaSheet].Cells[1, 1],
                        xlWorkbookMLS.Sheets[currAreaSheet].Cells[1, xlWorksheet2MLS.UsedRange.Columns.Count]];
                    initFrom.Copy(initTo); // copy header from sheet 2 to current area sheet

                    // copy over the rows that match the current zip code group
                    int currAreaSheetRow = 2;
                    string currAreaSheetName = xlWorkbookMLS.Sheets[currAreaSheet].Name;
                    for (int currRecord = 2; currRecord <= xlWorksheet2MLS.UsedRange.Rows.Count;
                        currRecord++)
                    {
                        string currZip =
                            xlWorksheet2MLS.Cells[currRecord, relevantCols["MLSZipCol2"]].Value.ToString();
                        if (specificAreas[currAreaSheetName].Any(s => currZip.Contains(s))) // if currZip matches any zip from the current area group
                        {
                            Excel.Range currFrom = xlWorksheet2MLS.Range[
                                    xlWorksheet2MLS.Cells[currRecord, 1], // copy-from row location
                                    xlWorksheet2MLS.Cells[currRecord, xlWorksheet2MLS.UsedRange.Columns.Count]
                                ];
                            Excel.Range currTo = // copy-to row location
                                xlWorkbookMLS.Sheets[currAreaSheet].Range[
                                    xlWorkbookMLS.Sheets[currAreaSheet].Cells[currAreaSheetRow, 1],
                                    xlWorkbookMLS.Sheets[currAreaSheet].Cells[currAreaSheetRow, xlWorksheet2MLS.UsedRange.Columns.Count]
                                ];
                            currFrom.Copy(currTo); // copy currRecord from sheet 2 to the current area sheet
                            currAreaSheetRow++;
                        }
                    }

                    // sort and do subtotals if needed
                    if (doSubtotals)
                    {
                        // sort the current area sheet
                        xlWorkbookMLS.Sheets[currAreaSheet].Sort.SetRange(xlWorkbookMLS.Sheets[currAreaSheet].UsedRange);
                        xlWorkbookMLS.Sheets[currAreaSheet].Sort.Header = Excel.XlYesNoGuess.xlYes;
                        xlWorkbookMLS.Sheets[currAreaSheet].Sort.SortFields.Add(
                                xlWorkbookMLS.Sheets[currAreaSheet].UsedRange.Columns[relevantCols["MLSAgentCol2"]],
                                Excel.XlSortOn.xlSortOnValues,
                                Excel.XlSortOrder.xlAscending
                            );
                        xlWorkbookMLS.Sheets[currAreaSheet].Sort.Apply();

                        int[] subtotalCols =
                        {
                            relevantCols["MLSPriceCol2"],
                            relevantCols["MLSAsSACol2"],
                            relevantCols["MLSClosingsCol2"],
                            relevantCols["MLSTCCloseCol2"],
                            relevantCols["MLSBSClosingCol2"],
                            relevantCols["MLSBSTCCloseCol2"]
                        };
                        xlWorkbookMLS.Sheets[currAreaSheet].UsedRange.Subtotal(relevantCols["MLSAgentCol2"],
                            Excel.XlConsolidationFunction.xlSum, subtotalCols);
                    }
                }
            }

            // sort and do subtotals if needed
            if (doSubtotals)
            {
                // sort worksheets 2 & 3 by agent names
                xlWorksheet2MLS.Sort.SetRange(xlWorksheet2MLS.UsedRange);
                xlWorksheet2MLS.Sort.Header = Excel.XlYesNoGuess.xlYes;
                xlWorksheet2MLS.Sort.SortFields.Add(
                        xlRange2MLS.Columns[relevantCols["MLSAgentCol2"]],
                        Excel.XlSortOn.xlSortOnValues,
                        Excel.XlSortOrder.xlAscending
                    );
                xlWorksheet3MLS.Sort.SetRange(xlWorksheet3MLS.UsedRange);
                xlWorksheet3MLS.Sort.Header = Excel.XlYesNoGuess.xlYes;
                xlWorksheet3MLS.Sort.SortFields.Add(
                        xlRange3MLS.Columns[relevantCols["MLSOfficeCol3"]],
                        Excel.XlSortOn.xlSortOnValues,
                        Excel.XlSortOrder.xlAscending
                    );
                xlWorksheet2MLS.Sort.Apply();
                xlWorksheet3MLS.Sort.Apply();

                if (runAsCapstone)
                {
                    // sort worksheet 4 by zip code then subsort by agent name
                    xlWorksheet4MLS.UsedRange.Sort(
                            Key1: xlWorksheet4MLS.UsedRange.Columns[relevantCols["MLSZipCol2"]],
                            Key2: xlWorksheet4MLS.UsedRange.Columns[relevantCols["MLSAgentCol2"]],
                            Header: Excel.XlYesNoGuess.xlYes
                        );
                }

                //create subtotals on the sorted data in worksheets 2 & 3
                int[] subtotalCols2 =
                {
                    relevantCols["MLSPriceCol2"],
                    relevantCols["MLSAsSACol2"],
                    relevantCols["MLSClosingsCol2"],
                    relevantCols["MLSTCCloseCol2"],
                    relevantCols["MLSBSClosingCol2"],
                    relevantCols["MLSBSTCCloseCol2"]
                };
                int[] subtotalCols3 =
                {
                    relevantCols["MLSPriceCol3"],
                    relevantCols["MLSAsSACol3"],
                    relevantCols["MLSClosingsCol3"],
                    relevantCols["MLSTCCloseCol3"],
                    relevantCols["MLSBSClosingCol3"],
                    relevantCols["MLSBSTCCloseCol3"],
                };
                xlWorksheet2MLS.UsedRange.Subtotal(relevantCols["MLSAgentCol2"],
                    Excel.XlConsolidationFunction.xlSum, subtotalCols2);
                xlWorksheet3MLS.UsedRange.Subtotal(relevantCols["MLSOfficeCol3"],
                    Excel.XlConsolidationFunction.xlSum, subtotalCols3);

                if (runAsCapstone)
                {
                    int[] subtotalCols4 =
                    {
                        relevantCols["MLSPriceCol2"],
                        relevantCols["MLSAsSACol2"],
                        relevantCols["MLSClosingsCol2"],
                        relevantCols["MLSTCCloseCol2"],
                        relevantCols["MLSBSClosingCol2"],
                        relevantCols["MLSBSTCCloseCol2"]
                    };
                    xlWorksheet4MLS.UsedRange.Subtotal(relevantCols["MLSAgentCol2"],
                        Excel.XlConsolidationFunction.xlSum, subtotalCols4);
                }
            }

            // format the close date columns of every sheet as a date
            xlWorksheet2MLS.Columns[relevantCols["MLSCloseDateCol2"]].NumberFormat = "MM/DD/YYYY";
            xlWorksheet3MLS.Columns[relevantCols["MLSCloseDateCol3"]].NumberFormat = "MM/DD/YYYY";
            if (runAsCapstone)
            {
                for (int i = 4; i <= xlWorkbookMLS.Sheets.Count; i++)
                    xlWorkbookMLS.Sheets[i].Columns[relevantCols["MLSCloseDateCol2"]].NumberFormat = "MM/DD/YYYY";
            }

            // format the price columns of every sheet as money
            xlWorksheet2MLS.Columns[relevantCols["MLSPriceCol2"]].NumberFormat = "$ #,###,###.00";
            xlWorksheet3MLS.Columns[relevantCols["MLSPriceCol3"]].NumberFormat = "$ #,###,###.00";
            if (runAsCapstone)
            {
                for (int i = 4; i <= xlWorkbookMLS.Sheets.Count; i++)
                    xlWorkbookMLS.Sheets[i].Columns[relevantCols["MLSPriceCol2"]].NumberFormat = "$ #,###,###.00";
            }
        }
    }
}
