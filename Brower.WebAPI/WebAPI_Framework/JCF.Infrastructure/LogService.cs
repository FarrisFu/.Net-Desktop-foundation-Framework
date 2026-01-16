using log4net;

namespace JCF.Infrastructure
{
    /// <summary>
    /// 单例日志服务类Log4net
    /// </summary>
    public class LogService
    {
        private static readonly ILog Logger;

        static LogService()
        {
            Logger = LogManager.GetLogger(typeof(LogService));
        }

        public static void Info(object message)
        {
            Logger.Info(message);
        }

        public static void Info(object message, Exception ex)
        {
            Logger.Info(message, ex);
        }

        public static void Debug(object message)
        {
            Logger.Debug(message);
        }

        public static void Debug(object message, Exception ex)
        {
            Logger.Debug(message, ex);
        }

        public static void Error(object message)
        {
            Logger.Error(message);
        }

        public static void Error(object message, Exception ex)
        {
            Logger.Error(message, ex);
        }

        public static void Warn(object message)
        {
            Logger.Warn(message);
        }

        public static void Warn(object message, Exception ex)
        {
            Logger.Warn(message, ex);
        }
    }
}
