using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using HealthNutrition.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.SqlServer.Server;

namespace HealthNutrition.Server.Configurations.Entities
{
    public class HBSSeedConfiguration : IEntityTypeConfiguration<HealthNutritionBenefit>
    {
        public void Configure(EntityTypeBuilder<HealthNutritionBenefit> builder)
        {
            builder.HasData(
                 new HealthNutritionBenefit
                 {
                     Id = 1,
                     NutrientName = "Vitamin A",
                     NutrientInfo = "Vitamin A is important for normal vision, the immune system, reproduction, and growth and development.Vitamin A also helps your heart, lungs, and other organs work properly.",
                     NutrientFoodType1 = "Leafy Green Vegetables(Kale, Broccoli)",
                     NutrientFoodType2 = "Bright Colour Vegetables(Carrots, Bell Peppers)",
                     NutrientFoodType3 = "Dairy Products(Egg, Milk)",
                     NutrientImage = "https://img.freepik.com/premium-photo/carrot-table-background-fresh-sweet-carrots-cooking-food-fruits-vegetables-health-concept-baby-carrots-bunch-leaf_73523-8672.jpg",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
                 );
        }
    }
}

