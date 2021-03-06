﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using UrduLibs;
using Telerik.WinForms.Documents.Proofing;

namespace UrduProofReader.extra
{
    public partial class PDFViewer : Form
    {
        int currentScrollVal = 2;
        FileInfo _fileInfo;
        public PDFViewer()
        {
            InitializeComponent();
        }

        private void uiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PDFViewer_Load(object sender, EventArgs e)
        {           
            button1.Left = button1.Parent.Width - (button1.Width + 10);
            //button1.Left = button1.Parent.Width - (button1.Width + 120);

            uiOpenFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
            splitContainer1.SplitterDistance = splitContainer1.Height - 55;
            splitContainer1.FixedPanel = FixedPanel.Panel2;

            loadFile(true);

            RadDictionary dic = new RadDictionary();
            dic.Load(new MemoryStream(Encoding.UTF8.GetBytes(UrduLibs.UrduDictionary.Instance.FullText.ToString())));
            var d = new Telerik.WinForms.Documents.Proofing.DocumentSpellChecker();
            d.AddDictionary(dic, System.Globalization.CultureInfo.CurrentCulture);
            radRichTextEditor1.SpellChecker = d;

            radRichTextEditor1.SpellChecker.DataChanged += SpellChecker_DataChanged;
        }

        private void SpellChecker_DataChanged(object sender, EventArgs e)
        {
            // New Word Added in Dic
            DocumentSpellChecker dsc = (DocumentSpellChecker)sender;
            ICustomWordDictionary spellchecker = dsc.GetCustomDictionary();
            UrduLibs.UrduDictionary.Instance.save(spellchecker.Words.Last());
        }

        private void loadFile(bool close)
        {
            try
            {
                if (uiOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileInfo = new FileInfo(uiOpenFileDialog.FileName);
                }

                if (_fileInfo != null)
                {
                    uiPDF.src = _fileInfo.FullName;
                }

                uiSaveDialog.Filter = "Text File (*.txt)|*.txt";
                uiSaveDialog.FileName = Path.GetFileNameWithoutExtension(_fileInfo.Name);
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.error(ex);
                MessageBox.Show("معذرت، کچھ مسئلہ پیدا ہوگیا ہے، دوبارہ کوشش کیجیے", "معذرت", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(close)
                this.Close();
            }
        }

        private void PDFViewer_SizeChanged(object sender, EventArgs e)
        {
            button1.Left = button1.Parent.Width - (button1.Width + 10);
            //button1.Left = button1.Parent.Width - (button1.Width + 120);

            if (splitContainer1.Height > 55)
            {
                splitContainer1.SplitterDistance = splitContainer1.Height - 55;
                splitContainer1.FixedPanel = FixedPanel.Panel2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadFile(false);
            //radRichTextEditor1.SpellChecker.AddWord()
        }

        private void radRichTextEditor1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Up)
            {
                if (currentScrollVal > 0)
                {
                    currentScrollVal = currentScrollVal - 2;
                    uiPDF.setViewScroll("FitH", (currentScrollVal));
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Down)
            {
                currentScrollVal = currentScrollVal + 2;
                uiPDF.setViewScroll("FitH", (currentScrollVal));
            }
        }
    }
}
