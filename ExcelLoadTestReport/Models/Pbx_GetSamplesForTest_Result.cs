//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelLoadTestReport.Models
{
    using System;
    
    public partial class Pbx_GetSamplesForTest_Result
    {
        public int LoadTestRunId { get; set; }
        public string MachineName { get; set; }
        public string CategoryName { get; set; }
        public string CounterName { get; set; }
        public string InstanceName { get; set; }
        public Nullable<System.DateTime> Interval { get; set; }
        public int CounterType { get; set; }
        public Nullable<float> ComputedValue { get; set; }
        public byte ThresholdRuleResult { get; set; }
    }
}
