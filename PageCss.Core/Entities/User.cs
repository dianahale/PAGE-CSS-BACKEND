using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.Entities
{
    public class User : IdentityUser
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        public SubscriptionPlan SubscriptionPlans { get; set; }

    }
}
