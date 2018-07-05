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
    [Route("api/CurdSnackDetail")]
    public class CurdSnackDetailsController : Controller
    {
        private readonly ILogger _logger;

        private readonly CurdSnackContext _context;

        public CurdSnackDetailsController(CurdSnackContext context, ILogger<CurdSnackDetailsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/CurdSnackDetail
        [HttpGet]
        public IEnumerable<CurdSnackDetail> GetCurdSnackDetails()
        {
            return _context.CurdSnackDetails;
        }

        // GET: api/CurdSnackDetails/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">CurdSnack id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurdSnackDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnack = await _context.CurdSnacks.SingleOrDefaultAsync(m => m.Id == id);
            if (curdSnack == null)
            {
                return NoContent();
            }
            var curdSnackDetail = await _context.CurdSnackDetails.SingleOrDefaultAsync(m => m.Id == curdSnack.DetailId);
            if (curdSnack.Detail == null)
            {
                return NoContent();
            }

            var response = new CurdSnackDetail
            {
                Id = curdSnackDetail.Id,
                Details = curdSnackDetail.Details
            };

            return Ok(response);
        }

        // PUT: api/CurdSnackDetail
        [HttpPut]
        public async Task<IActionResult> PutCurdSnackDetail([FromBody] CurdSnackDetail curdSnackDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(curdSnackDetail).State = EntityState.Modified;

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

        // PUT: api/CurdSnackDetail/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">CurdSnack id</param>
        /// <param name="curdSnackDetail">curdSnackDetail data</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurdSnackDetail([FromRoute] long id, [FromBody] CurdSnackDetail curdSnackDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnack = _context.CurdSnacks.FirstOrDefault(x => x.Id == id);

            if (curdSnack == null)
            {
                return BadRequest();
            }

            curdSnackDetail.Id = curdSnack.DetailId;
            _context.Entry(curdSnackDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurdSnackDetailExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/CurdSnackDetail/5
        [HttpPost("{id}")]
        public async Task<IActionResult> PostCurdSnackDetail([FromRoute] long id, [FromBody] CurdSnackDetail curdSnackDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnack = _context.CurdSnacks.FirstOrDefault(x => x.Id == id);

            if (curdSnack == null)
            {
                return BadRequest();
            }
            curdSnack.Detail = curdSnackDetail;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PostCurdSnackDetail error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        // DELETE: api/CurdSnackDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurdSnackDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curdSnackDetail = await _context.CurdSnackDetails.SingleOrDefaultAsync(m => m.Id == id);

            if (curdSnackDetail == null)
            {
                return NoContent();
            }

            _context.CurdSnackDetails.Remove(curdSnackDetail);
            await _context.SaveChangesAsync();

            return Ok(curdSnackDetail);
        }

        private bool CurdSnackDetailExists(long id)
        {
            return _context.CurdSnackDetails.Any(e => e.Id == id);
        }
    }
}
