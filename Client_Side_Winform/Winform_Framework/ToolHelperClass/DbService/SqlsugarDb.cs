using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolHelperClass.DbService
{
    public class SqlsugarDb : IDisposable
    {
        #region 属性
        private readonly SqlSugarScope _scope;
        private readonly string _connectionString;
        public SqlSugarScope Db => _scope;
        #endregion

        #region 构造函数
        public SqlsugarDb(string databasePath)
        {
            _connectionString = databasePath;
            _scope = new SqlSugarScope(new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = DbType.Sqlite,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute// 主键/自增列初始化方式
            },
            db =>
            {
                // 这里可以进行一些全局配置
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    //记录日志
                };
            });
        }
        #endregion

        #region 初始化数据库Codefirst
        public void InitializeDatabase<T>() where T : class, new()
        {
            _scope.CodeFirst.SetStringDefaultLength(200).InitTables<T>();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
