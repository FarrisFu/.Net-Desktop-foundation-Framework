using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_User", TableDescription = "用户表")]
    public class UserEntity
    {
        /// <summary>
        /// 主键ID，自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "用户名")]
        public string UserName { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "密码")]
        public string Password { get; set; }
    }
}
