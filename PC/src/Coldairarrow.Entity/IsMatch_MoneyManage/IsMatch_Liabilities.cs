using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.IsMatch_MoneyManage
{
    /// <summary>
    /// IsMatch_Liabilities
    /// </summary>
    [Table("IsMatch_Liabilities")]
    public class IsMatch_Liabilities
    {

        /// <summary>
        /// Id
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// CreatorId
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// Deleted
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

        public Int32? Type { get; set; }


        public DateTime? Time { get; set; }

        /// <summary>
        /// Money
        /// </summary>
        public Decimal? Money { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public String Remark { get; set; }

    }
}