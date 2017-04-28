using System.Windows.Forms;
using System.Drawing;
using System;
using Telerik.WinForms.Documents.UI.Extensibility;
using System.ComponentModel.Composition.Hosting;
using Telerik.WinForms.Documents.FormatProviders.Xaml;
using Telerik.WinForms.Documents.FormatProviders.Rtf;
using Telerik.WinForms.Documents.FormatProviders.Html;
using Telerik.WinForms.Documents.FormatProviders.Pdf;
using Telerik.WinForms.Documents.FormatProviders.Txt;
using Telerik.WinForms.Documents.FormatProviders.OpenXml.Docx;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinForms.Documents.Proofing;
using Telerik.WinForms.RichTextEditor.RichTextBoxUI.Dialogs;

namespace UrduProofReader.classes
{
    class GUIUtils
    {
        public static void loadRadMEF()
        {
            RadCompositionInitializer.Catalog = new TypeCatalog(
                // format providers
                typeof(XamlFormatProvider),
                typeof(RtfFormatProvider),
                typeof(DocxFormatProvider),
                typeof(PdfFormatProvider),
                typeof(HtmlFormatProvider),
                typeof(TxtFormatProvider),

                // mini toolbars
                typeof(SelectionMiniToolBar),
                //typeof(ImageMiniToolBar),

                // context menu
                typeof(Telerik.WinControls.RichTextEditor.UI.ContextMenu),

                // the default English spellchecking dictionary
                typeof(RadEn_USDictionary),

                // dialogs
                typeof(AddNewBibliographicSourceDialog),
                typeof(ChangeEditingPermissionsDialog),
                typeof(EditCustomDictionaryDialog),
                typeof(FindReplaceDialog),
                typeof(FloatingBlockPropertiesDialog),
                typeof(FontPropertiesDialog),
                //typeof(ImageEditorDialog),
                typeof(InsertCaptionDialog),
                typeof(InsertCrossReferenceWindow),
                typeof(InsertDateTimeDialog),
                typeof(InsertTableDialog),
                typeof(InsertTableOfContentsDialog),
                typeof(ManageBibliographicSourcesDialog),
                typeof(ManageBookmarksDialog),
                typeof(ManageStylesDialog),
                typeof(NotesDialog),
                typeof(ProtectDocumentDialog),
                //typeof(RadInsertHyperlinkDialog),
                //typeof(RadInsertSymbolDialog),
                //typeof(RadParagraphPropertiesDialog),
                typeof(SetNumberingValueDialog),
                typeof(SpellCheckingDialog),
                typeof(StyleFormattingPropertiesDialog),
                typeof(TableBordersDialog),
                typeof(TablePropertiesDialog),
                typeof(TabStopsPropertiesDialog),
                typeof(UnprotectDocumentDialog),
                typeof(WatermarkSettingsDialog)
                );
        }

        public static void HighlightText(ref RichTextBox myRtb, string word, System.Drawing.Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = System.Drawing.Color.Black;
        }

        private static bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }

        //Or any control
        public static void ToggleStatus(Control c, bool s)
        {
            if (ControlInvokeRequired(c, () => ToggleStatus(c, s))) return;
            c.Enabled = s;
        }

        //Or any control
        public static void UpdateText(Control c, string s)
        {
            if (ControlInvokeRequired(c, () => UpdateText(c, s))) return;
            c.Text = s;
        }

        public static void UpdateProgress(ProgressBar c, int s)
        {
            if (ControlInvokeRequired(c, () => UpdateProgress(c, s))) return;

            c.Increment(s);
        }

        public static void FinishProgress(ProgressBar c)
        {
            if (ControlInvokeRequired(c, () => FinishProgress(c))) return;

            c.Style = ProgressBarStyle.Continuous;
            c.MarqueeAnimationSpeed = 0;
        }
    }
}
