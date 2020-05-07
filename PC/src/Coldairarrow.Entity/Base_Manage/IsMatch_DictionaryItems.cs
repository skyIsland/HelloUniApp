using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Base_Manage
{
    /// <summary>
    /// 数据字典项
    /// </summary>
    [Table("IsMatch_DictionaryItems")]
    public class IsMatch_DictionaryItems
    {

        /// <summary>
        /// 自然主键
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// 否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// 数据字典编码
        /// </summary>
        public String DictionaryItemCode { get; set; }

        /// <summary>
        /// 数据字典项文本
        /// </summary>
        public String DictionaryItemText { get; set; }

        /// <summary>
        /// 所属数据字典
        /// </summary>
        public String DictionaryId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public Int32? Rank { get; set; }

    }
}