using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_Order", TableDescription = "订单表")]
    public class OrderEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
        public int OrderId { get; set; }


        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string OrderCode { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string OrderType { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string Remark { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string Creator { get; set; }

        [SugarColumn(ColumnDataType = "varchar(64)")]
        public string CreatDate { get; set; }
    }
}
