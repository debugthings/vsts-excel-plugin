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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(selectLoadTest));
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wizardPages1 = new ExcelLoadTestReport.WizardPages();
            this.selectServer = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectRunType = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.selectLT = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboLoadTest = new System.Windows.Forms.ComboBox();
            this.setReportInfo = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.setReports = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOtherCounters = new System.Windows.Forms.CheckBox();
            this.chkStandardReports = new System.Windows.Forms.CheckBox();
            this.setCounters = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.wizardPages1.SuspendLayout();
            this.selectServer.SuspendLayout();
            this.selectRunType.SuspendLayout();
            this.selectLT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.setReportInfo.SuspendLayout();
            this.setReports.SuspendLayout();
            this.setCounters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(153, 489);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(234, 489);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Enabled = false;
            this.btnFinish.Location = new System.Drawing.Point(315, 489);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Location = new System.Drawing.Point(396, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.selectServer);
            this.wizardPages1.Controls.Add(this.selectRunType);
            this.wizardPages1.Controls.Add(this.selectLT);
            this.wizardPages1.Controls.Add(this.setReportInfo);
            this.wizardPages1.Controls.Add(this.setReports);
            this.wizardPages1.Controls.Add(this.setCounters);
            this.wizardPages1.Location = new System.Drawing.Point(-9, 59);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(502, 399);
            this.wizardPages1.TabIndex = 4;
            // 
            // selectServer
            // 
            this.selectServer.Controls.Add(this.comboBox1);
            this.selectServer.Controls.Add(this.label2);
            this.selectServer.Controls.Add(this.textBox1);
            this.selectServer.Controls.Add(this.label1);
            this.selectServer.Location = new System.Drawing.Point(4, 22);
            this.selectServer.Name = "selectServer";
            this.selectServer.Padding = new System.Windows.Forms.Padding(3);
            this.selectServer.Size = new System.Drawing.Size(494, 373);
            this.selectServer.TabIndex = 0;
            this.selectServer.Text = "selectServer";
            this.selectServer.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.CausesValidation = false;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(17, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name (example Server\\SQLEXPRESS)";
            // 
            // selectRunType
            // 
            this.selectRunType.Controls.Add(this.radioButton2);
            this.selectRunType.Controls.Add(this.radioButton1);
            this.selectRunType.Location = new System.Drawing.Point(4, 22);
            this.selectRunType.Name = "selectRunType";
            this.selectRunType.Padding = new System.Windows.Forms.Padding(3);
            this.selectRunType.Size = new System.Drawing.Size(494, 373);
            this.selectRunType.TabIndex = 4;
            this.selectRunType.Text = "selectRunType";
            this.selectRunType.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(114, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Compare Test Run";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single Test Run";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // selectLT
            // 
            this.selectLT.Controls.Add(this.label7);
            this.selectLT.Controls.Add(this.dataGridView1);
            this.selectLT.Controls.Add(this.comboLoadTest);
            this.selectLT.Location = new System.Drawing.Point(4, 22);
            this.selectLT.Name = "selectLT";
            this.selectLT.Padding = new System.Windows.Forms.Padding(3);
            this.selectLT.Size = new System.Drawing.Size(494, 373);
            this.selectLT.TabIndex = 5;
            this.selectLT.Text = "selectLoadTest";
            this.selectLT.UseVisualStyleBackColor = true;
            this.selectLT.Enter += new System.EventHandler(this.selectLT_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Select Load Test(s)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(17, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(459, 290);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // comboLoadTest
            // 
            this.comboLoadTest.CausesValidation = false;
            this.comboLoadTest.FormattingEnabled = true;
            this.comboLoadTest.Location = new System.Drawing.Point(17, 41);
            this.comboLoadTest.Name = "comboLoadTest";
            this.comboLoadTest.Size = new System.Drawing.Size(459, 21);
            this.comboLoadTest.TabIndex = 0;
            this.comboLoadTest.SelectedIndexChanged += new System.EventHandler(this.comboLoadTest_SelectedIndexChanged);
            // 
            // setReportInfo
            // 
            this.setReportInfo.Controls.Add(this.txtDescription);
            this.setReportInfo.Controls.Add(this.label6);
            this.setReportInfo.Controls.Add(this.label5);
            this.setReportInfo.Controls.Add(this.txtReportTitle);
            this.setReportInfo.Location = new System.Drawing.Point(4, 22);
            this.setReportInfo.Name = "setReportInfo";
            this.setReportInfo.Padding = new System.Windows.Forms.Padding(3);
            this.setReportInfo.Size = new System.Drawing.Size(494, 373);
            this.setReportInfo.TabIndex = 3;
            this.setReportInfo.Text = "setReportInfo";
            this.setReportInfo.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(16, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(459, 271);
            this.txtDescription.TabIndex = 1;
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
            // txtReportTitle
            // 
            this.txtReportTitle.Location = new System.Drawing.Point(16, 37);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(459, 20);
            this.txtReportTitle.TabIndex = 0;
            // 
            // setReports
            // 
            this.setReports.Controls.Add(this.label4);
            this.setReports.Controls.Add(this.label3);
            this.setReports.Controls.Add(this.chkOtherCounters);
            this.setReports.Controls.Add(this.chkStandardReports);
            this.setReports.Location = new System.Drawing.Point(4, 22);
            this.setReports.Name = "setReports";
            this.setReports.Padding = new System.Windows.Forms.Padding(3);
            this.setReports.Size = new System.Drawing.Size(494, 373);
            this.setReports.TabIndex = 1;
            this.setReports.Text = "setReports";
            this.setReports.UseVisualStyleBackColor = true;
            this.setReports.Enter += new System.EventHandler(this.setReports_Enter);
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
            this.chkOtherCounters.Size = new System.Drawing.Size(130, 17);
            this.chkOtherCounters.TabIndex = 1;
            this.chkOtherCounters.Text = "Select Other Counters";
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
            this.setCounters.Controls.Add(this.treeView1);
            this.setCounters.Location = new System.Drawing.Point(4, 22);
            this.setCounters.Name = "setCounters";
            this.setCounters.Padding = new System.Windows.Forms.Padding(3);
            this.setCounters.Size = new System.Drawing.Size(494, 373);
            this.setCounters.TabIndex = 2;
            this.setCounters.Text = "setCounters";
            this.setCounters.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(17, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(459, 361);
            this.treeView1.TabIndex = 0;
            // 
            // selectLoadTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 524);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.wizardPages1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(491, 551);
            this.MinimumSize = new System.Drawing.Size(491, 551);
            this.Name = "selectLoadTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Setup Load Test Report";
            this.wizardPages1.ResumeLayout(false);
            this.selectServer.ResumeLayout(false);
            this.selectServer.PerformLayout();
            this.selectRunType.ResumeLayout(false);
            this.selectRunType.PerformLayout();
            this.selectLT.ResumeLayout(false);
            this.selectLT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.setReportInfo.ResumeLayout(false);
            this.setReportInfo.PerformLayout();
            this.setReports.ResumeLayout(false);
            this.setReports.PerformLayout();
            this.setCounters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages1;
        private System.Windows.Forms.TabPage selectServer;
        private System.Windows.Forms.TabPage setReports;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage setCounters;
        private System.Windows.Forms.TabPage selectRunType;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage setReportInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkOtherCounters;
        private System.Windows.Forms.CheckBox chkStandardReports;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage selectLT;
        private System.Windows.Forms.ComboBox comboLoadTest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;

    }
}