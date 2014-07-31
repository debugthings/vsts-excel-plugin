using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelLoadTestReport;
using System.Security;
using System.Security.Principal;

namespace ExcelLoadTestReport.RibbonCommands
{
    class RibbonCommands
    {
        static Excel.Application App = Globals.ThisAddIn.Application;

        public static void ConditionalFormatting(int Min, int Max)
        {
            App.Selection.FormatConditions.AddColorScale(3);
            App.Selection.FormatConditions(App.Selection.FormatConditions.Count).SetFirstPriority();
            App.Selection.FormatConditions[1].ColorScaleCriteria[1].Type = Excel.XlConditionValueTypes.xlConditionValueNumber;
            App.Selection.FormatConditions[1].ColorScaleCriteria[1].Value = 0.5;
            App.Selection.FormatConditions[1].ColorScaleCriteria[1].FormatColor.Color = 8109667;
            App.Selection.FormatConditions[1].ColorScaleCriteria[1].FormatColor.TintAndShade = 0;

            App.Selection.FormatConditions[1].ColorScaleCriteria[2].Type = Excel.XlConditionValueTypes.xlConditionValueNumber;
            App.Selection.FormatConditions[1].ColorScaleCriteria[2].Value = Min;
            App.Selection.FormatConditions[1].ColorScaleCriteria[2].FormatColor.Color = 8711167;
            App.Selection.FormatConditions[1].ColorScaleCriteria[2].FormatColor.TintAndShade = 0;

            App.Selection.FormatConditions[1].ColorScaleCriteria[3].Type = Excel.XlConditionValueTypes.xlConditionValueNumber;
            App.Selection.FormatConditions[1].ColorScaleCriteria[3].Value = Max;
            App.Selection.FormatConditions[1].ColorScaleCriteria[3].FormatColor.Color = 7039480;
            App.Selection.FormatConditions[1].ColorScaleCriteria[3].FormatColor.TintAndShade = 0;

        }

        public static void ConditionalFormattingMultiple(Single percentage)
        {
            Excel.Range rng = App.Selection;

            foreach (Excel.CustomProperty property in App.ActiveSheet.CustomProperties)
            {
                if (property.Name.Equals("PublixLTTestCount", StringComparison.CurrentCultureIgnoreCase))
                {
                    int testCount = int.Parse(property.Value);
                    if (rng.Columns.Count % testCount == 0)
                    {
                        int startRow = rng.Row;
                        int startColumn = rng.Column;
                        for (int i = 0; i < rng.Rows.Count; i++)
                        {
                            for (int j = 0; j < rng.Columns.Count; j+=testCount)
                            {
                                App.ActiveSheet.Range[App.ActiveSheet.Cells[startRow + i, startColumn + j],
                                    App.ActiveSheet.Cells[startRow + i, (startColumn + j) + (testCount - 1)]].Select();
                                string addressFirstCol = App.ActiveSheet.Range[App.ActiveSheet.Cells[startRow + i, startColumn + j],
                                    App.ActiveSheet.Cells[startRow + i, startColumn + j]].Address;
                                Excel.Range itemToFormat = App.Selection;
                                var something = itemToFormat.FormatConditions.AddIconSetCondition();
                                Excel.IconSetCondition frmtCond = itemToFormat.FormatConditions[itemToFormat.FormatConditions.Count];
                                itemToFormat.FormatConditions[itemToFormat.FormatConditions.Count].SetFirstPriority();
                                frmtCond.ReverseOrder = false;
                                frmtCond.ShowIconOnly = false;
                                frmtCond.IconSet = Excel.XlIconSet.xl3TrafficLights1;

                                frmtCond.IconCriteria[1].Icon = Excel.XlIcon.xlIconGreenUpArrow;

                                frmtCond.IconCriteria[2].Icon = Excel.XlIcon.xlIconNoCellIcon;
                                frmtCond.IconCriteria[2].Type = Excel.XlConditionValueTypes.xlConditionValueFormula;
                                frmtCond.IconCriteria[2].Operator = 7;
                                frmtCond.IconCriteria[2].Value = string.Format("={0}*0.9", addressFirstCol);


                                frmtCond.IconCriteria[3].Icon = Excel.XlIcon.xlIconRedDownArrow;
                                frmtCond.IconCriteria[3].Type = Excel.XlConditionValueTypes.xlConditionValueFormula;
                                frmtCond.IconCriteria[3].Operator = 7;
                                frmtCond.IconCriteria[3].Value = string.Format("={0}*1.10", addressFirstCol);

                            }
                        }
                    }
                }
            }
        }

