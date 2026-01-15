using JCF.Application.Contracts.Requests;
using JCF.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace JCF.Web.Controllers
{
    /// <summary>
    /// 权限认证
    /// </summary>

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// 用户登录接口
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest user)
        {
            try
            {
                var response = await _authService.Login(user);
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                // 处理其他异常
                return StatusCode(500, "内部服务器错误");
            }
        }
    }

}

