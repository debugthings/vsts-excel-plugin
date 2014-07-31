namespace ExcelLoadTestReport
{
    partial class loadTestView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteLTs = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkFilterByMe = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblWait = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loadTestRunId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedLoadTestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedLoadTestsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.loadTestRunId,
            this.loadTestName,
            this.startTime,
            this.endTime,
            this.durationDataGridViewTextBoxColumn,
            this.runByDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.selectedLoadTestsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(789, 489);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick_1);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markSelectedToolStripMenuItem,
            this.uncheckSelectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 48);
            // 
            // markSelectedToolStripMenuItem
            // 
            this.markSelectedToolStripMenuItem.Name = "markSelectedToolStripMenuItem";
            this.markSelectedToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.markSelectedToolStripMenuItem.Text = "Check Selected";
            this.markSelectedToolStripMenuItem.Click += new System.EventHandler(this.markSelectedToolStripMenuItem_Click);
            // 
            // uncheckSelectedToolStripMenuItem
            // 
            this.uncheckSelectedToolStripMenuItem.Name = "uncheckSelectedToolStripMenuItem";
            this.uncheckSelectedToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.uncheckSelectedToolStripMenuItem.Text = "Uncheck Selected";
            this.uncheckSelectedToolStripMenuItem.Click += new System.EventHandler(this.uncheckSelectedToolStripMenuItem_Click);
            // 
            // btnDeleteLTs
            // 
            this.btnDeleteLTs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLTs.Location = new System.Drawing.Point(725, 527);
            this.btnDeleteLTs.Name = "btnDeleteLTs";
            this.btnDeleteLTs.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLTs.TabIndex = 1;
            this.btnDeleteLTs.Text = "Delete";
            this.btnDeleteLTs.UseVisualStyleBackColor = true;
            this.btnDeleteLTs.Click += new System.EventHandler(this.btnDeleteLTs_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(644, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // chkFilterByMe
            // 
            this.chkFilterByMe.AutoSize = true;
            this.chkFilterByMe.Location = new System.Drawing.Point(13, 8);
            this.chkFilterByMe.Name = "chkFilterByMe";
            this.chkFilterByMe.Size = new System.Drawing.Size(139, 17);
            this.chkFilterByMe.TabIndex = 4;
            this.chkFilterByMe.Text = "Only show my tests runs";
            this.chkFilterByMe.UseVisualStyleBackColor = true;
            this.chkFilterByMe.Visible = false;
            this.chkFilterByMe.CheckedChanged += new System.EventHandler(this.chkFilterByMe_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(242, 264);
            this.progressBar1.MarqueeAnimationSpeed = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(328, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 100;
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.BackColor = System.Drawing.Color.Transparent;
            this.lblWait.Location = new System.Drawing.Point(242, 245);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(225, 13);
            this.lblWait.TabIndex = 6;
            this.lblWait.Text = "Please wait while the test results are fetched...";
            // 
            // selected
            // 
            this.selected.DataPropertyName = "Selected";
            this.selected.FillWeight = 5F;
            this.selected.HeaderText = "Selected";
            this.selected.MinimumWidth = 60;
            this.selected.Name = "selected";
            this.selected.Width = 60;
            // 
            // loadTestRunId
            // 
            this.loadTestRunId.DataPropertyName = "LoadTestRunId";
            this.loadTestRunId.FillWeight = 5F;
            this.loadTestRunId.HeaderText = "Id";
            this.loadTestRunId.MinimumWidth = 40;
            this.loadTestRunId.Name = "loadTestRunId";
            this.loadTestRunId.Width = 40;
            // 
            // loadTestName
            // 
            this.loadTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loadTestName.DataPropertyName = "LoadTestName";
            this.loadTestName.FillWeight = 50F;
            this.loadTestName.HeaderText = "Load Test Name";
            this.loadTestName.MinimumWidth = 250;
            this.loadTestName.Name = "loadTestName";
            // 
            // startTime
            // 
            this.startTime.DataPropertyName = "StartTime";
            this.startTime.FillWeight = 10F;
            this.startTime.HeaderText = "StartTime";
            this.startTime.MinimumWidth = 120;
            this.startTime.Name = "startTime";
            this.startTime.Width = 120;
            // 
            // endTime
            // 
            this.endTime.DataPropertyName = "EndTime";
            this.endTime.FillWeight = 10F;
            this.endTime.HeaderText = "EndTime";
            this.endTime.MinimumWidth = 120;
            this.endTime.Name = "endTime";
            this.endTime.Width = 120;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.FillWeight = 62.86147F;
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 70;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Width = 70;
            // 
            // runByDataGridViewTextBoxColumn
            // 
            this.runByDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.runByDataGridViewTextBoxColumn.DataPropertyName = "RunBy";
            this.runByDataGridViewTextBoxColumn.FillWeight = 20F;
            this.runByDataGridViewTextBoxColumn.HeaderText = "RunBy";
            this.runByDataGridViewTextBoxColumn.Name = "runByDataGridViewTextBoxColumn";
            this.runByDataGridViewTextBoxColumn.Width = 20;
            // 
            // selectedLoadTestsBindingSource
            // 
            this.selectedLoadTestsBindingSource.DataSource = typeof(ExcelLoadTestReport.DAO.SelectedLoadTests);
            // 
            // loadTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 562);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkFilterByMe);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteLTs);
            this.Controls.Add(this.dataGridView1);
            this.Name = "loadTestView";
            this.Text = "Load Tests";
            this.Shown += new System.EventHandler(this.loadTestView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedLoadTestsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteLTs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource selectedLoadTestsBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem markSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckSelectedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadTestRunId;
        private System.Windows.Forms.DataGridViewTextBoxColumn loadTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn runByDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox chkFilterByMe;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblWait;
    }
}