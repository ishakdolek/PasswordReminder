using System.Text;
using PCLCrypto;

namespace PasswordReminder.Extension
{
    public static class CrytpHelper
    {
        private static readonly string Pass = "pass";

        private static byte[] CreateSalt(int lengthInBytes)
        {
            return WinRTCrypto.CryptographicBuffer.GenerateRandom(lengthInBytes);
        }

        private static byte[] CreateDerivedKey(string password, byte[] salt, int keyLengthInBytes = 32, int iterations = 1000)
        {
            byte[] key = NetFxCrypto.DeriveBytes.GetBytes(password, salt, iterations, keyLengthInBytes);
            return key;
        }

        public static string Encrytp(string data)
        {
            var salt = CreateSalt(16);
            var result = EncryptAes(data, Pass, salt);
            return Encoding.UTF8.GetString(result, 0, result.Length);
        }

        public static string Decrytp(string data)
        {
            var salt = CreateSalt(16);
            var bytes = Encoding.UTF8.GetBytes(data);
            return DecryptAes(bytes, Pass, salt);
        }

        private static byte[] EncryptAes(string data, string password, byte[] salt)
        {
            byte[] key = CreateDerivedKey(password, salt);
            var aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var symetricKey = aes.CreateSymmetricKey(key);
            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(data));
            return bytes;
        }

        private static string DecryptAes(byte[] data, string password, byte[] salt)
        {
            byte[] key = CreateDerivedKey(password, salt);
            var aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var symetricKey = aes.CreateSymmetricKey(key);
            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(symetricKey, data);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
