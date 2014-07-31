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
    class TableOfContents
    {
        #region ITemplateBase Members

        Excel.Application App = Globals.ThisAddIn.Application;


        public delegate void Fill(List<int> TestNumber, List<DAO.LoadTestReports> reportList);

        public Fill FillFromExternal { get; set; }

        public bool FillInternal(List<int> TestNumber, List<DAO.LoadTestReports> reportList)
        {
            return false;
        }

        #endregion
    }
}
