using JCF.Application;
using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

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
            var menu = await _dictionaryRepository.Query();
            return Ok(menu);
        }

    }
}
