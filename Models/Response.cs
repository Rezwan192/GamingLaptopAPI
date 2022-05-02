using System;
using Microsoft.EntityFrameworkCore;

namespace GamingLaptopAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public List<GamingLaptop> gamingLaptops { get; set; } = new();
    }
}
