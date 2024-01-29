using Duende.IdentityServer.EntityFramework.Options;
using HealthNutrition.Server.Configurations.Entities;
using HealthNutrition.Server.Models;
using HealthNutrition.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HealthNutrition.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<HealthNutritionBenefit> HealthNutritionBenefits  { get; set; }
        public DbSet<ExerciseRoutine> ExerciseRoutines { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<FeedBackEnquiry> FeedBackEnquiries { get; set; }
        public DbSet<BodyMassIndex> BodyMassIndexes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new HBSSeedConfiguration());
            builder.ApplyConfiguration(new ExerciseSeedConfiguration());
            builder.ApplyConfiguration(new SubscriptionPlanSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
        }
    }
}
