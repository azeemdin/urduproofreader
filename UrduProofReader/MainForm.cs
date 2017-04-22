using System;
using System.Text;
using System.Windows.Forms;
using UrduProofReader.token;
using UrduProofReader.classes;
using System.Diagnostics;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace UrduProofReader
{
    public partial class MainForm : Form
    {
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form {msg=0xa3 
        ProofReader _reader;
        Stopwatch _watch;
        private delegate void EnableDisableButtonDelegate();
        private delegate void SetToolStripDelegate(string text);

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_NCLBUTTONDBLCLK)
            //{
            //    m.Result = IntPtr.Zero;
            //    return;
            //}
            base.WndProc(ref m);
        }

        private void uiExitToolButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uiExitMenuButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _reader = new ProofReader(uiRegex.Checked);
        }

        private void uiTokenForm_Click(object sender, EventArgs e)
        {
            ManageTokens tokens = new ManageTokens();
            tokens.ShowDialog();
        }

        private void uiToolbarCorrectbtn_Click(object sender, EventArgs e)
        {
            try
            {
                updateIt();

                foreach (List<string> line in _reader.AllTokens)
                {
                    if (line.Count != 3)
                    {
                        if(uiTextToProcess.Text.Contains(line[0]))
                        GUIUtils.HighlightText(ref uiUpdatedText, line[1], System.Drawing.Color.Red);
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

        private void updateIt()
        {
            uiToolbarCorrectbtn.Enabled = false;
            _watch = Stopwatch.StartNew();
            uiStatusLabel.Text = "برائے مہربانی انتظار کیجیے";

            _reader.IsRegex = uiRegex.Checked;
            _reader.TextToProcess = new StringBuilder(uiTextToProcess.Text);

            _reader.processText();

            if (!_reader.IsError)
            {
                uiUpdatedText.Text = _reader.UpdatedText.ToString();
            }
            else
            {
                uiUpdatedText.Text = "";
                uiStatusLabel.Text = "Error! [" + _reader.ErrorText + "]";
            }

            _watch.Stop();
            uiStatusLabel.Text = "وقت: " + _watch.ElapsedMilliseconds + " ملی سیکنڈز";
            uiToolbarCorrectbtn.Enabled = true;
        }

        private void uiLoadFile_Click(object sender, EventArgs e)
        {
            try { 
            loadFile();
            }
            catch (Exception ex)
            {
                Logger logger = new Logger();
                logger.error(ex);
                MessageBox.Show("معذرت، کچھ مسئلہ پیدا ہوگیا ہے، دوبارہ کوشش کیجیے", "معذرت", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadFile()
        {
            uiTokenFileDialogue.Filter = "Urdu File (*.txt,*.doc,*.docx)|*.txt;*.doc;*.docx";
            if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
            {
                Utils._textFilePath = new FileInfo(uiTokenFileDialogue.FileName);
                if (Utils._textFilePath != null)
                {
                    if (Utils._textFilePath.Extension.Equals(".txt"))
                    {
                        uiTextToProcess.Text = File.ReadAllText(Utils._textFilePath.FullName);
                    }
                    else
                    {
                        Word.Application app = new Word.Application();
                        Word.Document doc = null;
                        object missing = Type.Missing;
                        object readOnly = true;
                        object path = Utils._textFilePath.FullName;
                        try
                        {
                            doc = app.Documents.Open(ref path, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                            uiTextToProcess.Text = doc.Content.Text;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ورڈ کی فائل شامل کرنے میں مسئلہ ہے دوبارہ کوشش کیجیے", "ورڈ فائل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            if(doc != null)
                            doc.Close();

                            if(app != null)
                            app.Quit();
                        }
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            processDir();
        }

        private void processDir()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Utils._selectedDir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
            }

            if (Utils._selectedDir == null)
                return;

            FileProcessor fileProcessor = new FileProcessor(Utils._selectedDir, uiRegex.Checked);
            fileProcessor.endProcessing += FileProcessor_endProcessing;
            fileProcessor.reportProgress += FileProcessor_reportProgress;
            uiStatusLabel.Text = "برائے مہربانی انتظار کیجیے";
            disableButtons();
            uiStatusProgress.ProgressBar.Style = ProgressBarStyle.Marquee;
            uiStatusProgress.ProgressBar.MarqueeAnimationSpeed = 30;

            _watch = System.Diagnostics.Stopwatch.StartNew();
            fileProcessor.processDir();
        }

        private void FileProcessor_reportProgress(object sender, FileInfo e)
        {
        }

        private void FileProcessor_endProcessing(object sender, StringBuilder e)
        {
            _watch.Stop();
            Utils._selectedDir = null;
            Utils.FinishProgress(uiStatusProgress.ProgressBar);
            Invoke(new SetToolStripDelegate(SetToolStrip), "وقت: " + _watch.ElapsedMilliseconds + " ملی سیکنڈز");

            Invoke(new EnableDisableButtonDelegate(enableButtons));
        }

        private void SetToolStrip(string text)
        {
            uiStatusLabel.Text = text;
        }

        private void disableButtons()
        {
            uiToolbarCorrectbtn.Enabled = false;
            uiLoadFileBtn.Enabled = false;
            uiLoadDirBtn.Enabled = false;
        }

        private void enableButtons()
        {
            uiToolbarCorrectbtn.Enabled = true;
            uiLoadFileBtn.Enabled = true;
            uiLoadDirBtn.Enabled = true;
        }

        private void uiTokenList_Click(object sender, EventArgs e)
        {
            ManageTokens tokens = new ManageTokens();
            tokens.ShowDialog();
        }

        private void uiMenuLoadFile_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void uiMenuProcessDir_Click(object sender, EventArgs e)
        {
            processDir();
        }

        private void تصحیحکیجیےToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateIt();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(uiTextToProcess.SelectedText))
            {
                NewToken newToken = new NewToken();
                newToken.newText = uiTextToProcess.SelectedText;
                newToken.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TokenImporter importer;
            if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
            {
                importer = new TokenImporter(uiTokenFileDialogue.FileName);
                int i = importer.import();

                MessageBox.Show("[" + i + "] نئے الفاظ درآمد ہو گئے ہیں۔", "درآمد", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Height > 506)
            {
                label1.Left = label1.Parent.Width - (label1.Width + 10);
                label2.Left = label2.Parent.Width - (label2.Width + 10);

                uiTextToProcess.Height = uiTextToProcess.Parent.Height - (60);
                uiUpdatedText.Height = uiUpdatedText.Parent.Height - (60);
            }
            else
            {
                label1.Left = 631;
                label1.Left = label1.Parent.Width - (label1.Width + 10);
                label2.Left = label2.Parent.Width - (label2.Width + 10);

                uiTextToProcess.Height = 133;
                uiUpdatedText.Height = 133;
            }
        }
    }
}
