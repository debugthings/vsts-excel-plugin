using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelLoadTestReport;

namespace ExcelLoadTestReport.RibbonCommands
{
    class DebugCommands
    {
        Excel.Application App = Globals.ThisAddIn.Application;

        public void AddSheet()
        {
            App.ActiveWorkbook.Sheets.Add(After: App.ActiveWorkbook.Sheets[App.ActiveWorkbook.Sheets.Count]);
            App.ActiveSheet.Name = "NewSheet";
        }


        public void HideSheet()
        {
            App.Sheets["NewSheet"].Select();
            App.ActiveWindow.SelectedSheets.Visible = false;
        }

        public void AddData()
        {
            App.ActiveSheet.Range["A1"] = "Test";
            App.ActiveSheet.Range["A2"] = "Test";
        }

        public void CreatePivotChart(string Range = "", string Sheetname = "", string PivotTableName = "")
        {
            App.ActiveWorkbook.Sheets.Add(After: App.ActiveWorkbook.Sheets[App.ActiveWorkbook.Sheets.Count]);
            App.ActiveSheet.Name = "NewPivot";
            var pvtCache = App.ActiveWorkbook.PivotCaches().Create(
            SourceType: Excel.XlPivotTableSourceType.xlDatabase,
            SourceData: "NewSheet!A1:A2",
            Version: Excel.XlPivotTableVersionList.xlPivotTableVersion14).CreatePivotTable(
            TableDestination: "NewPivot!R3C1",
            TableName: "NewPivotTable",
            DefaultVersion: Excel.XlPivotTableVersionList.xlPivotTableVersion14);
            App.Sheets["NewPivot"].Select();
        }
    }
}