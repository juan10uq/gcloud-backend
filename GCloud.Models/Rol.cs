using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Rol", Schema = "Security")]
    public class Rol : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        public Rol()
        {
            Users = new Collection<User>();
        }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [InverseProperty("Roles")]
        public virtual ICollection<User> Users { get; set; }
    }
}
