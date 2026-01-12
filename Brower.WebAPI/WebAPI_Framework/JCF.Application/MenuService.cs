using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application
{
    public class MenuService
    {
        private readonly IDictionaryRepository _dictionaryRepository;
        public MenuService(IDictionaryRepository dictionaryRepository) 
        {
            _dictionaryRepository = dictionaryRepository;
        }

        //public static async Task<List<DictionaryEntity>> GetMenuByCode()
        //{
        //    //var menu = await _dictionaryRepository.Query(d => d.DictType == "Menu").Result;
        //    return menu;
        //}
    }
}
