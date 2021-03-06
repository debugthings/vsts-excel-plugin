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
    using System.Collections.Generic;
    
    public partial class LoadTestMessage
    {
        public int LoadTestRunId { get; set; }
        public int AgentId { get; set; }
        public int MessageId { get; set; }
        public byte MessageType { get; set; }
        public string MessageText { get; set; }
        public string SubType { get; set; }
        public string StackTrace { get; set; }
        public System.DateTime MessageTimeStamp { get; set; }
        public Nullable<int> TestCaseId { get; set; }
        public Nullable<int> RequestId { get; set; }
        public Nullable<int> TestLogId { get; set; }
    
        public virtual LoadTestRun LoadTestRun { get; set; }
    }
}
