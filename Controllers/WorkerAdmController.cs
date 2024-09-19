using Microsoft.AspNetCore.Mvc;
using Organizzi.Controllers.DatabaseController;
using Organizzi.Models;
using System;
using System.Threading.Tasks;

namespace Organizzi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerAdmController : ControllerBase
    {
        private readonly ServicesController _servicesDb;

        public WorkerAdmController(ServicesController servicesDb)
        {
            _servicesDb = servicesDb;
        }

        // GET: api/<WorkerAdmController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _servicesDb.Index();
                return Ok(result); // Retorna o objeto em caso de sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna o erro em caso de falha
            }
        }

        // GET api/<WorkerAdmController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _servicesDb.Details(id);
                return Ok(result); // Retorna o objeto em caso de sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna o erro em caso de falha
            }
        }

        // POST api/<WorkerAdmController>/NewService
        [HttpPost("NewService")]
        public async Task<IActionResult> PostNewService([FromBody] Services service)
        {
            try
            {
                var result = await _servicesDb.Create(service);
                return Ok(result); // Retorna o objeto em caso de sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna o erro em caso de falha
            }
        }

        // PUT api/<WorkerAdmController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Services service)
        {
            try
            {
                var result = await _servicesDb.Edit(id, service);
                return Ok(result); // Retorna o objeto em caso de sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna o erro em caso de falha
            }
        }

        // DELETE api/<WorkerAdmController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _servicesDb.Delete(id);
                return Ok(result); // Retorna o objeto em caso de sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Retorna o erro em caso de falha
            }
        }
    }
}
