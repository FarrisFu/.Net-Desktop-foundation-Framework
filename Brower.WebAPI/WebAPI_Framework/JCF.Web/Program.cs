
using JCF.Domain.Shared.models;
using JCF.Web.Extension;
using Microsoft.Extensions.Options;
using Autofac;
using Autofac.Extensions.DependencyInjection;

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
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<AppSetting>(builder.Configuration);//配置文件绑定到实体类
            builder.Services.AddSqlsugar(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<AppSetting>>());//添加SqlSugar服务扩展

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
