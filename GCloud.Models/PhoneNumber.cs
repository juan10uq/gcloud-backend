using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("PhoneNumber", Schema = "Tenant")]
    public class PhoneNumber : EntityBase
    {
        /// <summary>Gets or sets the AreaCode. </summary>
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string AreaCode { get; set; }

        /// <summary>Gets or sets the Number. </summary>
        [Required]
        [StringLength(8, MinimumLength = 7)]
        public string Number { get; set; }

        /// <summary>Gets or sets the Primary. </summary>
        [Required]
        public bool Primary { get; set; }

        /// <summary>Gets or sets the PhoneType. </summary>
        public PhoneType PhoneType { get; set; }

        /// <summary>Gets or sets the ContactId. </summary>
        public Guid? ContactId { get; set; }

        /// <summary>Gets or sets the Contact. </summary>
        public Contact Contact { get; set; }

        /// <summary>Gets or sets the GymId. </summary>
        public Guid? GymId { get; set; }

        /// <summary>Gets or sets the Gym. </summary>
        public Gym Gym { get; set; }

        /// <summary>Gets or sets the CustomerId. </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>Gets or sets the Customer. </summary>
        public Customer Customer { get; set; }

        /// <summary>Gets or sets the UserId. </summary>
        public Guid? UserId { get; set; }

        /// <summary>Gets or sets the User. </summary>
        public User User { get; set; }

    }

    public enum PhoneType
    {
        Mobil,
        Home,
        Work
    }
}
