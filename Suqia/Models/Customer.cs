using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suqia.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Detailed Address")]
        public string Address { get; set; }

        // Foreign Key for Area
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        // Navigation Property: A customer can have multiple orders
        public virtual ICollection<Order> Orders { get; set; }
    }
}