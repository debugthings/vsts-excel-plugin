using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Data.Entity.Infrastructure;

namespace ExcelLoadTestReport {
        public partial class loadTestView : Form {


                BindingSource _bs = new BindingSource ();
                string lastSortedColumn = string.Empty;
                SortOrder lastSortOrder = SortOrder.None;
                public List<DAO.SelectedLoadTests> LoadTests { get; internal set; }

                public loadTestView () {
                        InitializeComponent ();

                }

                public delegate List<DAO.SelectedLoadTests> UpdateLoadTests (bool FilterByMe);

                public UpdateLoadTests FillFromExternal { get; set; }

                public loadTestView (bool AddSizeColumn)
                    : this () {
                        var dgVCol = new DataGridViewColumn ();
                        dgVCol.Name = "Size";
                        dgVCol.HeaderText = "Size";
                        dgVCol.DataPropertyName = "Size";
                        dgVCol.CellTemplate = dataGridView1.Columns [1].CellTemplate;
                        this.dataGridView1.Columns.Add (dgVCol);
                }

                private void updateDatagrid (bool FilterByMe) {
                        LoadTests = FillFromExternal (FilterByMe);
                        _bs.DataSource = LoadTests;
                        dataGridView1.AutoResizeColumns ();
                }

                private List<DAO.SelectedLoadTests> UseInternalList (bool FilterByMe) {
                        if ( LoadTests == null ) {
                                LoadTests = FillFromExternal (false);
                        }
                        if ( FilterByMe ) {
                                var _user = WindowsIdentity.GetCurrent ();
                                var filter = (from lts in LoadTests
                                              where lts.RunBy.StartsWith (string.Format ("[{0}]", _user.Name), StringComparison.CurrentCultureIgnoreCase)
                                              select lts).ToList ();
                                return filter;
                        }
                        return LoadTests;
                }

                private void loadTestView_Load (object sender, EventArgs e) {
                        this.Refresh ();
                        dataGridView1.DataSource = _bs;
                        var bg = new BackgroundWorker ();
                        bg.DoWork += new DoWorkEventHandler (bg_DoWork);
                        bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler (bg_RunWorkerCompleted);
                        bg.RunWorkerAsync ();
                }

                void bg_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
                        _bs.DataSource = UseInternalList (chkFilterByMe.Checked);
                        dataGridView1.AutoResizeColumns ();
                        progressBar1.Visible = false;
                        lblWait.Visible = false;
                        dataGridView1.Visible = true;
                        chkFilterByMe.Visible = true;
                }

                void bg_DoWork (object sender, DoWorkEventArgs e) {
                        LoadTests = UseInternalList (false);
                }

                private void dataGridView1_DataBindingComplete (object sender, DataGridViewBindingCompleteEventArgs e) {
                        if ( e.ListChangedType == ListChangedType.Reset ) {
                                var style = dataGridView1.DefaultCellStyle.Clone ();
                                style.BackColor = Color.FromArgb (255, 255, 231, 231);
                                foreach ( DataGridViewRow r in dataGridView1.Rows ) {
                                        if ( r.Cells ["endTime"].Value == null ) {
                                                var cStyle = r.Cells ["selected"].Style.Clone ();
                                                cStyle.BackColor = Color.FromArgb (255, 255, 231, 231);
                                                cStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                                r.DefaultCellStyle = style;
                                                r.Cells ["selected"].Style = cStyle;
                                        }
                                }
                        }
                }

                private void btnDeleteLTs_Click (object sender, EventArgs e) {
                        List<object []> loadTests = new List<object []> ();

                        foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                                if ( (bool)item.Cells ["selected"].Value == true ) {
                                        loadTests.Add (new object [] { (int?)item.Cells ["loadTestRunId"].Value, item.Cells ["loadTestName"].Value, item.Cells ["startTime"].Value });
                                }
                        }

                        if ( loadTests.Count > 0 ) {
                                var result = MessageBox.Show ("Are you sure you want to delete the selected load tests?", "Confirm Delete", MessageBoxButtons.YesNo);
                                if ( result == System.Windows.Forms.DialogResult.Yes ) {

                                        var modDelete = new deleteWait ();
                                        var progBar = modDelete.Controls.Find ("progressBar1", true) [0] as ProgressBar;
                                        var control = modDelete.Controls.Find ("label3", true) [0];
                                        progBar.Step = 100 / loadTests.Count;
                                        modDelete.Show ();
                                        foreach ( var item in loadTests ) {
                                                using ( var context = new Models.LoadTest2010Entities () ) {
                                                        ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 1200;
                                                        progBar.PerformStep ();
                                                        control.Text = string.Format ("Deleting load test \"{0}\" run on {1}.", item [1], item [2]);
                                                        modDelete.Refresh ();
                                                        context.DeleteLoadTestRun ((int?)item [0]);
                                                }
                                        }
                                        modDelete.Close ();
                                        updateDatagrid (chkFilterByMe.Checked);
                                }
                        } else {
                                var result = MessageBox.Show ("Please select at least one load test.", "Nothing Selected");
                        }

                }

                private void dataGridView1_ColumnHeaderMouseClick (object sender, DataGridViewCellMouseEventArgs e) {

                }

                private void dataGridView1_ColumnHeaderMouseClick_1 (object sender, DataGridViewCellMouseEventArgs e) {
                        DAO.LTCompare cmp = null;
                        if ( lastSortedColumn == dataGridView1.Columns [e.ColumnIndex].DataPropertyName ) {

                                if ( lastSortOrder == SortOrder.Descending | lastSortOrder == SortOrder.None ) {
                                        lastSortOrder = SortOrder.Ascending;
                                        cmp = new DAO.LTCompare (dataGridView1.Columns [e.ColumnIndex].DataPropertyName, lastSortOrder);

                                } else {
                                        lastSortOrder = SortOrder.Descending;
                                        cmp = new DAO.LTCompare (dataGridView1.Columns [e.ColumnIndex].DataPropertyName, lastSortOrder);
                                }
                        } else {
                                cmp = new DAO.LTCompare (dataGridView1.Columns [e.ColumnIndex].DataPropertyName, SortOrder.Ascending);
                                lastSortOrder = SortOrder.Ascending;
                        }
                        lastSortedColumn = dataGridView1.Columns [e.ColumnIndex].DataPropertyName;
                        var dsource =
                            new List<DAO.SelectedLoadTests> (((List<DAO.SelectedLoadTests>)_bs.DataSource));
                        dsource.Sort (cmp);
                        _bs.DataSource = dsource;
                }

                private void markSelectedToolStripMenuItem_Click (object sender, EventArgs e) {
                        foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                                if ( item.Selected ) {
                                        if ( (bool)item.Cells ["selected"].Value == false ) {
                                                item.Cells ["selected"].Value = true;
                                        }
                                }

                        }
                }

                private void uncheckSelectedToolStripMenuItem_Click (object sender, EventArgs e) {
                        foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                                if ( item.Selected ) {
                                        if ( (bool)item.Cells ["selected"].Value == true ) {
                                                item.Cells ["selected"].Value = false;
                                        }
                                }

                        }
                }

                private void chkFilterByMe_CheckedChanged (object sender, EventArgs e) {
                        if ( LoadTests != null ) {
                                _bs.DataSource = UseInternalList (chkFilterByMe.Checked);
                        }

                }

        }
}
