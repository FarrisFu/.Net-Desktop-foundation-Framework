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
    public class MenuRepository:BaseRepository<MenuEntity>,IMenuRepository
    {
        public MenuRepository(IBaseDB<MenuEntity> baseDB)
        {
            base.BaseDB = baseDB;
        }
    }
}
