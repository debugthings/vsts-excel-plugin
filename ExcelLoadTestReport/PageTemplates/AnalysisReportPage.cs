using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelLoadTestReport.PageTemplates
{
    class AnalysisReportPage : ITemplateBase
    {
        #region ITemplateBase Members

        public string PageTitle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PageDescription
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Fill(List<int> TestNumber, Dictionary<int, DAO.Counters> Counters, bool CreateChart = true, bool CreateRawSheets = true, string ChartName = "")
        {
            throw new NotImplementedException();
        }

        public void CreateTOC(List<int> TestNumber, List<DAO.LoadTestReports> reportList)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
