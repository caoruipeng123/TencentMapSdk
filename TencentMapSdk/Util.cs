using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TencentMapSdk
{
    /// <summary>
    /// 
    /// </summary>
    public class Util
    {
        /// <summary>
        /// 获取md5加密字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="salt">在尾部添加随机字符串</param>
        /// <returns></returns>
        public static string MD5(string str, string salt = "")
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] buffer = null;
            buffer = Encoding.UTF8.GetBytes(str + salt);
            byte[] newBuffer = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in newBuffer)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
