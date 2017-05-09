using System;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using UrduLibs;
using System.Windows.Forms;
using UrduProofReader.token;
using Microsoft.Office.Interop.Word;
using System.Data;
using System.IO;
using System.Drawing.Text;
using System.Drawing;

namespace UrduProofReaderWE
{
    public partial class ProofReader
    {
        WdColor _selectedColor = WdColor.wdColorBlack;

        private void ProofReader_Load(object sender, RibbonUIEventArgs e)
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();

            foreach (FontFamily font in installedFontCollection.Families)
            {
                RibbonDropDownItem item= Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                item.Label = font.Name;
                uiFonts.Items.Add(item);
            }

            System.Collections.Generic.List<int> sizeList = new System.Collections.Generic.List <int>{ 8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72};

            foreach (int i in sizeList)
            {
                RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                item.Label = i.ToString();
                uiSizes.Items.Add(item);
            }

        }

        private void uiCorrectIt_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                object missing = Type.Missing;
                object trueObj = true;

                if (uiCustomTokens.Checked)
                {
                    uiTokenFileDialogue.Filter = "Token File (*.txt)|*.txt;*";
                    if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
                    {
                        TokenDataSet.Instance.initlize(uiTokenFileDialogue.FileName);
                    }
                }


                UrduLibs.ProofReader _reader = new UrduLibs.ProofReader(uiRegex.Checked, uiTokenSort.Checked, uiFullWord.Checked);

                _reader.TextToProcess = new StringBuilder(Globals.ThisAddIn.Application.ActiveDocument.Content.Text);
                _reader.RemoveAirab = uiAirab.Checked;
                if (Globals.ThisAddIn.Application.Selection.Text != null)
                {
                    _reader.SelectedText = new StringBuilder(Globals.ThisAddIn.Application.Selection.Text);
                }
                _reader.processText();

                //Globals.ThisAddIn.Application.ActiveDocument.Content.Text = Globals.ThisAddIn.Application.ActiveDocument.Content.Text.Replace("چل", "چل اوئے");

                //Range rng = Globals.ThisAddIn.Application.ActiveDocument.Content;
                //System.Data.DataTable dt = TokenDataSet.Instance.sorted(uiTokenSort.Checked);


                if (!_reader.IsError)
                    Globals.ThisAddIn.Application.ActiveDocument.Content.Text = _reader.UpdatedText.ToString();
                else
                    MessageBox.Show("معذرت، کچھ مسئلہ پیدا ہوگیا ہے، دوبارہ کوشش کیجیے", "معذرت", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (uiShowChanges.Checked)
                {
                    Globals.ThisAddIn.Application.Selection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToFirst, Type.Missing, Type.Missing);
                    // Highlight changed text making the program slow
                    foreach (DataRow line in TokenDataSet.Instance.sorted(uiTokenSort.Checked).Rows)
                    {
                        if (!bool.Parse(line[2] + ""))
                        {
                            try
                            {
                                HighlightText(Globals.ThisAddIn.Application, line[1] + "");
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.error(ex);
                MessageBox.Show("معذرت، کچھ مسئلہ پیدا ہوگیا ہے، دوبارہ کوشش کیجیے", "معذرت", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uiImportTokens_Click(object sender, RibbonControlEventArgs e)
        {
            TokenImporter importer;
            uiTokenFileDialogue.Filter = "Token File (*.txt)|*.txt;*";
            if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
            {
                importer = new TokenImporter(uiTokenFileDialogue.FileName);
                int i = importer.import();

                MessageBox.Show("[" + i + "] نئے الفاظ درآمد ہو گئے ہیں۔", "درآمد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uiManageTokens_Click(object sender, RibbonControlEventArgs e)
        {
            ManageTokens tokens = new ManageTokens();
            tokens.ShowDialog();
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            uiTokenFileDialogue.Filter = "Token File (*.txt)|*.txt;*";
            if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
            {
                string[] tokens = File.ReadAllLines(uiTokenFileDialogue.FileName);

                foreach (string token in tokens)
                {
                    Globals.ThisAddIn.Application.Selection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToFirst, Type.Missing, Type.Missing);
                    ChangeTextFormatting(Globals.ThisAddIn.Application, token);
                }
            }
        }

        private void HighlightText(Microsoft.Office.Interop.Word.Application WordApp, object findText)
        {
            object missing = Type.Missing;

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = WdReplace.wdReplaceNone;
            object wrap = 0;
            WordApp.Selection.Find.ClearFormatting();
            while (WordApp.Selection.Find.Execute(ref findText,
                                           ref matchCase,
                                           ref matchWholeWord,
                                           ref matchWildCards,
                                           ref matchSoundLike,
                                           ref nmatchAllWordForms,
                                           ref forward,
                                           ref wrap,
                                           ref format,
                                           /*ref replaceWithText,*/ ref missing,
                                           /*ref replace,*/         ref missing,
                                           ref matchKashida,
                                           ref matchDiacritics,
                                           ref matchAlefHamza,
                                           ref matchControl))
            {
                if(_selectedColor != null && _selectedColor== WdColor.wdColorBlack)
                    WordApp.Application.Selection.Font.Color = WdColor.wdColorDarkRed;
                else
                WordApp.Application.Selection.Font.Color = _selectedColor;
                WordApp.Application.Selection.Font.Bold = 1;
            }

        }

        private void ChangeTextFormatting(Microsoft.Office.Interop.Word.Application WordApp, object findText)
        {
            object missing = Type.Missing;

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = true;
            object matchSoundLike = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = WdReplace.wdReplaceNone;
            object wrap = 0;
            WordApp.Selection.Find.ClearFormatting();
            while (WordApp.Selection.Find.Execute(ref findText,
                                           ref matchCase,
                                           ref matchWholeWord,
                                           ref matchWildCards,
                                           ref matchSoundLike,
                                           ref nmatchAllWordForms,
                                           ref forward,
                                           ref wrap,
                                           ref format,
                                           /*ref replaceWithText,*/ ref missing,
                                           /*ref replace,*/         ref missing,
                                           ref matchKashida,
                                           ref matchDiacritics,
                                           ref matchAlefHamza,
                                           ref matchControl))
            {
                WordApp.Application.Selection.Font.Name = uiFonts.SelectedItem.Label;
                WordApp.Application.Selection.Font.SizeBi = float.Parse(uiSizes.SelectedItem.Label);
                WordApp.Application.Selection.Font.Color = _selectedColor;

                if (uiBold.Checked)
                    WordApp.Application.Selection.Font.Bold = 1;
                else
                    WordApp.Application.Selection.Font.Bold = 0;

                if (uiUnderline.Checked)
                    WordApp.Application.Selection.Font.Underline = WdUnderline.wdUnderlineSingle;
                else
                    WordApp.Application.Selection.Font.Underline = WdUnderline.wdUnderlineNone;


                if (uiItalic.Checked)
                    WordApp.Application.Selection.Font.Italic = 1;
                else
                    WordApp.Application.Selection.Font.Italic = 0;
            }

        }

        private void uiSelectColor_Click(object sender, RibbonControlEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _selectedColor = (Microsoft.Office.Interop.Word.WdColor)(colorDialog1.Color.R + 0x100 * colorDialog1.Color.G + 0x10000 * colorDialog1.Color.B);
            }
        }
    }
}
