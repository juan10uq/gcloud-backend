using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Invoice", Schema = "Tenant")]
    public class Invoice : EntityBase
    {
        /// <summary>
        /// Gets or sets the Number. 
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the Note. 
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the Register. 
        /// </summary>
        public string Register { get; set; }

        /// <summary>
        /// Gets or sets the GrandTotal. 
        /// </summary>
        public long GrandTotal { get; set; }

        /// <summary>
        /// Gets or sets the TotalTax. 
        /// </summary>
        public long TotalTax { get; set; }

        /// <summary>
        /// Gets or sets the Balance. 
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// Gets or sets the Total. 
        /// </summary>
        public long Discount { get; set; }

        /// <summary>
        /// Gets or sets the Status. 
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the SubTotal. 
        /// </summary>
        public long SubTotal { get; set; }

        /// <summary>Gets or sets the CustomerId. </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>Gets or sets the Customer. </summary>
        public Customer Customer { get; set; }

        /// <summary>Gets or sets the GymId. </summary>
        public Guid? GymId { get; set; }

        /// <summary>Gets or sets the Gym. </summary>
        public Gym Gym { get; set; }

        /// <summary>Gets or sets the InvoiceLines. </summary>
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        /// <summary>Gets or sets the PaymentInvoices. </summary>
        public virtual ICollection<PaymentInvoice> PaymentInvoices { get; set; }

        /// <summary>Gets or sets the Discounts. </summary>
        public virtual ICollection<Discount> Discounts { get; set; }
    }

    public enum Status
    {
        Closed,
        Parked
    }
}
