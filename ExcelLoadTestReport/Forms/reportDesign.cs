using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelLoadTestReport.Forms
{
    public partial class reportDesign : UserControl
    {
        private string _connString = string.Empty;
        public reportDesign()
        {
            InitializeComponent();
        }


        BindingSource bindSource = new BindingSource();
        BindingSource _counters = new BindingSource();

        public List<DAO.LoadTestReports> Reports { get; set; }

        public List<int> LoadTestRuns { get; set; }

        public List<TreeNode> ChangedNodes { get; set; }

        public void BindReports(string ConnectionString)
        {
            if (Reports == null)
            {
                throw new Exception("Reports property is not set.");
            }

            if (LoadTestRuns == null)
            {
                throw new Exception("LoadTestRuns property is not set.");
            }

            bindingNavigator1.BindingSource = bindSource;
            bindSource.DataSource = Reports;
            bindSource.CurrentChanged += new EventHandler(bindSource_CurrentChanged);
            bindSource.AddingNew += new AddingNewEventHandler(bindSource_AddingNew);
            foreach (var item in Reports)
            {
                if (!reportType.Items.Contains(item.ReportType))
                    reportType.Items.Add(item.ReportType);
            }

            if (!availableCounters.Nodes.ContainsKey("Counters"))
            {
                availableCounters.Nodes.Add("Counters", "Counters");
                using (var ltCounterContext = new Models.LoadTest2010Entities(ConnectionString))
                {
                    var counterNames = from ltCounterInstance in ltCounterContext.LoadTestPerformanceCounterInstances
                                       join ltCounter in ltCounterContext.LoadTestPerformanceCounters
                                       on new { ltCounterInstance.CounterId, ltCounterInstance.LoadTestRunId } equals new { ltCounter.CounterId, ltCounter.LoadTestRunId }
                                       join ltCounterCat in ltCounterContext.LoadTestPerformanceCounterCategories
                                       on new { ltCounter.CounterCategoryId, ltCounter.LoadTestRunId } equals new { ltCounterCat.CounterCategoryId, ltCounterCat.LoadTestRunId }
                                       where LoadTestRuns.Contains(ltCounterInstance.LoadTestRunId)
                                       select new
                                       {
                                           CounterCategory = ltCounterCat.CategoryName,
                                           Counter = ltCounter.CounterName,
                                           Instance = ltCounterInstance.InstanceName
                                       };
                    foreach (var item in counterNames)
                    {
                        if (!availableCounters.Nodes["Counters"].Nodes.ContainsKey(item.CounterCategory))
                        {
                            availableCounters.Nodes["Counters"].Nodes.Add(item.CounterCategory, item.CounterCategory);
                        }
                        if (!availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes.ContainsKey(item.Counter))
                        {
                            availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes.Add(item.Counter, item.Counter);
                        }
                        if (!availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes[item.Counter].Nodes.ContainsKey(item.Instance) && item.Instance != "systemdiagnosticsperfcounterlibsingleinstance")
                        {
                            availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes[item.Counter].Nodes.Add(item.Instance, item.Instance);
                        }
                    }

                }
            }
            ChangedNodes = new List<TreeNode>();
        }

        void bindSource_AddingNew(object sender, AddingNewEventArgs e)
        {

            var source = sender as BindingSource;
            var rpt = new DAO.LoadTestReports();
            rpt.ReportName = "New Report";
            rpt.Counters = new List<DAO.Counters>();
            e.NewObject = rpt;
        }

        void bindSource_CurrentChanged(object sender, EventArgs e)
        {
            availableCounters.Nodes["Counters"].Collapse(false);
            recursiveChangeColor(availableCounters.Nodes);

            var source = sender as BindingSource;
            var report = source.Current as DAO.LoadTestReports;


            _counters.DataSource = report.Counters;
            reportCounters.DataSource = _counters;

            reportName.Text = !string.IsNullOrEmpty(report.ReportName) ? report.ReportName : string.Empty;
            reportType.SelectedIndex = !string.IsNullOrEmpty(report.ReportType) ? reportType.Items.IndexOf(report.ReportType) : 0;
            chkCharts.Checked = report.CreateChart;
            generateRaw.Checked = report.GenerateRawDataSheets;
            if (report.Counters != null)
            {
                foreach (var item in report.Counters)
                {
                    var count = item as DAO.Counters;
                    if (count.CounterInstance != null)
                    {
                        if (availableCounters.Nodes["Counters"].Nodes.ContainsKey(count.CounterCategory))
                        {
                            if (availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes.ContainsKey(count.CounterName))
                            {
                                if (availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].Nodes.ContainsKey(count.CounterInstance))
                                {
                                    availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].Nodes[count.CounterInstance].ForeColor = Color.LightGray;
                                    availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].Nodes[count.CounterInstance].Tag = "default";
                                    if (!availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].IsExpanded)
                                        availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].Expand();
                                    break;
                                }
                                availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].ForeColor = Color.LightGray;
                                availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Nodes[count.CounterName].Tag = "default";
                                if (!availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].IsExpanded)
                                    availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Expand();
                                break;
                            }
                            availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].ForeColor = Color.LightGray;
                            availableCounters.Nodes["Counters"].Nodes[count.CounterCategory].Tag = "default";
                            if (!availableCounters.Nodes["Counters"].IsExpanded)
                                availableCounters.Nodes["Counters"].Expand();
                            break;
                        }
                    }
                }
            }
            availableCounters.Nodes["Counters"].Expand();
        }

        private void recursiveChangeColor(TreeNodeCollection nodes)
        {
            foreach (TreeNode item in nodes)
            {
                item.ForeColor = Color.Black;
                if (item.Nodes != null)
                {
                    recursiveChangeColor(item.Nodes);
                }
            }
        }

        private void reportName_TextChanged(object sender, EventArgs e)
        {
            var report = bindSource.Current as DAO.LoadTestReports;
            report.ReportName = reportName.Text;
        }

        private void reportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var report = bindSource.Current as DAO.LoadTestReports;
            if (!string.IsNullOrEmpty(reportType.SelectedItem.ToString()))
            {
                report.ReportType = reportType.SelectedItem.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCounterToLst();
        }

        private void AddCounterToLst()
        {
            var node = availableCounters.SelectedNode;
            var cntr = new DAO.Counters();
            switch (node.Level)
            {
                case 1:
                    cntr.CounterCategory = node.Text;
                    break;
                case 2:
                    cntr.CounterName = node.Text;
                    cntr.CounterCategory = node.Parent.Text;
                    break;
                case 3:
                    cntr.CounterInstance = node.Text;
                    cntr.CounterName = node.Parent.Text;
                    cntr.CounterCategory = node.Parent.Parent.Text;
                    break;
                default:
                    break;
            }
            _counters.Add(cntr);
            node.ForeColor = Color.LightGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveCounterFromList();
        }

        private void reportCounters_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            foreach (DataGridViewColumn item in dataGrid.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void availableCounters_DoubleClick(object sender, EventArgs e)
        {
            AddCounterToLst();
        }

        private void RemoveCounterFromList()
        {
            var item = reportCounters.CurrentRow.DataBoundItem as DAO.Counters;
            _counters.Remove(item);
            if (!string.IsNullOrEmpty(item.CounterInstance))
            {
                availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes[item.CounterName].Nodes[item.CounterInstance].ForeColor = Color.Black;
                return;
            }
            if (!string.IsNullOrEmpty(item.CounterName))
            {
                availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].Nodes[item.CounterName].ForeColor = Color.Black;
                return;
            }
            if (!string.IsNullOrEmpty(item.CounterCategory))
            {
                availableCounters.Nodes["Counters"].Nodes[item.CounterCategory].ForeColor = Color.Black;
                return;
            }
        }

        private void generateRaw_CheckedChanged(object sender, EventArgs e)
        {
            var source = bindingNavigator1.BindingSource;
            var report = source.Current as DAO.LoadTestReports;
            report.GenerateRawDataSheets = generateRaw.Checked;
        }

        private void chkCharts_CheckedChanged(object sender, EventArgs e)
        {
            var source = bindingNavigator1.BindingSource;
            var report = source.Current as DAO.LoadTestReports;
            report.CreateChart = chkCharts.Checked;
        }
    }
}
