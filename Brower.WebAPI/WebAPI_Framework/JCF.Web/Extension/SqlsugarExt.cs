using JCF.Domain.Shared.models;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace JCF.Web.Extension
{
    public static class SqlsugarExt
    {      
        public static void AddSqlsugar(this IServiceCollection services, IOptions<AppSetting> appsetting)
        {
            // 从 appSettings 中获取连接字符串
            //var connectionPath = appsetting.Value.ConnectionStrings.DefaultConnection ;
            var connectionString = $"DataSource={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LocalData", "LocalData.db")};Version=3;";
            services.AddScoped<ISqlSugarClient>(option =>
            {
                var connectionConfig = new ConnectionConfig
                {
                    ConnectionString = connectionString,
                    DbType = DbType.Sqlite,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                    //todo 添加SQL执行记录
                };

                return new SqlSugarClient(connectionConfig);
            });
        }


    }
}