        public static List<DAO.SelectedLoadTests> GetMyLoadTests(bool FilterByMe = true)
        {
            var _user = WindowsIdentity.GetCurrent();
            using (var ltDbContext = new Models.LoadTest2010Entities())
            {
                var selectedTest = (from ltN in ltDbContext.LoadTestRuns
                                    select new DAO.SelectedLoadTests
                                    {
                                        Duration = ltN.RunDuration,
                                        EndTime = ltN.EndTime,
                                        LoadTestName = ltN.LoadTestName,
                                        LoadTestRunId = ltN.LoadTestRunId,
                                        RunBy = ltN.Comment,
                                        Selected = false,
                                        StartTime = ltN.StartTime,
                                    }).ToList();
                var myTests = (from myT in selectedTest
                               where myT.RunBy.StartsWith(string.Format("[{0}]", _user.Name), StringComparison.CurrentCultureIgnoreCase)
                               select myT).ToList();

                return myTests;
            }
        }

        public static List<DAO.SelectedLoadTests> GetLargeLoadTests(bool FilterByMe)
        {
            var _user = WindowsIdentity.GetCurrent();
            using (var ltDbContext = new Models.LoadTest2010Entities())
            {
                ltDbContext.CommandTimeout = 1200;
                var selectedTest = (from ltN in ltDbContext.GetLargeLoadTests()
                                    select new DAO.SelectedLoadTests
                                    {
                                        Duration = (int)ltN.Duration,
                                        EndTime = ltN.EndTime,
                                        LoadTestName = ltN.LoadTestName,
                                        LoadTestRunId = (int)ltN.LoadTestRunId,
                                        RunBy = ltN.Comment,
                                        Selected = false,
                                        StartTime = ltN.StartTime,
                                        Size = (int)ltN.DBSizeInKB
                                    }).ToList();

                return selectedTest;
            }
        }

        public static List<DAO.SelectedLoadTests> GetHighSampleCountLoadTests(bool FilterByMe)
        {
            var _user = WindowsIdentity.GetCurrent();
            using (var ltDbContext = new Models.LoadTest2010Entities())
            {
                ltDbContext.CommandTimeout = 1200;
                var selectedTest = (from ltN in ltDbContext.GetLargeCounterSampleLoadTests()
                                    select new DAO.SelectedLoadTests
                                    {
                                        Duration = (int)ltN.TestDuration,
                                        EndTime = ltN.TestEnd,
                                        LoadTestName = ltN.LoadTestName,
                                        LoadTestRunId = (int)ltN.LoadTestRunID,
                                        RunBy = ltN.Comment,
                                        Selected = false,
                                        StartTime = ltN.TestStart,
                                        Size = (long)ltN.CountOfSampleRecords
                                    }).ToList();

                return selectedTest;
            }
        }

        public static List<DAO.SelectedLoadTests> GetSmallDurationLoadTests(bool FilterByMe)
        {
            var _user = WindowsIdentity.GetCurrent();
            using (var ltDbContext = new Models.LoadTest2010Entities())
            {
                var selectedTest = (from ltN in ltDbContext.LoadTestRuns
                                    where ltN.RunDuration < (15 * 60)
                                    select new DAO.SelectedLoadTests
                                    {
                                        Duration = ltN.RunDuration,
                                        EndTime = ltN.EndTime,
                                        LoadTestName = ltN.LoadTestName,
                                        LoadTestRunId = ltN.LoadTestRunId,
                                        RunBy = ltN.Comment,
                                        Selected = false,
                                        StartTime = ltN.StartTime,
                                        Size = ltN.RunDuration
                                    }).ToList();
                return selectedTest;
            }
        }

