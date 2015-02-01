using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("PaymentType", Schema = "System")]
    public class PaymentType : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the Name. </summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the Code. </summary>
        public string Code { get; set; }

        /// <summary>Gets or sets the PaymentCategory. </summary>
        public PaymentCategory PaymentCategory { get; set; }
    }

    public enum PaymentCategory
    {
        General,
        Integrated
    }
}
