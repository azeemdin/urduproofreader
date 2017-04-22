using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrduProofReader.classes
{
    class Logger
    {
        public static void log(string message)
        {
            if (File.Exists(Utils._basePath + "\\error.txt"))
            {
                File.Create(Utils._basePath + "\\error.txt");
            }

            File.AppendAllText(Utils._basePath + "\\error.txt",DateTime.Now.ToShortDateString()  + ": " + message);
        }
    }
}
