using PageCss.Core.Entities;
using PageCss.Core.ViewModelsIn;

namespace PageCss.ApplicationService.PlanesSubscription
{
    public interface ISubscriptionPlanesApplicationService
    {
        Task<int> AddSubscriptionPlanAsync(SubscriptionPlanViewModel subscriptionPlan);
        Task EditSubscriptionPlanAsync(int id,SubscriptionPlanViewModel subscriptionPlan);
        Task<SubscriptionPlan> GetSubscriptionPlanAsync(int subscriptionPlanId);
        Task<List<SubscriptionPlan>> GetSubscriptionPlansAsync();
        Task DeleteSubscriptionPlanAsync(int subscriptionPlanId);

    }
}
