using JCF.Service.HttpCore;
using JCF.Service.ModelResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.IServices
{
    public interface IGetOrderService
    {
        Task<HttpResult<GetOrdersResult>> GetOrders();
    }
}
