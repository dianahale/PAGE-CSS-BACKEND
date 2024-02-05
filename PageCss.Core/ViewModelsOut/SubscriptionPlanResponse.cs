using PageCss.Core.Entities;

namespace PageCss.Core.ViewModelsOut
{
    public class SubscriptionPlanResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public SubscriptionPlan Model { get; set; }
        public string RequestId { get; set; }
    }
}
