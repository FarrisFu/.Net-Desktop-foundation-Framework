using JCF.Domain.Shared.models;
using Microsoft.Extensions.Options;
using SqlSugar;
using System.Reflection;

namespace JCF.Web.Extension
{
    public static class SqlsugarExt
    {
        public static void AddSqlsugar(this IServiceCollection services, IConfiguration configuration)
        {
            // 从 appSettings 中获取连接字符串
            services.Configure<ConnectionStrings>(configuration.GetSection(ConnectionStrings.SectionName));//配置文件绑定到实体类
            var connection = configuration.GetSection(ConnectionStrings.SectionName)
                .Get<ConnectionStrings>()
                ?? throw new InvalidOperationException("无法获取数据库连接配置，请检查配置文件。");
            var connectionString = connection.Connection;
            if (connection.DbType == DataBaseType.Sqlite)
                connectionString = $"DataSource={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, connection.Connection)};Version=3;";
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

                var db = new SqlSugarClient(connectionConfig);
                InitDatabaseFromDll(db);//批量建表

                return db;
            });
        }

        /// <summary>
        /// 批量建表
        /// </summary>
        /// <param name="db"></param>
        private static void InitDatabaseFromDll(SqlSugarClient db)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var domainDllFile = Path.Combine(basePath, "JCF.Domain.dll");
            if (!File.Exists(domainDllFile))
                return;

            var assembly = Assembly.LoadFrom(domainDllFile);

            var entityTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "JCF.Domain.Entitys")
                .ToArray();

            //批量创建表
            db.CodeFirst.InitTables(entityTypes);
        }
    }
}
