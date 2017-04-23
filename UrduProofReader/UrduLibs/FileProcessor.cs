using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrduLibs
{
    public class FileProcessor
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

        public FileProcessor(FileInfo fileInfo, bool regex, bool tokenOrder, bool fullWord)
        {
            this._fileInfo = fileInfo;
            init(regex, tokenOrder, fullWord);
        }

        public FileProcessor(DirectoryInfo dirInfo, bool regex, bool tokenOrder, bool fullWord)
        {
            this._directoryInfo = dirInfo;
            init(regex, tokenOrder, fullWord);
        }

        private void init(bool regex, bool tokenOrder, bool fullword)
        {
            _reader = new ProofReader(regex, tokenOrder, fullword);
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

                if (!Directory.Exists(Utils._updatedDirPath.FullName))
                {
                    Directory.CreateDirectory(Utils._updatedDirPath.FullName);
                }

                File.WriteAllText(Utils._updatedDirPath.FullName + "\\" + this._fileInfo.Name, _reader.UpdatedText.ToString());

                this.reportProgress(this, this._fileInfo);
            }
        }

        public void processDir()
        {
            Task.Factory.StartNew(processingFiles).ContinueWith(result => processingDone());

        }
    }
}
