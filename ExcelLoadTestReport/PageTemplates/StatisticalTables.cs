using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelLoadTestReport;


namespace ExcelLoadTestReport.PageTemplates
{

    class StatisticalTables : ITemplateBase
    {

        Excel.Application App = Globals.ThisAddIn.Application;

        #region ITemplateBase Members

        public string PageTitle
        {
            get;
            set;
        }

        public string PageDescription
        {
            get;
            set;
        }
        /// <summary>
        /// Use this template to create pivot charts and graphs for an entire category or a specific counter
        /// </summary>
        /// <param name="TestNumber">The numeric LoadTestRunId from the database</param>
        /// <param name="Category">Category name of counters in database (Processor, Memory, LoadTest:Transactions)</param>
        /// <param name="Counter">Counter name for a specific category (Processor %</param>
        /// <param name="Category">Select true if you would like to create a pivot chart to accompany this pivot table</param>
        /// <returns></returns>

        private string _connString = string.Empty;

        public StatisticalTables(string ConnectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                _connString = ConnectionString;
            }
            else
            {
                throw new ArgumentException("You must provide the connection string to the constructor.", "ConnectionString");
            }
        }

        public bool Fill(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters, bool CreateChart = true, bool CreateRawSheets = true, string ChartName = "")
        {
            if (TestNumber.Count > 1)
            {
                CreateStatsTableMultiple(TestNumber, Counters, ChartName, CreateChart, CreateRawSheets);
            }
            else
            {
                CreateStatsTable(TestNumber, Counters, ChartName, CreateChart, CreateRawSheets);

            }
            return true;
        }

        public int CreateSheet(string SheetName, dynamic results)
        {



            var statsTable = new Dictionary<string, Dictionary<string, List<Single>>>();
            foreach (var item in results)
            {
                string correctedName = item.InstanceName;
                string loadTestRunId = item.LoadTestRunId.ToString();
                if (correctedName.Trim().EndsWith(")"))
                {
                    correctedName = correctedName.Remove(correctedName.Length - 5);
                }
                if (!statsTable.ContainsKey(loadTestRunId))
                {
                    statsTable.Add(loadTestRunId, new Dictionary<string, List<Single>>());
                }
                if (!statsTable[loadTestRunId].ContainsKey(correctedName))
                {
                    statsTable[loadTestRunId].Add(correctedName, new List<Single>());
                }
                if (statsTable[loadTestRunId].ContainsKey(correctedName))
                {
                    if (statsTable[loadTestRunId][correctedName] == null)
                    {
                        statsTable[loadTestRunId][correctedName] = new List<Single>();
                    }
                    statsTable[loadTestRunId][correctedName].Add(item.ComputedValue);
                }
                System.Threading.Thread.Sleep(0);
            }


            foreach (var listOfStats in statsTable.Keys)
            {
                string rawSheetName = string.Format("{1} rawStat{0}", SheetName.Replace("-", ""), listOfStats);
                rawSheetName = rawSheetName.Length > 30 ? rawSheetName.Remove(30) : rawSheetName;

                string statSheetName = string.Format("{1} Stats {0}", SheetName, listOfStats);
                statSheetName = statSheetName.Length > 30 ? statSheetName.Remove(30) : statSheetName;


                Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
                Globals.ThisAddIn.Application.ActiveSheet.Name = rawSheetName;
                Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "raw");

                // Create statistics sheet here as well.
                Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
                Globals.ThisAddIn.Application.ActiveSheet.Name = statSheetName;
                Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "stats");

                App.ActiveSheet.Range["A1"] = "";
                App.ActiveSheet.Range["B1"] = "Min";
                App.ActiveSheet.Range["C1"] = "Max";
                App.ActiveSheet.Range["D1"] = "Avg.";
                App.ActiveSheet.Range["E1"] = "90th Percentile";
                App.ActiveSheet.Range["F1"] = "95th Percentile";
                App.ActiveSheet.Range["G1"] = "99th Percentile";
                App.ActiveSheet.Range["H1"] = "Std. Dev.";

