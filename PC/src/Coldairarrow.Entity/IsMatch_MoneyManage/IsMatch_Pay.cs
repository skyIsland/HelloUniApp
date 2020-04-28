using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IsMatch_MoneyManage
{
    /// <summary>
    /// 支出表
    /// </summary>
    [Table("IsMatch_Pay")]
    public class IsMatch_Pay
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
        /// 是否已删除
        /// </summary>
        public Boolean Deleted { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public Int32? Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public Int32? Month { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        public Int32? Day { get; set; }

        /// <summary>
        /// 支出时间
        /// </summary>
        public DateTime? PayTime { get; set; }

        /// <summary>
        /// 支出方式
        /// </summary>
        public Int32? PayWay { get; set; }

        /// <summary>
        /// 支付金额
        /// </summary>
        public Decimal? Money { get; set; }

        /// <summary>
        /// PayType
        /// </summary>
        public Int32? PayType { get; set; }

        public String Remark { get; set; }

    }
}