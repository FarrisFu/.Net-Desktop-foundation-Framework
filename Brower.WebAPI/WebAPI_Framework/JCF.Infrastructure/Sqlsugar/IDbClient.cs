using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Infrastructure.Sqlsugar
{
    public interface IDbClient
    {
        SqlSugarClient GetDbClient();

        void BeginTran();
        void CommitTran();
        void RollbackTran();


    }
}
