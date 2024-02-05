using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.ViewModelsOut
{
    public class UsersViewModelOut
    {
        public string Id { get; set; }
        
        [EmailAddress]
        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string PhoneNumber { get; set; }

    }
}
