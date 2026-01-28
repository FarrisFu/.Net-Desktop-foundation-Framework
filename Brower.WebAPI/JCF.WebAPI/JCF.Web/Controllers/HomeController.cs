using JCF.Application;
using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using JCF.Domain.Shared.Exceptions;
using JCF.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace JCF.Web.Controllers
{
    /// <summary>
    /// 数据库测试器
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        private readonly IOrderRepository _IOrderRepository;

        public HomeController(IDictionaryRepository dictionaryRepository, IOrderRepository orderRepository)
        {
            _dictionaryRepository = dictionaryRepository;
            _IOrderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            LogService.Info("用户登录请求开始");
            LogService.Warn("这是一个警告日志示例");
            LogService.Error("这是一个错误日志示例");
            LogService.Debug("这是一个调试日志示例");
            //throw new Exception("测试全局异常日志记录");
            //throw new InParametersException("参数不合法");

            //List<OrderEntity> orderList = new List<OrderEntity>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    orderList.Add(new OrderEntity()
            //    {
            //        OrderCode = "Order" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + i,
            //        OrderType = "Type" + "test",
            //        Remark = "这是一个测试订单" ,
            //        Creator = "Admin",
            //        CreatDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")
            //    });

            //}
            //int xx=await _IOrderRepository.Add(orderList);


            var menu = await _dictionaryRepository.Query();
            return Ok(menu);
        }

    }
}
