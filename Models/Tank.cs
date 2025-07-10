namespace Soqia.Models
{
    public class Tank
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Capacity { get; set; }
        public string? Location { get; set; }
        public string? WaterType { get; set; }
        public double Price { get; set; }
        public int RegionId { get; set; }
        public Region? Region { get; set; }
    }
}
