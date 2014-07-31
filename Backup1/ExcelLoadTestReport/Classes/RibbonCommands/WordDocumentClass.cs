using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security;
using System.Security.Principal;

namespace ExcelLoadTestReport.RibbonCommands
{
    public class WordDocumentClass
    {
        private Microsoft.Office.Interop.Word.Application wordApp;
        private Microsoft.Office.Interop.Word.Document doc;

        public WordDocumentClass()
        {
            wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
        }

        public void CreateWordDoc()
        {
            doc = wordApp.Documents.Add(Template: "K:\\-TEMPLAT\\07ISBigDoc.dotm", NewTemplate: false, DocumentType: Word.WdNewDocumentType.wdNewBlankDocument);
        }

        public void UpdateFirstChapter(string ChapterTitle = null, string ChapterIntroduction = null,
            string FirstFrameTitle = null, string FirstBlockLabel = null, string FirstBlockParagraph = null,
            string PublicationDate = null, string DocumentAuthor = null)
        {
            if (!string.IsNullOrEmpty(ChapterTitle))
            {
                doc.FormFields["Text4"].Range.Text = ChapterTitle;
            }
            if (!string.IsNullOrEmpty(ChapterIntroduction))
            {
                doc.FormFields["Text6"].Range.Text = ChapterIntroduction;
            }
            if (!string.IsNullOrEmpty(FirstFrameTitle))
            {
                doc.FormFields["Text9"].Range.Text = FirstFrameTitle;
            }
            if (!string.IsNullOrEmpty(FirstBlockLabel))
            {
                doc.FormFields["Text8"].Range.Text = FirstBlockLabel;
            }
            if (!string.IsNullOrEmpty(FirstBlockParagraph))
            {
                wordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
                wordApp.Selection.Range.Text = FirstBlockParagraph;
            }
            if (!string.IsNullOrEmpty(PublicationDate))
            {
                doc.FormFields["Text1"].Range.Text = PublicationDate;
            }
            if (!string.IsNullOrEmpty(DocumentAuthor))
            {
                doc.FormFields["Text3"].Range.Text = DocumentAuthor;
            }
            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
        }

        public void AddNewChapter(string ChapterTitle = null, string ChapterIntroduction = null,
            string FirstFrameTitle = null, string FirstBlockLabel = null, string FirstBlockParagraph = null)
        {
            Word.WdOrientation currentPageOrientation = wordApp.Selection.PageSetup.Orientation;
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.InsertBreak(Type: Word.WdBreakType.wdSectionBreakOddPage);

            if (currentPageOrientation == Word.WdOrientation.wdOrientLandscape)
            {
                ChangePageOrientation(false);
            }

            wordApp.DisplayAutoCompleteTips = true;
            wordApp.ActiveDocument.get_AttachedTemplate().AutoTextEntries("New Chapter").Insert(
            Where: wordApp.Selection.Range, RichText: true);



            if (!string.IsNullOrEmpty(ChapterTitle))
            {
                doc.FormFields["Text4"].Range.Text = ChapterTitle;
            }
            if (!string.IsNullOrEmpty(ChapterIntroduction))
            {
                doc.FormFields["Text6"].Range.Text = ChapterIntroduction;
            }
         
            NewFrame(FirstFrameTitle, FirstBlockLabel, FirstBlockParagraph, true);
        }

