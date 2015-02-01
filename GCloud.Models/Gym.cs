using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Gym", Schema = "Tenant")]
    public class Gym: EntityBase
    {
        /// <summary>Gets or sets the Name. </summary>
        [MaxLength(60)]
        public string Name { get; set; }

        /// <summary>Gets or sets the Code. </summary>
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>Gets or sets the Addresses. </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>Gets or sets the PhoneNumbers. </summary>
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>Gets or sets the Contacts. </summary>
        public virtual ICollection<Contact> Contacts { get; set; }

        /// <summary>Gets or sets the CurrencyId. </summary>
        public Guid? CurrencyId { get; set; }

        /// <summary>Gets or sets the Tenant's Currency. </summary>
        public Currency Currency { get; set; }

        /// <summary>Gets or sets the CountryId. </summary>
        public Guid? CountryId { get; set; }

        /// <summary>Gets or sets the Tenant's Country. </summary>
        public Country Country { get; set; } 
    }
}
