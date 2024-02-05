using PageCss.Core.Entities;

namespace PageCss.Core.ViewModelsOut
{
    public class SubscriptionPlanListResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public List<SubscriptionPlan> Model { get; set; }
        public string RequestId { get; set; }
    }
}
