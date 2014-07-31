using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace ExcelLoadTestReport.PageTemplates
{
    class PivotTableAndChartTemplate : ITemplateBase
    {
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
        public bool Fill(int TestNumber, string Category, string Counter, bool CreateChart = true)
        {
            CreatePivotTable(TestNumber, Category, Counter, CreateChart);
            return true;
        }

        public PivotTableAndChartTemplate() { }


        private void CreatePivotTable(int TestNumber, string Category, string Counter, bool CreateChart = true)
        {

            string CounterClean = Counter.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":","");
            string CategoryClean = Category.Replace("\\", "").Replace("/", "").Replace("[", "").Replace("]", "").Replace("?", "").Replace("*", "").Replace(":", "");

            string PivotTableName = String.Format("Pivot{0}-{1}", CategoryClean, CounterClean);
            Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Add(After: Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count]);
            var pvtCache = Globals.ThisAddIn.Application.ActiveWorkbook.PivotCaches().Create(SourceType: Excel.XlPivotTableSourceType.xlExternal);
            pvtCache.Connection = new string[] { "OLEDB;Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=LoadTest2010;Data Source=TPHRNA01;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=JAMESLDAVIS01;Use Encryption for Data=False;Tag with column collation when possible=False" };
            pvtCache.CommandType = Excel.XlCmdType.xlCmdSql;
            pvtCache.CommandText = new string[] { String.Format("[dbo].[Prc_GetSamplesForTest] {0}, N'{1}', {2}", TestNumber, Category, !string.IsNullOrEmpty(Counter) ? String.Format("N'{0}'",Counter) : "NULL") };
            pvtCache.MaintainConnection = true;
            pvtCache.CreatePivotTable(TableDestination: Globals.ThisAddIn.Application.ActiveCell, TableName: PivotTableName, DefaultVersion: Excel.XlPivotTableVersionList.xlPivotTableVersion12);

            string PvtSheetName = String.Format("Pivot {0}-{1}", CategoryClean, CounterClean);
            string ChartSheetName = String.Format("Chart {0}-{1}", CategoryClean, CounterClean);

            Globals.ThisAddIn.Application.ActiveSheet.Name = PvtSheetName.Length > 30 ? PvtSheetName.Remove(30) : PvtSheetName;

            var pvtTable = Globals.ThisAddIn.Application.ActiveSheet.PivotTables(PivotTableName);

            var pvtField = pvtTable.PivotFields("Interval");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                pvtField.Position = 1;
                pvtField.NumberFormat = "hh:mm:ss";
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            pvtField = pvtTable.PivotFields("MachineName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = 1;
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            pvtField = pvtTable.PivotFields("CategoryName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = 2;
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            pvtField = pvtTable.PivotFields("CounterName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = 3;
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            pvtField = pvtTable.PivotFields("InstanceName");
            {
                pvtField.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
                pvtField.Position = 4;
                pvtField.Subtotals = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
            }
            pvtTable.AddDataField(pvtTable.PivotFields("ComputedValue"), "Average of ComputedValue", Excel.XlConsolidationFunction.xlAverage);
            pvtTable.ColumnGrand = false;
            pvtTable.RowGrand = false;

    //        ActiveSheet.PivotTables("PivotLoadTestRequest-RequestsSec").PivotFields( _
    //    "InstanceName").Subtotals = Array(False, False, False, False, False, False, False, _
    //    False, False, False, False, False)
    //With ActiveSheet.PivotTables("PivotLoadTestRequest-RequestsSec")
    //    .ColumnGrand = False
    //    .RowGrand = False
    //End With
    //Range("F2").Select
    //ActiveSheet.PivotTables("PivotLoadTestRequest-RequestsSec").PivotFields( _
    //    "MachineName").Subtotals = Array(False, False, False, False, False, False, False, _
    //    False, False, False, False, False)
    //Range("F3").Select
    //ActiveSheet.PivotTables("PivotLoadTestRequest-RequestsSec").PivotFields( _
    //    "CategoryName").Subtotals = Array(False, False, False, False, False, False, False, _
    //    False, False, False, False, False)
    //Range("F4").Select
    //ActiveSheet.PivotTables("PivotLoadTestRequest-RequestsSec").PivotFields( _
    //    "CounterName").Subtotals = Array(False, False, False, False, False, False, False, _
    //    False, False, False, False, False)
    //Range("F5").Select

            if (CreateChart)
            {
                Globals.ThisAddIn.Application.ActiveSheet.Shapes.AddChart().Select();
                Globals.ThisAddIn.Application.ActiveChart.SetSourceData(Source: pvtTable.DataBodyRange);
                Globals.ThisAddIn.Application.ActiveChart.ChartType = Excel.XlChartType.xlLine;
                Globals.ThisAddIn.Application.ActiveChart.Location(Where: Excel.XlChartLocation.xlLocationAsNewSheet);
                Globals.ThisAddIn.Application.ActiveChart.Name = ChartSheetName.Length > 30 ? ChartSheetName.Remove(30) : ChartSheetName;
            }

        }



        #endregion
    }
}
