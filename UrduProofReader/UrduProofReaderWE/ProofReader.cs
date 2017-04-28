using System;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using UrduLibs;
using System.Windows.Forms;
using UrduProofReader.token;
using Microsoft.Office.Interop.Word;
using System.Data;

namespace UrduProofReaderWE
{
    public partial class ProofReader
    {
        private void ProofReader_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void uiCorrectIt_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                object missing = Type.Missing;
                object trueObj = true;


                UrduLibs.ProofReader _reader = new UrduLibs.ProofReader(uiRegex.Checked, uiTokenSort.Checked, uiFullWord.Checked);

                _reader.TextToProcess = new StringBuilder(Globals.ThisAddIn.Application.ActiveDocument.Content.Text);
                _reader.processText();

                //Globals.ThisAddIn.Application.ActiveDocument.Content.Text = Globals.ThisAddIn.Application.ActiveDocument.Content.Text.Replace("چل", "چل اوئے");

                //Range rng = Globals.ThisAddIn.Application.ActiveDocument.Content;
                //System.Data.DataTable dt = TokenDataSet.Instance.sorted(uiTokenSort.Checked);


                if (!_reader.IsError)
                    Globals.ThisAddIn.Application.ActiveDocument.Content.Text = _reader.UpdatedText.ToString();
                else
                    MessageBox.Show("معذرت، کچھ مسئلہ پیدا ہوگیا ہے، دوبارہ کوشش کیجیے", "معذرت", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
