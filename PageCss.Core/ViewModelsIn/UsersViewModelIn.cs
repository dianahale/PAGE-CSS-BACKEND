using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.ViewModelsIn
{
    public class UsersViewModelIn
    {
        
        [EmailAddress]
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }

    }
}
