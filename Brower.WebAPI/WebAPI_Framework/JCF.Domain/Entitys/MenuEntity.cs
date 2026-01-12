using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_Menu", TableDescription = "菜单")]
    public class MenuEntity
    {
        /// <summary>
        /// 主键ID，自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int Id { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "菜单类型")]
        public string MenuType { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "菜单编码")]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单名
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "菜单名")]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单名英文
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "菜单名英文")]
        public string MenuNameEnglish { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "父菜单")]
        public string MenuFatherCode { get; set; }
        /// <summary>
        /// 菜单dll
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "菜单dll")]
        public string MenuDllName { get; set; }
        /// <summary>
        /// 菜单函数名
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "菜单函数名")]
        public string MenuFunName { get; set; }
    }
}
