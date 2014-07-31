using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelLoadTestReport.PageTemplates
{
    interface ITemplateBase 
    {
        /// <summary>
        /// Set the title of the report page to be generated.
        /// </summary>
        string PageTitle { get; set; }
        /// <summary>
        /// Set the description or abstract of the page to be generated.
        /// </summary>
        /// <remarks>It's probably best to describe what we're looking at on the page. A simple remark about what is in the graphs should do, unless there is something special about the data we're looking at.</remarks>
        string PageDescription { get; set; }
        /// <summary>
        /// Fill this page template with a data set that contains the performance counters for the data.
        /// </summary>
        /// <param name="DataSet"></param>
        /// <returns></returns>
        bool Fill(int TestNumber, string Category, string Counter, bool CreateChart = true);

    }
}
