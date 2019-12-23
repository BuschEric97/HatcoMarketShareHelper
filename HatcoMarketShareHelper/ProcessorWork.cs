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
        public void processorWork(Excel._Worksheet xlWorksheet1MLS, Excel._Worksheet xlWorksheet2MLS,
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
                string highSchool = "";
                string titleCo = "";
                if (runAsCapstone)
                {
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSZipCol1"]].Value != null)
                        zip = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSZipCol1"]].Value.ToString();
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSRegionCol1"]].Value != null)
                        region = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSRegionCol1"]].Value.ToString();
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSHighSchoolCol1"]].Value != null)
                        highSchool = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSHighSchoolCol1"]].Value.ToString();
                    if (xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSTitleCoCol1"]].Value != null)
                        titleCo = xlRange1MLS.Cells[sheet1CurrRow, relevantCols["MLSTitleCoCol1"]].Value.ToString();
                }


                if (StringDistance.GetStringDistance(sellingAgent, listingAgent) <= 1 ||
                    sellingAgent == "")
                {
                    if (includeNonMLS || sellingAgent != "Non-MLS Agent")
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
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol2"]].Value
                                = highSchool;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }
                }
                else
                {
                    if (includeNonMLS || sellingAgent != "Non-MLS Agent")
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
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol2"]].Value
                                = highSchool;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }

                    if (includeNonMLS || listingAgent != "Non-MLS Agent")
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
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol2"]].Value
                                = highSchool;
                            xlRange2MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol2"]].Value
                                = titleCo;
                        }

                        sheet2CurrRow++; // increment so data doesn't get overwritten
                    }
                }

                if (StringDistance.GetStringDistance(sellingOffice, listingOffice) <= 1 ||
                    sellingOffice == "")
                {
                    if (includeNonMLS || sellingAgent != "Non-MLS Agent")
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
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol3"]].Value
                                = highSchool;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }
                }
                else
                {
                    if (includeNonMLS || sellingAgent != "Non-MLS Agent")
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
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol3"]].Value
                                = highSchool;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }

                    if (includeNonMLS || listingAgent != "Non-MLS Agent")
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
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSZipCol3"]].Value
                                = zip;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSRegionCol3"]].Value
                                = region;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSHighSchoolCol3"]].Value
                                = highSchool;
                            xlRange3MLS.Cells[sheet2CurrRow, relevantCols["MLSTitleCoCol3"]].Value
                                = titleCo;
                        }

                        sheet3CurrRow++; // increment so data doesn't get overwritten
                    }
                }

                if (progress != null)
                    progress.Report(100 / rangeCount["rowCount1MLS"]);

                string progressDetailedString = sheet1CurrRow + "/" + (rangeCount["rowCount1MLS"] - 1);
                MethodInvoker inv = delegate
                {
                    form.processorProgressDetailed.Text = progressDetailedString;
                };
                form.Invoke(inv);
            }

            if (doSubtotals)
            {
                // sort worksheets 2 & 3 by agent names
                xlWorksheet2MLS.Sort.SetRange(xlWorksheet2MLS.UsedRange);
                xlWorksheet2MLS.Sort.Header = Excel.XlYesNoGuess.xlYes;
                xlWorksheet2MLS.Sort.SortFields.Add(
                        xlRange2MLS.Columns[1],
                        Excel.XlSortOn.xlSortOnValues,
                        Excel.XlSortOrder.xlAscending
                    );
                xlWorksheet3MLS.Sort.SetRange(xlWorksheet3MLS.UsedRange);
                xlWorksheet3MLS.Sort.Header = Excel.XlYesNoGuess.xlYes;
                xlWorksheet3MLS.Sort.SortFields.Add(
                        xlRange3MLS.Columns[1],
                        Excel.XlSortOn.xlSortOnValues,
                        Excel.XlSortOrder.xlAscending
                    );
                xlWorksheet2MLS.Sort.Apply();
                xlWorksheet3MLS.Sort.Apply();

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
                xlWorksheet2MLS.UsedRange.Subtotal(1, Excel.XlConsolidationFunction.xlSum, subtotalCols2);
                xlWorksheet3MLS.UsedRange.Subtotal(1, Excel.XlConsolidationFunction.xlSum, subtotalCols3);
            }
        }
    }
}
