using System.ComponentModel.DataAnnotations;

namespace PageCss.Core.Entities
{
    public class SubscriptionPlans
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public List<User> Users { get; set; }


        public SubscriptionPlans()
        {
            Users = new List<User>();
        }
    }
}
