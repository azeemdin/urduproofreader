namespace UrduProofReader.token
{
    partial class ManageTokens
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uiSave = new System.Windows.Forms.Button();
            this.uiClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // uiSave
            // 
            this.uiSave.Location = new System.Drawing.Point(12, 399);
            this.uiSave.Name = "uiSave";
            this.uiSave.Size = new System.Drawing.Size(153, 23);
            this.uiSave.TabIndex = 1;
            this.uiSave.Text = "تبدیلی محفوظ کیجیے";
            this.uiSave.UseVisualStyleBackColor = true;
            this.uiSave.Click += new System.EventHandler(this.uiSave_Click);
            // 
            // uiClose
            // 
            this.uiClose.Location = new System.Drawing.Point(549, 399);
            this.uiClose.Name = "uiClose";
            this.uiClose.Size = new System.Drawing.Size(118, 23);
            this.uiClose.TabIndex = 2;
            this.uiClose.Text = "بند کیجیے";
            this.uiClose.UseVisualStyleBackColor = true;
            this.uiClose.Click += new System.EventHandler(this.uiClose_Click);
            // 
            // ManageTokens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 434);
            this.Controls.Add(this.uiClose);
            this.Controls.Add(this.uiSave);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManageTokens";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "الفاظ کا ذخیرہ";
            this.Load += new System.EventHandler(this.ManageTokens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button uiSave;
        private System.Windows.Forms.Button uiClose;
    }
}