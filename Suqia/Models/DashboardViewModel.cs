namespace Suqia.Models
{
    public class DashboardViewModel
    {
        public int CompletedOrdersCount { get; set; }
        public int CustomersCount { get; set; }
        public int DriversCount { get; set; }
        public int TotalTanksCapacity { get; set; }
        public string MostRequestedArea { get; set; }
    }
}