using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCloud.Models
{
    [Table("CurrencyRate", Schema = "Tenant")]
    public class CurrencyRate : EntityBase
    {
        /// <summary>
        /// Currency code from which the exchange rate was converted.
        /// </summary>
        [Required, MaxLength(3)]
        public string FromCurrencyCode { get; set; }

        /// <summary>
        /// Currency code to which the exchange rate was converted.
        /// </summary>
        [Required, MaxLength(3)]
        public string ToCurrencyCode { get; set; }

        /// <summary>
        /// Average exchange rate for the day.
        /// </summary>
        public long AverageRate { get; set; }

        /// <summary>
        /// Final exchange rate for the day.
        /// </summary>
        public long EndOfDayRate { get; set; }

        /// <summary>
        /// Date and time the exchange rate was obtained.
        /// </summary>
        public DateTime CurrencyRateDate { get; set; }

    }
}
