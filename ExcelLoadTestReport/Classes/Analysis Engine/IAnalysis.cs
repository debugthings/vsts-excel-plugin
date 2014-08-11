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
        string Outcome { get; set; }
        string ReportName { get; set; }
        string ReportDescription { get; set; }
    }
}
