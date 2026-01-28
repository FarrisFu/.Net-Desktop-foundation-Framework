using JCF.Service.HttpCore;
using JCF.Service.ModelRequests;
using JCF.Service.ModelResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.IServices
{
    public interface IAuthorizeService
    {
        Task<HttpResult<LoginResult>> Login(LoginRequest user);
    }
}
