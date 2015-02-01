using System;

namespace GCloud.Models
{
    public class PaymentInvoice: EntityBase
    {
        /// <summary>
        /// Gets or sets the Amount. 
        /// </summary>
        public long Amount { get; set; }

        /// <summary>Gets or sets the InvoiceId. </summary>
        public Guid? InvoiceId { get; set; }

        /// <summary>Gets or sets the Invoice. </summary>
        public Invoice Invoice { get; set; }

        /// <summary>Gets or sets the PaymentTypeId. </summary>
        public Guid? PaymentTypeId { get; set; }

        /// <summary>Gets or sets the PaymentType. </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>Gets or sets the PaymentInvoiceType. </summary>
        public PaymentInvoiceType PaymentInvoiceType { get; set; }

        /// <summary>Gets or sets the CurrencyId. </summary>
        public Guid? CurrencyId { get; set; }

        /// <summary>Gets or sets the Tenant's Currency. </summary>
        public Currency Currency { get; set; } 
    }

    public enum PaymentInvoiceType
    {
        Payment,
        Refund
    }

}
