using System;
using GCloud.Common.Contract;

namespace GCloud.Common
{
    /// <summary>
    /// Class to wrap the .NET DateTime
    /// </summary>
    public class DateTimeAdapter : IDateTime
    {
        /// <summary>
        /// Gets the current UTC Time
        /// </summary>
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
