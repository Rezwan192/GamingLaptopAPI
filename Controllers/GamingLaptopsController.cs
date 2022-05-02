#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamingLaptopAPI.Models;

namespace GamingLaptopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingLaptopsController : ControllerBase
    {
        private readonly GamingLaptopAPIDBContext _context;

        public GamingLaptopsController(GamingLaptopAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/GamingLaptops
        [HttpGet]
        public async Task<ActionResult<Response>> GetGamingLaptops()
        {
            var gamingLaptops = await _context.GamingLaptops.ToListAsync();

            var response = new Response();

            if(gamingLaptops.Count == 0)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, no laptops present in database.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success, all laptops retrieved.";
                response.gamingLaptops = gamingLaptops;
            }

            return response;
        }

        // GET: api/GamingLaptops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetGamingLaptop(int id)
        {
            var gamingLaptop = await _context.GamingLaptops.FindAsync(id);

            var response = new Response();

            if (gamingLaptop == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, No laptop exists at given ID.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success, Laptop retrieved.";
                response.gamingLaptops.Add(gamingLaptop);
            }

            return response;
        }

        // DELETE: api/GamingLaptops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response2>> DeleteGamingLaptop(int id)
        {
            var graphicsCard = await _context.GraphicsCards.Include(g => g.Laptops).FirstOrDefaultAsync(g => g.GraphicsCardId == id);
            var response = new Response2();
            if (graphicsCard == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, graphics card not found.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success, laptops within given GraphicsCardId deleted.";

                var idsToDelete = graphicsCard.Laptops.Select(l => l.LaptopId).ToList();

                var x = _context.GamingLaptops.Where(gl => idsToDelete.Contains(gl.LaptopId));

                _context.GamingLaptops.RemoveRange(x);

                await _context.SaveChangesAsync();
            }
            return response;
        }

        private bool GamingLaptopExists(int id)
        {
            return _context.GamingLaptops.Any(e => e.LaptopId == id);
        }
    }
}
