﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using UrduLibs;
using System.Windows.Forms;
using UrduProofReader.token;

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
                UrduLibs.ProofReader _reader = new UrduLibs.ProofReader(uiRegex.Checked, uiTokenSort.Checked, uiFullWord.Checked);

                _reader.TextToProcess = new StringBuilder(Globals.ThisAddIn.Application.ActiveDocument.Content.Text);
                _reader.processText();

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
