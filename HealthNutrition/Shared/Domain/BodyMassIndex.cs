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
        public Double? Weight { get; set; }
        [Required]
        public Double? Height { get; set; }
        public Double? BMI { get; set; }

    }
}

