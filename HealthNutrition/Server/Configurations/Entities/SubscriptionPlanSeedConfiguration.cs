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
    public class SubscriptionPlanSeedConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
    {
        public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
        {
            builder.HasData(
                 new SubscriptionPlan
                 {
                     Id = 1,
                     SubscriptionPlanName = "Classic Weekly Bundle",
                     SubscriptionPlanImage = "https://cdn.textstudio.com/output/sample/normal/0/4/8/4/classic-logo-275-14840.png",
                     SubscriptionPlanInfo = "Classic Weekly Bundle Mainly Includes Vouchers/Coupons Sufficient For A Week",
                     SubscriptionPlanItem1 = "FairPrice Vouchers ($10 x 3)",
                     SubscriptionPlanItem2 = "FoodPanda $5 Off Next 3 Orders Coupon (Ag100)",
                     SubscriptionPlanPrice = "$35",
                     DateCreated = DateTime.Now,
                     DateUpdated = DateTime.Now,
                     CreatedBy = "System",
                     UpdatedBy = "System"
                 }
                 );
        }
    }
}

