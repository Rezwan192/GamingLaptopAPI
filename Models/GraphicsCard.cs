using System;
using System.ComponentModel.DataAnnotations;
namespace GamingLaptopAPI.Models
{
    public class GraphicsCard
    {
        [Key]
        public int GraphicsCardId { get; set; }
        public string GraphicsCardName { get; set; }
        public string Company { get; set; }
        public int ReleaseYear { get; set; }
        public double BaseClockSpeed { get; set; }
        public double BoostClockSpeed { get; set; }
        public int TotalMemory { get; set; }
        public string MemoryType { get; set; }
        public List<GamingLaptop> Laptops { get; set; }
    }
}
