using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Address", Schema = "Tenant")]
    public class Address: EntityBase
    {
        /// <summary>First street-address line.. </summary>
        [MaxLength(250)]
        public string Address1 { get; set; }

        /// <summary>Second street address line. </summary>
        [MaxLength(250)]
        public string Address2 { get; set; }

        /// <summary>Name of the city. </summary>
        [MaxLength(80)]
        public string City { get; set; }

        /// <summary>Gets or sets the Suburb. </summary>
        [MaxLength(80)]
        public string Suburb { get; set; }

        /// <summary>Postal code for the street address. </summary>
        [StringLength(10, MinimumLength = 5)]
        public string PostalCode { get; set; }

        /// <summary>Gets or sets the City. </summary>
        public AddressType AddressType  {get; set; }

        /// <summary>Gets or sets the Primary. </summary>
        [Required]
        public bool Primary { get; set; }

        /// <summary>Gets or sets the CountryId. </summary>
        public Guid? CountryId { get; set; }

        /// <summary>Gets or sets the Country. </summary>
        public Country Country { get; set; }

        /// <summary>Unique identification number for the state or province. Foreign key to StateProvince.Id. </summary>
        public Guid? StateProvinceId { get; set; }

        /// <summary>Gets or sets the StateProvince. </summary>
        public StateProvince StateProvince { get; set; }

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

    }

    public enum AddressType
    {
        Physical,
        Postal 
    }
}
