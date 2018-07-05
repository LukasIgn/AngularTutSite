using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularTutSiteApi.Contexts;
using AngularTutSiteApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AngularTutSiteApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CurdSnacks")]
    public class CurdSnacksController : Controller
    {
        private readonly ILogger _logger;

        private readonly CurdSnackContext _context;

        public CurdSnacksController(CurdSnackContext context, ILogger<CurdSnacksController> logger)
        {
            _context = context;
            _logger = logger;
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

        // PUT: api/CurdSnacks
        [HttpPut]
        public async Task<IActionResult> PutCurdSnack([FromBody] IEnumerable<CurdSnack> curdSnacks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var snack in curdSnacks)
            {
                _context.Attach(snack).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PutCurdSnack error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
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
            var child = _context.CurdSnackDetails.Add(new CurdSnackDetail());
            curdSnack.Detail = child.Entity;
            _context.CurdSnacks.Add(curdSnack);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PostCurdSnack error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
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