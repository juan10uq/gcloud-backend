using System;

namespace GCloud.Models
{
    /// Basic infrastructure of a POCO entity
    public interface IEntity
    {
        /// <summary>
        /// Entity's ID
        /// </summary>
        Guid Id { get; set; }
    }
}
