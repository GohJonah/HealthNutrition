using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class SubscriptionPlan : BaseDomainModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Subscription Plan Name Does Not Meet The Length Requirements")]
        public string? SubscriptionPlanName { get; set; }
        [Required(ErrorMessage = "An URL Of An Image Is Required")]
        [RegularExpression(@"\b(?:https?|ftp)://\S+.(?:jpg|jpeg|gif|png|bmp)\b", ErrorMessage = "Please Enter A Valid Image URL.")]
        public string? SubscriptionPlanImage { get; set; }
        [Required]
        public string? SubscriptionPlanInfo {  get; set; }
        [Required]
        public string? SubscriptionPlanItem1 { get; set; }
        [Required]
        public string? SubscriptionPlanItem2 { get; set; }
        [Required]
        public string? SubscriptionPlanPrice { get; set; }
    }
}
