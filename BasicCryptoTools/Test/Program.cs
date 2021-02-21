using BasicCryptoTools;
using System.Diagnostics;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var originalFile1 = Utils.GetFileInfo("Test.txt");
            var originalFile2 = Utils.GetFileInfo("Untitled 1.odt");

            var aes = new AesCrypto();
            aes.EncryptFile(originalFile1, password: "secret", output: "encrypted");
            aes.DecryptFile(Utils.GetFileInfo("encrypted"), "secret", "decrypted");

            aes.EncryptFile(originalFile2, password: "secret", output: "encrypted2");
            aes.DecryptFile(Utils.GetFileInfo("encrypted2"), "secret", "decrypted2");

            var hashGen = new HashGenerator();
            var originalHash = hashGen.GetFileSha512Hash(originalFile1);
            var decryptedHash = hashGen.GetFileSha512Hash(Utils.GetFileInfo("decrypted"));
            Debug.Assert(originalHash == decryptedHash);

            var base64gen = new Base64();
            var base64_String = base64gen.EncodeText("test string");
            var base64_File = base64gen.EncodeFile(originalFile2);
            Debug.Assert("test string" == base64gen.DecodeText(base64_String));

            _ = base64gen.DecodeFile(base64_File, "decoded_base64.odt");
        }
    }
}
