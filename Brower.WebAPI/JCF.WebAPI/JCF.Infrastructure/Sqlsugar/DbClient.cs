using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Infrastructure.Sqlsugar
{
    public class DbClient : IDbClient
    {
        private readonly ISqlSugarClient _dbClient;

        public DbClient(ISqlSugarClient dbClient)
        {
            _dbClient = dbClient;
        }

        /// <summary>
        /// 获取SqlSugarClient对象
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetDbClient()
        {
           return _dbClient as SqlSugarClient;
        }

        public void BeginTran()
        {
            GetDbClient().BeginTran();
        }

        public void CommitTran()
        {
            try
            {
                GetDbClient().CommitTran();
            }
            catch (Exception ex)
            {
                GetDbClient().RollbackTran();
                throw;
            }
        }

     
        public void RollbackTran()
        {
            GetDbClient().RollbackTran();
        }
    }
}
