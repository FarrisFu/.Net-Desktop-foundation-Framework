using JCF.Service.IServices;
using JCF.Service.Services;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service
{
    public static class ServiceRegistrar
    {
        /// <summary>
        /// 接口服务注册
        /// </summary>
        /// <param name="containerRegistry"></param>
        public static void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IAuthorizeService, AuthorizeService>();
            containerRegistry.Register<IGetOrderService, GetOrderService>();
        }
    }
}
