using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace ExcelLoadTestReport
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        bool ddLower = false;
        bool ddMiddle = false;
        bool ddUpper = false;

        bool rawCheckedStart = false;
        bool pivotCheckedStart = false;
        bool chartCheckedStart = false;
        bool statCheckedStart = false;

        public Ribbon()
        {
        }




        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExcelLoadTestReport.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks

        public void exportToWord(Office.IRibbonControl control)
        {
            var wrd = new RibbonCommands.WordDocumentClass();
            wrd.DebugCommand();
        }

        public void findMyLoadTests(Office.IRibbonControl control)
        {
            loadTestView _ltV = new loadTestView();
            var chkBx = _ltV.Controls.Find("chkFilterByMe", true)[0] as System.Windows.Forms.CheckBox;
            _ltV.FillFromExternal = new loadTestView.UpdateLoadTests(RibbonCommands.RibbonCommands.GetAllLoadTests);
            chkBx.Checked = true;
            _ltV.ShowDialog();
        }

        public void findLargeLoadTests(Office.IRibbonControl control)
        {
            loadTestView _ltV = new loadTestView(true);
            _ltV.FillFromExternal = new loadTestView.UpdateLoadTests(RibbonCommands.RibbonCommands.GetLargeLoadTests);
            _ltV.ShowDialog();
        }

        public void findShortLoadTests(Office.IRibbonControl control)
        {
            loadTestView _ltV = new loadTestView();
            _ltV.FillFromExternal = new loadTestView.UpdateLoadTests(RibbonCommands.RibbonCommands.GetSmallDurationLoadTests);
            _ltV.ShowDialog();
        }

        public void findHighSampleLoadTests(Office.IRibbonControl control)
        {
            loadTestView _ltV = new loadTestView(true);
            _ltV.FillFromExternal = new loadTestView.UpdateLoadTests(RibbonCommands.RibbonCommands.GetHighSampleCountLoadTests);
            _ltV.ShowDialog();
        }

        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;

        }

        public void button1_Click(Office.IRibbonControl control)
        {
            selectLoadTest _loadTestWiz = new selectLoadTest();
            _loadTestWiz.ShowDialog();
            _loadTestWiz.Dispose();
        }

        public string getItemLabel(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "cmbLower":
                    if (!ddLower)
                    {
                        ddLower = true;
                        return "1";
                    }
                    break;
                case "cmbMiddle":
                    if (!ddMiddle)
                    {
                        ddMiddle = true;
                        return "3";
                    }
                    break;
                case "cmbUpper":
                    if (!ddUpper)
                    {
                        ddUpper = true;
                        return "5";
                    }
                    break;
                default:
                    break;
            }
            return "1";
        }

        //gtVisible
        public bool gtVisible(Office.IRibbonControl control)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public void button2_Click(Office.IRibbonControl control)
        {
            ExcelLoadTestReport.PageTemplates.StatisticalTables statsPage = new PageTemplates.StatisticalTables("");
            //statsPage.Fill(1152, "LoadTest:Transaction", "Avg. Response Time", false, false, true);
        }

        public void button3_Click(Office.IRibbonControl control)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();
            _debugCommands.AddData();
        }

        public void button4_Click(Office.IRibbonControl control)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();
            _debugCommands.CreatePivotChart();
        }

        public void button5_Click(Office.IRibbonControl control)
        {
            RibbonCommands.DebugCommands _debugCommands = new RibbonCommands.DebugCommands();

            _debugCommands.HideSheet();
        }

        public void pivotToggle_Click(Office.IRibbonControl control, bool pressed)
        {
            
            RibbonCommands.RibbonCommands.ToggleVisibility(!pressed, control.Tag);
        }

        public bool get_Pressed(Office.IRibbonControl control)
        {
            if (!rawCheckedStart || !statCheckedStart || !pivotCheckedStart || !chartCheckedStart)
            {
                return true;
            }
            return false;
        }

        public void button6_Click(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.CorrectColors();
        }

        public void button7_Click(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.ClearMarkers();
        }

        public void button9_Click(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.ThinLines();
        }

        public void button12_Click(Office.IRibbonControl control)
        {

        }

        public void conditionalFormatButton_Click(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.ConditionalFormatting(3, 5);
        }

        public void conditionalFormatButtonMultiple_Click(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.ConditionalFormattingMultiple(0.10f);
        }

        public void btnActiveCells(Office.IRibbonControl control)
        {
            RibbonCommands.RibbonCommands.DeleteTestsListedAsTransactions();
        }

        public void btnEditCounters_Click(Office.IRibbonControl control)
        {
            // TODO implement chart performance counter editor
            var s = "s";
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
