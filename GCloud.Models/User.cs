using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("User", Schema = "Security")]
    public class User : EntityBase
    {
        public User()
        {
            PhoneNumbers = new Collection<PhoneNumber>();
            Roles = new Collection<Rol>();
        }

        [Required, MaxLength(50)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        /// <summary>Gets or sets the CustomField1. </summary>
        [MaxLength(100)]
        public string CustomField1 { get; set; }

        /// <summary>Gets or sets the CustomField2. </summary>
        [MaxLength(100)]
        public string CustomField2 { get; set; }

        /// <summary>Gets or sets the CustomField3. </summary>
        [MaxLength(100)]
        public string CustomField3 { get; set; }

        /// <summary>Gets or sets the CustomField4. </summary>
        [MaxLength(100)]
        public string CustomField4 { get; set; }

        /// <summary>Gets or sets the CustomField5. </summary>
        [MaxLength(100)]
        public string CustomField5 { get; set; }

        /// <summary>Gets or sets the PhoneNumbers. </summary>
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [InverseProperty("Users")]
        public ICollection<Rol> Roles { get; set; }
    }
}
