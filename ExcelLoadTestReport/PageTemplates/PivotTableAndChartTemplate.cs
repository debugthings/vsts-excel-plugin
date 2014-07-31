using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelLoadTestReport;
using System.Data.Objects;


namespace ExcelLoadTestReport.PageTemplates
{

    public delegate bool FillAsync(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters,
            bool CreateChart = true, bool CreateRawSheets = true, string ChartName = "");




    public class EntityTypeForChart
    {
        public int LoadTestRunId { get; set; }
        public string MachineName { get; set; }
        public string CategoryName { get; set; }
        public string CounterName { get; set; }
        public string InstanceName { get; set; }
        public DateTime Interval { get; set; }
        public DateTime IntervalStart { get; set; }
        public int CounterType { get; set; }
        public Single? ComputedValue { get; set; }
        public bool ThresholdRuleResult { get; set; }
    }

    public class EntityTypeForLookup
    {
        public string MachineName { get; set; }
        public int InstanceId { get; set; }
    }
    class PivotTableAndChartTemplate : ITemplateBase
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

        public PivotTableAndChartTemplate(string ConnectionString)
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

        public bool Fill(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters,
            bool CreateChart = true, bool CreateRawSheets = true, string ChartName = "")
        {
            CreatePivotTable(TestNumber, Counters, ChartName, CreateChart);
            return true;
        }

        private int CreateSheet(string SheetName, dynamic results, out int MachineCount, out int CounterCount, out int InstanceCount)
        {
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            Globals.ThisAddIn.Application.ActiveSheet.Name = SheetName;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "raw");

            App.Sheets[SheetName].Select();
            App.ActiveSheet.Range["A1"] = "Interval";
            App.ActiveSheet.Range["B1"] = "MachineName";
            App.ActiveSheet.Range["C1"] = "CategoryName";
            App.ActiveSheet.Range["D1"] = "CounterName";
            App.ActiveSheet.Range["E1"] = "InstanceName";
            App.ActiveSheet.Range["F1"] = "ComputedValue";
            App.ActiveSheet.Range["G1"] = "LoadTestRunId";

            int rowCount = 0;
            object[,] _multiDimensional = new object[1000, 7];
            int startingRow = 2;
            int jaggedCount = 0;
            string firstRowText = string.Empty;
            int itemCount = 0;
            Single itemValuesSum = 0;

            var listMachines = new List<string>();
            var listCounters = new List<string>();
            var listInstances = new List<string>();
            foreach (var item in results)
            {
                if (!listMachines.Contains(item.MachineName))
                {
                    listMachines.Add(item.MachineName);
                }
                if (!listCounters.Contains(item.CounterName))
                {
                    listCounters.Add(item.CounterName);
                }

                if (!listInstances.Contains(item.InstanceName))
                {
                    listInstances.Add(item.InstanceName);
                }
                // Store the first occurance of this counter
                if (rowCount == 0)
                {
                    firstRowText = item.MachineName + item.CategoryName + item.CounterName + item.InstanceName;
                }
                // Check to see if there are any other rows by a different name.
                // If there are increase the itemValuesSum by the new value.
                if (!firstRowText.Equals(item.MachineName + item.CategoryName + item.CounterName + item.InstanceName, StringComparison.CurrentCultureIgnoreCase))
                {
                    itemCount++;
                }
                else if (itemCount == 0)
                {
                    itemValuesSum += (Single)item.ComputedValue;
                }

                _multiDimensional[jaggedCount, 0] = item.Interval.TimeOfDay.ToString();
                _multiDimensional[jaggedCount, 1] = item.MachineName;
                _multiDimensional[jaggedCount, 2] = item.CategoryName;
                _multiDimensional[jaggedCount, 3] = item.CounterName;
                _multiDimensional[jaggedCount, 4] = item.InstanceName;
                _multiDimensional[jaggedCount, 5] = item.ComputedValue;
                _multiDimensional[jaggedCount, 6] = item.LoadTestRunId;
                System.Threading.Thread.Sleep(0);
                jaggedCount++;
                rowCount++;
                if (rowCount > 1000000)
                {
                    break;
                }
                if (rowCount > 0 && rowCount % 1000 == 0)
                {
                    int offset = rowCount + 2;
                    App.ActiveSheet.Range[string.Format("A{0}:G{1}", startingRow, offset)].Value2 = _multiDimensional;
                    startingRow = rowCount + 1;
                    jaggedCount = 0;
                    _multiDimensional = new object[1000, 7];
                }
            }


