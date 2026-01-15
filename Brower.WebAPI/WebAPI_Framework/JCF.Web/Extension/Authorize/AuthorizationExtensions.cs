using Microsoft.AspNetCore.Authorization;
namespace JCF.Web.Extension.Authorize
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserRead",
                    p => p.RequireClaim("permission", "user.read"));

                options.AddPolicy("UserWrite",
                   p => p.RequireClaim("permission", "user.write"));

                options.AddPolicy("OrderApprove",
                    p => p.RequireClaim("permission", "order.approve"));

                options.AddPolicy("SystemConfig",
                    p => p.RequireClaim("permission", "system.config"));
            });

            return services;
        }
    }
}
