using JCF.Application.Contracts.Results;
using JCF.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _IOrderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _IOrderRepository = orderRepository;
        }

        public async Task<GetOrderListResult> GetOrderList()
        {  
            var orderList = await _IOrderRepository.Query();
            return new GetOrderListResult
            {
                Orders = orderList
            };
        }
    }
}
