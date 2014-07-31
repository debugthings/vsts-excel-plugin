using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ExcelLoadTestReport
{
    public partial class Ribbon1
    {

        RibbonCommands.DebugCommands _debugCommands;
        RibbonCommands.RibbonCommands _ribbonCommands;

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            WindowsFormsSynchronizationContext.AutoInstall = true;
#if DEBUG
            this.debugGroup.Visible = true;
#endif
            
        }


        private void findMyLoadTests(object sender, RibbonControlEventArgs e)
        {

        }
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            selectLoadTest _loadTestWiz = new selectLoadTest();
            _loadTestWiz.ShowDialog();
            _loadTestWiz.Dispose();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelLoadTestReport.PageTemplates.StatisticalTables statsPage = new PageTemplates.StatisticalTables();
            //statsPage.Fill(1152, "LoadTest:Transaction", "Avg. Response Time", false, false, true);
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();
            _debugCommands.AddData();
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();
            _debugCommands.CreatePivotChart();
        }

        private void button5_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();
            
            _debugCommands.HideSheet();
        }

        private void pivotToggle_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.RibbonCommands _ribbonCommands = new RibbonCommands.RibbonCommands();

            var toggleSender = sender as RibbonToggleButton;
            _ribbonCommands.ToggleVisibility(!toggleSender.Checked, toggleSender.Tag);
            
        }

        private void button6_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.RibbonCommands _ribbonCommands = new RibbonCommands.RibbonCommands();
            _ribbonCommands.CorrectColors();
        }

        private void button7_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.RibbonCommands _ribbonCommands = new RibbonCommands.RibbonCommands();
            _ribbonCommands.ClearMarkers();
        }

        private void button9_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.RibbonCommands _ribbonCommands = new RibbonCommands.RibbonCommands();
            _ribbonCommands.ThinLines();
        }

        private void button12_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void conditionalFormatButton_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonCommands.RibbonCommands _ribbonCommands = new RibbonCommands.RibbonCommands();
            var toggleSender = sender as RibbonToggleButton;
            _ribbonCommands.ConditionalFormatting(3, 5);
        }
    }
}
