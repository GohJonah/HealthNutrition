using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using HealthNutrition.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.SqlServer.Server;
using static System.Net.WebRequestMethods;

namespace HealthNutrition.Server.Configurations.Entities
{
    public class ExerciseSeedConfiguration : IEntityTypeConfiguration<ExerciseRoutine>
    {
        public void Configure(EntityTypeBuilder<ExerciseRoutine> builder)
        {
            builder.HasData(
                 new ExerciseRoutine
                 {
                     Id = 1,
                     ExerciseName = "Squats",
                     ExerciseInfo = "Squats Helps To Targets Your Thighs, Hamstrings, Glutes & Calves",
                     ExercisePlan = "Daily: 10 - 15 Reps (x3 Sets)",
                     ExerciseImage = "https://builtwithscience.com/wp-content/uploads/2023/02/how-to-squat-properly-perfect-squat-form1.webp",
                     ExerciseVideoLink = "https://www.youtube.com/watch?v=IB_icWRzi4E",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
                 );
        }
    }
}

