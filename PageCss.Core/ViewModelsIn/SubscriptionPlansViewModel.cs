using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.ViewModelsIn
{
    public class SubscriptionPlanViewModel
    {

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
