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
    public class GraphicsCardsController : ControllerBase
    {
        private readonly GamingLaptopAPIDBContext _context;

        public GraphicsCardsController(GamingLaptopAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/GraphicsCards
        [HttpGet]
        public async Task<ActionResult<Response2>> GetGraphicsCards()
        {
            var graphicsCards = await _context.GraphicsCards.Include(g=>g.Laptops).ToListAsync();

            var response = new Response2();

            if (graphicsCards.Count == 0)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, no graphics cards present in database.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success, all graphics cards retrieved.";
                response.graphicsCards = graphicsCards;
            }

            return response;
        }

        // GET: api/GraphicsCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response2>> GetGraphicsCard(int id)
        {
            var graphicsCard = await _context.GraphicsCards.Include(g => g.Laptops).FirstOrDefaultAsync(g => g.GraphicsCardId == id);

            var response = new Response2();

            if (graphicsCard == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, No graphics card exists at given ID.";
            }
            else
            {
                response.statusCode = 200;
                response.statusDescription = "Success, graphics card retrieved.";
                response.graphicsCards.Add(graphicsCard);
            }

            return response;
        }

        // POST: api/GraphicsCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response2>> PostGraphicsCard(GraphicsCard graphicsCard)
        {
            var response = new Response2();
            /*
             * The below is commented out because although I wanted a failure response consistent with my response model, 
             * the program already checks for a valid GraphicsCard object in the argument before it checks the code within it,
             * so the if statement below will never be used 
            */
            //if (graphicsCard == null)
            //{
            //    response.statusCode = 400;
            //    response.statusDescription = "Failure, null values not allowed.";
            //    return response;
            //}

            _context.GraphicsCards.Add(graphicsCard);
            await _context.SaveChangesAsync();

            response.statusCode = 200;
            response.statusDescription = "Success, new graphics card added to database.";
            response.graphicsCards.Add(graphicsCard);
            return response;
        }

        // DELETE: api/GraphicsCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response2>> DeleteGraphicsCard(int id)
        {
            var graphicsCard = await _context.GraphicsCards.FindAsync(id);
            var response = new Response2();
            if (graphicsCard == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failure, no graphics cards exists at given ID.";
            }
            else
            {
                _context.GraphicsCards.Remove(graphicsCard);
                await _context.SaveChangesAsync();

                response.statusCode = 200;
                response.statusDescription = "Success, graphics card deleted.";
            }

            return response;
        }

        private bool GraphicsCardExists(int id)
        {
            return _context.GraphicsCards.Any(e => e.GraphicsCardId == id);
        }
    }
}
