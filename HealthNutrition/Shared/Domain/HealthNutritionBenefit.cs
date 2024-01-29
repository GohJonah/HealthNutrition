using HealthNutrition.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class HealthNutritionBenefit : BaseDomainModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Nutrient Name Does Not Meet The Length Requirements")]
        public string? NutrientName {  get; set; }
        [Required]
        public string? NutrientInfo { get; set; }
        [Required]
        public string? NutrientFoodType1 { get; set; }
        [Required]
        public string? NutrientFoodType2 { get; set; }
        [Required]
        public string? NutrientFoodType3 { get; set; }
        [Required(ErrorMessage = "An URL Of An Image Is Required")]
        [RegularExpression(@"\b(?:https?|ftp)://\S+.(?:jpg|jpeg|gif|png|bmp)\b",ErrorMessage = "Please Enter A Valid Image URL.")]
        public string? NutrientImage { get;set; }
    }
}
