using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coldairarrow.Entity.Bill
{
    /// <summary>
    /// IsMatch_MoneyChange
    /// </summary>
    [Table("IsMatch_MoneyChange")]
    public class IsMatch_MoneyChange
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(Order = 1)]
        public String Id { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// CreatorId
        /// </summary>
        public String CreatorId { get; set; }

        /// <summary>
        /// Deleted
        /// </summary>
        public Boolean? Deleted { get; set; }

        /// <summary>
        /// CategoryID
        /// </summary>
        public Int32? CategoryID { get; set; }

        /// <summary>
        /// Titile
        /// </summary>
        public String Titile { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public DateTime? Time { get; set; }

        /// <summary>
        /// Money
        /// </summary>
        public Decimal? Money { get; set; }

        /// <summary>
        /// Remarks
        /// </summary>
        public String Remarks { get; set; }

        /// <summary>
        /// UpdateUserID
        /// </summary>
        public String UpdateUserID { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// MoneyFormula
        /// </summary>
        public Int32? MoneyFormula { get; set; }

        /// <summary>
        /// RecordTypeSourceID
        /// </summary>
        public Int32? RecordTypeSourceID { get; set; }

        /// <summary>
        /// CreateType
        /// </summary>
        public String CreateType { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public String Code { get; set; }

    }
}