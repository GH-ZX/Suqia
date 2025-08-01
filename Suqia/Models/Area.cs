using System.ComponentModel.DataAnnotations;

namespace Suqia.Models
{
    public class Area
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Area name is required")]
        [Display(Name = "Area Name")]
        public string Name { get; set; }

        // Navigation Property: Each area can have multiple tanks
        public virtual ICollection<Tank> Tanks { get; set; }
        // Navigation Property: Each area can have multiple customers
        public virtual ICollection<Customer> Customers { get; set; }
    }
}