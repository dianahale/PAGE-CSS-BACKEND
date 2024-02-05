using PageCss.Core.Entities;
using PageCss.Core.ViewModelsOut;

namespace PageCss.ApplicationService.PlanesSubscription
{
    public interface ISubscriptionPlanesApplicationService
    {
        Task<int> AddSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan);
        Task DeleteSubscriptionPlanAsync(int subscriptionPlanId);
        Task EditSubscriptionPlanAsync(SubscriptionPlan subscriptionPlan);
        Task<SubscriptionPlan> GetSubscriptionPlanAsync(int subscriptionPlanId);
        Task<List<SubscriptionPlanViewModelOut>> GetSubscriptionPlansAsync();

    }
}
