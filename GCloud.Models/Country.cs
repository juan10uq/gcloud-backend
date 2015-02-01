using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Country", Schema = "System")]
    public class Country : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the Country Name. </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Country Code.
        /// </summary>
        [Required, MaxLength(2)]
        public string Code { get; set; }


        /// <summary>
        /// Gets or sets the Currency Code.
        /// </summary>
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the Currency Name.
        /// </summary>
        [MaxLength(100)]
        public string CurrencyName { get; set; }

        /// <summary>Gets the Tenants. </summary>
        public ICollection<Tenant> Tenants { get; internal set; }

        [InverseProperty("Nacionality")]
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }

    [Table("Province", Schema = "System")]
    public class StateProvince
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the Name. </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the ShortName. </summary>
        [Required]
        [StringLength(2)]
        public string Code { get; set; }

        /// <summary>Gets or sets the StateId. </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>Gets or sets the State. </summary>
        [Required]
        public Country Country { get; set; }
    }
}
