using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Group", Schema = "Tenant")]
    public class Group : EntityBase
    {
        /// <summary>Gets or sets the Name. </summary>
        [MaxLength(60)]
        public string Name { get; set; }

        /// <summary>Gets or sets the Code. </summary>
        [MaxLength(10)]
        public string Code { get; set; }

        /// <summary>Gets or sets the CustomField1. </summary>
        [MaxLength(100)]
        public string CustomField1 { get; set; }

        /// <summary>Gets or sets the CustomField2. </summary>
        [MaxLength(100)]
        public string CustomField2 { get; set; }

        /// <summary>Gets or sets the CustomField3. </summary>
        [MaxLength(100)]
        public string CustomField3 { get; set; }

        /// <summary>Gets or sets the Customers. </summary>
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
