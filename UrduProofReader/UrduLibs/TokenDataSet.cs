using System;
using System.Text;
using System.Data;
using System.IO;

namespace UrduLibs
{
    public class TokenDataSet
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

        public bool save(string text)
        {
            if (text != null && text.Length > 0)
            {
                File.AppendAllText(Utils._tokenFilePath.FullName, "\r\n"+ text);
                return true;
            }

            return false;
        }

        public bool save()
        {
            StringBuilder allTokens = new StringBuilder();
            int i = 0;
            foreach (DataRow row in DataTable.Rows)
            {
                if (row[0] == null || row[1] == null)
                {
                    return false;
                }

                if (!string.IsNullOrEmpty(row[2] + "") && !row[2].Equals("False"))
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

            File.WriteAllText(Utils._tokenFilePath.FullName, allTokens.ToString());

            return true;
        }

        public void initlize()
        {

            if (_table == null)
            {
                _table = new DataTable();

                DataColumn column = new DataColumn("Column1");
                _table.Columns.Add(column);
                column = new DataColumn("Column2");
                _table.Columns.Add(column);
                column = new DataColumn("Column3");
                _table.Columns.Add(column);
            }


            if (_table.Rows.Count > 0)
                _table.Rows.Clear();

            StringBuilder tokenFile;
            Utils._tokenFilePath = new FileInfo(Utils._tokenFilePath.FullName);

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
                    myRow[2] = true;
                }
                else
                {
                    // Not expression
                    myRow[0] = tokens[0];
                    myRow[1] = tokens[1];
                    myRow[2] = false;
                }

                _table.Rows.Add(myRow);
            }
        }

        public void dispose()
        {
            if (_table.Rows.Count > 0)
                _table.Rows.Clear();

            _table = null;
        }

        public void initlize(string fileName)
        {

            if (_table == null)
            {
                _table = new DataTable();

                DataColumn column = new DataColumn("Column1");
                _table.Columns.Add(column);
                column = new DataColumn("Column2");
                _table.Columns.Add(column);
                column = new DataColumn("Column3");
                _table.Columns.Add(column);
            }


            if(_table.Rows.Count>0)
            _table.Rows.Clear();

            StringBuilder tokenFile;
            tokenFile = new StringBuilder(File.ReadAllText(fileName));

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
                    myRow[2] = true;
                }
                else
                {
                    // Not expression
                    myRow[0] = tokens[0];
                    myRow[1] = tokens[1];
                    myRow[2] = false;
                }

                _table.Rows.Add(myRow);
            }
        }

        public void exportInDesignDic(string fileName)
        {
            StringBuilder allText = new StringBuilder();
            int i = 0;
            allText.Append("116381\r\n");
            foreach (DataRow row in DataTable.Rows)
            {
                if (row[0] == null || row[1] == null)
                {
                    continue;
                }

                allText.Append(row[1]);

                i++;
                if (_table.Rows.Count != i)
                    allText.Append("\r\n");
            }

            File.WriteAllText(fileName, allText.ToString());
        }

        public void exportInDesignScript(string fileName)
        {
            StringBuilder allText = new StringBuilder();
            int i = 0;
            foreach (DataRow row in DataTable.Rows)
            {
                if (row[0] == null || row[1] == null)
                {
                    continue;
                }

                allText.Append("text\t{findWhat:\"" + row[0] + "\"}\t{changeTo:\"" + row[1] + "\"}\t{includeFootnotes:true, includeMasterPages:true, includeHiddenLayers:true, wholeWord:false}");

                i++;
                if (_table.Rows.Count != i)
                    allText.Append("\r\n");
            }

            File.WriteAllText(fileName, allText.ToString());
        }

        public DataTable sorted(bool sort)
        {
            if (sort)
            {
                DataTable dtOut;
                this.DataTable.DefaultView.Sort = "Column1 ASC";
                dtOut = this.DataTable.DefaultView.ToTable();
                return dtOut;
            }

            return this.DataTable;
        }

    }
}
