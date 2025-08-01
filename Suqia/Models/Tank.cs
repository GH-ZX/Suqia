using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suqia.Models
{
    public class Tank
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tank capacity is required")]
        [Display(Name = "Tank Capacity (L)")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Water type is required")]
        [Display(Name = "Water Type")]
        public string WaterType { get; set; } // Example: "Drinking Water" or "Service Water"

        [Required(ErrorMessage = "Price per barrel is required")]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Price Per Barrel")]
        public decimal PricePerBarrel { get; set; }

        // Foreign Key for Area
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }
    }
}