using System.ComponentModel.DataAnnotations;

namespace Suqia.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Driver name is required")]
        [Display(Name = "Driver Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Navigation Property: A driver can have multiple delivery orders
        public virtual ICollection<Order> Orders { get; set; }
    }
}