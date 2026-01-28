using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    public class OrderEntity
    {
        public int OrderId { get; set; }


        public string OrderCode { get; set; }


        public string OrderType { get; set; }


        public string Remark { get; set; }


        public string Creator { get; set; }


        public string CreatDate { get; set; }
    }
}
