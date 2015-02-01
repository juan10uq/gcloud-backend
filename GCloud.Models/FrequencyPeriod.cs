using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
     [Table("FrequencyPeriod", Schema = "System")]
    public class FrequencyPeriod : IEntity
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the Name. </summary>
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the Code. </summary>
        [MaxLength(3)]
        [Required]
        public string Code { get; set; }
    }
}
