using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;


namespace ExcelLoadTestReport
{
    public partial class ThisAddIn 
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var configSection = (ReportDefaults)System.Configuration.ConfigurationManager.GetSection("reportSection");
             
        }


        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion


       
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct INTERFACEINFO
    {
        [MarshalAs(UnmanagedType.IUnknown)]
        public object punk;
        public Guid iid;
        public ushort wMethod;
    }

    [ComImport, ComConversionLoss, InterfaceType((short)1),
    Guid("00000016-0000-0000-C000-000000000046")]
    public interface IMessageFilter
    {
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime)]
        int HandleInComingCall([In] uint dwCallType, [In] IntPtr htaskCaller,
            [In] uint dwTickCount,
            [In, MarshalAs(UnmanagedType.LPArray)] INTERFACEINFO[]
            lpInterfaceInfo);

        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime)]
        int RetryRejectedCall([In] IntPtr htaskCallee, [In] uint dwTickCount,
            [In] uint dwRejectType);

        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime)]
        int MessagePending([In] IntPtr htaskCallee, [In] uint dwTickCount,
            [In] uint dwPendingType);
    }

}
