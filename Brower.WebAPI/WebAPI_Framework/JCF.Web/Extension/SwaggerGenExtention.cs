using Microsoft.OpenApi.Models;
using System.Reflection;

namespace JCF.Web.Extension
{
    public static class SwaggerGenExtention
    {
        public static void AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                //添加XML注释(需要设置文件输出选项)
                string xmlFile=Path.Combine(AppContext.BaseDirectory,Assembly.GetExecutingAssembly().GetName().Name + ".xml");
                option.IncludeXmlComments(xmlFile, true);

                //JWT 身份验证配置
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "请输入Bearer后跟空格和JWT令牌，例如：Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                //添加安全要求
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });



        }
    }
}
