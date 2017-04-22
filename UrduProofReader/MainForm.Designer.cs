namespace UrduProofReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.uiStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiStatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiTokenForm = new System.Windows.Forms.ToolStripMenuItem();
            this.uiExitMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.اعمالToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تصحیحکیجیےToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiMenuLoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uiMenuProcessDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiToolbarCorrectbtn = new System.Windows.Forms.ToolStripButton();
            this.uiLoadFileBtn = new System.Windows.Forms.ToolStripButton();
            this.uiLoadDirBtn = new System.Windows.Forms.ToolStripButton();
            this.uiTokenList = new System.Windows.Forms.ToolStripButton();
            this.uiExitToolButton = new System.Windows.Forms.ToolStripButton();
            this.uiTokenFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.uiRegex = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiTextToProcess = new System.Windows.Forms.RichTextBox();
            this.uiGetTextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.uiUpdatedText = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.uiGetTextMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiStatusLabel,
            this.uiStatusProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Size = new System.Drawing.Size(23, 17);
            this.uiStatusLabel.Text = "تیار";
            // 
            // uiStatusProgress
            // 
            this.uiStatusProgress.Name = "uiStatusProgress";
            this.uiStatusProgress.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.uiStatusProgress.RightToLeftLayout = true;
            this.uiStatusProgress.Size = new System.Drawing.Size(100, 16);
            this.uiStatusProgress.Step = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.اعمالToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiTokenForm,
            this.uiExitMenuButton});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "&فائل";
            // 
            // uiTokenForm
            // 
            this.uiTokenForm.Name = "uiTokenForm";
            this.uiTokenForm.Size = new System.Drawing.Size(142, 22);
            this.uiTokenForm.Text = "&الفاظ کا ذخیرہ";
            this.uiTokenForm.Click += new System.EventHandler(this.uiTokenForm_Click);
            // 
            // uiExitMenuButton
            // 
            this.uiExitMenuButton.Name = "uiExitMenuButton";
            this.uiExitMenuButton.Size = new System.Drawing.Size(142, 22);
            this.uiExitMenuButton.Text = "&بند کیجیے";
            this.uiExitMenuButton.Click += new System.EventHandler(this.uiExitMenuButton_Click);
            // 
            // اعمالToolStripMenuItem
            // 
            this.اعمالToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تصحیحکیجیےToolStripMenuItem,
            this.uiMenuLoadFile,
            this.uiMenuProcessDir});
            this.اعمالToolStripMenuItem.Name = "اعمالToolStripMenuItem";
            this.اعمالToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.اعمالToolStripMenuItem.Text = "&اعمال";
            // 
            // تصحیحکیجیےToolStripMenuItem
            // 
            this.تصحیحکیجیےToolStripMenuItem.Name = "تصحیحکیجیےToolStripMenuItem";
            this.تصحیحکیجیےToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.تصحیحکیجیےToolStripMenuItem.Text = "&تصحیح کیجیے";
            this.تصحیحکیجیےToolStripMenuItem.Click += new System.EventHandler(this.تصحیحکیجیےToolStripMenuItem_Click);
            // 
            // uiMenuLoadFile
            // 
            this.uiMenuLoadFile.Name = "uiMenuLoadFile";
            this.uiMenuLoadFile.Size = new System.Drawing.Size(210, 22);
            this.uiMenuLoadFile.Text = "&فائل شامل کیجیے";
            this.uiMenuLoadFile.Click += new System.EventHandler(this.uiMenuLoadFile_Click);
            // 
            // uiMenuProcessDir
            // 
            this.uiMenuProcessDir.Name = "uiMenuProcessDir";
            this.uiMenuProcessDir.Size = new System.Drawing.Size(210, 22);
            this.uiMenuProcessDir.Text = "&ڈائریکٹری کی تصحیح کیجیے";
            this.uiMenuProcessDir.Click += new System.EventHandler(this.uiMenuProcessDir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiToolbarCorrectbtn,
            this.uiLoadFileBtn,
            this.uiLoadDirBtn,
            this.toolStripButton1,
            this.uiTokenList,
            this.uiExitToolButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(822, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiToolbarCorrectbtn
            // 
            this.uiToolbarCorrectbtn.Image = ((System.Drawing.Image)(resources.GetObject("uiToolbarCorrectbtn.Image")));
            this.uiToolbarCorrectbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiToolbarCorrectbtn.Name = "uiToolbarCorrectbtn";
            this.uiToolbarCorrectbtn.Size = new System.Drawing.Size(95, 22);
            this.uiToolbarCorrectbtn.Text = "تصحیح کیجیے";
            this.uiToolbarCorrectbtn.Click += new System.EventHandler(this.uiToolbarCorrectbtn_Click);
            // 
            // uiLoadFileBtn
            // 
            this.uiLoadFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("uiLoadFileBtn.Image")));
            this.uiLoadFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiLoadFileBtn.Name = "uiLoadFileBtn";
            this.uiLoadFileBtn.Size = new System.Drawing.Size(113, 22);
            this.uiLoadFileBtn.Text = "فائل شامل کیجیے";
            this.uiLoadFileBtn.Click += new System.EventHandler(this.uiLoadFile_Click);
            // 
            // uiLoadDirBtn
            // 
            this.uiLoadDirBtn.Image = ((System.Drawing.Image)(resources.GetObject("uiLoadDirBtn.Image")));
            this.uiLoadDirBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiLoadDirBtn.Name = "uiLoadDirBtn";
            this.uiLoadDirBtn.Size = new System.Drawing.Size(163, 22);
            this.uiLoadDirBtn.Text = "ڈائریکٹری کی تصحیح کیجیے";
            this.uiLoadDirBtn.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // uiTokenList
            // 
            this.uiTokenList.Image = ((System.Drawing.Image)(resources.GetObject("uiTokenList.Image")));
            this.uiTokenList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiTokenList.Name = "uiTokenList";
            this.uiTokenList.Size = new System.Drawing.Size(83, 22);
            this.uiTokenList.Text = "ذخیرہ الفاظ";
            this.uiTokenList.Click += new System.EventHandler(this.uiTokenList_Click);
            // 
            // uiExitToolButton
            // 
            this.uiExitToolButton.Image = ((System.Drawing.Image)(resources.GetObject("uiExitToolButton.Image")));
            this.uiExitToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uiExitToolButton.Name = "uiExitToolButton";
            this.uiExitToolButton.Size = new System.Drawing.Size(75, 22);
            this.uiExitToolButton.Text = "بند کیجیے";
            this.uiExitToolButton.Click += new System.EventHandler(this.uiExitToolButton_Click);
            // 
            // uiRegex
            // 
            this.uiRegex.AutoSize = true;
            this.uiRegex.Checked = true;
            this.uiRegex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uiRegex.Location = new System.Drawing.Point(12, 28);
            this.uiRegex.Name = "uiRegex";
            this.uiRegex.Size = new System.Drawing.Size(111, 17);
            this.uiRegex.TabIndex = 3;
            this.uiRegex.Text = "ریگولر ایکسپریشن";
            this.uiRegex.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Urdu Typesetting", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(631, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "تصحیح کے لیے متن یہاں شامل کریں";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextToProcess
            // 
            this.uiTextToProcess.ContextMenuStrip = this.uiGetTextMenu;
            this.uiTextToProcess.Location = new System.Drawing.Point(12, 51);
            this.uiTextToProcess.Name = "uiTextToProcess";
            this.uiTextToProcess.Size = new System.Drawing.Size(798, 133);
            this.uiTextToProcess.TabIndex = 1;
            this.uiTextToProcess.Text = "";
            // 
            // uiGetTextMenu
            // 
            this.uiGetTextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.uiGetTextMenu.Name = "uiGetText";
            this.uiGetTextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uiGetTextMenu.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem1.Text = "نیا لفظ شامل کیجیے";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Urdu Typesetting", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(627, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "تصحیح شدہ مواد یہاں سے حاصل کریں";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiUpdatedText
            // 
            this.uiUpdatedText.Location = new System.Drawing.Point(12, 244);
            this.uiUpdatedText.Name = "uiUpdatedText";
            this.uiUpdatedText.ReadOnly = true;
            this.uiUpdatedText.Size = new System.Drawing.Size(792, 133);
            this.uiUpdatedText.TabIndex = 3;
            this.uiUpdatedText.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uiUpdatedText);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.uiTextToProcess);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.uiRegex);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 392);
            this.panel2.TabIndex = 8;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(117, 22);
            this.toolStripButton1.Text = "ذخیرہ درآمد کیجیے";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اردو پروف ریڈر";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uiGetTextMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiExitMenuButton;
        private System.Windows.Forms.ToolStripButton uiExitToolButton;
        private System.Windows.Forms.ToolStripStatusLabel uiStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar uiStatusProgress;
        private System.Windows.Forms.ToolStripMenuItem uiTokenForm;
        private System.Windows.Forms.ToolStripButton uiToolbarCorrectbtn;
        private System.Windows.Forms.ToolStripButton uiLoadFileBtn;
        private System.Windows.Forms.ToolStripButton uiLoadDirBtn;
        private System.Windows.Forms.OpenFileDialog uiTokenFileDialogue;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripButton uiTokenList;
        private System.Windows.Forms.ToolStripMenuItem اعمالToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiMenuLoadFile;
        private System.Windows.Forms.ToolStripMenuItem uiMenuProcessDir;
        private System.Windows.Forms.ToolStripMenuItem تصحیحکیجیےToolStripMenuItem;
        private System.Windows.Forms.CheckBox uiRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox uiTextToProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox uiUpdatedText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip uiGetTextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}