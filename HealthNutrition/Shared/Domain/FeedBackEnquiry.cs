using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class FeedBackEnquiry : BaseDomainModel
    {
        [Required]
        public string? FeedBackTopic { get; set; }
        public string? FeedBackInfo { get; set; }
        [Required]
        public string? FeedBackRating { get; set; }
    }
}
