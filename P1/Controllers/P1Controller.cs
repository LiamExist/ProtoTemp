using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class P1Controller : ControllerBase
    {
       /* private static List<P1> P1s = new List<P1>
            {
                new P1 {
                    Id = 2,
                    Name ="Player One",
                    FirstName = "Player",
                    LastName = "One",
                    Place = "Sydney"
                }
            };*/

        private readonly DataContext _context;
        public P1Controller(DataContext context)
        {
            _context = context;//--

        }

        [HttpGet]
        public async Task<ActionResult<List<P1>>> Get()
        {
            return Ok(await _context.P1s.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<P1>> Get(int id)
        {
            var p1 = await _context.P1s.FindAsync(id);
            if (p1 == null)
                return BadRequest("Nof Found.");

            return Ok(p1);
        }

        [HttpPost]
        public async Task<ActionResult<List<P1>>> Add(P1 items)
        {
            _context.P1s.Add(items);
            await _context.SaveChangesAsync();

            return Ok(await _context.P1s.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<P1>>> Update(P1 request)
        {
            var dbP1 = await _context.P1s.FindAsync(request.Id);
            if (dbP1 == null)
                return BadRequest("Not Found");
            dbP1.Name = request.Name;
            dbP1.FirstName = request.FirstName;
            dbP1.LastName = request.LastName;
            dbP1.Place = request.Place;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.P1s.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult<List<P1>>> Delete(int id)
        {
            var dbP1 = await _context.P1s.FindAsync(id);
            if (dbP1 == null)
                return BadRequest("Nof Found.");

            _context.P1s.Remove(dbP1);
            await _context.SaveChangesAsync();

            return Ok(await _context.P1s.ToListAsync());
        }
    }
}
