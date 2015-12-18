using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace ExcelLoadTestReport.DAO
{

    public partial class SelectedLoadTests
    {
        public SelectedLoadTests() { }

        public int LoadTestRunId { get; set; }
        public bool Selected { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Duration { get; set; }
        public string LoadTestName { get; set; }
        public string RunBy { get; set; }
        public Single Size { get; set; }
    }

    public class LTCompare : IComparer<SelectedLoadTests>
    {

        public string SortProperty { get; internal set; }
        public SortOrder SortingProperty { get; set; }
        public LTCompare() {}
        public LTCompare(string PropertyName, SortOrder Sorting = SortOrder.Ascending) { 
            SortProperty = PropertyName;
            SortingProperty = Sorting;
        }

        #region IComparer<SelectedLoadTests> Members

        public int Compare(SelectedLoadTests x, SelectedLoadTests y)
        {
            SelectedLoadTests left = x;
            SelectedLoadTests right = y;

            if (SortingProperty == SortOrder.Descending)
            {
                left = y;
                right = x;
            }

            switch (SortProperty.ToLower())
            {
                case "starttime":
                    if (left.StartTime == null && right.StartTime != null)
                    {
                        return -1;
                    }
                    if (left.StartTime != null && right.StartTime == null)
                    {
                        return 1;
                    }
                    if (left.StartTime == null && right.StartTime == null)
                    {
                        return left.LoadTestRunId.CompareTo(right.LoadTestRunId);
                    }
                    return DateTime.Compare((DateTime)left.StartTime, (DateTime)right.StartTime);
                case "endtime":
                    if (left.EndTime == null && right.EndTime != null)
                    {
                        return -1;
                    }
                    if (left.EndTime != null && right.EndTime == null)
                    {
                        return 1;
                    }
                    if (left.EndTime == null && right.EndTime == null)
                    {
                        return DateTime.Compare((DateTime)left.StartTime, (DateTime)right.StartTime);
                    }
                    return DateTime.Compare((DateTime)left.EndTime, (DateTime)right.EndTime);
                case "duration":
                    return left.Duration.CompareTo(right.Duration);
                case "loadtestrunid":
                    return left.LoadTestRunId.CompareTo(right.LoadTestRunId);
                case "loadtestname":
                    return left.LoadTestName.CompareTo(right.LoadTestName);
                case "size":
                    return left.Size.CompareTo(right.Size);
                case "runby":
                    return left.RunBy.CompareTo(right.RunBy);
                default:
                    return 0;
            }
        }

        #endregion
    }

    public class LoadTestReports
    {
        
        public string ReportName { get; set; }
        public string ReportType { get; set; }
        public bool CreateChart { get; set; }
        public bool GenerateRawDataSheets { get; set; }
        public List<Counters> Counters { get; set; }
    }

    public class Counters
    {
        [DisplayName("Category")]
        public string CounterCategory { get; set; }
        [DisplayName("Counter")]
        public string CounterName { get; set; }
        [DisplayName("Instance")]
        public string CounterInstance { get; set; }
        [DisplayName("Filter Out Rig?")]
        public bool FilterOutLoadTestRig { get; set; }
        public override string ToString()
        {
            string formated = string.Empty;
            if (!string.IsNullOrEmpty(CounterCategory))
            {
                formated += "{0}";
            }
            if (!string.IsNullOrEmpty(CounterName))
            {
                formated += " - {1}";
            }
            if (!string.IsNullOrEmpty(CounterInstance))
            {
                formated += " - {2}";
            }
            return string.Format(formated, CounterCategory, CounterName, CounterInstance);
        }
    }

    
}
