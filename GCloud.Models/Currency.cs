using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Currency", Schema = "System")]
    public class Currency : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Currency name. </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The ISO code for the currency.
        /// </summary>
        [Required, MaxLength(3)]
        public string Code { get; set; }

        /// <summary>Gets the Tenants. </summary>
        public ICollection<Tenant> Tenants { get; internal set; }

        public virtual ICollection<Gym> Gyms { get; set; }
    }
}
