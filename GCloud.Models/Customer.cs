using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Customer", Schema = "Tenant")]
    public class Customer : EntityBase
    {
        /// <summary>Gets or sets the Name. </summary>
         [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the LastName. 
        /// </summary>
        [Required, MaxLength(80)]
        public string LastName { get; set; }

         /// <summary>
        /// Gets or sets the Identification. 
        /// </summary>
        [MaxLength(50)]
        public string Identification { get; set; }

        /// <summary>
        /// Gets or sets the Card. 
        /// </summary>
        public int Card { get; set; }

        /// <summary>
        /// Gets or sets the IdentificationType. 
        /// </summary>
        public IdentificationType IdentificationType { get; set; }
        
         /// <summary>
        /// Gets or sets the Birthday. 
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets a Note about the Customer. 
        /// </summary>
        [MaxLength(250)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        public State State { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>Gets or sets the AllowNotifications. </summary>
        public bool AllowNotifications { get; set; }

        /// <summary>Gets or sets the CustomField1. </summary>
        [MaxLength(100)]
        public string CustomField1 { get; set; }

        /// <summary>Gets or sets the CustomField2. </summary>
        [MaxLength(100)]
        public string CustomField2 { get; set; }

        /// <summary>Gets or sets the CustomField3. </summary>
        [MaxLength(100)]
        public string CustomField3 { get; set; }

        /// <summary>Gets or sets the CustomField4. </summary>
        [MaxLength(100)]
        public string CustomField4 { get; set; }

        /// <summary>Gets or sets the CustomField5. </summary>
        [MaxLength(100)]
        public string CustomField5 { get; set; }

        /// <summary>Gets or sets the NacionalityId. </summary>
        public Guid? NacionalityId { get; set; }

        /// <summary>Gets or sets the State. </summary>
        [InverseProperty("Customers")]
        public Country Nacionality { get; set; }

        /// <summary>Gets or sets the GroupId. </summary>
        public Guid? GroupId { get; set; }

        /// <summary>Gets or sets the Group. </summary>
        public Group Group { get; set; }

        /// <summary>Gets or sets the PhoneNumbers. </summary>
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>Gets or sets the Addresses. </summary>
        public virtual ICollection<Address> Addresses { get; set; }


        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1}", Name.Trim(), LastName.Trim()); }
        }
    }

    public enum Gender
    {
        Female,
        Male
    }

    public enum IdentificationType
    {
        National,
        Passport,
        Resident
    }

    public enum State
    {
        Active,
        Inactive,
        Moroso
    }
}
