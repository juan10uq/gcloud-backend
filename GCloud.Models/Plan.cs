using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Plan", Schema = "Tenant")]
    public class Plan : EntityBase
    {
        /// <summary>Gets or sets the Name. </summary>
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the Code. </summary>
        [MaxLength(3)]
        [Required]
        public string Code { get; set; }
    }
}