            if (jaggedCount > 0 && rowCount < 1000000)
            {
                object[,] CopyArray = new object[jaggedCount, 7];
                for (int i = 0; i < jaggedCount; i++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        CopyArray[i, k] = _multiDimensional[i, k];
                    }
                }
                App.ActiveSheet.Range[string.Format("A{0}:G{1}", startingRow, rowCount + 2)].Value2 = CopyArray;
            }

            // A little bit of a hack to NOT display the pivot table and chart.
            // This happens because the load generator creates a _Total transaction but has nothing to fill it with so it places
            // all 0s in the data.

            MachineCount = listMachines.Count;
            InstanceCount = listInstances.Count;
            CounterCount = listCounters.Count;

            if (itemCount == 0 && itemValuesSum == 0)
            {
                return 0;
            }

            return rowCount;
        }

        private void CreatePivotTableInternal(string Range, string SourceSheet, string Sheetname, string PivotTableName)
        {
            string sheetRange = string.Format("'{0}'!{1}", SourceSheet, Range);
            App.ActiveWorkbook.Sheets.Add(After: App.ActiveWorkbook.Sheets[App.ActiveWorkbook.Sheets.Count]);
            App.ActiveSheet.Name = Sheetname;
            Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTSheetType", "pivot");


            var pvtCache = App.ActiveWorkbook.PivotCaches().Create(
            SourceType: Excel.XlPivotTableSourceType.xlDatabase,
            SourceData: sheetRange,
            Version: Excel.XlPivotTableVersionList.xlPivotTableVersion14).CreatePivotTable(
            TableDestination: string.Format("'{0}'!R3C1", Sheetname),
            TableName: PivotTableName,
            DefaultVersion: Excel.XlPivotTableVersionList.xlPivotTableVersion14);
            App.Sheets[Sheetname].Select();
        }

        private void CreatePivotTable(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters,
            string ChartName, bool CreateChart = true)
        {
            if (TestNumber.Count == 0)
            {
                return;
            }

            string ChartClean = ChartName.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":", "");

            string rawSheetName = String.Format("rawPvt{0}", ChartClean);
            string PivotTableName = String.Format("Pivot Table {0}", ChartClean);
            string PvtSheetName = String.Format("{0} Pivot", ChartClean);
            string ChartSheetName = String.Format("{0} Chart", ChartClean);

            rawSheetName = rawSheetName.Length > 30 ? rawSheetName.Remove(30) : rawSheetName;
            PvtSheetName = PvtSheetName.Length > 30 ? PvtSheetName.Remove(30) : PvtSheetName;

            int MachineCount = 0;
            int CounterCount = 0;
            int InstanceCount = 0;

            
                int sheetRows = 0;
                using (var context = new Models.LoadTest2010Entities(_connString))
                {
                    context.CommandTimeout = 120;
                    var sb = new StringBuilder();
                    int firstItem = TestNumber[0];
                    IEnumerable<Models.Pbx_GetSamplesForTest_Result> result = null;
                    for (int i = 0; i < TestNumber.Count; i++)
                    {
                        foreach (var counterList in Counters)
                        {
                            int testNum = TestNumber[i];
                            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                            sw.Start();
                            var conCatresult = (from items in context.PublixGetSamplesForTest(testNum, counterList.Value.CounterCategory, counterList.Value.CounterName, counterList.Value.CounterInstance, counterList.Value.FilterOutLoadTestRig) select items).ToList();
                            sw.Stop();
                            var ts = sw.Elapsed;
                            if (result == null)
                            {
                                result = conCatresult;
                            }
                            else
                            {
                                result = result.Concat(conCatresult);
                            }
                        }
                    }

                    sheetRows = CreateSheet(rawSheetName, result, out MachineCount, out CounterCount, out InstanceCount);
                    if (sheetRows == 0)
                    {
                        return;
                    }
                }
                string sheetRange = string.Format("A1:G{0}", sheetRows);
                CreatePivotTableInternal(sheetRange, rawSheetName, PvtSheetName, PivotTableName);
                //Globals.ThisAddIn.Application.ActiveSheet.CustomProperties.Add("PublixLTCounterstObject", Counters);
            

            var pvtTable = CreatePivotTableData("", PivotTableName, MachineCount, CounterCount, InstanceCount, TestNumber.Count);

            if (CreateChart)
            {
                CreateExcelChart(TestNumber, "", "", ChartSheetName, pvtTable);
            }

        }

        private static dynamic CreatePivotTableData(string Category, string PivotTableName, int MachineCount, int CounterCount, int InstanceCount, int TestCount)
        {
            var pvtTable = Globals.ThisAddIn.Application.ActiveSheet.PivotTables(PivotTableName);

            int position = 0;
            var pvtField = pvtTable.PivotFields("Interval");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                pvtField.Position = 1;
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            if (MachineCount > 1)
            {
                pvtField = pvtTable.PivotFields("MachineName");
                {
                    pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                    pvtField.Position = (++position);
                    pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
                }
            }

            pvtField = pvtTable.PivotFields("CategoryName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = (++position);
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }

            pvtField = pvtTable.PivotFields("CounterName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = (++position);
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }

            if (InstanceCount > 1)
            {
                pvtField = pvtTable.PivotFields("InstanceName");
                {
                    pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                    pvtField.Position = (++position);
                    pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
                }
            }
            if (TestCount > 1)
            {
                pvtField = pvtTable.PivotFields("LoadTestRunId");
                {
                    pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                    pvtField.Position = (++position);
                    pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
                }

            }

            pvtTable.AddDataField(pvtTable.PivotFields("ComputedValue"), "Average of ComputedValue", Excel.XlConsolidationFunction.xlAverage);
            pvtTable.ColumnGrand = false;
            pvtTable.RowGrand = false;
            return pvtTable;
        }

        private void CreateExcelChart(List<int> TestNumber, string Category, string Counter, string ChartSheetName, dynamic pvtTable)
        {
            Globals.ThisAddIn.Application.ActiveSheet.Shapes.AddChart().Select();
            Globals.ThisAddIn.Application.ActiveChart.SetSourceData(Source: pvtTable.DataBodyRange);
            Globals.ThisAddIn.Application.ActiveChart.ChartType = Excel.XlChartType.xlLine;
            Globals.ThisAddIn.Application.ActiveChart.Location(Where: Excel.XlChartLocation.xlLocationAsNewSheet);
            Globals.ThisAddIn.Application.ActiveChart.Name = ChartSheetName.Length > 30 ? ChartSheetName.Remove(30) : ChartSheetName;
            App.ActiveChart.ApplyLayout(3);
            App.ActiveChart.ChartTitle.Text = string.Format("{0}", ChartSheetName);
            if (TestNumber.Count > 1)
            {
                int seriesCount = App.ActiveChart.SeriesCollection().Count;
                if (seriesCount < 50)
                {

                    Dictionary<int, Excel.XlRgbColor> lineColors = new Dictionary<int, Excel.XlRgbColor>();
                    for (int i = 0; i < TestNumber.Count; i++)
                    {
                        Excel.XlRgbColor color = Excel.XlRgbColor.rgbBlack;
                        switch (i)
                        {
                            case 0:
                                color = Excel.XlRgbColor.rgbBlack;
                                break;
                            case 1:
                                color = Excel.XlRgbColor.rgbRed;
                                break;
                            case 2:
                                color = Excel.XlRgbColor.rgbBlue;
                                break;
                            case 3:
                                color = Excel.XlRgbColor.rgbGreen;
                                break;
                            case 4:
                                color = Excel.XlRgbColor.rgbOrange;
                                break;
                            default:
                                break;
                        }
                        lineColors.Add(TestNumber[i], color);
                    }
                    for (int i = 1; i <= seriesCount; i++)
                    {
                        var item = App.ActiveChart.SeriesCollection(i);
                        string[] splitString = App.ActiveChart.SeriesCollection(i).Name.Split('-');
                        int testNumber = int.Parse(splitString.Last().Trim());
                        item.Format.Line.Visible = true;
                        item.Format.Line.ForeColor.RGB = lineColors[testNumber];
                        item.Format.Line.Transparency = 0;

                    }
                }
            }

        }

        #endregion

        #region ITemplateBase Members

        void ws_FollowHyperlink(Excel.Hyperlink Target)
        {
            try
            {
                Excel.Chart chart = App.Charts[Target.SubAddress];
                if (chart.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                {
                    chart.Select();
                }
            }
            catch (Exception)
            {
                // Small hack to navigate to a chart instead of a worksheet
                Excel.Worksheet worksheet = App.Worksheets[Target.SubAddress];
                if (worksheet.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                {
                    worksheet.Select();
                }
            }

        }

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
                if (string.IsNullOrEmpty(App.Cells[i,1].Value))
                {
                    rowNumber = i;
                    break;
                }
            }

            Excel.Worksheet ws = App.ActiveSheet;
            ws.FollowHyperlink += new Excel.DocEvents_FollowHyperlinkEventHandler(ws_FollowHyperlink);
            App.ActiveSheet.Select();
            
            foreach (var rept in reportList)
            {
                var cell = App.Cells[rowNumber, 1];
                var report = rept as DAO.LoadTestReports;
                var counterList = new Dictionary<int, counter>();

                string ChartClean = report.ReportName.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":", "");

                string rawSheetName = String.Format("rawPvt{0}", ChartClean);
                string PivotTableName = String.Format("Pivot Table {0}", ChartClean);
                string PvtSheetName = String.Format("{0} Pivot", ChartClean);
                string ChartSheetName = String.Format("{0} Chart", ChartClean);


                string rawSheetNameShort = rawSheetName.Length > 30 ? rawSheetName.Remove(30) : rawSheetName;
                string PvtSheetNameshort = PvtSheetName.Length > 30 ? PvtSheetName.Remove(30) : PvtSheetName;
                string ChartSheetNameshort = ChartSheetName.Length > 30 ? ChartSheetName.Remove(30) : ChartSheetName;

                if (report.ReportType == "PivotTableAndCharts")
                {

                    try
                    {
                        var chart = App.Charts[ChartSheetName];
                        App.ActiveSheet.HyperLinks.Add(Anchor: cell,
                Address: "",
                SubAddress: string.Format("{0}", chart.Name),
                TextToDisplay: ChartSheetName);
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

        #endregion
    }
}
