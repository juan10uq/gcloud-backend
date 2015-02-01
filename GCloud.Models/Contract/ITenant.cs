using System;

namespace GCloud.Models
{
    public interface ITenant
    { 
        /// <summary>
        /// Represents the tenant's id 
        /// </summary>
        Guid TenantId { get; set; }
    }
}
