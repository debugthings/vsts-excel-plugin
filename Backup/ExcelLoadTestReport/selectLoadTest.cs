using System;
using System.Collections.Generic;
using System.ComponentModel;
using SqlClient = System.Data.SqlClient;
using Sql = System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelLoadTestReport
{
    public partial class selectLoadTest : Form
    {

        string _databaseServer;
        string _databaseName;
        SqlClient.SqlConnection _sqlConn;
        string _sqlInitialConnectString = "Data Source={0};Initial Catalog=master;Integrated Security=SSPI;";
        string _sqlDBConnectStringBase = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";
        string _sqlDBConnectString = "";
        List<int> SelectedTests = new List<int>();
        System.Collections.Hashtable _selectedHash = new System.Collections.Hashtable();
        Sql.DataRowView _selectedLoadTest;

        public selectLoadTest()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            comboBox1.Items.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                _sqlConn = new SqlClient.SqlConnection();
                _sqlConn.ConnectionString = String.Format(_sqlInitialConnectString,textBox1.Text);
                SqlClient.SqlCommand _sqlCommand = new SqlClient.SqlCommand("sp_databases", _sqlConn);
                _sqlCommand.CommandType = Sql.CommandType.StoredProcedure;
                try
                {
                    using (_sqlConn)
                    {
                        _sqlConn.Open();
                        using (_sqlCommand)
                        {
                            SqlClient.SqlDataAdapter _sqlDataAdapter = new SqlClient.SqlDataAdapter(_sqlCommand);
                            using (_sqlDataAdapter)
                            {
                                Sql.DataSet _ds = new Sql.DataSet("Databases");
                                using (_ds)
                                {
                                    _sqlDataAdapter.Fill(_ds);
                                    comboBox1.DataSource = _ds.Tables[0];
                                    comboBox1.DisplayMember = "DATABASE_NAME";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    comboBox1.Enabled = true;
                    _databaseServer = textBox1.Text;
                }

            }
        }


        private void textBox1_Validating(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                comboBox1.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
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
                    if (!_selectedHash.ContainsKey(i) && !(dataGridView1[0,i].Value is System.DBNull))
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sqlDBConnectString = string.Format(_sqlDBConnectStringBase, textBox1.Text, ((Sql.DataRowView)comboBox1.SelectedItem).Row[0]);
        }

        private void comboLoadTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sqlConn = new SqlClient.SqlConnection();
            _sqlConn.ConnectionString = _sqlDBConnectString;
            SqlClient.SqlCommand _sqlCommand = new SqlClient.SqlCommand("SELECT StartTime As [Time], RunDuration As Duration, SUBSTRING(Comment,CHARINDEX('[',Comment,0) + 1,CHARINDEX(']',Comment,0)-2) As [User], Description, LoadTestRunId From LoadTestRun WHERE LoadTestName = @loadTestName", _sqlConn);
            _sqlCommand.Parameters.Add(new SqlClient.SqlParameter("loadTestName", ((Sql.DataRowView)comboLoadTest.SelectedItem).Row[0]));
            _sqlCommand.CommandType = Sql.CommandType.Text;
            _selectedLoadTest = (Sql.DataRowView)comboLoadTest.SelectedItem;
            try
            {
                using (_sqlConn)
                {
                    _sqlConn.Open();
                    using (_sqlCommand)
                    {
                        SqlClient.SqlDataAdapter _sqlDataAdapter = new SqlClient.SqlDataAdapter(_sqlCommand);
                        using (_sqlDataAdapter)
                        {
                            Sql.DataSet _ds = new Sql.DataSet("LoadTestRuns");
                            using (_ds)
                            {
                                dataGridView1.DataSource = null;
                                _ds.Tables.Add();
                                _ds.Tables[0].Columns.Add(" ", System.Type.GetType("System.Boolean"));
                                _sqlDataAdapter.Fill(_ds.Tables[0]);
                                dataGridView1.DataSource = _ds.Tables[0];
                                ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView1.Columns[0]).FalseValue = false;
                                ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView1.Columns[0]).TrueValue = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                comboBox1.Enabled = true;
                _databaseServer = textBox1.Text;
            }
        }

        private void selectLT_Enter(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            if (comboLoadTest.Items.Count == 0)
            {
                _sqlConn = new SqlClient.SqlConnection();
                _sqlConn.ConnectionString = _sqlDBConnectString;
                SqlClient.SqlCommand _sqlCommand = new SqlClient.SqlCommand("SELECT DISTINCT LoadTestName FROM LoadTestRun", _sqlConn);
                _sqlCommand.CommandType = Sql.CommandType.Text;
                try
                {
                    using (_sqlConn)
                    {
                        _sqlConn.Open();
                        using (_sqlCommand)
                        {
                            SqlClient.SqlDataAdapter _sqlDataAdapter = new SqlClient.SqlDataAdapter(_sqlCommand);
                            using (_sqlDataAdapter)
                            {
                                Sql.DataSet _ds = new Sql.DataSet("LoadTests");
                                using (_ds)
                                {

                                    _sqlDataAdapter.Fill(_ds);
                                    comboLoadTest.DataSource = _ds.Tables[0];
                                    comboLoadTest.DisplayMember = "LoadTestName";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    comboBox1.Enabled = true;
                    _databaseServer = textBox1.Text;
                }
            }
            else
            {
                //if (_selectedLoadTest != null)
                //{
                //    comboLoadTest.SelectedItem = _selectedLoadTest;   
                //}
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("time",StringComparison.CurrentCultureIgnoreCase))
            {
                e.CellStyle.Format = "MM/dd/yyyy hh:mm t";
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
                if (_selectedHash.ContainsKey(i) && (bool)_selectedHash[i] == true)
                {
                    int LoadTestId = 0;
                    if (int.TryParse(dataGridView1["LoadTestRunId",i].Value.ToString(),out LoadTestId))
                    {
                        CreateReport(LoadTestId);
                    }
                }
			}
            this.Close();
        }

        private void CreateReport(int LoadTestRunId)
        {
            ExcelLoadTestReport.PageTemplates.PivotTableAndChartTemplate cpuPage = new PageTemplates.PivotTableAndChartTemplate();
            cpuPage.Fill(LoadTestRunId, "Processor", "% Processor Time", true);
            cpuPage.Fill(LoadTestRunId, "Memory", "Available MBytes", true);
            cpuPage.Fill(LoadTestRunId, "LoadTest:Transaction", "Avg. Response Time", true);
            cpuPage.Fill(LoadTestRunId, "LoadTest:Transaction", "Transactions/Sec", true);
            cpuPage.Fill(LoadTestRunId, "LoadTest:Page", "Avg. Page Time", true);
            cpuPage.Fill(LoadTestRunId, "LoadTest:Request", "Requests/Sec", true);
            cpuPage.Fill(LoadTestRunId, "LoadTest:Request", "Avg. Response Time", true);
            cpuPage.Fill(LoadTestRunId, "Process", "% Processor Time", true);
            cpuPage.Fill(LoadTestRunId, "Process", "Private Bytes", true);
            cpuPage.Fill(LoadTestRunId, "PhysicalDisk", "", true);
            cpuPage.Fill(LoadTestRunId, "LogicalDisk", "", true);
            //Avg. Response Time
        }

        private void setReports_Enter(object sender, EventArgs e)
        {
            btnFinish.Enabled = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }

}
