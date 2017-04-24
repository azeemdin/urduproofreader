using System;
using System.ComponentModel;
using System.Windows.Forms;
using UrduLibs;

namespace UrduProofReader.token
{
    public partial class ManageTokens : Form
    {
        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form {msg=0xa3 
        int rowIndex = -1;
        int oldRow = -2;
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

            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void uiSave_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("کیا آپ الفاظ کے ذخیرے میں تبدیلی کو محفوظ کرنا چاہتے ہیں؟", "تبدیل محفوظ کیجیے", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!TokenDataSet.Instance.save())
                {
                    MessageBox.Show("تبدیل محفوظ کرتے ہوئے کوئی غلطی ہوئی ہے، مہربانی کر کے دوبارہ دیکھیے", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TokenDataSet.Instance.initlize();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TokenDataSet.Instance.DataTable;

                //MessageBox.Show("تبدیلیاں محفوظ ہو گئی ہیں", "تبدیل محفوظ کیجیے", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uiSearch_Click(object sender, EventArgs e)
        {
            rowIndex = -1;
            uiDelete.Enabled = false;
            dataGridView1.ClearSelection();
            bool found = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Contains(textBox1.Text))
                {
                    //Select the row here
                    rowIndex = row.Index;

                    if (oldRow == -2 || oldRow != rowIndex && rowIndex> oldRow)
                    {
                        oldRow = rowIndex;

                        dataGridView1.Rows[rowIndex].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
                        dataGridView1.Focus();
                        uiDelete.Enabled = true;
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                oldRow = -2;
        }

        private void uiDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);
                uiDelete.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            oldRow = -2;
        }
    }
}
