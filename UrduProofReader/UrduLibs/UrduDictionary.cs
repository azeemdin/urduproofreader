using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrduLibs
{
    public class UrduDictionary
    {
        StringBuilder _fullText;
        static UrduDictionary _me;

        public static UrduDictionary Instance
        {
            get
            {
                if (_me == null)
                    _me = new UrduDictionary();

                return _me;
            }
        }

        public StringBuilder FullText
        {
            get { return _fullText; }
        }

        public UrduDictionary()
        {
            if (!File.Exists(Utils._updatedDirPath.FullName))
            {
                File.WriteAllText(Utils._updatedDirPath.FullName, Utils._dicWords.ToString());
                _fullText = new StringBuilder(Utils._dicWords.ToString());
            }
            else
            {
                _fullText = new StringBuilder(File.ReadAllText(Utils._updatedDirPath.FullName));
            }
        }

        public void save(string newword)
        {
            if (!File.Exists(Utils._dicCustFilePath.FullName))
            {
                File.WriteAllText(Utils._dicCustFilePath.FullName, newword + "::");
                return;
            }

            File.AppendAllText(Utils._dicCustFilePath.FullName, newword+ "::");
        }
    }
}
