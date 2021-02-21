using System.IO;

namespace BasicCryptoTools
{
    public static class Utils
    {
        public static FileInfo GetFileInfo(params string[] path)
        {
            return new FileInfo(Path.Combine(path));
        }
    }
}
