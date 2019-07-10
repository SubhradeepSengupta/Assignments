using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotnetAssignment2.Model;

namespace DotnetAssignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly MessageDbContext _context;

        public DataController(MessageDbContext context)
        {
            _context = context;
        }

        // HTTP GET: api/Data
        [HttpGet]
        public IEnumerable<Message> Getdata()
        {
            return _context.data;
        }

        // HTTP GET: api/Data/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _context.data.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // HTTP PUT: api/Data/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutData([FromRoute] int id, [FromBody] Message data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != data.Id)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // HTTP POST: api/Data
        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] Message data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.data.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetData", new { id = data.Id }, data);
        }

        private bool DataExists(int id)
        {
            return _context.data.Any(e => e.Id == id);
        }
    }
}