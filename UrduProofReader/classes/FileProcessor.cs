using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrduProofReader.classes
{
    class FileProcessor
    {
        FileInfo _fileInfo;
        DirectoryInfo _directoryInfo;
        ProofReader _reader;
        public event EventHandler<StringBuilder> endProcessing;
        public event EventHandler<FileInfo> reportProgress;

        public ProofReader Reader
        {
            get { return this._reader; }
        }

        public FileProcessor(FileInfo fileInfo, bool regex, bool tokenOrder)
        {
            this._fileInfo = fileInfo;
            init(regex, tokenOrder);
        }

        public FileProcessor(DirectoryInfo dirInfo, bool regex, bool tokenOrder)
        {
            this._directoryInfo = dirInfo;
            init(regex, tokenOrder);
        }

        private void init(bool regex, bool tokenOrder)
        {
            _reader = new ProofReader(regex, tokenOrder);
        }

        private void _processFile()
        {
            _reader.TextToProcess = new StringBuilder(File.ReadAllText(this._fileInfo.FullName));
            _reader.processText();
        }

        private void processingDone()
        {           
            endProcessing(this, this.Reader.ErrorText);
        }

        public void processFile()
        {
            Task.Factory.StartNew(_processFile).ContinueWith(result => processingDone());
        }

        public void processingFiles()
        {
            string[] allFiles = Directory.GetFiles(this._directoryInfo.FullName, "*.txt");
            foreach (string myFile in allFiles)
            {
                this._fileInfo = new FileInfo(myFile);
                _processFile();

                if (!Directory.Exists(Utils._basePath + "\\updated"))
                {
                    Directory.CreateDirectory(Utils._basePath + "\\updated");
                }

                File.WriteAllText(Utils._basePath + "\\updated\\" + this._fileInfo.Name, _reader.UpdatedText.ToString());

                this.reportProgress(this, this._fileInfo);
            }
        }

        public void processDir()
        {
            Task.Factory.StartNew(processingFiles).ContinueWith(result => processingDone());

        }
    }
}
