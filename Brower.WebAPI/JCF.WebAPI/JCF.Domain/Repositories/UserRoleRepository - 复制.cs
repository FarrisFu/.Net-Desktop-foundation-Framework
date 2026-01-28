using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using JCF.Infrastructure.Sqlsugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Repositories
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(IBaseDB<OrderEntity> baseDB)
        {
            base.BaseDB = baseDB;
        }
    }
}
