using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.Entities
{
    public class SubscriptionPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }


        public List<User> Users { get; set; }


        public SubscriptionPlan()
        {
            Users = new List<User>();
        }
    }
}
