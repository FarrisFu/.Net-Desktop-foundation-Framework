using JCF.Application;
using JCF.Application.Contracts.Requests;
using JCF.Application.Services;
using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JCF.Web.Controllers
{
    /// <summary>
    /// 权限测试器
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly PermissionService _permissionService;
        public UserController(JwtTokenService jwtTokenService, PermissionService permissionService)
        {
            _jwtTokenService = jwtTokenService;
            _permissionService = permissionService;
        }

        /// <summary>
        /// 固定登录接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest user)
        {
            // ⚠️ 示例：真实项目中要查数据库
            if (user.UserName == "admin" && user.Password == "123456")
            {
                //var permisions = new List<string>();
                //permisions.Add("user.read");
                //permisions.Add("order.approve");

                var permisions = await _permissionService.GetUserPermissionsAsync(2);
                var userEntity = new UserEntity { Id = 1, UserName = user.UserName, Password = user.Password };

                var token = _jwtTokenService.GenerateAccessToken(userEntity, permisions);

                return Ok(new
                {
                    token
                });
            }

            return Unauthorized("用户名或密码错误");
        }
        /// <summary>
        /// 查看用户列表
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "UserRead")]
        [HttpPost]
        public IActionResult ListUsers()
        {
            return Ok("可以查看用户");
        }
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "UserWrite")]
        [HttpPost]
        public IActionResult EditUser()
        {
            return Ok("可以编辑用户");
        }
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = "OrderApprove")]
        [HttpPost()]
        public IActionResult Approve()
        {
            return Ok("订单已审核");
        }
    }

}
