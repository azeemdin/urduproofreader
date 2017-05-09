namespace UrduProofReaderWE
{
    partial class ProofReader : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ProofReader()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.uiRegex = this.Factory.CreateRibbonCheckBox();
            this.uiTokenSort = this.Factory.CreateRibbonCheckBox();
            this.uiCorrectIt = this.Factory.CreateRibbonButton();
            this.uiFullWord = this.Factory.CreateRibbonCheckBox();
            this.uiAirab = this.Factory.CreateRibbonCheckBox();
            this.uiShowChanges = this.Factory.CreateRibbonCheckBox();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.uiManageTokens = this.Factory.CreateRibbonButton();
            this.uiImportTokens = this.Factory.CreateRibbonButton();
            this.uiCustomTokens = this.Factory.CreateRibbonCheckBox();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.uiBold = this.Factory.CreateRibbonCheckBox();
            this.uiUnderline = this.Factory.CreateRibbonCheckBox();
            this.uiItalic = this.Factory.CreateRibbonCheckBox();
            this.uiFonts = this.Factory.CreateRibbonDropDown();
            this.uiSizes = this.Factory.CreateRibbonDropDown();
            this.uiSelectColor = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.uiTokenFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "اردو پروف ریڈر";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.uiRegex);
            this.group1.Items.Add(this.uiTokenSort);
            this.group1.Items.Add(this.uiCorrectIt);
            this.group1.Items.Add(this.uiFullWord);
            this.group1.Items.Add(this.uiAirab);
            this.group1.Items.Add(this.uiShowChanges);
            this.group1.Label = "تصحیح";
            this.group1.Name = "group1";
            // 
            // uiRegex
            // 
            this.uiRegex.Checked = true;
            this.uiRegex.Label = "ریگولر ایکسپریشن";
            this.uiRegex.Name = "uiRegex";
            // 
            // uiTokenSort
            // 
            this.uiTokenSort.Label = "الفاظ کی ترتیب";
            this.uiTokenSort.Name = "uiTokenSort";
            // 
            // uiCorrectIt
            // 
            this.uiCorrectIt.Label = "تصحیح کیجیے";
            this.uiCorrectIt.Name = "uiCorrectIt";
            this.uiCorrectIt.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.uiCorrectIt_Click);
            // 
            // uiFullWord
            // 
            this.uiFullWord.Label = "پورا لفظ تلاش کیجیے";
            this.uiFullWord.Name = "uiFullWord";
            // 
            // uiAirab
            // 
            this.uiAirab.Label = "اعراب ختم کیجیے";
            this.uiAirab.Name = "uiAirab";
            // 
            // uiShowChanges
            // 
            this.uiShowChanges.Label = "تبدیل کو واضح کیجیے";
            this.uiShowChanges.Name = "uiShowChanges";
            // 
            // group2
            // 
            this.group2.Items.Add(this.uiManageTokens);
            this.group2.Items.Add(this.uiImportTokens);
            this.group2.Items.Add(this.uiCustomTokens);
            this.group2.Label = "ذخیرہ الفاظ";
            this.group2.Name = "group2";
            // 
            // uiManageTokens
            // 
            this.uiManageTokens.Label = "ذخیرہ";
            this.uiManageTokens.Name = "uiManageTokens";
            this.uiManageTokens.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.uiManageTokens_Click);
            // 
            // uiImportTokens
            // 
            this.uiImportTokens.Label = "ذخیرہ درآمد کیجیے";
            this.uiImportTokens.Name = "uiImportTokens";
            this.uiImportTokens.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.uiImportTokens_Click);
            // 
            // uiCustomTokens
            // 
            this.uiCustomTokens.Label = "منتخب ذخیرہ الفاظ";
            this.uiCustomTokens.Name = "uiCustomTokens";
            // 
            // group3
            // 
            this.group3.Items.Add(this.uiBold);
            this.group3.Items.Add(this.uiUnderline);
            this.group3.Items.Add(this.uiItalic);
            this.group3.Items.Add(this.uiFonts);
            this.group3.Items.Add(this.uiSizes);
            this.group3.Items.Add(this.uiSelectColor);
            this.group3.Items.Add(this.button1);
            this.group3.Label = "فارمیٹنگ";
            this.group3.Name = "group3";
            // 
            // uiBold
            // 
            this.uiBold.Label = "موٹا";
            this.uiBold.Name = "uiBold";
            // 
            // uiUnderline
            // 
            this.uiUnderline.Label = "انڈر لائن";
            this.uiUnderline.Name = "uiUnderline";
            // 
            // uiItalic
            // 
            this.uiItalic.Label = "ٹیڑھا";
            this.uiItalic.Name = "uiItalic";
            // 
            // uiFonts
            // 
            this.uiFonts.Label = "فونٹ";
            this.uiFonts.Name = "uiFonts";
            // 
            // uiSizes
            // 
            this.uiSizes.Label = "سائز";
            this.uiSizes.Name = "uiSizes";
            // 
            // uiSelectColor
            // 
            this.uiSelectColor.Label = "رنگ منتخب کیجیے";
            this.uiSelectColor.Name = "uiSelectColor";
            this.uiSelectColor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.uiSelectColor_Click);
            // 
            // button1
            // 
            this.button1.Label = "تبدیل کیجیے";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // ProofReader
            // 
            this.Name = "ProofReader";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ProofReader_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiRegex;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiTokenSort;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton uiCorrectIt;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiFullWord;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton uiManageTokens;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton uiImportTokens;
        private System.Windows.Forms.OpenFileDialog uiTokenFileDialogue;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiAirab;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiCustomTokens;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiBold;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiUnderline;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiItalic;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown uiFonts;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton uiSelectColor;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown uiSizes;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox uiShowChanges;
    }

    partial class ThisRibbonCollection
    {
        internal ProofReader ProofReader
        {
            get { return this.GetRibbon<ProofReader>(); }
        }
    }
}