                int startingColumn = 1;
                foreach (var item in statsTable[listOfStats].Keys)
                {
                    int countNumber = statsTable[listOfStats][item].Count;
                    App.Sheets[rawSheetName].Select();
                    App.ActiveSheet.Cells[1, startingColumn] = item;
                    Single[,] _multiDimensional = new Single[countNumber, 1];

                    for (int i = 0; i < countNumber; i++)
                    {
                        _multiDimensional[i, 0] = statsTable[listOfStats][item][i];
                    }

                    App.ActiveSheet.Range[App.Cells[2, startingColumn], App.Cells[1 + countNumber, startingColumn]] = _multiDimensional;

                    string formulaAddress = App.ActiveSheet.Range[App.Cells[2, startingColumn], App.Cells[2 + countNumber, startingColumn]].Address;

                    App.Sheets[statSheetName].Select();
                    App.ActiveSheet.Range[App.Cells[startingColumn + 1, 1], App.Cells[startingColumn + 1, 8]] =
                    new object[] {
                        item,
                        string.Format("=MIN('{0}'!{1})", rawSheetName, formulaAddress),
                        string.Format("=MAX('{0}'!{1})", rawSheetName, formulaAddress),
                        string.Format("=AVERAGE('{0}'!{1},0.99)", rawSheetName, formulaAddress),
                        string.Format("=PERCENTILE.INC('{0}'!{1},0.9)", rawSheetName, formulaAddress),
                        string.Format("=PERCENTILE.INC('{0}'!{1},0.95)", rawSheetName, formulaAddress),
                        string.Format("=PERCENTILE.INC('{0}'!{1},0.99)", rawSheetName, formulaAddress),
                        string.Format("=STDEV.P('{0}'!{1})", rawSheetName, formulaAddress)
                    };
                    startingColumn++;
                    System.Threading.Thread.Sleep(0);

                }

