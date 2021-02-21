using FileManager;
using System.IO;

namespace BasicCryptoTools
{
    public class HashGenerator
    {
        private readonly IFileManager _mgr;

        public HashGenerator()
        {
            _mgr = new LocalFileManager();
        }

        public string GetTextMd5Hash(string value)
        {
            return _mgr.GetTextMd5Hash(value);
        }

        public string GetFileMd5Hash(FileInfo fInfo)
        {
            return _mgr.GetFileMd5Hash(fInfo);
        }

        public string GetBytesMd5Hash(byte[] value)
        {
            return _mgr.GetBytesMd5Hash(value);
        }

        public string GetTextSha256Hash(string value)
        {
            return _mgr.GetTextSha256Hash(value);
        }

        public string GetFileSha256Hash(FileInfo fInfo)
        {
            return _mgr.GetFileSha256Hash(fInfo);
        }

        public string GetBytesSha256Hash(byte[] value)
        {
            return _mgr.GetBytesSha256Hash(value);
        }

        public string GetTextSha512Hash(string value)
        {
            return _mgr.GetTextSha512Hash(value);
        }

        public string GetFileSha512Hash(FileInfo fInfo)
        {
            return _mgr.GetFileSha512Hash(fInfo);
        }

        public string GetBytesSha512Hash(byte[] value)
        {
            return _mgr.GetBytesSha512Hash(value);
        }
    }
}
