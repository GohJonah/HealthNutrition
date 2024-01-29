using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNutrition.Shared.Domain
{
    public class ExerciseRoutine : BaseDomainModel
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Exercise Name Does Not Meet The Length Requirements")]
        public string? ExerciseName { get; set; }
        [Required]
        public string? ExerciseInfo { get; set; }
        [Required]
        public string? ExercisePlan { get; set; }
        [Required(ErrorMessage = "An URL Of An Image Is Required")]
        [RegularExpression(@"\b(?:https?|ftp)://\S+.(?:jpg|jpeg|gif|png|bmp|webp)\b", ErrorMessage = "Please Enter A Valid Image URL.")]
        public string? ExerciseImage { get; set; }
        [Required(ErrorMessage = "A URL Of A Youtube Video Is Required")]
        public string? ExerciseVideoLink { get; set; }
    }
}
