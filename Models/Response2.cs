using System;
using Microsoft.EntityFrameworkCore;

namespace GamingLaptopAPI.Models
{
    public class Response2
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<GraphicsCard> graphicsCards { get; set; } = new();
    }
}
