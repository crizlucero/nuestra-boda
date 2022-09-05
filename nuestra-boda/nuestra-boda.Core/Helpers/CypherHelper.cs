using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace nuestra_boda.Core.Helpers
{
    public static class CypherHelper
    {
        static readonly string SecretKey = "Vm4XZSm8";
        static readonly string PublicKey = "MG9mQmXk";
        public static string Encrypt(string plainText)
        {
            try
            {
                string ToReturn = "";
                byte[] secretkeyByte = Array.Empty<byte>();
                secretkeyByte = Encoding.UTF8.GetBytes(SecretKey);
                byte[] publickeybyte = Array.Empty<byte>();
                publickeybyte = Encoding.UTF8.GetBytes(PublicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(plainText);
                using (DESCryptoServiceProvider des = new())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string Decrypt(string encryptedText)
        {
            try
            {
                string ToReturn = "";
                byte[] privatekeyByte = Array.Empty<byte>();
                privatekeyByte = Encoding.UTF8.GetBytes(SecretKey);
                byte[] publickeybyte = Array.Empty<byte>();
                publickeybyte = Encoding.UTF8.GetBytes(PublicKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[encryptedText.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(encryptedText.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new ())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
