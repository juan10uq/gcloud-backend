using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GCloud.Models.Contract;

namespace GCloud.Models
{
    [Table("Tenant", Schema = "System")]
    public class Tenant : IEntity, ILogicalDelete
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Active field.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the Tenant's name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate. 
        /// </summary>
        [Required]
        public DateTime CreateDate { get; set; }

        /// <summary>Gets or sets the Tenant's Country. </summary>
        [Required]
        public Country Country { get; set; }

        /// <summary>Gets or sets the CurrencyId. </summary>
        [Required]
        public Guid CurrencyId { get; set; }

        /// <summary>Gets or sets the Tenant's Currency. </summary>
        [Required]
        public Currency Currency { get; set; }

        /// <summary>Gets or sets the CountryId. </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>Gets or sets the TenantState. </summary>
        [Required]
        public TenantState TenantState { get; set; }
    }

    public enum TenantState
    {
        Demo,
        Active,
        Inactive
    }
}
