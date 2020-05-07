using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Base_Manage
{
    /// <summary>
    /// 数据字典
    /// </summary>
    [Table("IsMatch_Dictionary")]
    public class IsMatch_Dictionary
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
        public String DictionaryCode { get; set; }

        /// <summary>
        /// 数据字典名称
        /// </summary>
        public String DictionaryName { get; set; }

        /// <summary>
        /// 数据字典描述
        /// </summary>
        public String Description { get; set; }

    }
}