                App.ActiveSheet.Cells.Select();
                App.ActiveSheet.Cells.EntireColumn.AutoFit();
                System.Threading.Thread.Sleep(0);
            }

            return 0;
        }

        public int CreateTransactionSheet(string SheetName, dynamic results)
        {

            string statSheetName = string.Format("Stats {0}", SheetName);
            statSheetName = statSheetName.Length > 30 ? statSheetName.Remove(30) : statSheetName;

            // Create statistics sheet here as well.
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            Globals.ThisAddIn.Application.ActiveSheet.Name = statSheetName;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "stats");
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetName", statSheetName);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetDescription", "Statistics for Transaction Response times.");

            App.ActiveSheet.Range["A1"] = "Transaction Name";
            App.ActiveSheet.Range["B1"] = "Count";
            App.ActiveSheet.Range["C1"] = "Average";
            App.ActiveSheet.Range["D1"] = "Minimum";
            App.ActiveSheet.Range["E1"] = "Maximum";
            App.ActiveSheet.Range["F1"] = "90th Percentile";
            App.ActiveSheet.Range["G1"] = "95th Percentile";
            App.ActiveSheet.Range["H1"] = "99th Percentile";
            App.ActiveSheet.Range["I1"] = "Median";
            App.ActiveSheet.Range["J1"] = "Std. Dev.";
            App.ActiveSheet.Range["K1"] = "Avg. Transaction Time";

            int startingRow = 2;
            foreach (var item in results)
            {
                object[] _multiDimensional = new object[] { item.TransactionName, item.Count, item.Avg, item.Min, item.Max, item._90th, item._95th, item._99th, item.Median, item.StdDev, item.TransAvg };
                App.ActiveSheet.Range[App.Cells[startingRow, 1], App.Cells[startingRow, 11]] = _multiDimensional;
                startingRow++;
                System.Threading.Thread.Sleep(0);
            }

            App.ActiveSheet.Cells.Select();
            App.ActiveSheet.Cells.EntireColumn.AutoFit();
            System.Threading.Thread.Sleep(0);

            return startingRow;
        }

        public int CreateTransactionSheetMultiple(string SheetName, Dictionary<int, dynamic> results, List<int> TestNumber)
        {

            string statSheetName = string.Format("Stats {0}", SheetName);
            statSheetName = statSheetName.Length > 30 ? statSheetName.Remove(30) : statSheetName;

            // Create statistics sheet here as well.
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            Globals.ThisAddIn.Application.ActiveSheet.Name = statSheetName;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "stats");
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTTestCount", TestNumber.Count);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetName", statSheetName);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetDescription", "Statistics for Transaction Response times.");

            var list = new List<string>();
            list.Add("Count");
            list.Add("Average");
            list.Add("Minimum");
            list.Add("Maximum");
            list.Add("90th Percentile");
            list.Add("95th Percentile");
            list.Add("99th Percentile");
            list.Add("Median");
            list.Add("Std. Dev.");
            list.Add("Avg. Transaction Time");
            App.ActiveSheet.Cells[1, 1] = "Transaction Name";

            for (int i = 0, column = 2; i < list.Count; i++, column += TestNumber.Count)
            {
                App.ActiveSheet.Range[App.ActiveSheet.Cells[1, column], App.ActiveSheet.Cells[1, column + TestNumber.Count - 1]] = new object[] { list[i], "", "" };
                App.ActiveSheet.Range[App.ActiveSheet.Cells[1, column], App.ActiveSheet.Cells[1, column + TestNumber.Count - 1]].Merge();
            }

            for (int i = 0; i < list.Count; i++)
            {
                int testNumberCounter = 1;
                foreach (var item in TestNumber)
                {
                    App.ActiveSheet.Range[App.ActiveSheet.Cells[2, ((i * TestNumber.Count) + 1) + testNumberCounter], App.ActiveSheet.Cells[2, ((i * TestNumber.Count) + 1) + testNumberCounter]] = item;
                    testNumberCounter++;
                }
            }

            var testCombine = new Dictionary<string, object[]>();
            int testNumber = 1;
            foreach (var item in TestNumber)
            {
                foreach (var lineItem in results[item])
                {
                    var key = lineItem.ScenarioName + lineItem.TestName + lineItem.TransactionName;
                    if (!testCombine.ContainsKey(key))
                    {
                        testCombine.Add(key, new object[(TestNumber.Count * list.Count) + 1]);
                        testCombine[key][0] = lineItem.TransactionName;
                    }
                    testCombine[key][(0 * TestNumber.Count) + testNumber] = lineItem.Count;
                    testCombine[key][(1 * TestNumber.Count) + testNumber] = lineItem.Avg;
                    testCombine[key][(2 * TestNumber.Count) + testNumber] = lineItem.Min;
                    testCombine[key][(3 * TestNumber.Count) + testNumber] = lineItem.Max;
                    testCombine[key][(4 * TestNumber.Count) + testNumber] = lineItem._90th;
                    testCombine[key][(5 * TestNumber.Count) + testNumber] = lineItem._95th;
                    testCombine[key][(6 * TestNumber.Count) + testNumber] = lineItem._99th;
                    testCombine[key][(7 * TestNumber.Count) + testNumber] = lineItem.Median;
                    testCombine[key][(8 * TestNumber.Count) + testNumber] = lineItem.StdDev;
                    testCombine[key][(9 * TestNumber.Count) + testNumber] = lineItem.TransAvg;
                }
                testNumber++;
            }

            int startingRow = 3;
            foreach (var item in testCombine)
            {
                App.ActiveSheet.Range[App.Cells[startingRow, 1], App.Cells[startingRow, (TestNumber.Count * list.Count) + 1]] = item.Value;
                startingRow++;
                System.Threading.Thread.Sleep(0);
            }
            App.ActiveSheet.Cells.Select();
            App.ActiveSheet.Cells.EntireColumn.AutoFit();
            System.Threading.Thread.Sleep(0);

            return startingRow;
        }

        public int CreatePageSheet(string SheetName, dynamic results)
        {

            string statSheetName = string.Format("Stats {0}", SheetName);
            statSheetName = statSheetName.Length > 30 ? statSheetName.Remove(30) : statSheetName;

            // Create statistics sheet here as well.
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            Globals.ThisAddIn.Application.ActiveSheet.Name = statSheetName;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "stats");
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetName", statSheetName);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetDescription", "Statistics for Page Response times.");

            App.ActiveSheet.Range["A1"] = "Page";
            App.ActiveSheet.Range["B1"] = "Count";
            App.ActiveSheet.Range["C1"] = "Average";
            App.ActiveSheet.Range["D1"] = "Minimum";
            App.ActiveSheet.Range["E1"] = "Maximum";
            App.ActiveSheet.Range["F1"] = "90th Percentile";
            App.ActiveSheet.Range["G1"] = "95th Percentile";

            int startingRow = 2;
            foreach (var item in results)
            {
                object[] _multiDimensional = new object[] { item.TransactionName, item.Count, item.Avg, item.Min, item.Max, item._90th, item._95th };
                App.ActiveSheet.Range[App.Cells[startingRow, 1], App.Cells[startingRow, 7]] = _multiDimensional;
                startingRow++;
                System.Threading.Thread.Sleep(0);
            }

            App.ActiveSheet.Cells.Select();
            App.ActiveSheet.Cells.EntireColumn.AutoFit();
            System.Threading.Thread.Sleep(0);

            return startingRow;
        }

        public int CreatePageSheetMultiple(string SheetName, Dictionary<int, dynamic> results, List<int> TestNumber)
        {

            string statSheetName = string.Format("Stats {0}", SheetName);
            statSheetName = statSheetName.Length > 30 ? statSheetName.Remove(30) : statSheetName;

            // Create statistics sheet here as well.
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            Globals.ThisAddIn.Application.ActiveSheet.Name = statSheetName;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "stats");
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTTestCount", TestNumber.Count);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetName", statSheetName);
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetDescription", "Statistics for Page Response times.");

            var list = new List<string>();
            list.Add("Count");
            list.Add("Average");
            list.Add("Minimum");
            list.Add("Maximum");
            list.Add("90th Percentile");
            list.Add("95th Percentile");
            App.ActiveSheet.Cells[1, 1] = "Page";

            for (int i = 0, column = 2; i < list.Count; i++, column += TestNumber.Count)
            {
                App.ActiveSheet.Range[App.ActiveSheet.Cells[1, column], App.ActiveSheet.Cells[1, column + TestNumber.Count - 1]] = new object[] { list[i], "", "" };
                App.ActiveSheet.Range[App.ActiveSheet.Cells[1, column], App.ActiveSheet.Cells[1, column + TestNumber.Count - 1]].Merge();
            }

            for (int i = 0; i < list.Count; i++)
            {
                int testNumberCounter = 1;
                foreach (var item in TestNumber)
                {
                    App.ActiveSheet.Range[App.ActiveSheet.Cells[2, ((i * TestNumber.Count) + 1) + testNumberCounter], App.ActiveSheet.Cells[2, ((i * TestNumber.Count) + 1) + testNumberCounter]] = item;
                    testNumberCounter++;
                }
            }

            var testCombine = new Dictionary<string, object[]>();
            int testNumber = 1;
            foreach (var item in TestNumber)
            {
                foreach (var lineItem in results[item])
                {
                    var key = lineItem.ScenarioName + lineItem.TestName + lineItem.TransactionName;
                    if (!testCombine.ContainsKey(key))
                    {
                        testCombine.Add(key, new object[(TestNumber.Count * list.Count) + 1]);
                        testCombine[key][0] = lineItem.TransactionName;
                    }
                    testCombine[key][(0 * TestNumber.Count) + testNumber] = lineItem.Count;
                    testCombine[key][(1 * TestNumber.Count) + testNumber] = lineItem.Avg;
                    testCombine[key][(2 * TestNumber.Count) + testNumber] = lineItem.Min;
                    testCombine[key][(3 * TestNumber.Count) + testNumber] = lineItem.Max;
                    testCombine[key][(4 * TestNumber.Count) + testNumber] = lineItem._90th;
                    testCombine[key][(5 * TestNumber.Count) + testNumber] = lineItem._95th;
                }
                testNumber++;
            }

            int startingRow = 3;
            foreach (var item in testCombine)
            {
                App.ActiveSheet.Range[App.Cells[startingRow, 1], App.Cells[startingRow, (TestNumber.Count * list.Count) + 1]] = item.Value;
                startingRow++;
                System.Threading.Thread.Sleep(0);
            }
            App.ActiveSheet.Cells.Select();
            App.ActiveSheet.Cells.EntireColumn.AutoFit();
            System.Threading.Thread.Sleep(0);

            return startingRow;
        }

        internal void CreateStatsTableInternal(string Range, string SourceSheet, string Sheetname, string PivotTableName)
        {
            string sheetRange = string.Format("'{0}'!{1}", SourceSheet, Range);
            App.ActiveWorkbook.Sheets.Add(After: App.ActiveWorkbook.Sheets[App.ActiveWorkbook.Sheets.Count]);
            App.ActiveSheet.Name = Sheetname;


            var pvtCache = App.ActiveWorkbook.PivotCaches().Create(
            SourceType: Excel.XlPivotTableSourceType.xlDatabase,
            SourceData: sheetRange,
            Version: Excel.XlPivotTableVersionList.xlPivotTableVersion14).CreatePivotTable(
            TableDestination: string.Format("'{0}'!R3C1", Sheetname),
            TableName: PivotTableName,
            DefaultVersion: Excel.XlPivotTableVersionList.xlPivotTableVersion14);
            App.Sheets[Sheetname].Select();
        }

        private void CreateStatsTable(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters, string ChartName, bool CreateChart = true, bool CreateFromRange = false)
        {
            App.DisplayAlerts = false;

            if (!CreateFromRange)
            {
            }
            else
            {
                int sheetRows = 0;
                using (var context = new Models.LoadTest2010Entities(_connString))
                {
                    context.CommandTimeout = 60;
                    var sb = new StringBuilder();
                    for (int i = 0; i < TestNumber.Count; i++)
                    {
                        int testNum = TestNumber[i];
                        string ChartClean = ChartName.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":", "");
                        string rawSheetName = String.Format("{1} {0}", ChartClean, testNum);

                        rawSheetName = rawSheetName.Length > 30 ? rawSheetName.Remove(30) : rawSheetName;


                        dynamic result = null;
                        foreach (var counterList in Counters)
                        {
                            if (counterList.Value.CounterCategory.Equals("LoadTest:Transaction", StringComparison.CurrentCultureIgnoreCase)
                                && counterList.Value.CounterName.Equals("Avg. Response Time", StringComparison.CurrentCultureIgnoreCase))
                            {
                                result = (from items in context.LoadTestTransactionSummaryDatas
                                          join transName in context.WebLoadTestTransactions
                                          on new { items.LoadTestRunId, items.TransactionId } equals new { transName.LoadTestRunId, transName.TransactionId }
                                          join testName in context.LoadTestCases
                                          on new { items.LoadTestRunId, transName.TestCaseId } equals new { testName.LoadTestRunId, testName.TestCaseId }
                                          join scenarioName in context.LoadTestScenarios
                                          on new { items.LoadTestRunId, testName.ScenarioId } equals new { scenarioName.LoadTestRunId, scenarioName.ScenarioId }
                                          where items.LoadTestRunId == testNum
                                          select new
                                          {
                                              ScenarioName = scenarioName.ScenarioName,
                                              TestName = testName.TestCaseName,
                                              TransactionName = transName.TransactionName,
                                              Count = items.TransactionCount,
                                              Avg = items.Average,
                                              Min = items.Minimum,
                                              Max = items.Maximum,
                                              _90th = items.Percentile90,
                                              _95th = items.Percentile95,
                                              _99th = items.Percentile99,
                                              Median = items.Median,
                                              StdDev = items.StandardDeviation,
                                              TransAvg = items.AvgTransactionTime
                                          });
                                sheetRows = CreateTransactionSheet(rawSheetName, result);
                            }
                            else if (counterList.Value.CounterCategory.Equals("LoadTest:Page", StringComparison.CurrentCultureIgnoreCase)
                                && counterList.Value.CounterName.Equals("Avg. Page Time", StringComparison.CurrentCultureIgnoreCase))
                            {
                                result = (from items in context.LoadTestPageResults
                                          where items.LoadTestRunId == testNum
                                          select new
                                          {
                                              TransactionName = items.RequestUri,
                                              Count = items.PageCount,
                                              Avg = items.Average,
                                              Min = items.Minimum,
                                              Max = items.Maximum,
                                              _90th = items.Percentile90,
                                              _95th = items.Percentile95,
                                          });
                                sheetRows = CreatePageSheet(rawSheetName, result);
                            }
                            else
                            {
                                result.UnionAll((from items in context.LoadTestComputedCounterSamples
                                                 where items.LoadTestRunId == testNum
                                                 && items.CategoryName == counterList.Value.CounterCategory
                                                 && items.CounterName == counterList.Value.CounterName
                                                 select items));
                                sheetRows = CreateSheet(rawSheetName, result);
                            }
                        }

                    }

                    if (sheetRows == 0)
                    {
                        return;
                    }
                }
                string sheetRange = string.Format("A1:G{0}", sheetRows);

            }

        }

        private void CreateStatsTableMultiple(List<int> TestNumber,
            Dictionary<int, DAO.Counters> Counters, string ChartName, bool CreateChart = true, bool CreateFromRange = false)
        {
            App.DisplayAlerts = false;

            if (!CreateFromRange)
            {
            }
            else
            {
                string rawSheetName = string.Empty;
                int sheetRows = 0;
                using (var context = new Models.LoadTest2010Entities())
                {
                    context.CommandTimeout = 60;
                    var sb = new StringBuilder();

                    dynamic result = null;
                    var newList = new Dictionary<int, dynamic>();
                    for (int i = 0; i < TestNumber.Count; i++)
                    {
                        int testNum = TestNumber[i];
                        foreach (var counterList in Counters)
                        {
                            string ChartClean = ChartName.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":", "");
                            rawSheetName = String.Format("{0} Compare", ChartClean);

                            rawSheetName = rawSheetName.Length > 30 ? rawSheetName.Remove(30) : rawSheetName;

                            if (counterList.Value.CounterCategory.Equals("LoadTest:Transaction", StringComparison.CurrentCultureIgnoreCase)
                                && counterList.Value.CounterName.Equals("Avg. Response Time", StringComparison.CurrentCultureIgnoreCase))
                            {

                                result = (from items in context.LoadTestTransactionSummaryDatas
                                          join transName in context.WebLoadTestTransactions
                                          on new { items.LoadTestRunId, items.TransactionId } equals new { transName.LoadTestRunId, transName.TransactionId }
                                          join testName in context.LoadTestCases
                                          on new { items.LoadTestRunId, transName.TestCaseId } equals new { testName.LoadTestRunId, testName.TestCaseId }
                                          join scenarioName in context.LoadTestScenarios
                                          on new { items.LoadTestRunId, testName.ScenarioId } equals new { scenarioName.LoadTestRunId, scenarioName.ScenarioId }
                                          where items.LoadTestRunId == testNum
                                          select new
                                          {
                                              ScenarioName = scenarioName.ScenarioName,
                                              TestName = testName.TestCaseName,
                                              TransactionName = transName.TransactionName,
                                              Count = items.TransactionCount,
                                              Avg = items.Average,
                                              Min = items.Minimum,
                                              Max = items.Maximum,
                                              _90th = items.Percentile90,
                                              _95th = items.Percentile95,
                                              _99th = items.Percentile99,
                                              Median = items.Median,
                                              StdDev = items.StandardDeviation,
                                              TransAvg = items.AvgTransactionTime
                                          });
                                newList.Add(testNum, result);

                            }
                            else if (counterList.Value.CounterCategory.Equals("LoadTest:Page", StringComparison.CurrentCultureIgnoreCase)
                                && counterList.Value.CounterName.Equals("Avg. Page Time", StringComparison.CurrentCultureIgnoreCase))
                            {
                                result = (from items in context.LoadTestPageResults
                                          where items.LoadTestRunId == testNum
                                          select new
                                          {
                                              ScenarioName = items.ScenarioName,
                                              TestName = items.TestCaseName,
                                              TransactionName = items.RequestUri,
                                              Count = items.PageCount,
                                              Avg = items.Average,
                                              Min = items.Minimum,
                                              Max = items.Maximum,
                                              _90th = items.Percentile90,
                                              _95th = items.Percentile95,
                                          });
                                newList.Add(testNum, result);
                            }

                        }
                    }
                    foreach (var counterList in Counters)
                    {
                        if (counterList.Value.CounterCategory.Equals("LoadTest:Transaction", StringComparison.CurrentCultureIgnoreCase)
                                  && counterList.Value.CounterName.Equals("Avg. Response Time", StringComparison.CurrentCultureIgnoreCase))
                        {
                            sheetRows = CreateTransactionSheetMultiple(rawSheetName, newList, TestNumber);
                        }
                        else if (counterList.Value.CounterCategory.Equals("LoadTest:Page", StringComparison.CurrentCultureIgnoreCase)
                            && counterList.Value.CounterName.Equals("Avg. Page Time", StringComparison.CurrentCultureIgnoreCase))
                        {
                            sheetRows = CreatePageSheetMultiple(rawSheetName, newList, TestNumber);
                        }
                        else
                        {
                            sheetRows = CreateSheet(rawSheetName, result);
                        }
                    }
                    if (sheetRows == 0)
                    {
                        return;
                    }
                }
                string sheetRange = string.Format("A1:G{0}", sheetRows);

            }

        }



        #endregion


        #region ITemplateBase Members


        public void CreateTOC(List<int> TestNumber, List<DAO.LoadTestReports> reportList)
        {

            bool createTOC = true;
            foreach (var tocTest in App.Sheets)
            {
                if (tocTest is Excel.Worksheet)
                {
                    var worksheet = tocTest as Excel.Worksheet;
                    if (worksheet.Name == "TOC")
                    {
                        createTOC = false;
                        worksheet.Select();
                    }

                }
            }
            if (createTOC)
            {
                Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(Before: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[1]);
                Globals.ThisAddIn.Application.ActiveSheet.Name = "TOC";
                Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "TOC");
            }
            foreach (var worksheetTest in App.Sheets)
            {
                if (worksheetTest is Excel.Worksheet)
                {
                    var worksheet = worksheetTest as Excel.Worksheet;
                    if (worksheet.Name.StartsWith("sheet", StringComparison.CurrentCultureIgnoreCase))
                    {
                        worksheet.Delete();
                    }
                }
            }
            int rowNumber = 1;
            for (int i = 1; i < 1000000; i++)
            {
                if (string.IsNullOrEmpty(App.Cells[i, 1].Value))
                {
                    rowNumber = i;
                    break;
                }
            }
            var cell = App.Cells[rowNumber, 1];

            foreach (Excel.Worksheet item in App.Worksheets)
            {
                if (item.CustomProperties != null && item.CustomProperties.Count > 0)
                {
                    foreach (Excel.CustomProperty custProp in item.CustomProperties)
                    {
                        if (custProp.Name == "PublixLTSheetName")
                        {
                            try
                            {

                                App.ActiveSheet.HyperLinks.Add(Anchor: cell,
                        Address: string.Format("{0}", item.Name),
                        SubAddress: string.Format("{0}", item.Name),
                        TextToDisplay: custProp.Value);
                                rowNumber++;
                                cell = App.Cells[rowNumber, 1];
                            }
                            catch (Exception)
                            {
                                // Swallow this so we can continue processing.
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