        public static List<DAO.SelectedLoadTests> GetAllLoadTests(bool FilterByMe)
        {
            var _user = WindowsIdentity.GetCurrent();
            using (var ltDbContext = new Models.LoadTest2010Entities())
            {
                var selectedTest = (from ltN in ltDbContext.LoadTestRuns
                                    select new DAO.SelectedLoadTests
                                    {
                                        Duration = ltN.RunDuration,
                                        EndTime = ltN.EndTime,
                                        LoadTestName = ltN.LoadTestName,
                                        LoadTestRunId = ltN.LoadTestRunId,
                                        RunBy = ltN.Comment,
                                        Selected = false,
                                        StartTime = ltN.StartTime,
                                    }).ToList();
                var myTests = (from myT in selectedTest
                               where myT.RunBy.StartsWith(string.Format("[{0}]", _user.Name), StringComparison.CurrentCultureIgnoreCase)
                               select myT).ToList();
                return selectedTest;
            }
        }

        public static void ToggleVisibility(bool hide, string sheettype)
        {
            foreach (var worksheetTest in App.Sheets)
            {
                if (worksheetTest is Excel.Worksheet)
                {
                    var worksheet = worksheetTest as Excel.Worksheet;
                    foreach (Excel.CustomProperty property in worksheet.CustomProperties)
                    {
                        if (property.Name.Equals("PublixLTSheetType", StringComparison.CurrentCultureIgnoreCase) && property.Value.Equals(sheettype, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (hide)
                            {
                                worksheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
                            }
                            else
                            {
                                worksheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                            }

                        }
                    }
                }
            }

            if (sheettype.Equals("chart", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (Excel.Chart chart in App.Charts)
                {
                    if (hide)
                    {
                        chart.Visible = Excel.XlSheetVisibility.xlSheetHidden;
                    }
                    else
                    {
                        chart.Visible = Excel.XlSheetVisibility.xlSheetVisible;
                    }
                }
            }

        }

        public static void HideSheet()
        {
            App.Sheets["NewSheet"].Select();
            App.ActiveWindow.SelectedSheets.Visible = false;
        }

        public static void AddData()
        {
            App.ActiveSheet.Range["A1"] = "Test";
            App.ActiveSheet.Range["A2"] = "Test";
        }

        public static void CreatePivotChart(string Range = "", string Sheetname = "", string PivotTableName = "")
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

        public static void CorrectColors()
        {

            int seriesCount = App.ActiveChart.SeriesCollection().Count;
            List<int> _testList = new List<int>();
            for (int i = 1; i <= seriesCount; i++)
            {
                string[] splitString = App.ActiveChart.SeriesCollection(i).Name.Split('-');
                int testNumber = 0;
                if (!int.TryParse(splitString.Last().Trim(), out testNumber))
                {
                    return;
                }
                if (!_testList.Contains(testNumber))
                {
                    _testList.Add(testNumber);
                }
            }
            _testList.OrderBy(x => x);
            Dictionary<int, Excel.XlRgbColor> lineColors = new Dictionary<int, Excel.XlRgbColor>();
            for (int i = 0; i < _testList.Count; i++)
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
                lineColors.Add(_testList[i], color);
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

        public static void ClearMarkers()
        {

            int seriesCount = App.ActiveChart.SeriesCollection().Count;
            for (int i = 1; i <= seriesCount; i++)
            {
                var item = App.ActiveChart.SeriesCollection(i);
                item.MarkerStyle = Excel.XlMarkerStyle.xlMarkerStyleNone;
            }
        }

        public static void ThinLines()
        {

            int seriesCount = App.ActiveChart.SeriesCollection().Count;
            for (int i = 1; i <= seriesCount; i++)
            {
                var item = App.ActiveChart.SeriesCollection(i);
                item.Format.Line.Weight = 1.5;
            }
        }

        public static void DeleteTestsListedAsTransactions()
        {
            var r = App.Selection.Rows;

            var firstPart = new List<string>();
            var secondPart = new Dictionary<int, string>();
            foreach (var item in r)
            {
                var split = item.Columns[1].Value.Split('.');
                if (split.Length > 0)
                {
                    if (split[0] != null)
                    {
                        firstPart.Add(split[0].Trim());
                    }
                }
                if (split.Length > 1)
                {
                    if (split[1] != null)
                    {
                        secondPart.Add(item.Row, split[1].Trim());
                    }
                }
            }

            int rowChange = 0;
            foreach (var item in secondPart)
            {
                if (firstPart.Contains(item.Value))
                {
                    Excel.Range r3 = App.Rows[item.Key - rowChange];
                    r3.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                    rowChange++;
                }
            }

        }
    }
}