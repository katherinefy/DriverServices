using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DriverServices.Common
{
    public class SecurityHelper
    {
        /// <summary>
        /// Md5加密 UTF-8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Md5(string str)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] data = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}


