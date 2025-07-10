using System;

namespace Soqia.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TankId { get; set; }
        public Tank? Tank { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderTime { get; set; }
        public string? Status { get; set; }
    }
}
