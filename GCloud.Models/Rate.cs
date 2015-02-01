using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("Rate", Schema = "Tenant")]
    public class Rate: EntityBase
    {
        /// <summary>Gets or sets the FrequencyPeriodId. </summary>
        public Guid? FrequencyPeriodId { get; set; }

        /// <summary>Gets or sets the FrequencyPeriod. </summary>
        public FrequencyPeriod FrequencyPeriod { get; set; }

        /// <summary>Gets or sets the PlanId. </summary>
        public Guid? PlanId { get; set; }

        /// <summary>Gets or sets the Plan. </summary>
        public Plan Plan { get; set; }

        /// <summary>Gets or sets the Price. </summary>
        public long Price { get; set; }
    }
}
