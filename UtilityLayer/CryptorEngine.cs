using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Drawing.Drawing2D;
//using System.Drawing;

namespace UtilityLayer
{
    public class CryptorEngine
    {
        #region Public Methods
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray=null;
            byte[] resultArray = null;
            byte[] toEncryptArray = null;
            MD5CryptoServiceProvider hashmd5 = null;
            TripleDESCryptoServiceProvider tdes = null;
            ICryptoTransform cTransform = null;
            try
             {

                 toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                 //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                 string key = "ABCDEFGHIJ";// (string)settingsReader.GetValue("SecurityKey", typeof(String));
                 if (useHashing)
                 {
                     hashmd5 = new MD5CryptoServiceProvider();
                     keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                     hashmd5.Clear();
                 }
                 else
                     keyArray = UTF8Encoding.UTF8.GetBytes(key);

                 tdes = new TripleDESCryptoServiceProvider();
                 tdes.Key = keyArray;
                 tdes.Mode = CipherMode.ECB;
                 tdes.Padding = PaddingMode.PKCS7;
                 cTransform = tdes.CreateEncryptor();
                 resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                 tdes.Clear();

                 return Convert.ToBase64String(resultArray, 0, resultArray.Length);
             }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 keyArray = null;
                 toEncryptArray = null;
                 resultArray = null;
                 if (hashmd5 != null) ((IDisposable)hashmd5).Dispose();
                 if (tdes != null) ((IDisposable)tdes).Dispose();
                 if (cTransform != null) ((IDisposable)cTransform).Dispose();
             }
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray=null;
            byte[] toEncryptArray = null;
            byte[] resultArray = null;
            MD5CryptoServiceProvider hashmd5 = null;
            TripleDESCryptoServiceProvider tdes = null;
            ICryptoTransform cTransform = null;
            try
            {
                
                toEncryptArray = Convert.FromBase64String(cipherString);
                //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
                string key = "ABCDEFGHIJ";
                if (useHashing)
                {
                    hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                cTransform = tdes.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                keyArray = null;
                toEncryptArray = null;
                resultArray = null;
                if (hashmd5 != null) ((IDisposable)hashmd5).Dispose();
                if (tdes != null) ((IDisposable)tdes).Dispose();
                if (cTransform != null) ((IDisposable)cTransform).Dispose();
            }
        }
        #endregion

        #region Encrypt-Decrypt Querystring
        #region Fields
        private static byte[] key = { };
        private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };
        private static string stringKey = "!5663a#KN";
        #endregion
        #region Methods
        public static string EncryptQueryString(string value)
        {
            DESCryptoServiceProvider des = null;
            Byte[] byteArray = null;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                des = new DESCryptoServiceProvider();
                byteArray = Encoding.UTF8.GetBytes(value);
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream,des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception)
            {
                // Handle Exception Here
                return string.Empty;
            }
            finally
            {
                byteArray = null;                
                if (des != null) ((IDisposable)des).Dispose();
                if (memoryStream != null) ((IDisposable)memoryStream).Dispose();
                if (cryptoStream != null) ((IDisposable)cryptoStream).Dispose();
            }
            
        }
        public static string DecryptQueryString(string value)
        {
            DESCryptoServiceProvider des =null;
            Byte[] byteArray = null;
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));
                des = new DESCryptoServiceProvider();
                byteArray = Convert.FromBase64String(value);
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(memoryStream,
                des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cryptoStream.Write(byteArray, 0, byteArray.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception)
            {
                // Handle Exception Here
                return string.Empty;
            }
            finally
            {
                byteArray = null;
                if (des != null) ((IDisposable)des).Dispose();
                if (memoryStream != null) ((IDisposable)memoryStream).Dispose();
                if (cryptoStream != null) ((IDisposable)cryptoStream).Dispose();
            }            
        }
        #endregion
        #endregion
    }
}
