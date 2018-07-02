using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularTutSiteApi.Models;

namespace AngularTutSiteApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CurdSnacks")]
    public class CurdSnacksController : Controller
    {
        private readonly CurdSnackContext _context;

        public CurdSnacksController(CurdSnackContext context)
        {
            _context = context;
        }

        // GET: api/CurdSnacks
        [HttpGet]
        public IEnumerable<CurdSnack> GetCurdSnacks()
        {
            return _context.CurdSnacks;
        }

        // GET: api/CurdSnacks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurdSnack([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnack = await _context.CurdSnacks.SingleOrDefaultAsync(m => m.Id == id);

            if (curdSnack == null)
            {
                return NotFound();
            }

            return Ok(curdSnack);
        }

        // PUT: api/CurdSnacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurdSnack([FromRoute] long id, [FromBody] CurdSnack curdSnack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curdSnack.Id)
            {
                return BadRequest();
            }

            _context.Entry(curdSnack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurdSnackExists(id))
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

        // POST: api/CurdSnacks
        [HttpPost]
        public async Task<IActionResult> PostCurdSnack([FromBody] CurdSnack curdSnack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CurdSnacks.Add(curdSnack);

            try
            {
                
            await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                var a = ex;
            }
            return CreatedAtAction("GetCurdSnack", new { id = curdSnack.Id }, curdSnack);
        }

        // DELETE: api/CurdSnacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurdSnack([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnack = await _context.CurdSnacks.SingleOrDefaultAsync(m => m.Id == id);
            if (curdSnack == null)
            {
                return NotFound();
            }

            _context.CurdSnacks.Remove(curdSnack);
            await _context.SaveChangesAsync();

            return Ok(curdSnack);
        }

        private bool CurdSnackExists(long id)
        {
            return _context.CurdSnacks.Any(e => e.Id == id);
        }
    }
}