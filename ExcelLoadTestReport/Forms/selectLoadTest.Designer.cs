namespace ExcelLoadTestReport
{
    partial class selectLoadTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectLoadTest));
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wizardPages1 = new ExcelLoadTestReport.WizardPages();
            this.selectLT = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.comboConnectionString = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loadTestRunId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedLoadTestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.comboLoadTest = new System.Windows.Forms.ComboBox();
            this.renameTestRuns = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.setReportInfo = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.setReports = new System.Windows.Forms.TabPage();
            this.chkBoxCommon = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOtherCounters = new System.Windows.Forms.CheckBox();
            this.chkStandardReports = new System.Windows.Forms.CheckBox();
            this.setCounters = new System.Windows.Forms.TabPage();
            this.reportDesign1 = new ExcelLoadTestReport.Forms.reportDesign();
            this.chkPerProcess = new System.Windows.Forms.CheckBox();
            this.chkDotNetCounters = new System.Windows.Forms.CheckBox();
            this.chkSQLCounters = new System.Windows.Forms.CheckBox();
            this.wizardPages1.SuspendLayout();
            this.selectLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedLoadTestsBindingSource)).BeginInit();
            this.renameTestRuns.SuspendLayout();
            this.setReportInfo.SuspendLayout();
            this.setReports.SuspendLayout();
            this.setCounters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Location = new System.Drawing.Point(454, 533);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(535, 533);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Enabled = false;
            this.btnFinish.Location = new System.Drawing.Point(616, 533);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(697, 533);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // wizardPages1
            // 
            this.wizardPages1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPages1.Controls.Add(this.selectLT);
            this.wizardPages1.Controls.Add(this.renameTestRuns);
            this.wizardPages1.Controls.Add(this.setReportInfo);
            this.wizardPages1.Controls.Add(this.setReports);
            this.wizardPages1.Controls.Add(this.setCounters);
            this.wizardPages1.Location = new System.Drawing.Point(12, 84);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(760, 443);
            this.wizardPages1.TabIndex = 4;
            // 
            // selectLT
            // 
            this.selectLT.BackColor = System.Drawing.SystemColors.Control;
            this.selectLT.Controls.Add(this.label2);
            this.selectLT.Controls.Add(this.comboConnectionString);
            this.selectLT.Controls.Add(this.dataGridView1);
            this.selectLT.Controls.Add(this.label7);
            this.selectLT.Controls.Add(this.comboLoadTest);
            this.selectLT.Location = new System.Drawing.Point(4, 22);
            this.selectLT.Name = "selectLT";
            this.selectLT.Padding = new System.Windows.Forms.Padding(3);
            this.selectLT.Size = new System.Drawing.Size(752, 417);
            this.selectLT.TabIndex = 5;
            this.selectLT.Text = "selectLoadTest";
            this.selectLT.Enter += new System.EventHandler(this.selectLT_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Connection String";
            // 
            // comboConnectionString
            // 
            this.comboConnectionString.CausesValidation = false;
            this.comboConnectionString.FormattingEnabled = true;
            this.comboConnectionString.Location = new System.Drawing.Point(9, 25);
            this.comboConnectionString.Name = "comboConnectionString";
            this.comboConnectionString.Size = new System.Drawing.Size(471, 21);
            this.comboConnectionString.TabIndex = 5;
            this.comboConnectionString.SelectedIndexChanged += new System.EventHandler(this.comboConnectionString_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedDataGridViewCheckBoxColumn,
            this.loadTestRunId,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.durationDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4,
            this.runByDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.selectedLoadTestsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(740, 310);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "Selected";
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            this.selectedDataGridViewCheckBoxColumn.Width = 105;
            // 
            // loadTestRunId
            // 
            this.loadTestRunId.DataPropertyName = "LoadTestRunId";
            this.loadTestRunId.HeaderText = "Id";
            this.loadTestRunId.Name = "loadTestRunId";
            this.loadTestRunId.Width = 106;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "StartTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "Start Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 105;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EndTime";
            this.dataGridViewTextBoxColumn3.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Width = 106;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LoadTestName";
            this.dataGridViewTextBoxColumn4.HeaderText = "LoadTest Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // runByDataGridViewTextBoxColumn
            // 
            this.runByDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.runByDataGridViewTextBoxColumn.DataPropertyName = "RunBy";
            this.runByDataGridViewTextBoxColumn.HeaderText = "Run By";
            this.runByDataGridViewTextBoxColumn.Name = "runByDataGridViewTextBoxColumn";
            this.runByDataGridViewTextBoxColumn.Width = 105;
            // 
            // selectedLoadTestsBindingSource
            // 
            this.selectedLoadTestsBindingSource.DataSource = typeof(ExcelLoadTestReport.DAO.SelectedLoadTests);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Select Load Test(s)";
            // 
            // comboLoadTest
            // 
            this.comboLoadTest.CausesValidation = false;
            this.comboLoadTest.FormattingEnabled = true;
            this.comboLoadTest.Location = new System.Drawing.Point(9, 70);
            this.comboLoadTest.Name = "comboLoadTest";
            this.comboLoadTest.Size = new System.Drawing.Size(471, 21);
            this.comboLoadTest.TabIndex = 0;
            this.comboLoadTest.SelectedIndexChanged += new System.EventHandler(this.comboLoadTest_SelectedIndexChanged);
            // 
            // renameTestRuns
            // 
            this.renameTestRuns.BackColor = System.Drawing.SystemColors.Control;
            this.renameTestRuns.Controls.Add(this.label1);
            this.renameTestRuns.Location = new System.Drawing.Point(4, 22);
            this.renameTestRuns.Name = "renameTestRuns";
            this.renameTestRuns.Padding = new System.Windows.Forms.Padding(3);
            this.renameTestRuns.Size = new System.Drawing.Size(752, 417);
            this.renameTestRuns.TabIndex = 6;
            this.renameTestRuns.Text = "renameTestRun";
            this.renameTestRuns.Enter += new System.EventHandler(this.renameTestRuns_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FUTURE Use the data grid below to rename your tests to something meaningful.";
            // 
            // setReportInfo
            // 
            this.setReportInfo.BackColor = System.Drawing.SystemColors.Control;
            this.setReportInfo.Controls.Add(this.txtDescription);
            this.setReportInfo.Controls.Add(this.txtReportTitle);
            this.setReportInfo.Controls.Add(this.label6);
            this.setReportInfo.Controls.Add(this.label5);
            this.setReportInfo.Location = new System.Drawing.Point(4, 22);
            this.setReportInfo.Name = "setReportInfo";
            this.setReportInfo.Padding = new System.Windows.Forms.Padding(3);
            this.setReportInfo.Size = new System.Drawing.Size(752, 417);
            this.setReportInfo.TabIndex = 3;
            this.setReportInfo.Text = "setReportInfo";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(16, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(730, 323);
            this.txtDescription.TabIndex = 1;
            // 
            // txtReportTitle
            // 
            this.txtReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportTitle.Location = new System.Drawing.Point(16, 37);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(730, 20);
            this.txtReportTitle.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Report Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Title of Report";
            // 
            // setReports
            // 
            this.setReports.BackColor = System.Drawing.SystemColors.Control;
            this.setReports.Controls.Add(this.chkSQLCounters);
            this.setReports.Controls.Add(this.chkDotNetCounters);
            this.setReports.Controls.Add(this.chkPerProcess);
            this.setReports.Controls.Add(this.chkBoxCommon);
            this.setReports.Controls.Add(this.label4);
            this.setReports.Controls.Add(this.label3);
            this.setReports.Controls.Add(this.chkOtherCounters);
            this.setReports.Controls.Add(this.chkStandardReports);
            this.setReports.Location = new System.Drawing.Point(4, 22);
            this.setReports.Name = "setReports";
            this.setReports.Padding = new System.Windows.Forms.Padding(3);
            this.setReports.Size = new System.Drawing.Size(752, 417);
            this.setReports.TabIndex = 1;
            this.setReports.Text = "setReports";
            this.setReports.Enter += new System.EventHandler(this.setReports_Enter);
            // 
            // chkBoxCommon
            // 
            this.chkBoxCommon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBoxCommon.AutoSize = true;
            this.chkBoxCommon.Checked = true;
            this.chkBoxCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxCommon.Location = new System.Drawing.Point(17, 191);
            this.chkBoxCommon.Name = "chkBoxCommon";
            this.chkBoxCommon.Size = new System.Drawing.Size(103, 23);
            this.chkBoxCommon.TabIndex = 2;
            this.chkBoxCommon.Text = "Common Counters";
            this.chkBoxCommon.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(411, 52);
            this.label4.TabIndex = 1;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(416, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "These reports include the standard hardware stats as well as the response time gr" +
    "aphs.\r\nThey also include requests per second and transaction per second overlaid" +
    " with the\r\nCPU information.";
            // 
            // chkOtherCounters
            // 
            this.chkOtherCounters.AutoSize = true;
            this.chkOtherCounters.Location = new System.Drawing.Point(17, 91);
            this.chkOtherCounters.Name = "chkOtherCounters";
            this.chkOtherCounters.Size = new System.Drawing.Size(115, 17);
            this.chkOtherCounters.TabIndex = 1;
            this.chkOtherCounters.Text = "Advanced Reports";
            this.chkOtherCounters.UseVisualStyleBackColor = true;
            this.chkOtherCounters.CheckedChanged += new System.EventHandler(this.chkOtherCounters_CheckedChanged);
            // 
            // chkStandardReports
            // 
            this.chkStandardReports.AutoSize = true;
            this.chkStandardReports.Checked = true;
            this.chkStandardReports.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStandardReports.Location = new System.Drawing.Point(17, 17);
            this.chkStandardReports.Name = "chkStandardReports";
            this.chkStandardReports.Size = new System.Drawing.Size(143, 17);
            this.chkStandardReports.TabIndex = 0;
            this.chkStandardReports.Text = "Create Standard Reports";
            this.chkStandardReports.UseVisualStyleBackColor = true;
            // 
            // setCounters
            // 
            this.setCounters.BackColor = System.Drawing.SystemColors.Control;
            this.setCounters.Controls.Add(this.reportDesign1);
            this.setCounters.Location = new System.Drawing.Point(4, 22);
            this.setCounters.Name = "setCounters";
            this.setCounters.Padding = new System.Windows.Forms.Padding(3);
            this.setCounters.Size = new System.Drawing.Size(752, 417);
            this.setCounters.TabIndex = 2;
            this.setCounters.Text = "setCounters";
            this.setCounters.Enter += new System.EventHandler(this.setCounters_Enter);
            // 
            // reportDesign1
            // 
            this.reportDesign1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportDesign1.ChangedNodes = null;
            this.reportDesign1.LoadTestRuns = null;
            this.reportDesign1.Location = new System.Drawing.Point(6, 6);
            this.reportDesign1.Name = "reportDesign1";
            this.reportDesign1.Reports = null;
            this.reportDesign1.Size = new System.Drawing.Size(740, 411);
            this.reportDesign1.TabIndex = 0;
            // 
            // chkPerProcess
            // 
            this.chkPerProcess.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPerProcess.AutoSize = true;
            this.chkPerProcess.Checked = true;
            this.chkPerProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPerProcess.Location = new System.Drawing.Point(126, 191);
            this.chkPerProcess.Name = "chkPerProcess";
            this.chkPerProcess.Size = new System.Drawing.Size(119, 23);
            this.chkPerProcess.TabIndex = 3;
            this.chkPerProcess.Text = "Per Process Counters";
            this.chkPerProcess.UseVisualStyleBackColor = true;
            // 
            // chkDotNetCounters
            // 
            this.chkDotNetCounters.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDotNetCounters.AutoSize = true;
            this.chkDotNetCounters.Checked = true;
            this.chkDotNetCounters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDotNetCounters.Location = new System.Drawing.Point(251, 191);
            this.chkDotNetCounters.Name = "chkDotNetCounters";
            this.chkDotNetCounters.Size = new System.Drawing.Size(87, 23);
            this.chkDotNetCounters.TabIndex = 4;
            this.chkDotNetCounters.Text = ".NET Counters";
            this.chkDotNetCounters.UseVisualStyleBackColor = true;
            // 
            // chkSQLCounters
            // 
            this.chkSQLCounters.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSQLCounters.AutoSize = true;
            this.chkSQLCounters.Checked = true;
            this.chkSQLCounters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSQLCounters.Location = new System.Drawing.Point(344, 191);
            this.chkSQLCounters.Name = "chkSQLCounters";
            this.chkSQLCounters.Size = new System.Drawing.Size(117, 23);
            this.chkSQLCounters.TabIndex = 5;
            this.chkSQLCounters.Text = "SQL Server Counters";
            this.chkSQLCounters.UseVisualStyleBackColor = true;
            // 
            // selectLoadTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.wizardPages1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 551);
            this.Name = "selectLoadTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Setup Load Test Report";
            this.Load += new System.EventHandler(this.selectLoadTest_Load);
            this.wizardPages1.ResumeLayout(false);
            this.selectLT.ResumeLayout(false);
            this.selectLT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedLoadTestsBindingSource)).EndInit();
            this.renameTestRuns.ResumeLayout(false);
            this.renameTestRuns.PerformLayout();
            this.setReportInfo.ResumeLayout(false);
            this.setReportInfo.PerformLayout();
            this.setReports.ResumeLayout(false);
            this.setReports.PerformLayout();
            this.setCounters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage setCounters;
        private System.Windows.Forms.TabPage setReports;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkOtherCounters;
        private System.Windows.Forms.CheckBox chkStandardReports;
        private System.Windows.Forms.TabPage setReportInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage selectLT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboLoadTest;
        private WizardPages wizardPages1;
        private System.Windows.Forms.TabPage renameTestRuns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadTestRunIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadTestNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource selectedLoadTestsBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadTestRunId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn runByDataGridViewTextBoxColumn;
        private Forms.reportDesign reportDesign1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboConnectionString;
        private System.Windows.Forms.CheckBox chkBoxCommon;
        private System.Windows.Forms.CheckBox chkSQLCounters;
        private System.Windows.Forms.CheckBox chkDotNetCounters;
        private System.Windows.Forms.CheckBox chkPerProcess;

    }
}