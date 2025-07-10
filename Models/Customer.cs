using System.Collections.Generic;

namespace Soqia.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int RegionId { get; set; }
        public Region? Region { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
