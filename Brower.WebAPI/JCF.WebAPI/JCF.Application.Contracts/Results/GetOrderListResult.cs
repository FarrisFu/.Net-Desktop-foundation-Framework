using JCF.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application.Contracts.Results
{
    public class GetOrderListResult
    {
        public List<OrderEntity> Orders { get; set; }
    }
}
