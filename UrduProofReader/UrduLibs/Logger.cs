using System;
using System.Text;
using System.IO;

namespace UrduLibs
{
    public class Logger
    {
        readonly object _lock = new object();


        public void error(Exception ex)
        {
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
                using (FileStream file = new FileStream(Utils._tokenFilePath.FullName , FileMode.Append, FileAccess.Write, FileShare.Read))
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
