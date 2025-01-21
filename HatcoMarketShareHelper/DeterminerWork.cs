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
using System.Collections.Concurrent;

namespace HatcoMarketShareHelper
{
    class DeterminerWork
    {
        private static Object mutex = new Object(); // mutual exclusion lock to make sure two threads don't write to the MLS file concurrently

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlWorksheetMLS"></param>
        /// <param name="xlWorksheetAIM"></param>
        /// <param name="xlRangeMLS"></param>
        /// <param name="xlRangeAIM"></param>
        /// <param name="rangeCount"></param>
        /// <param name="relevantCols"></param>
        /// <param name="thresholds"></param>
        /// <param name="progress"></param>
        public int determinerDoWork(Dictionary<string, int> rangeCount, Dictionary<string, int> relevantCols,
            Dictionary<string, double> thresholds, Form1 form)
        {
            int returnCode = 0;

            var rangePart = Partitioner.Create(2, rangeCount["rowCountMLS"]);
            var parOpts = new ParallelOptions();
            parOpts.MaxDegreeOfParallelism = 6;

            Parallel.ForEach(rangePart, parOpts, (range, state) =>
            {
                try
                {
                    bool zipMatch = false;
                    bool dateClosedMatch = false;
                    int addressMatch = 0;
                    int ownerMatch = 0;
                    int closedGFNumRow = 2;
                    List<int> consideredRowsAIM = new List<int>();

                    // loop through the files and do the main work
                    for (int currentMLSFile = range.Item1; currentMLSFile <= range.Item2; currentMLSFile++)
                    {
                        MethodInvoker inv2 = delegate
                        {
                            form.debugScreen.AppendText(Environment.NewLine + "Working on row " + currentMLSFile + " in MLS xl file");
                        };
                        form.Invoke(inv2);
                        Console.WriteLine("Working on row " + currentMLSFile + " in MLS xl file");

                        // initialize the variables that will determine if file in row closed
                        //
                        // For addressMatch and ownerMatch: 0 = no match,
                        // 1 = likely a match, 2 = definitely a match
                        zipMatch = false;
                        dateClosedMatch = false;
                        addressMatch = 0;
                        ownerMatch = 0;
                        closedGFNumRow = 2;
                        consideredRowsAIM = new List<int>();

                        /// determine if zip codes are a match
                        if (Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSZipCol"]].Value2 != null)
                        {
                            string MLSZip = Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSZipCol"]].Value2.ToString();

                            for (int currentAIMFile = 2; currentAIMFile <= rangeCount["rowCountAIM"]; currentAIMFile++)
                            {
                                if (Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMZipCol"]].Value2 != null)
                                {
                                    string AIMZip = Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMZipCol"]].Value2.ToString();

                                    if (MLSZip == AIMZip)
                                    {
                                        consideredRowsAIM.Add(currentAIMFile); // add the current AIM file row to the list of considered AIM rows
                                        zipMatch = true;
                                    }
                                }
                            }
                        }

                        /// determine if date closed is a match
                        if (zipMatch && Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSCloseDateCol"]].Value2 != null) // check that the next MLS close date cell is not empty
                        {
                            // parse MLS close date into a DateTime struct
                            string MLSRawCloseDate = Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSCloseDateCol"]].Value.ToString();
                            DateTime MLSCloseDate = DateTime.Parse(MLSRawCloseDate);

                            List<int> newConsideredRows = new List<int>(consideredRowsAIM.Count);
                            consideredRowsAIM.ForEach((item) => { newConsideredRows.Add(item); });
                            foreach (int currentAIMFile in consideredRowsAIM)
                            {
                                if (Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMCloseDateCol"]].Value2 != null) // check that the next AIM close date cell is not empty
                                {
                                    // parse AIM close date into a DateTime struct
                                    string AIMRawCloseDate = Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMCloseDateCol"]].Value.ToString();
                                    DateTime AIMCloseDate = DateTime.Parse(AIMRawCloseDate);

                                    if ((MLSCloseDate - AIMCloseDate).TotalDays <= 15) // check that the two close dates are within 15 days of each other
                                    {
                                        dateClosedMatch = true;
                                        //Console.WriteLine("Found match in days between row " + currentMLSFile
                                        //    + " in MLS xl file and row " + currentAIMFile + " in AIM xl file");
                                    }
                                    else
                                        newConsideredRows.Remove(currentAIMFile);
                                }
                                else
                                    newConsideredRows.Remove(currentAIMFile);
                            }
                            consideredRowsAIM = newConsideredRows;
                        }

                        /// determine if owner/seller name are a match only if date closed and addrees are already a match
                        if (zipMatch && dateClosedMatch && Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSOwnerCol"]].Value2 != null)
                        {
                            string owner = Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSOwnerCol"]].Value2.ToString();
                            string[] parsedOwner = owner.ToLower().Split(' ');

                            //List<int> newConsideredRows = consideredRowsAIM;
                            foreach (int currentAIMFile in consideredRowsAIM)
                            {
                                if (Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMSellerCol"]].Value2 != null)
                                {
                                    string seller = Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMSellerCol"]].Value2.ToString();
                                    string[] parsedSeller = seller.ToLower().Split(' ');

                                    // Check that the first 3 (if applicable) words
                                    // in the owner string reasonably match with a
                                    // word in the seller string
                                    bool fnLnMatch = false;

                                    int numMatches = 0; // number of owner words that matches with seller words
                                    for (int i = 0, j = 1; i < parsedOwner.Length && j <= 3; i++)
                                    {
                                        if (!((parsedOwner[i].Length == 1) || (parsedOwner[i].Length == 2)
                                            || (parsedOwner[i].ToLower() == "and"))) // if not a word that should be ignored
                                        { // words that should be ignored: "and" and words with length 1 or 2
                                          // go through parsedSeller and check that the current parsedOwner word is contained
                                            for (int k = 0; k < parsedSeller.Length; k++)
                                                if (StringDistance.GetStringDistance(parsedOwner[i], parsedSeller[k]) <= 1)
                                                {
                                                    numMatches++;
                                                    break; // break out of inner for loop
                                                }
                                            j++;
                                        }
                                    }

                                    if ((parsedOwner.Length < 3 && numMatches >= 1) ||
                                        (parsedOwner.Length >= 3 && numMatches >= 2))
                                        fnLnMatch = true;

                                    // check ownerDistance against the percentage threshold of the longer test string to see if it is a match
                                    if (fnLnMatch)
                                    {
                                        ownerMatch = 2;
                                        break;
                                    }
                                    else
                                    {
                                        ownerMatch = 1;
                                    }
                                }
                                //else
                                //newConsideredRows.Remove(currentAIMFile);
                            }
                            //consideredRowsAIM = newConsideredRows;
                        }

                        /// determine if property addresses are a match only if date closed is already a match
                        if (zipMatch && dateClosedMatch && ownerMatch > 0 && Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSAddressCol"]].Value2 != null)
                        {
                            string addressMLS = Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSAddressCol"]].Value2.ToString();
                            string[] parsedAddressMLS = addressMLS.Split(' ');

                            foreach (int currentAIMFile in consideredRowsAIM)
                            {
                                if (Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMAddressCol"]].Value2 != null)
                                {
                                    // get the address strings from the xl files and parse them by the space character
                                    string addressAIM = Program.xlRangeAIM.Cells[currentAIMFile, relevantCols["AIMAddressCol"]].Value2.ToString();
                                    string[] parsedAddressAIM = addressAIM.Split(' ');

                                    if (parsedAddressMLS[0] == parsedAddressAIM[0]) // check that the address numbers match
                                    {
                                        // account for condominium, private road, and country road
                                        if (addressMLS.ToLower().Contains("condominium"))
                                        {
                                            addressMLS = addressMLS.ToLower().Replace("condominium", "");
                                            addressAIM = addressAIM.ToLower();
                                        }
                                        else if (addressAIM.ToLower().Contains("condominium"))
                                        {
                                            addressMLS = addressMLS.ToLower();
                                            addressAIM = addressAIM.ToLower().Replace("condominium", "");
                                        }
                                        if (addressMLS.ToLower().Contains("pr") && addressAIM.ToLower().Contains("private road"))
                                        {
                                            addressMLS = addressMLS.ToLower().Replace("pr", "");
                                            addressAIM = addressAIM.ToLower().Replace("private road", "");
                                        }
                                        else if (addressMLS.ToLower().Contains("private road") && addressAIM.ToLower().Contains("pr"))
                                        {
                                            addressMLS = addressMLS.ToLower().Replace("private road", "");
                                            addressAIM = addressAIM.ToLower().Replace("pr", "");
                                        }
                                        if (addressMLS.ToLower().Contains("cr") && addressAIM.ToLower().Contains("county road"))
                                        {
                                            addressMLS = addressMLS.ToLower().Replace("cr", "");
                                            addressAIM = addressAIM.ToLower().Replace("county road", "");
                                        }
                                        else if (addressMLS.ToLower().Contains("county road") && addressAIM.ToLower().Contains("cr"))
                                        {
                                            addressMLS = addressMLS.ToLower().Replace("county road", "");
                                            addressAIM = addressAIM.ToLower().Replace("cr", "");
                                        }

                                        int addressDistance = StringDistance.GetStringDistance(addressMLS, addressAIM); // get distance between the two strings

                                        // compute updated thresholds
                                        int addressThresholdUpdated = (int)Math.Ceiling(thresholds["addressThreshold"] * Math.Max(addressMLS.Length, addressAIM.Length));
                                        int addressThresholdWeakUpdated = (int)Math.Ceiling(thresholds["addressThresholdWeak"] * Math.Max(addressMLS.Length, addressAIM.Length));

                                        // check addressDistance against the percentage threshold of the longer test string to see if it is a match
                                        if (addressDistance <= addressThresholdUpdated)
                                        {
                                            addressMatch = 2;
                                            closedGFNumRow = currentAIMFile;

                                            MethodInvoker inv = delegate
                                            {
                                                form.debugScreen.AppendText(Environment.NewLine +
                                                    "Found match in address between row " + currentMLSFile
                                                    + " in MLS xl file and row " + currentAIMFile + " in AIM xl file");
                                            };
                                            form.Invoke(inv);
                                            Console.WriteLine("Found match in address between row " + currentMLSFile
                                                + " in MLS xl file and row " + currentAIMFile + " in AIM xl file");
                                            break; // if a match is found, there's no need to search any further
                                        }
                                        else if (addressDistance <= addressThresholdWeakUpdated && addressDistance > addressThresholdUpdated)
                                        {
                                            addressMatch = 1;
                                            closedGFNumRow = currentAIMFile;

                                            MethodInvoker inv = delegate
                                            {
                                                form.debugScreen.AppendText(Environment.NewLine +
                                                    "Found likely match in address between row " + currentMLSFile
                                                    + " in MLS xl file and row " + currentAIMFile + " in AIM xl file");
                                            };
                                            form.Invoke(inv);
                                            Console.WriteLine("Found likely match in address between row " + currentMLSFile
                                                + " in MLS xl file and row " + currentAIMFile + " in AIM xl file");
                                        }
                                    }
                                }
                            }
                        }

                        // critical section
                        lock (mutex)
                        {
                            /// determine whether the file was closed with hatco or not and print to xl file
                            if (zipMatch && dateClosedMatch && addressMatch == 2 && ownerMatch == 2)
                            {
                                string closedGF = Convert.ToString(Program.xlRangeAIM.Cells[closedGFNumRow, relevantCols["AIMFileNoCol"]].Value);
                                string escrOff = Convert.ToString(Program.xlRangeAIM.Cells[closedGFNumRow, relevantCols["AIMEscrowCol"]].Value);
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSGFCol"]].Value = closedGF;
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSEscrowOfficerCol"]].Value = escrOff;

                                MethodInvoker inv = delegate
                                {
                                    form.debugScreen.AppendText(Environment.NewLine + "File on row " + currentMLSFile +
                                        " of MLS xl file closed with GF #" + closedGF);
                                };
                                form.Invoke(inv);
                                Console.WriteLine("File on row " + currentMLSFile + " of MLS xl file closed with GF #"
                                    + closedGF);
                            }
                            else if (zipMatch && dateClosedMatch && addressMatch > 0 && ownerMatch > 0)
                            {
                                string closedGF = Convert.ToString(Program.xlRangeAIM.Cells[closedGFNumRow, relevantCols["AIMFileNoCol"]].Value);
                                string escrOff = Convert.ToString(Program.xlRangeAIM.Cells[closedGFNumRow, relevantCols["AIMEscrowCol"]].Value);
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSGFCol"]].Value = closedGF;
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSLikelyCloseCol"]].Value = "true";
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSEscrowOfficerCol"]].Value = escrOff;

                                MethodInvoker inv = delegate
                                {
                                    form.debugScreen.AppendText(Environment.NewLine + "File on row " + currentMLSFile +
                                        " likely closed with GF #" + closedGF);
                                };
                                form.Invoke(inv);
                                Console.WriteLine("File on row " + currentMLSFile + " likely closed with GF #" + closedGF);
                            }
                            else
                            {
                                Program.xlRangeMLS.Cells[currentMLSFile, relevantCols["MLSGFCol"]].Value = "did not close";

                                MethodInvoker inv = delegate
                                {
                                    form.debugScreen.AppendText(Environment.NewLine + "File on row " + currentMLSFile + " did not close");
                                };
                                form.Invoke(inv);
                                Console.WriteLine("File on row " + currentMLSFile + " did not close");
                            }

                            // update progress bar after each row of MLS file
                            MethodInvoker inv1 = delegate
                            {
                                form.determinerProgressBar.Increment(1);
                            };
                            form.Invoke(inv1);

                            // update detailed progress after each row of MLS file
                            //string progressDetailedUpdate = (int.Parse(form.determinerProgressDetailed.Text.Split('/')[0]) + 1) +
                            //    "/" + (rangeCount["rowCountMLS"] - 1);
                            //MethodInvoker inv2 = delegate
                            //{
                            //    form.determinerProgressDetailed.Text = progressDetailedUpdate;
                            //};
                            //form.Invoke(inv2);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    returnCode = 1;
                    state.Stop();
                }
            });

            return returnCode;
        }
    }
}
