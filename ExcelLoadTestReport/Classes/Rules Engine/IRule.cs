using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelLoadTestReport.Classes.RulesEngine
{
    interface IRule
    {
        void Process();
        string Name { get; set; }
        string Description { get; set; }
    }
}
