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
    public class DictionaryRepository:BaseRepository<DictionaryEntity>,IDictionaryRepository
    {
        public DictionaryRepository(IBaseDB<DictionaryEntity> baseDB)
        {
            base.BaseDB = baseDB;
        }
    }
}
