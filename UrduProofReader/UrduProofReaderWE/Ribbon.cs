using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System.Drawing.Text;
using System.Drawing;
using System.Data;
using UrduProofReader.token;
using UrduProofReader.extra;
using UrduLibs;

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


namespace UrduProofReaderWE
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        bool isRegex=true;
        bool isSorted = false;
        bool isFullWord = false;
        bool isRemovedAirab = false;
        bool isSetHighlight = false;
        bool isCustomWords = false;

        bool isBold = false;
        bool isUnderline = false;
        bool isItalic = false;
        float fontSize = 12;
        string fontName = "Arial";

        OpenFileDialog uiTokenFileDialogue = new OpenFileDialog();
        ColorDialog colorDialog1 = new ColorDialog();

        WdColor _selectedColor = WdColor.wdColorBlack;

        static StringBuilder fullXML = new StringBuilder(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<customUI onLoad=""Ribbon_Load"" xmlns=""http://schemas.microsoft.com/office/2009/07/customui"">
    <ribbon>
        <tabs>
            <tab idMso=""TabAddIns"" label=""اردو پروف ریڈر"">
                <group id=""group1"" label=""تصحیح"">
                    <checkBox id=""uiRegex"" label=""ریگولر ایکسپریشن"" onAction=""SetRegex"" getPressed=""DefaultChecked"" />
                    <checkBox id=""uiTokenSort"" onAction=""SetSort"" label=""الفاظ کی ترتیب"" />
                    <button id=""uiCorrectIt"" onAction=""uiCorrectIt_Click"" label=""تصحیح کیجیے"" showImage=""false"" />
                    <checkBox id=""uiFullWord"" onAction=""SetFullWord"" label=""پورا لفظ تلاش کیجیے"" />
                    <checkBox id=""uiAirab"" onAction=""SetAirab"" label=""اعراب ختم کیجیے"" />
                    <checkBox id=""uiShowChanges"" onAction=""SetHighlight"" label=""تبدیلی کو نمایاں کیجیے"" />
                </group>
                <group id=""group2"" label=""ذخیرہ الفاظ"">
                    <button id=""uiManageTokens"" onAction=""uiManageTokens_Click"" label=""ذخیرہ"" showImage=""false"" />
                    <button id=""uiImportTokens"" onAction=""uiImportTokens_Click"" label=""ذخیرہ درآمد کیجیے"" showImage=""false"" />
                    <checkBox id=""uiCustomTokens"" onAction=""SetCustomWords"" label=""منتخب ذخیرہ الفاظ"" />
                </group>
                <group id=""group3"" label=""فارمیٹنگ"">
                    <checkBox id=""uiBold"" onAction=""SetBold"" label=""موٹا"" />
                    <checkBox id=""uiUnderline"" onAction=""setUnderline"" label=""انڈر لائن"" />
                    <checkBox id=""uiItalic"" onAction=""setItalic"" label=""ٹیڑھا"" />
                    [FONTDROPDOWN]
                    [SIZEDROPDOWN]
                    <button id=""uiSelectColor"" onAction=""uiSelectColor_Click"" label=""رنگ منتخب کیجیے"" showImage=""false"" />
                    <button id=""button1"" onAction=""button1_Click"" label=""تبدیل کیجیے"" showImage=""false"" />
                </group>
            </tab>
        </tabs>
    </ribbon>
  <contextMenus>
    <contextMenu idMso=""ContextMenuSpell"">
      <button id=""AddWordBtn"" onAction=""AddWord_Click"" label=""لفظ شامل کیجیے"" showImage=""false"" />
    </contextMenu>
    <contextMenu idMso=""ContextMenuText"">
      <button id=""AddWordBtn1"" onAction=""AddWord_Click"" label=""لفظ شامل کیجیے"" showImage=""false"" />
    </contextMenu>
  </contextMenus>
</customUI>");

        public void AddWord_Click(IRibbonControl control)
        {
            if (!string.IsNullOrEmpty(Globals.ThisAddIn.Application.Selection.Text))
            {
                NewToken newToken = new NewToken();
                newToken.newText = Globals.ThisAddIn.Application.Selection.Text;
                newToken.ShowDialog();
            }
        }

        public void uiImportTokens_Click(IRibbonControl control)
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

        private void button1_Click(IRibbonControl control)
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
                WordApp.Application.Selection.Font.Name = fontName;
                WordApp.Application.Selection.Font.SizeBi = fontSize;
                WordApp.Application.Selection.Font.Color = _selectedColor;

                if (isBold)
                    WordApp.Application.Selection.Font.Bold = 1;
                else
                    WordApp.Application.Selection.Font.Bold = 0;

                if (isUnderline)
                    WordApp.Application.Selection.Font.Underline = WdUnderline.wdUnderlineSingle;
                else
                    WordApp.Application.Selection.Font.Underline = WdUnderline.wdUnderlineNone;


                if (isItalic)
                    WordApp.Application.Selection.Font.Italic = 1;
                else
                    WordApp.Application.Selection.Font.Italic = 0;
            }

        }
        public void uiManageTokens_Click(IRibbonControl control)
        {
            ManageTokens tokens = new ManageTokens();
            tokens.ShowDialog();
        }

        public void uiSelectColor_Click(IRibbonControl control)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _selectedColor = (Microsoft.Office.Interop.Word.WdColor)(colorDialog1.Color.R + 0x100 * colorDialog1.Color.G + 0x10000 * colorDialog1.Color.B);
            }
        }

        public void uiCorrectIt_Click(IRibbonControl control)
        {
            try
            {
                object missing = Type.Missing;
                object trueObj = true;

                if (isCustomWords)
                {
                    uiTokenFileDialogue.Filter = "Token File (*.txt)|*.txt;*";
                    if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
                    {
                        TokenDataSet.Instance.initlize(uiTokenFileDialogue.FileName);
                    }
                }


                UrduLibs.ProofReader _reader = new UrduLibs.ProofReader(isRegex, isSorted, isFullWord);

                _reader.TextToProcess = new StringBuilder(Globals.ThisAddIn.Application.ActiveDocument.Content.Text);
                _reader.RemoveAirab = isRemovedAirab;
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

                if (isSetHighlight)
                {
                    Globals.ThisAddIn.Application.Selection.GoTo(WdGoToItem.wdGoToLine, WdGoToDirection.wdGoToFirst, Type.Missing, Type.Missing);
                    // Highlight changed text making the program slow
                    foreach (DataRow line in TokenDataSet.Instance.sorted(isSorted).Rows)
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
                if (_selectedColor != null && _selectedColor == WdColor.wdColorBlack)
                    WordApp.Application.Selection.Font.Color = WdColor.wdColorDarkRed;
                else
                    WordApp.Application.Selection.Font.Color = _selectedColor;
                WordApp.Application.Selection.Font.Bold = 1;
            }

        }

        public static void populateDropDown()
        {
            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            StringBuilder fontsDD = new StringBuilder();
            StringBuilder sizeDD = new StringBuilder();
            fontsDD.Append(@"<dropDown id=""uiFonts"" label=""فونٹ"" onAction=""GetFontName"" showImage=""false"">");
            sizeDD.Append(@"<dropDown id=""uiSizes"" label=""سائز"" showImage=""false"">");
            int j = 0;
            foreach (FontFamily font in installedFontCollection.Families)
            {
                fontsDD.Append("<item label=\"" + font.Name + "\" id=\"__prdfont" + j++ + "\" />\r\n");
            }

            fontsDD.Append(@"</dropDown>");

            fullXML = fullXML.Replace("[FONTDROPDOWN]", fontsDD.ToString());

            System.Collections.Generic.List<int> sizeList = new System.Collections.Generic.List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            foreach (int i in sizeList)
            {
                sizeDD.Append("<item label=\"" + i + "\" id=\"__prdsize" + j++ + "\" />\r\n");
            }

            sizeDD.Append(@"</dropDown>");

            fullXML = fullXML.Replace("[SIZEDROPDOWN]", sizeDD.ToString());
        }

        public Ribbon()
        {
        }

        public void SetRegex(IRibbonControl control, bool val)
        {
            isRegex = val;
        }
        public void GetFontName(IRibbonControl control, string val)
        {
            MessageBox.Show(val);
        }

        public void SetSort(IRibbonControl control, bool val)
        {
            isSorted = val;
        }

        public void SetFullWord(IRibbonControl control, bool val)
        {
            isFullWord = val;
        }
        
        public void SetAirab(IRibbonControl control, bool val)
        {
            isRemovedAirab = val;
        }

        public void SetHighlight(IRibbonControl control, bool val)
        {
            isSetHighlight = val;
        }

        public void SetCustomWords(IRibbonControl control, bool val)
        {
            isCustomWords = val;
        }

        public void SetBold(IRibbonControl control, bool val)
        {
            isBold = val;
        }

        public void setUnderline(IRibbonControl control, bool val)
        {
            isUnderline = val;
        }

        public void setItalic(IRibbonControl control, bool val)
        {
            isItalic = val;
        }

        public bool DefaultChecked(IRibbonControl control)
        {

            return true;
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("UrduProofReaderWE.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            //Assembly asm = Assembly.GetExecutingAssembly();
            //string[] resourceNames = asm.GetManifestResourceNames();
            //for (int i = 0; i < resourceNames.Length; ++i)
            //{
            //    if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
            //    {
            //        using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
            //        {
            //            if (resourceReader != null)
            //            {
            //                return resourceReader.ReadToEnd();
            //            }
            //        }
            //    }
            //}
            //return null;
            populateDropDown();
            return fullXML.ToString();
        }

        #endregion
    }
}
