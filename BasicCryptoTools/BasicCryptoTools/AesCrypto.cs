using FileManager;
using System.IO;
using System.Security.Cryptography;

namespace BasicCryptoTools
{
    public class AesCrypto
    {
        private readonly IFileManager _mgr;
        public byte[] Salt { get; set; }

        public AesCrypto()
        {
            _mgr = new LocalFileManager();
            Salt = new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 };
        }

        public byte[] EncryptText(string input, string password, EncodingEnums encoding = EncodingEnums.UTF8)
        {
            return Encrypt(encoding.GetEncoding().GetBytes(input), password);
        }

        public string DecryptText(byte[] encryptedText, string password, EncodingEnums encoding = EncodingEnums.UTF8)
        {
            return encoding.GetEncoding().GetString(Decrypt(encryptedText, password));
        }

        public FileInfo EncryptFile(FileInfo input, string password, params string[] output)
        {
            var bytes = _mgr.ReadBinaryFile(input);
            var encryptedBytes = Encrypt(bytes, password);
            return _mgr.WriteBinaryFile(Path.Combine(output), encryptedBytes, true);
        }

        public FileInfo DecryptFile(FileInfo input, string password, params string[] output)
        {
            var bytes = _mgr.ReadBinaryFile(input);
            var decryptedBytes = Decrypt(bytes, password);
            return _mgr.WriteBinaryFile(Path.Combine(output), decryptedBytes, true);
        }

        private byte[] Encrypt(byte[] input, string password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Salt);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }

        private byte[] Decrypt(byte[] input, string password)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Salt);
            MemoryStream ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
