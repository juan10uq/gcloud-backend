using System;

namespace GCloud.Common.Contract
{
    /// <summary>
    /// Interfaz to wrap the .NET DateTime
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Gets the current UTC Time
        /// </summary>
        DateTime UtcNow { get; }
    }
}