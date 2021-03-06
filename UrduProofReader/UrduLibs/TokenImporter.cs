﻿using System;
using System.Text;
using System.IO;

namespace UrduLibs
{
    public class TokenImporter
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
                    string[] tokens = oldLineText.ToString().Split(new char[] { '،' });
                    if (tokens.Length == 3 || tokens.Length == 2)
                    {
                        newLinestoAdd.Append(tokens[0] + "،" + tokens[1] + "\r\n");
                    }
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
