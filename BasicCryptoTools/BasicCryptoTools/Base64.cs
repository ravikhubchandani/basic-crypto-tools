using FileManager;
using System.IO;

namespace BasicCryptoTools
{
    public class Base64
    {
        private readonly IFileManager _mgr;

        public Base64()
        {
            _mgr = new LocalFileManager();
        }

        public string EncodeText(string value)
        {
            return _mgr.EncodeTextBase64String(value);
        }

        public FileInfo EncodeText(string value, params string[] output)
        {
            string base64 = _mgr.EncodeTextBase64String(value);
            return _mgr.WriteTextFile(_mgr.GetFileInfo(output), base64, EncodingEnums.ASCII, overwrite: true);
        }

        public string DecodeText(string base64value)
        {
            return _mgr.DecodeTextBase64String(base64value);
        }

        public FileInfo DecodeText(string base64value, params string[] output)
        {
            string decodedBase64 = _mgr.DecodeTextBase64String(base64value);
            return _mgr.WriteTextFile(_mgr.GetFileInfo(output), decodedBase64, EncodingEnums.UTF8, overwrite: true);
        }

        public string EncodeFile(FileInfo fInfo)
        {
            return _mgr.EncodeFileBase64String(fInfo);
        }

        public FileInfo EncodeFile(FileInfo fInfo, params string[] output)
        {
            string base64 = _mgr.EncodeFileBase64String(fInfo);
            return _mgr.WriteTextFile(_mgr.GetFileInfo(output), base64, EncodingEnums.ASCII, overwrite: true);
        }

        public byte[] DecodeFile(string base64value)
        {
            return _mgr.DecodeFileBase64String(base64value);
        }

        public FileInfo DecodeFile(string base64value, params string[] output)
        {
            byte[] decodedBase64 = _mgr.DecodeFileBase64String(base64value);
            return _mgr.WriteBinaryFile(Path.Combine(output), decodedBase64, overwrite: true);
        }
    }
}
