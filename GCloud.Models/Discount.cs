using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Discount", Schema = "Tenant")]
    public class Discount : EntityBase
    {
        /// <summary>
        /// Gets or sets the DiscountType. 
        /// </summary>
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Gets or sets the Percentage. 
        /// </summary>
        public long Percentage { get; set; }

        /// <summary>
        /// Gets or sets the Amount. 
        /// </summary>
        public long Amount { get; set; }

        /// <summary>Gets or sets the InvoiceId. </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>Gets or sets the Invoice. </summary>
        public Invoice Invoice { get; set; }
    }

    public enum DiscountType
    {
        Percentage,
        Amount
    }
}
