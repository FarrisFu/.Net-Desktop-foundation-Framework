using JCF.Application.Contracts.Requests;
using JCF.Application.Contracts.Results;
using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application.Services
{
    public class AuthService
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly PermissionService _permissionService;
        private readonly IUserRepository _userRepository;

        public AuthService(JwtTokenService jwtTokenService, PermissionService permissionService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _permissionService = permissionService;
            _userRepository = userRepository;
        }

        public async Task<LoginResult> Login(LoginRequest request)
        {
            var user = await _userRepository.Query(p => p.UserName == request.UserName && p.Password == request.Password);
            if (user.Count != 1)
            {
                throw new UnauthorizedAccessException("用户名或密码错误");
            }

            var permissions = await _permissionService.GetUserPermissionsAsync(user[0].Id);
            var userEntity = new UserEntity { Id = 1, UserName = request.UserName, Password = request.Password };
            var token = _jwtTokenService.GenerateAccessToken(userEntity, permissions);

            return new LoginResult { Token = token };


        }
    }
}
