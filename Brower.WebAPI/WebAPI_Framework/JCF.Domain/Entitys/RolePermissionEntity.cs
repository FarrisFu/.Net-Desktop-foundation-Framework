using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_RolePermission", TableDescription = "角色权限表")]
    public class RolePermissionEntity
    {
       
        /// <summary>
        ///角色ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "角色ID")]
        public int RoleId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "权限ID")]
        public int PermissionId { get; set; }
    }
}
