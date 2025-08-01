using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suqia.Models
{
    public enum OrderStatus
    {
        [Display(Name = "New Order")]
        New,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Cancelled")]
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Quantity in Barrels")]
        public int QuantityInBarrels { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "Order Status")]
        public OrderStatus Status { get; set; } = OrderStatus.New;

        // Foreign Key for Customer
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        // Foreign Key for Tank
        [Display(Name = "Tank")]
        public int TankId { get; set; }
        [ForeignKey("TankId")]
        public virtual Tank Tank { get; set; }
        
        // Foreign Key for Driver (can be null initially)
        [Display(Name = "Driver")]
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
}