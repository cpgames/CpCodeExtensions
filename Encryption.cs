using System;
using System.Security.Cryptography;
using System.Text;

namespace cpGames.core
{
    public static class Encryption
    {
        #region Fields
        public static readonly Encoding encoding = Encoding.Unicode;
        #endregion

        #region Methods
        public static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public static byte[] Hash(byte[] msg, string salt)
        {
            var msgWithSalt = ByteArrayToString(msg) + salt;
            return SHA256.Create().ComputeHash(StringToByteArray(msgWithSalt));
        }

        public static byte[] Encrypt(byte[] msg, string key)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(key);
            return rsa.Encrypt(msg, false);
        }

        public static byte[] Encrypt(string msg, string key)
        {
            return Encrypt(StringToByteArray(msg), key);
        }

        public static byte[] Decrypt(byte[] encryptedMsg, string key)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(key);
            return rsa.Decrypt(encryptedMsg, false);
        }

        public static byte[] StringToByteArray(string msg)
        {
            return encoding.GetBytes(msg);
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            return encoding.GetString(bytes);
        }

        public static string GenerateKeyPair(out string privateKey)
        {
            var rsa = new RSACryptoServiceProvider();
            privateKey = rsa.ToXmlString(true);
            return rsa.ToXmlString(false);
        }
        #endregion
    }
}