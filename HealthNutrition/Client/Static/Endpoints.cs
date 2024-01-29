using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNutrition.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly String HealthNutritionBenefitsEndpoint = $"{Prefix}/healthnutritionbenefits";
        public static readonly String ExerciseRoutinesEndpoint = $"{Prefix}/exerciseroutines";
        public static readonly String SubscriptionPlansEndpoint = $"{Prefix}/subscriptionplans";
        public static readonly String PaymentMethodsEndpoint = $"{Prefix}/paymentmethods";
        public static readonly String FeedBackEnquiriesEndpoint = $"{Prefix}/feedbackenquiries";
        public static readonly String BodyMassIndexesEndpoint = $"{Prefix}/bodymassindexes";
    }
}
