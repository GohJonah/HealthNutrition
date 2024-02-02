using HealthNutrition.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class BodyMassIndex : BaseDomainModel
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public Double? Weight { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Height must be greater than 0")]
        public Double? Height { get; set; }
        public Double? BMI { get; set; }

    }
}