        public void NewFrame(string FrameTitle = null, string FirstBlockLabel = null, string FirstBlockParagraph = null, bool SameOrientationAsLastPage = false)
        {
            wordApp.Selection.TypeParagraph();
            
            Word.WdOrientation currentPageOrientation = wordApp.Selection.PageSetup.Orientation;
            wordApp.Selection.InsertBreak(Type: Word.WdBreakType.wdSectionBreakNextPage);
            
            if (SameOrientationAsLastPage)
            {
                wordApp.Selection.PageSetup.Orientation = currentPageOrientation;
            }
            else
            {
                if (currentPageOrientation == Word.WdOrientation.wdOrientLandscape)
                {
                    wordApp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                }
                else
                {
                    wordApp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                }
            }


            wordApp.ActiveDocument.get_AttachedTemplate().AutoTextEntries("Frame Title").Insert(
            Where: wordApp.Selection.Range, RichText: true);

            NewBlock(FirstBlockLabel, FirstBlockParagraph);

            if (!string.IsNullOrEmpty(FrameTitle))
            {
                doc.FormFields["Text9"].Range.Text = FrameTitle;
            }

            BreakFirstFooterChain();

            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
            
        }

        public void NewBlock(string BlockLabel = null, string BlockParagraph = null)
        {
            wordApp.WordBasic.WW7_EditAutoText(Name: "block", Insert: 1);
            //wordApp.ActiveDocument.get_AttachedTemplate().AutoTextEntries("block").Insert(
            //Where: wordApp.Selection.Range, RichText: true);

            if (!string.IsNullOrEmpty(BlockLabel))
            {
                doc.FormFields["Text8"].Range.Text = BlockLabel;
            }
            if (!string.IsNullOrEmpty(BlockParagraph))
            {
                wordApp.Selection.MoveDown(Unit: Word.WdUnits.wdLine, Count: 1);
                wordApp.Selection.Range.Text = BlockParagraph;
            }

            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
        }

        public void ChangePageOrientation(bool Landscape = true)
        {
            if (Landscape)
            {
                wordApp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
                wordApp.Selection.HeaderFooter.LinkToPrevious = false;
                wordApp.Selection.EndKey(Unit: Word.WdUnits.wdLine);
                foreach (Word.TabStop item in wordApp.Selection.ParagraphFormat.TabStops)
                {
                    if (item.Position == wordApp.InchesToPoints(6.5f))
                    {
                        item.Position = wordApp.InchesToPoints(9f);
                    }
                }
                wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
            }
            else
            {
                wordApp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
                wordApp.Selection.HeaderFooter.LinkToPrevious = false;
                wordApp.Selection.EndKey(Unit: Word.WdUnits.wdLine);
                foreach (Word.TabStop item in wordApp.Selection.ParagraphFormat.TabStops)
                {
                    if (item.Position == wordApp.InchesToPoints(9f))
                    {
                        item.Position = wordApp.InchesToPoints(6.5f);
                    }
                }
                wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
            }
            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdStory);
        }

        public void ContinueFrame()
        {
            wordApp.Selection.TypeParagraph();
            wordApp.Selection.InsertBreak(Type: Word.WdBreakType.wdPageBreak);
            BreakFooterChain();
        }

