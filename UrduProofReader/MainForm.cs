using System;
using System.Text;
using System.Windows.Forms;
using UrduProofReader.token;
using UrduProofReader.classes;
using System.Diagnostics;
using System.IO;

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
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }
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
            updateIt();
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
            loadFile();
        }

        private void loadFile()
        {
            uiTokenFileDialogue.Filter = "Urdu File (*.txt)|*.txt";
            if (uiTokenFileDialogue.ShowDialog() == DialogResult.OK)
            {
                Utils._textFilePath = new FileInfo(uiTokenFileDialogue.FileName);
                if (Utils._textFilePath != null)
                {
                    uiTextToProcess.Text = File.ReadAllText(Utils._textFilePath.FullName);
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
    }
}
