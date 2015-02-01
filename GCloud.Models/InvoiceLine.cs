using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("InvoiceLine", Schema = "Tenant")]
    public class InvoiceLine : EntityBase
    {
        /// <summary>
        /// Gets or sets the Price. 
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Gets or sets the Cost. 
        /// </summary>
        public long Cost { get; set; }

        /// <summary>
        /// Gets or sets the TaxAmount. 
        /// </summary>
        public long TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the Total. 
        /// </summary>
        public long Total { get; set; }

        /// <summary>
        /// Gets or sets the Description. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Title. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Quantity. 
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>Gets or sets the InvoiceId. </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>Gets or sets the Invoice. </summary>
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Gets or sets the LineType. 
        /// </summary>
        public LineType LineType { get; set; }
    }

    public enum LineType
    {
        Service,
        Product
    }
}
