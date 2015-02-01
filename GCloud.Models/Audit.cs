using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Audit", Schema = "Tenant")]
    public class Audit : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Indicates if the entity is active, this is used instead of deleting the entity record in the database
        /// </summary>
        public string Resource { get; set; }
        public string UserName { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}
