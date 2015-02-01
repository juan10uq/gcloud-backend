using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Contact", Schema = "Tenant")]
    public class Contact : EntityBase
    {
        /// <summary>Gets or sets the Name. </summary>
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the LastName. 
        /// </summary>
        [MaxLength(80)]
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the Email. 
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the WebSite. 
        /// </summary>
        [MaxLength(200)]
        public string WebSite { get; set; }

        /// <summary>
        /// Gets or sets the Twitter. 
        /// </summary>
        [MaxLength(200)]
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets the Facebook. 
        /// </summary>
        [MaxLength(200)]
        public string Facebook { get; set; }

        /// <summary>Gets or sets the Primary. </summary>
        [Required]
        public bool Primary { get; set; }

        /// <summary>
        /// Gets or sets the Identification. 
        /// </summary>
        [MaxLength(50)]
        public string Identification { get; set; }

        /// <summary>Gets or sets the CustomField1. </summary>
        [MaxLength(100)]
        public string CustomField1 { get; set; }

        /// <summary>Gets or sets the CustomField2. </summary>
        [MaxLength(100)]
        public string CustomField2 { get; set; }

        /// <summary>Gets or sets the CustomField3. </summary>
        [MaxLength(100)]
        public string CustomField3 { get; set; }

        /// <summary>Gets or sets the PhoneNumbers. </summary>
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>Gets or sets the Addresses. </summary>
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
