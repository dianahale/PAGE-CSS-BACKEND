using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.ViewModelsOut
{
    public class SubscriptionPlanViewModelOut
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
