using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace UrduProofReader.classes
{
    class TokenDataSet
    {
        static TokenDataSet _me;
        DataTable _table;
        public static TokenDataSet Instance
        {
            get
            {
                if (_me == null)
                    _me = new TokenDataSet();

                return _me;
            }
        }

        public DataTable DataTable
        {
            get
            {
                if (_table == null)
                    initlize();

                return _table;
            }
        }

        public bool save()
        {
            StringBuilder allTokens = new StringBuilder();
            int i = 0;
            foreach (DataRow row in _table.Rows)
            {
                if (row[0] == null || row[1] == null || string.IsNullOrEmpty(row[2] + ""))
                {
                    return false;
                }

                if (row[2].Equals("Y"))
                {
                    allTokens.Append("E،" + row[0] + "،" + row[1]);
                }
                else
                {
                    allTokens.Append(row[0] + "،" + row[1]);
                }

                i++;
                if (_table.Rows.Count != i)
                    allTokens.Append("\r\n");
            }

            File.WriteAllText(Utils._basePath + "\\" + "tokenfile.txt", allTokens.ToString());

            return true;
        }

        public void initlize()
        {

            if (_table == null)
            {
                _table = new DataTable();

                DataColumn column = new DataColumn("تلاش کیجیے");
                _table.Columns.Add(column);
                column = new DataColumn("تبدیل کیجیے");
                _table.Columns.Add(column);
                column = new DataColumn("ریگولر ایکسپریشن");
                _table.Columns.Add(column);
            }


            if(_table.Rows.Count>0)
            _table.Rows.Clear();

            StringBuilder tokenFile;
            Utils._tokenFilePath = new FileInfo(Utils._basePath + "\\" + "tokenfile.txt");

            tokenFile = new StringBuilder(File.ReadAllText(Utils._tokenFilePath.FullName));

            string[] lines = tokenFile.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                DataRow myRow = _table.NewRow();
                string[] tokens = line.Split(new char[] { '،' });

                if (tokens.Length == 3)
                {
                    // Expression
                    myRow[0] = tokens[1];
                    myRow[1] = tokens[2];
                    myRow[2] = "Y";
                }
                else
                {
                    // Not expression
                    myRow[0] = tokens[0];
                    myRow[1] = tokens[1];
                    myRow[2] = "N";
                }

                _table.Rows.Add(myRow);
            }
        }

    }
}
