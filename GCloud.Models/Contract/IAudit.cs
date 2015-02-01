using System;

namespace GCloud.Models
{
    public interface IAudit
    {
        Guid CreatedBy { get; set; }

        Guid UpdatedBy { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}
