using JCF.Service.HttpCore;
using JCF.Service.IServices;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        public async Task<HttpResult<LoginResult>> Login(LoginRequest user)
        {
            var  result = await HttpHelper.PostAsync<LoginRequest, LoginResult>("Auth/login", user);
            return result;
        }
    }
}
