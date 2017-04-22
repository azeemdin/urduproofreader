using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace UrduProofReader.classes
{
    class TokenImporter
    {
        FileInfo _fileInfo;
        StringBuilder oldTokenFile;
        StringBuilder newTokenFile;

        public TokenImporter(string filePath)
        {
            _fileInfo = new FileInfo(filePath);
        }

        public int import()
        {
            int i = 0;
            newTokenFile = new StringBuilder(File.ReadAllText(Utils._tokenFilePath.FullName));
            oldTokenFile = new StringBuilder(File.ReadAllText(_fileInfo.FullName));
            StringBuilder newLinestoAdd = new StringBuilder();
            StringBuilder oldLineText = new StringBuilder();
            string[] newLines = newTokenFile.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);

            string[] oldLines = oldTokenFile.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            bool exists = false;
            foreach (string oldLine in oldLines)
            {
                exists = false;
                oldLineText.Clear();
                oldLineText.Append(oldLine);
                foreach (string newLine in newLines)
                {
                    if (newLine.Equals(oldLine))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    newLinestoAdd.Append(oldLineText.ToString() + "\r\n");
                    i++;
                }
            }

            if (newLinestoAdd.ToString().Contains("\r\n"))
            {
                File.AppendAllText(Utils._tokenFilePath.FullName, newLinestoAdd.ToString().Substring(0, newLinestoAdd.Length - 1));
            }

            return i;
        }
    }
}
