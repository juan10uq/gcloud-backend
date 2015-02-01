using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using GCloud.Models.Contract;
using Newtonsoft.Json;

namespace GCloud.Models
{
    public abstract class EntityBase : AuditEntityBase, IEntity, ITenant, IConcurrency, ILogicalDelete
    {
        /// <summary>Gets or sets the Id. </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Indicates if the entity is active, this is used instead of deleting the entity record in the database
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore] //Ignoring Active property for breeze clients
        public bool Active { get; set; }

        /// <summary>
        /// Represents the tenant's id 
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]//Ignoring TenantId property for breeze clients
        [Required]
        [Index("Tenant", IsClustered = false)]
        public Guid TenantId { get; set; }

        [ConcurrencyCheck]
        public int RowVersion { get; set; } 
    }

    public abstract class AuditEntityBase : IAudit
    {
        [IgnoreDataMember]
        [JsonIgnore] //Ignoring CreateDate property for breeze clients
        public DateTime? CreateDate { get; set; }

        [IgnoreDataMember]
        [JsonIgnore] //Ignoring UpdateDate property for breeze clients
        public DateTime? UpdateDate { get; set; }

        [IgnoreDataMember]
        [JsonIgnore] //Ignoring UpdateDate property for breeze clients
        public Guid CreatedBy { get; set; }

        [IgnoreDataMember]
        [JsonIgnore] //Ignoring UpdateDate property for breeze clients
        public Guid UpdatedBy { get; set; }
    }
}
