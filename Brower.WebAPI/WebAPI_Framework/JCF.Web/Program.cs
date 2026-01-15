
using JCF.Domain.Shared.models;
using JCF.Web.Extension;
using Microsoft.Extensions.Options;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JCF.Web.Extension.Authorize;

namespace JCF.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //创建Autofac容器
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            //注册Autofac模块
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterAutofacModules();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //添加Swagger服务扩展
            builder.Services.AddSwaggerGen();

            //添加SqlSugar服务扩展
            builder.Services.AddSqlsugar(builder.Configuration);

            //添加Jwt认证服务扩展
            builder.Services.AddJwtAuthentication(builder.Configuration);
            //添加授权策略服务扩展
            builder.Services.AddAuthorizationPolicies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //添加权限验证中间件
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
