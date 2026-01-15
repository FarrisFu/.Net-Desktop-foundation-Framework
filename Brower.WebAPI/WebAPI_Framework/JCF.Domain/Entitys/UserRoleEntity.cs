using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_UserRole", TableDescription = "用户角色表")]
    public class UserRoleEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "用户ID")]
        public int UserId { get; set; }


        /// <summary>
        ///角色ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "角色ID")]
        public int RoleId { get; set; }
    }
}
