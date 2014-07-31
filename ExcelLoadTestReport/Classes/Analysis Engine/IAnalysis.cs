using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelLoadTestReport.Classes.AnalysisEngine
{
    interface IAnalysis
    {
        void Process();

        string Name { get; set; }
        string Description { get; set; }
    }

    interface IAnalysisReport
    {
        public string Outcome { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
    }
}
