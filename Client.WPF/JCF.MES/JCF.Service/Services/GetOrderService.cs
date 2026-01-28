using JCF.Service.HttpCore;
using JCF.Service.IServices;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.Services
{
    internal class GetOrderService : IGetOrderService
    {
        public async Task<HttpResult<GetOrdersResult>> GetOrders()
        {
            var result = await HttpHelper.GetAsync<GetOrdersResult>("Order/GetOrders");
            return result;
        }
    }
}
