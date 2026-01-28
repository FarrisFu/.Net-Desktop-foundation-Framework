using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_Permission", TableDescription = "权限表")]
    public class PermissionEntity
    {
        /// <summary>
        /// 主键ID，自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int Id { get; set; }

        /// <summary>
        ///权限代码
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "权限代码")]
        public string Code { get; set; }//user.read / order.approve


        /// <summary>
        /// 权限名称
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "权限名称")]
        public string Name { get; set; }
    }
}
