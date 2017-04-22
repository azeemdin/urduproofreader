using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UrduProofReader.classes
{
    class ProofReader
    {
        bool _error;
        StringBuilder _errorText;
        StringBuilder _allText;
        StringBuilder _updatedText;
        List<List<string>> _allTokens;
        bool _isRegex = true;

        public bool IsError
        {
            get { return this._error; }
        }

        public bool IsRegex
        {
            get { return this._isRegex; }
            set { _isRegex = value; }
        }

        public StringBuilder ErrorText
        {
            get
            {
                if (_errorText != null)
                    return _errorText;
                return null;
            }
            set
            {
                if (_errorText == null)
                {
                    _errorText = new StringBuilder(value.ToString());
                }
                else
                {
                    _errorText = new StringBuilder(value.ToString());
                }
            }
        }

        public StringBuilder UpdatedText
        {
            get
            {
                if (_updatedText != null)
                    return _updatedText;
                return null;
            }
            set
            {
                if (_updatedText == null)
                {
                    _updatedText = new StringBuilder(value.ToString());
                }
                else
                {
                    _updatedText = new StringBuilder(value.ToString());
                }
            }
        }

        public StringBuilder TextToProcess
        {
            get {
                if (_allText != null)
                    return _allText;
                return null;
            }
            set {
                if (_allText == null)
                {
                    _allText = new StringBuilder(value.ToString());
                }
                else
                {
                    _allText = new StringBuilder(value.ToString());
                }
            }
        }

        public List<List<string>> AllTokens
        {
            get {
                if (_allTokens == null)
                    _allTokens = new List<List<string>>();

                return _allTokens;
            }
        }

        private void clearTokens()
        {
            foreach (List<string> list in AllTokens)
            {
                list.Clear();
            }
            _allTokens.Clear();
            _allTokens = null;
        }

        public ProofReader(bool regex)
        {
            this._isRegex = regex;
            Utils._tokenFilePath = new FileInfo(Utils._basePath + "\\" + "tokenfile.txt");
            loadTokenFile();
        }

        public void loadTokenFile()
        {
            StringBuilder tokenFile;
            clearTokens();

            if (!File.Exists(Utils._basePath + "\\" + "tokenfile.txt"))
            {
                File.WriteAllText(Utils._basePath + "\\" + "tokenfile.txt", Utils._tokenList);
            }
                try
            {
                tokenFile = new StringBuilder(File.ReadAllText(Utils._tokenFilePath.FullName));
            }
            catch (Exception ex)
            {
                this._error = true;
                ErrorText = new StringBuilder("Unable to load token file");
                return;
            }

            string[] lines = tokenFile.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                string[] tokens = line.Split(new char[] { '،' });
                List<string> list = new List<string>();

                if (tokens.Length == 3)
                {
                    list.Add("E");
                    list.Add(tokens[1]);
                    list.Add(tokens[2]);
                }
                else
                {
                    list.Add(tokens[0]);
                    list.Add(tokens[1]);
                }

                AllTokens.Add(list);
            }
        }

        public void processText()
        {
            this._error = false;
            if (TextToProcess == null)
            {
                this._error = true;
                ErrorText = new StringBuilder("Please provide text to process");
                return;
            }

            UpdatedText = TextToProcess;

            UpdatedText = UpdatedText.Replace(" ،", "،");
            UpdatedText = UpdatedText.Replace("،", "، ");

            //UpdatedText = UpdatedText.Replace(" ۔", "۔");
            //UpdatedText = UpdatedText.Replace("۔", "۔ ");

            //UpdatedText = UpdatedText.Replace(" :", ":");
            //UpdatedText = UpdatedText.Replace(":", ": ");

            foreach (List<string> line in AllTokens)
            {
                if (line.Count == 3)
                {
                    if (_isRegex)
                        UpdatedText = new StringBuilder(Regex.Replace(UpdatedText.ToString(), @"" + line[1], line[2]));
                }
                else
                {
                    UpdatedText = UpdatedText.Replace(line[0], line[1]);

                    MainForm form = (MainForm) Application.OpenForms["MainForm"];
                }
            }

            UpdatedText = UpdatedText.Replace(" ، ", "، ");
            //UpdatedText = UpdatedText.Replace(" ۔ ", "۔ ");
            //UpdatedText = UpdatedText.Replace(" : ", ": ");
        }

    }
}

