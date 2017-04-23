using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;

namespace UrduLibs
{
    public class ProofReader
    {
        bool _error;
        StringBuilder _errorText;
        StringBuilder _allText;
        StringBuilder _updatedText;
        bool _isRegex = true;
        bool _isTokenOrder=false;
        bool _isFullWord = false;

        public bool IsError
        {
            get { return this._error; }
        }

        public bool FullWord
        {
            get { return this._isFullWord; }
            set { _isFullWord = value; }
        }

        public bool TokenOrder
        {
            get { return this._isTokenOrder; }
            set { _isTokenOrder = value; }
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

        public ProofReader(bool regex, bool tokenOrder, bool fullWord)
        {
            this._isRegex = regex;
            this._isTokenOrder = tokenOrder;
            this._isFullWord = fullWord;

            if (!Directory.Exists(Utils._basePath))
                Directory.CreateDirectory(Utils._basePath);

            validateCreateTokenFile();
        }

        public void validateCreateTokenFile()
        {
            if (!File.Exists(Utils._tokenFilePath.FullName))
            {
                File.WriteAllText(Utils._tokenFilePath.FullName, Utils._tokenList);
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

            DataTable dt = TokenDataSet.Instance.sorted(this.TokenOrder);


            foreach (DataRow line in dt.Rows)
            {
                if (bool.Parse(line[2]+""))
                {
                    if (IsRegex && !FullWord)
                        UpdatedText = new StringBuilder(Regex.Replace(UpdatedText.ToString(), @"" + line[0], line[1]+""));
                }
                else
                {
                    if (FullWord)
                    {
                        UpdatedText = new StringBuilder(Regex.Replace(UpdatedText.ToString(), @"\b" + line[0]+"\b", line[1] + ""));
                    }
                    else
                    {
                        UpdatedText = UpdatedText.Replace(line[0] + "", line[1] + "");
                    }
                }
            }

            UpdatedText = UpdatedText.Replace(" ، ", "، ");
        }

    }
}

