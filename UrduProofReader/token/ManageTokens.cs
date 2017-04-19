using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrduProofReader.classes;

namespace UrduProofReader.token
{
    public partial class ManageTokens : Form
    {
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form {msg=0xa3 

        public ManageTokens()
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

        private void uiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageTokens_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns[0].Name = "Column1";
            dataGridView1.Columns[0].DataPropertyName = "Column1";
            dataGridView1.Columns[1].Name = "Column2";
            dataGridView1.Columns[1].DataPropertyName = "Column2";
            dataGridView1.Columns[2].Name = "Column3";
            dataGridView1.Columns[2].DataPropertyName = "Column3";

            dataGridView1.DataSource = TokenDataSet.Instance.DataTable;
        }

        private void uiSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ الفاظ کے ذخیرے میں تبدیلی کو محفوظ کرنا چاہتے ہیں؟", "تبدیل محفوظ کیجیے", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!TokenDataSet.Instance.save())
                {
                    MessageBox.Show("تبدیل محفوظ کرتے ہوئے کوئی غلطی ہوئی ہے، مہربانی کر کے دوبارہ دیکھیے", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TokenDataSet.Instance.initlize();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TokenDataSet.Instance.DataTable;

                MessageBox.Show("تبدیلیاں محفوظ ہو گئی ہیں", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
