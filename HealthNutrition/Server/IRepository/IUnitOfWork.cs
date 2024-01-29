using HealthNutrition.Shared.Domain;
using HealthNutrition.Server.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNutrition.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<HealthNutritionBenefit> HealthNutritionBenefits { get; }
        IGenericRepository<ExerciseRoutine> ExerciseRoutines { get; }
        IGenericRepository<SubscriptionPlan> SubscriptionPlans { get; }
        IGenericRepository<PaymentMethod> PaymentMethods { get; }
        IGenericRepository<FeedBackEnquiry> FeedBackEnquiries { get; }
        IGenericRepository<BodyMassIndex> BodyMassIndexes { get; }
    }
}