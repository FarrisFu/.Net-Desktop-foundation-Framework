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

        public HomeController(IDictionaryRepository dictionaryRepository)
        {
            _dictionaryRepository = dictionaryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            LogService.Info("用户登录请求开始");
            LogService.Warn("这是一个警告日志示例");
            LogService.Error("这是一个错误日志示例");
            LogService.Debug("这是一个调试日志示例");
            throw new Exception("测试全局异常日志记录");
            throw new InParametersException("参数不合法");
            var menu = await _dictionaryRepository.Query();
            return Ok(menu);
        }

    }
}
