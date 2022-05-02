using System;
using System.ComponentModel.DataAnnotations;
namespace GamingLaptopAPI.Models
{
    public class GamingLaptop
    {
        [Key]
        public int LaptopId { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public string ModelNumber { get; set; }
        public int ReleaseYear { get; set; }
        public string Color { get; set; }
        public string Processor { get; set; }
        public double ScreenSize { get; set; }
        public string ScreenResolution { get; set; }
        public int ScreenRefreshRate { get; set; }
        public double BatteryCapacity { get; set; }
        public int TotalStorage { get; set; }
        public int TotalMemory { get; set; }
        public string OperatingSystem { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public bool IsTouchScreen { get; set; }
        public bool HasWebCam { get; set; }
    }
}
