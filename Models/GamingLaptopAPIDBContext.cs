using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using GamingLaptopAPI.Models;

namespace GamingLaptopAPI.Models
{
    public class GamingLaptopAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public GamingLaptopAPIDBContext(DbContextOptions<GamingLaptopAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("GamingLaptopDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<GamingLaptop> GamingLaptops { get; set; } = null!;
        public DbSet<GraphicsCard> GraphicsCards { get; set; } = null!;

    }
}



