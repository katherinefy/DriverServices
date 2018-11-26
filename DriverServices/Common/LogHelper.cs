using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DriverServices.Common
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string content)
        {
            string sPath = AppContext.BaseDirectory+"\\Logs\";// Path.Combine(AppContext.BaseDirectory, "DriverServices.xml");
            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
            string sFile = sPath + "\\Log_" + DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "") + ".log";
            File.AppendAllText(sFile, string.Format("{0:yyyy-MM-dd HH:mm:ss}\r\n{1}\r\n", DateTime.Now, content));
        }
    }
}
