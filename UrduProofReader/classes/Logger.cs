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
        readonly object _lock = new object();


        public void error(Exception ex)
        {

            //if (File.Exists(Utils._basePath + "\\error.txt"))
            //{
            //    File.Create(Utils._basePath + "\\error.txt");
            //}
            StringBuilder errorString = new StringBuilder();
            errorString.Append(ex.Message + "\r\n");
            errorString.Append(ex.StackTrace + "\r\n");
            if (ex.InnerException != null)
            {
                errorString.Append(ex.InnerException.Message + "\r\n");
                errorString.Append(ex.InnerException.StackTrace + "\r\n");
            }



            lock (_lock)
            {
                using (FileStream file = new FileStream(Utils._basePath + "\\error.txt", FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                    {
                        writer.Write(DateTime.Now.ToShortDateString() + ": " + errorString.ToString());
                    }
                }
            }
        }
    }
}
