using JCF.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application.Services
{
    public class PermissionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        public PermissionService(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<List<string>> GetUserPermissionsAsync(int userId)
        {
            var userRoles = await _userRoleRepository.Query(p => p.UserId == userId);
            var rolePermissions = await _rolePermissionRepository.Query(p => p.RoleId == userRoles.FirstOrDefault().RoleId);
            var permissionIds= rolePermissions.Select(p => p.PermissionId).Distinct().ToList();
            var permissions = await _permissionRepository.Query(p => permissionIds.Contains(p.Id));
            return permissions.Select(p => p.Code).ToList();
        }
    }
}
