using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Domain.Entitys
{
    [SugarTable("TAB_Dictionary", TableDescription = "通用字典")]
    public class DictionaryEntity
    {
        /// <summary>
        /// 主键ID，自增
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
        public int Id { get; set; }

        /// <summary>
        /// 字典类型
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)",  ColumnDescription = "字典类型")]
        public string DictType { get; set; }

        /// <summary>
        /// 字典编码，同类型下唯一
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", ColumnDescription = "字典编码")]
        public string DictCode { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "字典值")]
        public string DictValue { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "字典值英文")]
        public string DictValueEnglish { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [SugarColumn(ColumnDataType = "varchar(64)", IsNullable = true, ColumnDescription = "父节点")]
        public string DictFatherCode { get; set; }

    }
}
