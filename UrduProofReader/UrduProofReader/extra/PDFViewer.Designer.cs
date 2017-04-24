namespace UrduProofReader.extra
{
    partial class PDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFViewer));
            this.uiOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.uiPDF = new AxAcroPDFLib.AxAcroPDF();
            this.radRichTextEditor1 = new Telerik.WinControls.UI.RadRichTextEditor();
            this.richTextEditorRibbonBar1 = new Telerik.WinControls.UI.RichTextEditorRibbonBar();
            this.button1 = new System.Windows.Forms.Button();
            this.uiClose = new System.Windows.Forms.Button();
            this.uiSaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiOpenFileDialog
            // 
            this.uiOpenFileDialog.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.uiClose);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(826, 467);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.uiPDF);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.radRichTextEditor1);
            this.splitContainer2.Panel2.Controls.Add(this.richTextEditorRibbonBar1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(826, 414);
            this.splitContainer2.SplitterDistance = 160;
            this.splitContainer2.TabIndex = 1;
            // 
            // uiPDF
            // 
            this.uiPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPDF.Enabled = true;
            this.uiPDF.Location = new System.Drawing.Point(0, 0);
            this.uiPDF.Name = "uiPDF";
            this.uiPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("uiPDF.OcxState")));
            this.uiPDF.Size = new System.Drawing.Size(826, 160);
            this.uiPDF.TabIndex = 0;
            // 
            // radRichTextEditor1
            // 
            this.radRichTextEditor1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.radRichTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radRichTextEditor1.Location = new System.Drawing.Point(0, 174);
            this.radRichTextEditor1.Name = "radRichTextEditor1";
            this.radRichTextEditor1.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.radRichTextEditor1.Size = new System.Drawing.Size(826, 76);
            this.radRichTextEditor1.TabIndex = 2;
            this.radRichTextEditor1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.radRichTextEditor1_PreviewKeyDown);
            // 
            // richTextEditorRibbonBar1
            // 
            this.richTextEditorRibbonBar1.ApplicationMenuStyle = Telerik.WinControls.UI.ApplicationMenuStyle.BackstageView;
            this.richTextEditorRibbonBar1.AssociatedRichTextEditor = this.radRichTextEditor1;
            this.richTextEditorRibbonBar1.BuiltInStylesVersion = Telerik.WinForms.Documents.Model.Styles.BuiltInStylesVersion.Office2013;
            // 
            // 
            // 
            this.richTextEditorRibbonBar1.ExitButton.Text = "Exit";
            this.richTextEditorRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.richTextEditorRibbonBar1.Name = "richTextEditorRibbonBar1";
            // 
            // 
            // 
            this.richTextEditorRibbonBar1.OptionsButton.Text = "Options";
            this.richTextEditorRibbonBar1.Size = new System.Drawing.Size(826, 174);
            this.richTextEditorRibbonBar1.TabIndex = 3;
            this.richTextEditorRibbonBar1.TabStop = false;
            ((Telerik.WinControls.UI.RichTextEditorRibbonUI.RichTextEditorRibbonTab)(this.richTextEditorRibbonBar1.GetChildAt(0).GetChildAt(4).GetChildAt(0).GetChildAt(0).GetChildAt(4))).Text = "Mailings";
            ((Telerik.WinControls.UI.RichTextEditorRibbonUI.RichTextEditorRibbonTab)(this.richTextEditorRibbonBar1.GetChildAt(0).GetChildAt(4).GetChildAt(0).GetChildAt(0).GetChildAt(4))).Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            ((Telerik.WinControls.UI.RichTextEditorRibbonUI.RichTextEditorRibbonTab)(this.richTextEditorRibbonBar1.GetChildAt(0).GetChildAt(4).GetChildAt(0).GetChildAt(0).GetChildAt(4))).Name = "tabMailings";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "فائل تبدیل کیجیے";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiClose
            // 
            this.uiClose.Location = new System.Drawing.Point(12, 14);
            this.uiClose.Name = "uiClose";
            this.uiClose.Size = new System.Drawing.Size(90, 23);
            this.uiClose.TabIndex = 0;
            this.uiClose.Text = "بند کیجیے";
            this.uiClose.UseVisualStyleBackColor = true;
            this.uiClose.Click += new System.EventHandler(this.uiClose_Click);
            // 
            // PDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 467);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PDFViewer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "پی ڈی ایف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PDFViewer_Load);
            this.SizeChanged += new System.EventHandler(this.PDFViewer_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog uiOpenFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button uiClose;
        private System.Windows.Forms.SaveFileDialog uiSaveDialog;
        private AxAcroPDFLib.AxAcroPDF uiPDF;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
        private Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar1;
    }
}