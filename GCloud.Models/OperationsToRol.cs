using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("OperationsToRol", Schema = "Security")]
    public class OperationsToRol : EntityBase
    {
        public string RoleName { get; set; }
        public Guid ResourceId { get; set; }
        public Operations Operations { get; set; }
    }
}
