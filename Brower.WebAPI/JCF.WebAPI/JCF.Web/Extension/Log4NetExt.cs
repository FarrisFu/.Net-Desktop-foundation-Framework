using log4net;
using log4net.Config;
using System.Reflection;

namespace JCF.Web.Extension
{
    public static class Log4NetExt
    {
        private static bool _initialized ;
        public static void AddLog4Net(this WebApplicationBuilder builder)
        {
            if (_initialized) return;

            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            _initialized = true;
        }
    }
}
