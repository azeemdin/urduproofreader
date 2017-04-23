using System;
using System.Windows.Forms;
using UrduLibs;

namespace UrduProofReader.token
{
    public partial class NewToken : Form
    {
        public string newText;
        public NewToken()
        {
            InitializeComponent();
        }

        private void NewToken_Load(object sender, EventArgs e)
        {
            textBox1.Text = newText;
            textBox2.Text = newText;
        }

        private void uiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("مہربانی کرکے تلاش والا متن داخل کیجیے", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("مہربانی کرکے تبدیلی والا متن داخل کیجیے", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            TokenDataSet ts = new TokenDataSet();
            if (checkBox1.Checked)
            {
                ts.save("E،" + textBox1.Text + "،" + textBox2.Text);
            }
            else
            {
                ts.save(textBox1.Text + "،" + textBox2.Text);
            }

            //MessageBox.Show("تبدیلیاں محفوظ ہو گئی ہیں", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
