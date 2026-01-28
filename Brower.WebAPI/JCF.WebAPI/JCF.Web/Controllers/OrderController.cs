using JCF.Application.Contracts.Results;
using JCF.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JCF.Web.Controllers
{
    /// <summary>
    /// 订单接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly OrderService _OrderService;
        public OrderController(OrderService orderService)
        {
            _OrderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            GetOrderListResult result = await _OrderService.GetOrderList();            
            return Ok(result);
        }
    }
}