        private void BreakFooterChain()
        {
            wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter;
            wordApp.Selection.HeaderFooter.LinkToPrevious = false;
            //wordApp.Selection.PageSetup.DifferentFirstPageHeaderFooter = 0;
            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdLine);
            foreach (Word.TabStop item in wordApp.Selection.ParagraphFormat.TabStops)
            {
                if (wordApp.Selection.PageSetup.Orientation == Word.WdOrientation.wdOrientLandscape)
                {
                    if (item.Position == wordApp.InchesToPoints(6.5f))
                    {
                        item.Position = wordApp.InchesToPoints(9f);
                    }
                }
                else
                {
                    if (item.Position == wordApp.InchesToPoints(9f))
                    {
                        item.Position = wordApp.InchesToPoints(6.5f);
                    }
                }

            }
            wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        }

        private void BreakFirstFooterChain()
        {
            wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekFirstPageFooter;
            wordApp.Selection.HeaderFooter.LinkToPrevious = false;
            //wordApp.Selection.PageSetup.DifferentFirstPageHeaderFooter = 0;
            wordApp.Selection.EndKey(Unit: Word.WdUnits.wdLine);
            foreach (Word.TabStop item in wordApp.Selection.ParagraphFormat.TabStops)
            {
                if (wordApp.Selection.PageSetup.Orientation == Word.WdOrientation.wdOrientLandscape)
                {
                    if (item.Position == wordApp.InchesToPoints(6.5f))
                    {
                        item.Position = wordApp.InchesToPoints(9f);
                    }
                }
                else
                {
                    if (item.Position == wordApp.InchesToPoints(9f))
                    {
                        item.Position = wordApp.InchesToPoints(6.5f);
                    }
                }

            }
            wordApp.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        }

        public void DebugCommand()
        {
            string fullName = string.Empty;
            using (var _user = WindowsIdentity.GetCurrent())
            {
                using (var _nameSearch = new System.DirectoryServices.DirectorySearcher())
                {
                    _nameSearch.Filter = string.Format("SAMAccountName={0}", _user.Name.Split('\\')[1]);
                    _nameSearch.PropertiesToLoad.Add("cn");
                    _nameSearch.PropertiesToLoad.Add("displayName");
                    System.DirectoryServices.SearchResult result = _nameSearch.FindOne();
                    fullName = result.Properties["displayName"][0].ToString();
                }
            }

            CreateWordDoc();
            UpdateFirstChapter(
                "Load Test Summary",
                "This chapter explains the load test scenarios, the over all methodology of the test and the order the scenarios should execute.",
                "LoadTest Scenarios",
                "Scenarios",
                "This table shows the load test scenarios, tests and transactions, as well as a description of each.",
                DateTime.Now.ToShortDateString(),
                fullName);

            AddNewChapter("Hardware Statistics",
                "This chapter shows the CPU, Memory, Physical Disk and Logical Disk usage of the system under test during the load test.",
                "Summary", "Analysis");
            NewFrame("CPU Charts", "CPU Usage Chart", null, false);
            NewBlock("CPU Chart Legend");

            NewFrame("Memory Charts", "Available Megabytes Chart", null, true);
            NewBlock("Available Megabytes Chart Legend");

            NewFrame("Disk Charts", "Physical Disk Chart", null, true);
            NewBlock("Physical Disk Legend");
            ContinueFrame();
            NewBlock("Logical Disk Chart");
            ContinueFrame();
            NewBlock("Logical Disk Legend");

            AddNewChapter("Process Statistics",
                "This chapter shows the CPU, Memory, Physical Disk and Logical Disk usage of the application processes during the load test.",
                "Process CPU Charts", "Process CPU Usage Chart");
            ChangePageOrientation();
            NewBlock("CPU Chart Legend");
            NewFrame("Memory Charts", "Process Private Bytes Chart", null, true);
            NewBlock("Process Private Bytes Chart Legend");
            ContinueFrame();
            NewBlock("Process Virtual Bytes Chart");
            ContinueFrame();
            NewBlock("Process Virtual Bytes Chart Legend");


            AddNewChapter("Response Time Statistics",
               "This chapter shows the transaction response times of the system under test during the load test.",
               "Response Time Charts", "Transaction Response Time Chart");
            ChangePageOrientation();
            NewBlock("Transaction Response Time Legend");
            ContinueFrame();
            NewBlock("Transaction Per Second Chart");
            ContinueFrame();
            NewBlock("Transaction Per Second Legend");
            ContinueFrame();
            NewBlock("Page Response Time Chart");
            ContinueFrame();
            NewBlock("Page Response Time Legend");
            ContinueFrame();
            NewBlock("Page Per Second Chart");
            ContinueFrame();
            NewBlock("Page Per Second Legend");
            ContinueFrame();
            NewBlock("Request Response Time Chart");
            ContinueFrame();
            NewBlock("Request Response Time Legend");
            ContinueFrame();
            NewBlock("Request Per Second Chart");
            ContinueFrame();
            NewBlock("Request Per Second Legend");
        }
    }
}
