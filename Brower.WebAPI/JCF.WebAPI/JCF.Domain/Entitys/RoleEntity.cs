using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_Role", TableDescription = "角色表")]
    public class RoleEntity
    {
        /// <summary>
        /// 主键ID，自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int Id { get; set; }

        /// <summary>
        /// 角色代码
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "角色代码")]
        public string Code { get; set; }//-- admin / auditor / user


        /// <summary>
        ///角色名称
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "角色名称")]
        public string Name { get; set; }//-- 管理员 / 审核员
    }
}
