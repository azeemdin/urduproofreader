﻿namespace UrduProofReader.token
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uiSave = new System.Windows.Forms.Button();
            this.uiClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uiSearch = new System.Windows.Forms.Button();
            this.uiDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "تلاش کیجیے";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "تبدیل کیجیے";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ریگولر ایکسپریشن";
            this.Column3.Name = "Column3";
            // 
            // uiSave
            // 
            this.uiSave.Location = new System.Drawing.Point(12, 454);
            this.uiSave.Name = "uiSave";
            this.uiSave.Size = new System.Drawing.Size(153, 23);
            this.uiSave.TabIndex = 1;
            this.uiSave.Text = "تبدیلی محفوظ کیجیے";
            this.uiSave.UseVisualStyleBackColor = true;
            this.uiSave.Click += new System.EventHandler(this.uiSave_Click);
            // 
            // uiClose
            // 
            this.uiClose.Location = new System.Drawing.Point(549, 454);
            this.uiClose.Name = "uiClose";
            this.uiClose.Size = new System.Drawing.Size(118, 23);
            this.uiClose.TabIndex = 2;
            this.uiClose.Text = "بند کیجیے";
            this.uiClose.UseVisualStyleBackColor = true;
            this.uiClose.Click += new System.EventHandler(this.uiClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "تلاش کیجیے";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // uiSearch
            // 
            this.uiSearch.Location = new System.Drawing.Point(314, 35);
            this.uiSearch.Name = "uiSearch";
            this.uiSearch.Size = new System.Drawing.Size(75, 23);
            this.uiSearch.TabIndex = 5;
            this.uiSearch.Text = "تلاش کیجیے";
            this.uiSearch.UseVisualStyleBackColor = true;
            this.uiSearch.Click += new System.EventHandler(this.uiSearch_Click);
            // 
            // uiDelete
            // 
            this.uiDelete.Enabled = false;
            this.uiDelete.Location = new System.Drawing.Point(395, 35);
            this.uiDelete.Name = "uiDelete";
            this.uiDelete.Size = new System.Drawing.Size(75, 23);
            this.uiDelete.TabIndex = 6;
            this.uiDelete.Text = "خارج کیجیے";
            this.uiDelete.UseVisualStyleBackColor = true;
            this.uiDelete.Click += new System.EventHandler(this.uiDelete_Click);
            // 
            // ManageTokens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 489);
            this.Controls.Add(this.uiDelete);
            this.Controls.Add(this.uiSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button uiSave;
        private System.Windows.Forms.Button uiClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button uiSearch;
        private System.Windows.Forms.Button uiDelete;
    }
}