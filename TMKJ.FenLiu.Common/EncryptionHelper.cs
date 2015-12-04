using System;
using System.Security.Cryptography;
using System.Text;

namespace TMKJ.FenLiu.Common
{
    /// <summary>
    /// 加密与解密辅助类
    /// </summary>
    public class Md5Encryption : IEncrypt
    {
        //密钥
        private string _salt { get; set; }

        /// <summary>
        /// Md5附带密钥加密与解密
        /// </summary>
        /// <param name="salt"></param>
        public Md5Encryption(string salt)
        {
            _salt = salt;
        }

        /// <summary>
        /// Md5密钥加密与解密
        /// </summary>
        public Md5Encryption()
            : this("")
        { }

        //加密
        public string EncryptData(string plaintext)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                string hashCode = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(plaintext))).Replace("-", "") + BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(_salt))).Replace("-", "");
                return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(hashCode))).Replace("-", "");
            }
        }

        //解密
        public string DecryptData(string ciphertext)
        {
            throw new NotImplementedException("无法对MD5加密的密文进行解密");
        }
    }


    #region 加密与解密接口定义
    /// <summary>
    /// 加密与解密接口
    /// </summary>
    public interface IEncrypt
    {
        /// <summary>
        /// 将指定明文加密为密文
        /// </summary>
        /// <param name="plaintext">要加密的明文</param>
        /// <returns>加密后的密文</returns>
        string EncryptData(string plaintext);


        /// <summary>
        /// 将指定的密文解密为明文
        /// </summary>
        /// <param name="ciphertext">要解密的密文</param>
        /// <returns>解密后的明文</returns>
        string DecryptData(string ciphertext);

    }
    #endregion
}
