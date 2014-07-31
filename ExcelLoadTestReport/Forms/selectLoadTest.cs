using System;
using System.Collections.Generic;
using System.ComponentModel;
using SqlClient = System.Data.SqlClient;
using Sql = System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelLoadTestReport
{
    public partial class selectLoadTest : Form, IMessageFilter
    {
        Excel.Application App = Globals.ThisAddIn.Application;
        BindingSource _dataGridBs = new BindingSource();
        BindingSource _comboBs = new BindingSource();
        BindingSource _comboConnect = new BindingSource();
        List<int> SelectedTests = new List<int>();
        System.Collections.Hashtable _selectedHash = new System.Collections.Hashtable();
        BackgroundWorker _bgWorker = new BackgroundWorker();
        Windows.ModalWait _modWait = new Windows.ModalWait();
        string lastSortedColumn = string.Empty;
        SortOrder lastSortOrder = SortOrder.None;

        private string _connString = string.Empty;
        private string _prevSelectedName = string.Empty;
        private string _prevConnString = string.Empty;
        public selectLoadTest()
        {
            InitializeComponent();
        }

        #region IMessageFilter Members

        public int HandleInComingCall(uint dwCallType, IntPtr htaskCaller, uint dwTickCount, INTERFACEINFO[] lpInterfaceInfo)
        {
            return 1;
        }

        public int RetryRejectedCall(IntPtr htaskCallee, uint dwTickCount, uint dwRejectType)
        {
            int retVal = -1;
            Debug.WriteLine("RetryRejectedCall");
            if (MessageBox.Show("retry?", "Alert", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                retVal = 1;
            }
            return retVal;
        }

        public int MessagePending(IntPtr htaskCallee, uint dwTickCount, uint dwPendingType)
        {
            Debug.WriteLine("MessagePending");
            return 1;
        }


        [DllImport("ole32.dll")]
        static extern int CoRegisterMessageFilter(
            IMessageFilter lpMessageFilter,
            out IMessageFilter lplpMessageFilter);

        private IMessageFilter oldMessageFilter;
        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            if (this.wizardPages1.SelectedTab.Name.Equals("setReportInfo", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!chkOtherCounters.Checked)
                {
                    btnNext.Enabled = false;
                }
            }
            if (this.wizardPages1.SelectedTab.Text.Equals("selectLoadTest", StringComparison.CurrentCultureIgnoreCase))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!_selectedHash.ContainsKey(i) && !(dataGridView1[0, i].Value is System.DBNull))
                    {
                        _selectedHash.Add(i, dataGridView1[0, i].Value);
                    }
                }

            }
            if (this.wizardPages1.SelectedIndex < (this.wizardPages1.TabCount - 1))
            {
                this.wizardPages1.SelectedIndex++;
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.wizardPages1.SelectedIndex > 0)
            {
                this.wizardPages1.SelectedIndex--;
                btnNext.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOtherCounters_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = chkOtherCounters.Checked;
        }

        private void comboLoadTest_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                using (var ltDbContext = new Models.LoadTest2010Entities(_connString))
                {
                    var selectedTest = (from ltN in ltDbContext.LoadTestRuns
                                        where ltN.LoadTestName == (string)comboLoadTest.SelectedItem
                                        select new DAO.SelectedLoadTests
                                        {
                                            Duration = ltN.RunDuration,
                                            EndTime = ltN.EndTime,
                                            LoadTestName = ltN.LoadTestName,
                                            LoadTestRunId = ltN.LoadTestRunId,
                                            RunBy = ltN.Comment,
                                            Selected = false,
                                            StartTime = ltN.StartTime
                                        }).ToList();

                    _dataGridBs.DataSource = selectedTest;
                    dataGridView1.AutoResizeColumns();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void selectLT_Enter(object sender, EventArgs e)
        {
            var configSection = System.Configuration.ConfigurationManager.ConnectionStrings;
            var connNames = new List<string>();
            foreach (System.Configuration.ConnectionStringSettings item in configSection)
            {
                connNames.Add(item.Name);
            }
            if (_comboConnect.DataSource == null)
            {
                _comboConnect.DataSource = connNames;
            }

            _prevConnString = _connString;
            if (comboConnectionString.SelectedItem != null)
            {
                _connString = string.Format("name={0}", comboConnectionString.SelectedItem);
            }
            else
            {
                _connString = string.Format("name={0}", configSection[0].Name); ;
            }
            btnPrevious.Enabled = false;
            if (comboLoadTest.Items.Count == 0 | sender.GetType() == typeof(ComboBox))
            {
                try
                {
                    using (var ltDbContext = new Models.LoadTest2010Entities(_connString))
                    {
                        var loadTestNames = from ltN in ltDbContext.LoadTestRuns select ltN.LoadTestName;
                        _comboBs.DataSource = loadTestNames.Distinct().ToList();
                        comboLoadTest.SelectedIndex = 0;
                        comboLoadTest_SelectedIndexChanged(this, new EventArgs());
                    }
                    _prevSelectedName = comboConnectionString.SelectedItem.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("There was an error executing the command: {0}", ex.Message));
                    comboConnectionString.SelectedItem = _prevSelectedName;
                    _connString = _prevConnString;
                }
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("time", StringComparison.CurrentCultureIgnoreCase))
            {
                e.CellStyle.Format = "MM/dd/yyyy hh:mm t";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.ToLower().Contains("duration"))
            {
                e.Value = new TimeSpan(0, 0, int.Parse(e.Value.ToString())).ToString();
            }
            if (!dataGridView1.Columns[e.ColumnIndex].Name.Equals(" ", StringComparison.CurrentCultureIgnoreCase))
            {
                dataGridView1.Columns[e.ColumnIndex].ReadOnly = true;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals(" ", StringComparison.CurrentCultureIgnoreCase))
            {
                if (_selectedHash.ContainsKey(e.RowIndex) && (bool)_selectedHash[e.RowIndex] == true)
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value = true;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("LoadTestRunId", StringComparison.CurrentCultureIgnoreCase))
            {
                dataGridView1.Columns[e.ColumnIndex].Visible = false;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DAO.LTCompare cmp = null;
            if (lastSortedColumn == dataGridView1.Columns[e.ColumnIndex].DataPropertyName)
            {

                if (lastSortOrder == SortOrder.Descending | lastSortOrder == SortOrder.None)
                {
                    lastSortOrder = SortOrder.Ascending;
                    cmp = new DAO.LTCompare(dataGridView1.Columns[e.ColumnIndex].DataPropertyName, lastSortOrder);

                }
                else
                {
                    lastSortOrder = SortOrder.Descending;
                    cmp = new DAO.LTCompare(dataGridView1.Columns[e.ColumnIndex].DataPropertyName, lastSortOrder);
                }
            }
            else
            {
                cmp = new DAO.LTCompare(dataGridView1.Columns[e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
                lastSortOrder = SortOrder.Ascending;
            }
            lastSortedColumn = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            var dsource =
                new List<DAO.SelectedLoadTests>(((List<DAO.SelectedLoadTests>)_dataGridBs.DataSource));
            dsource.Sort(cmp);
            _dataGridBs.DataSource = dsource;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Display);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

            if (reportDesign1.Reports == null)
            {
                BuildReports();
            }

            // Get a list of the types of reports that can be used.
            var configSection = (ReportDefaults)System.Configuration.ConfigurationManager.GetSection("reportSection");
            var listOfReportTypes = new Dictionary<string, PageTemplates.ITemplateBase>();
            foreach (var rept in configSection.reportTypes)
            {
                var rType = rept as reportType;
                listOfReportTypes.Add(rType.reportTypeName, (PageTemplates.ITemplateBase)Activator.CreateInstance(rType.type, _connString));
            }

            if (reportDesign1.LoadTestRuns.Count == 0)
            {
                var result = MessageBox.Show("Please select at least one load test.", "Nothing Selected");
                return;
            }

            var control = _modWait.Controls.Find("label3", true)[0];
            var progBar = _modWait.Controls.Find("progressBar1", true)[0] as ProgressBar;
            progBar.Step = (int)(100 / reportDesign1.Reports.Count);
            _modWait.Show();

            foreach (var rept in reportDesign1.Reports)
            {
                var report = rept as DAO.LoadTestReports;
                var counterList = new Dictionary<int, DAO.Counters>();
                int counterNumber = 0;
                foreach (var item in report.Counters)
                {
                    var counter = item as DAO.Counters;
                    counterList.Add(counterNumber, counter);
                    counterNumber++;
                }
                progBar.PerformStep();
                control.Text = string.Format("Adding reports and charts for {0}", report.ReportName);
                var paramThreadStart = new System.Threading.ParameterizedThreadStart(o =>
                    {
                        CoRegisterMessageFilter(this, out oldMessageFilter);
                        PageTemplates.ITemplateBase chartExecution = listOfReportTypes[report.ReportType]; ;
                        try
                        {
                            chartExecution.Fill(reportDesign1.LoadTestRuns, counterList, report.CreateChart, report.GenerateRawDataSheets, report.ReportName);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message;
                        }
                    });
                System.Threading.Thread t = new System.Threading.Thread(paramThreadStart);
                t.SetApartmentState(System.Threading.ApartmentState.STA);
                t.Start();
                t.Join(TimeSpan.FromMinutes(10));
            }

            control.Text = string.Format("Adding table of contents");

            var toc = new PageTemplates.TableOfContents();

            foreach (var item in listOfReportTypes)
            {
                toc.FillFromExternal = new PageTemplates.TableOfContents.Fill(item.Value.CreateTOC);
                toc.FillFromExternal(reportDesign1.LoadTestRuns, reportDesign1.Reports);
            }
            _modWait.Close();
            this.Close();
        }

        private void setReports_Enter(object sender, EventArgs e)
        {
            btnFinish.Enabled = true;
            btnNext.Enabled = false;
        }

        private void selectLoadTest_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dataGridBs;
            comboLoadTest.DataSource = _comboBs;
            comboConnectionString.DataSource = _comboConnect;
            selectLT_Enter(this, new EventArgs());
        }

        private void renameTestRuns_Enter(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
        }

        void setCounters_Enter(object sender, EventArgs e)
        {
            BuildReports();
            reportDesign1.BindReports(_connString);
        }

        private void BuildReports()
        {
            // This method digs through the config file for default reports and adds them to a list
            // This list is then used to build the reports. This list can be edited in the application
            // using the report designer control.

            var configSection = (ReportDefaults)System.Configuration.ConfigurationManager.GetSection("reportSection");
            var listOfReportTypes = new Dictionary<string, PageTemplates.ITemplateBase>();
            var listOfreports = new List<DAO.LoadTestReports>();
            foreach (var rept in configSection.reports)
            {
                var report = rept as report;
                var reportDAO = new DAO.LoadTestReports();
                reportDAO.ReportName = report.ReportName;
                reportDAO.ReportType = report.reportTypeName;
                reportDAO.Counters = new List<DAO.Counters>();
                reportDAO.CreateChart = report.CreateChart;
                reportDAO.GenerateRawDataSheets = report.GenerateRawDataSheets;
                foreach (var item in report.Counters)
                {
                    var counter = item as counter;
                    reportDAO.Counters.Add(new DAO.Counters()
                    {
                        CounterCategory = counter.CounterCategory,
                        CounterName = counter.CounterName,
                        CounterInstance = counter.CounterInstance,
                        FilterOutLoadTestRig = counter.FilterOutLoadTestRig
                    });
                }
                listOfreports.Add(reportDAO);
            }

            var _list = new List<int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (_selectedHash.ContainsKey(i) && (bool)_selectedHash[i] == true)
                {
                    int LoadTestRunId = 0;
                    if (int.TryParse(dataGridView1["loadTestRunId", i].Value.ToString(), out LoadTestRunId))
                    {
                        _list.Add(LoadTestRunId);
                    }
                }
            }

            reportDesign1.Reports = listOfreports;
            reportDesign1.LoadTestRuns = _list;
        }

        private void comboConnectionString_SelectedIndexChanged(object sender, EventArgs e)
        {
            _connString = string.Format("name={0}", comboConnectionString.SelectedItem);
            SelectedTests.Clear();
            selectLT_Enter(sender, e);
        }
    }
}
