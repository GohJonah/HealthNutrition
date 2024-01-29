using HealthNutrition.Server.Data;
using HealthNutrition.Server.IRepository;
using HealthNutrition.Server.Models;
using HealthNutrition.Server.Repository;
using HealthNutrition.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthNutrition.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<HealthNutritionBenefit> _healthnutritionbenefits;
        private IGenericRepository<ExerciseRoutine> _exerciseroutines;
        private IGenericRepository<SubscriptionPlan> _subscriptionplans;
        private IGenericRepository<PaymentMethod> _paymentmethods;
        private IGenericRepository<FeedBackEnquiry> _feedbackenquiries;
        private IGenericRepository<BodyMassIndex> _bodymassindexes;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<HealthNutritionBenefit> HealthNutritionBenefits
            => _healthnutritionbenefits ??= new GenericRepository<HealthNutritionBenefit>(_context);
        public IGenericRepository<ExerciseRoutine> ExerciseRoutines
            => _exerciseroutines ??= new GenericRepository<ExerciseRoutine>(_context);
        public IGenericRepository<SubscriptionPlan> SubscriptionPlans
            => _subscriptionplans ??= new GenericRepository<SubscriptionPlan>(_context);
        public IGenericRepository<PaymentMethod> PaymentMethods
        => _paymentmethods ??= new GenericRepository<PaymentMethod>(_context);
        public IGenericRepository<FeedBackEnquiry> FeedBackEnquiries
            => _feedbackenquiries ??= new GenericRepository<FeedBackEnquiry>(_context);
        public IGenericRepository<BodyMassIndex> BodyMassIndexes
        => _bodymassindexes ??= new GenericRepository<BodyMassIndex>(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}