namespace ExcelLoadTestReport
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl8 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl9 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl10 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl11 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl12 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl13 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl14 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl15 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl16 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl17 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl18 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl19 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl20 = this.Factory.CreateRibbonDropDownItem();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.comboBox1 = this.Factory.CreateRibbonComboBox();
            this.comboBox2 = this.Factory.CreateRibbonComboBox();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.debugGroup = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button8 = this.Factory.CreateRibbonButton();
            this.rawToggle = this.Factory.CreateRibbonToggleButton();
            this.pivotToggle = this.Factory.CreateRibbonToggleButton();
            this.chartToggle = this.Factory.CreateRibbonToggleButton();
            this.statsToggle = this.Factory.CreateRibbonToggleButton();
            this.button6 = this.Factory.CreateRibbonButton();
            this.button7 = this.Factory.CreateRibbonButton();
            this.button9 = this.Factory.CreateRibbonButton();
            this.button12 = this.Factory.CreateRibbonButton();
            this.button10 = this.Factory.CreateRibbonButton();
            this.button11 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.button5 = this.Factory.CreateRibbonButton();
            this.button13 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.group6.SuspendLayout();
            this.debugGroup.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Groups.Add(this.group6);
            this.tab1.Groups.Add(this.debugGroup);
            this.tab1.Label = "Publix Load Test";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Items.Add(this.button8);
            this.group1.Label = "Reports";
            this.group1.Name = "group1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.rawToggle);
            this.group3.Items.Add(this.pivotToggle);
            this.group3.Items.Add(this.chartToggle);
            this.group3.Items.Add(this.statsToggle);
            this.group3.Label = "Toggle Visibility";
            this.group3.Name = "group3";
            // 
            // group4
            // 
            this.group4.Items.Add(this.button6);
            this.group4.Items.Add(this.button7);
            this.group4.Items.Add(this.button9);
            this.group4.Label = "Common Chart Fixes";
            this.group4.Name = "group4";
            // 
            // group5
            // 
            this.group5.Items.Add(this.comboBox1);
            this.group5.Items.Add(this.comboBox2);
            this.group5.Items.Add(this.button13);
            this.group5.Label = "Common Statistics Fixes";
            this.group5.Name = "group5";
            // 
            // comboBox1
            // 
            ribbonDropDownItemImpl1.Label = "1";
            ribbonDropDownItemImpl2.Label = "2";
            ribbonDropDownItemImpl3.Label = "3";
            ribbonDropDownItemImpl4.Label = "4";
            ribbonDropDownItemImpl5.Label = "5";
            ribbonDropDownItemImpl6.Label = "6";
            ribbonDropDownItemImpl7.Label = "7";
            ribbonDropDownItemImpl8.Label = "8";
            ribbonDropDownItemImpl9.Label = "9";
            ribbonDropDownItemImpl10.Label = "10";
            this.comboBox1.Items.Add(ribbonDropDownItemImpl1);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl2);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl3);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl4);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl5);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl6);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl7);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl8);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl9);
            this.comboBox1.Items.Add(ribbonDropDownItemImpl10);
            this.comboBox1.Label = "Middle Value";
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Text = null;
            // 
            // comboBox2
            // 
            ribbonDropDownItemImpl11.Label = "1";
            ribbonDropDownItemImpl12.Label = "2";
            ribbonDropDownItemImpl13.Label = "3";
            ribbonDropDownItemImpl14.Label = "4";
            ribbonDropDownItemImpl15.Label = "5";
            ribbonDropDownItemImpl16.Label = "6";
            ribbonDropDownItemImpl17.Label = "7";
            ribbonDropDownItemImpl18.Label = "8";
            ribbonDropDownItemImpl19.Label = "9";
            ribbonDropDownItemImpl20.Label = "10";
            this.comboBox2.Items.Add(ribbonDropDownItemImpl11);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl12);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl13);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl14);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl15);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl16);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl17);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl18);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl19);
            this.comboBox2.Items.Add(ribbonDropDownItemImpl20);
            this.comboBox2.Label = "Upper Value";
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Text = null;
            // 
            // group6
            // 
            this.group6.Items.Add(this.button12);
            this.group6.Items.Add(this.button10);
            this.group6.Items.Add(this.button11);
            this.group6.Label = "Database Maintenance";
            this.group6.Name = "group6";
            // 
            // debugGroup
            // 
            this.debugGroup.Items.Add(this.button2);
            this.debugGroup.Items.Add(this.button3);
            this.debugGroup.Items.Add(this.button4);
            this.debugGroup.Items.Add(this.button5);
            this.debugGroup.Label = "Debugging Commands";
            this.debugGroup.Name = "debugGroup";
            this.debugGroup.Visible = false;
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Label = "Create Load Test Report";
            this.button1.Name = "button1";
            this.button1.OfficeImageId = "CreateReportFromWizard";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button8.Label = "Export to Word";
            this.button8.Name = "button8";
            this.button8.OfficeImageId = "ExportWord";
            this.button8.ShowImage = true;
            // 
            // rawToggle
            // 
            this.rawToggle.Checked = true;
            this.rawToggle.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.rawToggle.Description = "Hide or show all raw data sheets in the work book.";
            this.rawToggle.Label = "Raw Data";
            this.rawToggle.Name = "rawToggle";
            this.rawToggle.OfficeImageId = "TableInsert";
            this.rawToggle.ScreenTip = "Hide or show all raw data sheets in the work book.";
            this.rawToggle.ShowImage = true;
            this.rawToggle.SuperTip = "Hide or show all raw data sheets in the work book.";
            this.rawToggle.Tag = "raw";
            this.rawToggle.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.pivotToggle_Click);
            // 
            // pivotToggle
            // 
            this.pivotToggle.Checked = true;
            this.pivotToggle.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.pivotToggle.Description = "Hide or show all pivot table sheets in the work book.";
            this.pivotToggle.Label = "Pivot Tables";
            this.pivotToggle.Name = "pivotToggle";
            this.pivotToggle.OfficeImageId = "PivotTableSelectFlyout";
            this.pivotToggle.ScreenTip = "Hide or show all pivot table sheets in the work book.";
            this.pivotToggle.ShowImage = true;
            this.pivotToggle.SuperTip = "Hide or show all pivot table sheets in the work book.";
            this.pivotToggle.Tag = "pivot";
            this.pivotToggle.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.pivotToggle_Click);
            // 
            // chartToggle
            // 
            this.chartToggle.Checked = true;
            this.chartToggle.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.chartToggle.Description = "Hide or show all chart sheets in the work book.";
            this.chartToggle.Label = "Charts";
            this.chartToggle.Name = "chartToggle";
            this.chartToggle.OfficeImageId = "ChartChangeType";
            this.chartToggle.ScreenTip = "Hide or show all chart sheets in the work book.";
            this.chartToggle.ShowImage = true;
            this.chartToggle.SuperTip = "Hide or show all chart sheets in the work book.";
            this.chartToggle.Tag = "chart";
            this.chartToggle.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.pivotToggle_Click);
            // 
            // statsToggle
            // 
            this.statsToggle.Checked = true;
            this.statsToggle.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.statsToggle.Description = "Hide or show all statisctics sheets in the work book.";
            this.statsToggle.Label = "Statistics";
            this.statsToggle.Name = "statsToggle";
            this.statsToggle.OfficeImageId = "Formula";
            this.statsToggle.ScreenTip = "Hide or show all statisctics sheets in the work book.";
            this.statsToggle.ShowImage = true;
            this.statsToggle.SuperTip = "Hide or show all statisctics sheets in the work book.";
            this.statsToggle.Tag = "stats";
            this.statsToggle.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.pivotToggle_Click);
            // 
            // button6
            // 
            this.button6.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button6.Label = "Correct Colors";
            this.button6.Name = "button6";
            this.button6.OfficeImageId = "ChartTypeLineInsertGallery";
            this.button6.ShowImage = true;
            this.button6.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button7.Label = "Remove Markers";
            this.button7.Name = "button7";
            this.button7.OfficeImageId = "ChartResetToMatchStyle";
            this.button7.ShowImage = true;
            this.button7.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button9.Label = "Thin Lines";
            this.button9.Name = "button9";
            this.button9.OfficeImageId = "ChartLines";
            this.button9.ShowImage = true;
            this.button9.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button9_Click);
            // 
            // button12
            // 
            this.button12.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button12.Label = "Short Load Tests";
            this.button12.Name = "button12";
            this.button12.OfficeImageId = "Recurrence";
            this.button12.ShowImage = true;
            this.button12.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button10.Label = "Large Load Tests";
            this.button10.Name = "button10";
            this.button10.OfficeImageId = "EquationMatrixGallery";
            this.button10.ShowImage = true;
            // 
            // button11
            // 
            this.button11.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button11.Label = "High Samples Count";
            this.button11.Name = "button11";
            this.button11.OfficeImageId = "EquationDelimiterGallery";
            this.button11.ShowImage = true;
            // 
            // button2
            // 
            this.button2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button2.Label = "Add Sheet";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "TableInsert";
            this.button2.ShowImage = true;
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button3.Label = "Add Data";
            this.button3.Name = "button3";
            this.button3.OfficeImageId = "TableDrawTable";
            this.button3.ShowImage = true;
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button4.Label = "Add Pivot";
            this.button4.Name = "button4";
            this.button4.OfficeImageId = "PivotTableSelectFlyout";
            this.button4.ShowImage = true;
            this.button4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button5.Label = "Hide Sheet";
            this.button5.Name = "button5";
            this.button5.OfficeImageId = "TableDeleteRowsAndColumnsMenuWord";
            this.button5.ShowImage = true;
            this.button5.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button5_Click);
            // 
            // button13
            // 
            this.button13.ImageName = "Conditional Formatting";
            this.button13.Label = "Conditional Formatting";
            this.button13.Name = "button13";
            this.button13.OfficeImageId = "ConditionalFormattingColorScalesGallery";
            this.button13.ShowImage = true;
            this.button13.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.conditionalFormatButton_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();
            this.debugGroup.ResumeLayout(false);
            this.debugGroup.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup debugGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton pivotToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton chartToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton rawToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton statsToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button7;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox comboBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button8;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button9;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button10;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button11;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button12;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button13;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
