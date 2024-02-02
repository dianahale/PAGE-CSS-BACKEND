using Microsoft.AspNetCore.Identity;

namespace PageCss.Core.Entities
{
    public class User : IdentityUser
    {
        public SubscriptionPlans subscriptionPlans { get; set; }

    }
}
