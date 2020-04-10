using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DattingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DattingApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PieskiController : ControllerBase
    {
        private DataContext _context;

        public PieskiController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Pieski
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Values.ToListAsync();
            return Ok(response);
        }

        // GET: api/Pieski/1
        [HttpGet("{id}", Name = "Get")]     
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            return Ok(result);
        }

        // POST: api/Pieski
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pieski/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
