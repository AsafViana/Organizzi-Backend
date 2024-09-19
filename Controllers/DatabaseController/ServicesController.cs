using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizzi.Models;
using System.Threading.Tasks;

namespace Organizzi.Controllers.DatabaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        // Simulação de um contexto de banco de dados ou serviço
        private readonly Context _context;

        public ServicesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [HttpPost("NewService")]
        public async Task<IActionResult> Create([FromBody] Services service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Details), new { id = service.ID }, service);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Services service)
        {
            if (id != service.ID)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Services.Any(e => e.ID == id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
