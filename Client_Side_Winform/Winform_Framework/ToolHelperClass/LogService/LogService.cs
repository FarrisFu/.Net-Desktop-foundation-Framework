using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToolHelperClass
{
    /// <summary>
    /// 单例日志服务类Log4net
    /// </summary>
    public class LogService
    {
        private static readonly ILog Logger;

        static LogService()
        {
            System.IO.FileInfo fileinfo = new System.IO.FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}/Config/log4net.config");
            log4net.Config.XmlConfigurator.Configure(fileinfo);
            Logger = LogManager.GetLogger("Log4net");
        }

        public static void Info(object message)
        {
            Logger.Info(message);
        }

        public static void Info(object message, Exception ex)
        {
            message = $"[{GetCurrentMethodFullName()}] {message}";
            Logger.Info(message, ex);
        }

        public static void Debug(object message)
        {
            Logger.Debug(message);
        }

        public static void Debug(object message, Exception ex)
        {
            message = $"[{GetCurrentMethodFullName()}] {message}";
            Logger.Debug(message, ex);
        }

        public static void Error(object message)
        {
            Logger.Error(message);
        }

        public static void Error(object message, Exception ex)
        {
            message = $"[{GetCurrentMethodFullName()}] {message}";
            Logger.Error(message, ex);
        }      

        public static void Warn(object message)
        {
            Logger.Warn(message);
        }

        public static void Warn(object message, Exception ex)
        {
            message = $"[{GetCurrentMethodFullName()}] {message}";
            Logger.Warn(message, ex);
        }

        /// <summary>
        /// 获取当前的类名.方法名
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentMethodFullName()
        {
            StackFrame frame;
            string str;
            string str1;
            bool flag;
            try
            {
                int num = 2;
                StackTrace stackTrace = new StackTrace();
                int length = stackTrace.GetFrames().Length;
                do
                {
                    int num1 = num;
                    num = num1 + 1;
                    frame = stackTrace.GetFrame(num1);
                    str = frame.GetMethod().DeclaringType.ToString();
                    flag = (!str.EndsWith("Exception") ? false : num < length);
                }
                while (flag);
                string name = frame.GetMethod().Name;
                str1 = string.Concat(str, ".", name);
            }
            catch
            {
                str1 = null;
            }
            return str1;
        }
    }
}
