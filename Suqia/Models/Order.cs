using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suqia.Models
{
    public enum OrderStatus
    {
        [Display(Name = "??? ????")]
        New,
        [Display(Name = "??? ???????")]
        InProgress,
        [Display(Name = "?? ???????")]
        Completed,
        [Display(Name = "????")]
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "???? ????????")]
        public int QuantityInBarrels { get; set; }

        [Display(Name = "????? ?????")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Display(Name = "???? ?????")]
        public OrderStatus Status { get; set; } = OrderStatus.New;

        // Foreign Key ??????
        [Display(Name = "??????")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        // Foreign Key ??????
        [Display(Name = "??????")]
        public int TankId { get; set; }
        [ForeignKey("TankId")]
        public virtual Tank Tank { get; set; }
        
        // Foreign Key ?????? (???? ?? ???? ?????? ?? ???????)
        [Display(Name = "??????")]
        public int? DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
}