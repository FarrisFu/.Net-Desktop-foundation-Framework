using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
namespace JCF.Web.Extension.Authorize
{
    public static class JwtEventsFactory
    {
        public static JwtBearerEvents Create()
        {
            return new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();

                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        code = "TOKEN_EXPIRED",
                        message = "登录已过期，请重新登录"
                    });

                    return context.Response.WriteAsync(result);
                },
                OnForbidden = context =>
                {
                    context.Response.StatusCode = 403;
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        code = "FORBIDDEN",
                        message = "您没有权限访问此资源"
                    });

                    return context.Response.WriteAsync(result);
                }

            };
        }
    }
}
