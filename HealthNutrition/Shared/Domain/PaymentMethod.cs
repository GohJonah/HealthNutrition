using HealthNutrition.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class PaymentMethod : BaseDomainModel
    {
        [Required]
        public int? SubscriptionPlanId { get; set; }
        public virtual SubscriptionPlan? SubscriptionPlan { get; set; }
        [Required]
        public string? PaymentType { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 19, ErrorMessage = "Card Number Does Not Meet The Length Requirements")]
        public string? CardNumber { get; set; }
        [Required]
        public string? ExpiryDate { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Security Code Does Not Meet The Length Requirements")]
        public string? SecurityCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}


