using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.ViewModelsIn
{
    public class UsersViewModelIn
    {
        
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int SubscriptionPlanId { get; set; }
    }
}
