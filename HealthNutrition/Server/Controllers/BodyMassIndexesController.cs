using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthNutrition.Server.Data;
using HealthNutrition.Shared.Domain;
using HealthNutrition.Server.IRepository;

namespace HealthNutrition.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMassIndexesController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public BodyMassIndexesController(ApplicationDbContext context)
        public BodyMassIndexesController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/BodyMassIndexes
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<BodyMassIndex>>> GetBodyMassIndexes()
        public async Task<IActionResult> GetBodyMassIndexes()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            // return NotFound();
            var bodymassindexes = await _unitOfWork.BodyMassIndexes.GetAll();
            return Ok(bodymassindexes);
            //if (_context.BodyMassIndexes == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.BodyMassIndexes.ToListAsync();
        }

        // GET: api/BodyMassIndexes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<BodyMassIndex>> GetBodyMassIndex(int id)
        public async Task<IActionResult> GetBodyMassIndex(int id)
        {
            //if (_context.BodyMassIndexes == null)
            //{
            //    return NotFound();
            //}
            //var bodyMassIndex = await _context.BodyMassIndexes.FindAsync(id);
            var bodyMassIndex = await _unitOfWork.BodyMassIndexes.Get(q => q.Id == id);

            if (bodyMassIndex == null)
            {
                return NotFound();
            }

            //return bodyMassIndex;
            return Ok(bodyMassIndex);
        }

        // PUT: api/BodyMassIndexes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyMassIndex(int id, BodyMassIndex bodyMassIndex)
        {
            if (id != bodyMassIndex.Id)
            {
                return BadRequest();
            }

            // _context.Entry(bodyMassIndex).State = EntityState.Modified;
            _unitOfWork.BodyMassIndexes.Update(bodyMassIndex);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!BodyMassIndexExists(id))
                if (!await BodyMassIndexExists(id))
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

        // POST: api/BodyMassIndexes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BodyMassIndex>> PostBodyMassIndex(BodyMassIndex bodyMassIndex)
        {
            //if (_context.BodyMassIndexes == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.BodyMassIndexes'  is null.");
            //}
            //  _context.BodyMassIndexes.Add(BodyMassIndex);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.BodyMassIndexes.Insert(bodyMassIndex);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBodyMassIndex", new { id = bodyMassIndex.Id }, bodyMassIndex);
        }

        // DELETE: api/BodyMassIndexes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyMassIndex(int id)
        {
            //if (_context.BodyMassIndexes == null)
            //{
            //    return NotFound();
            //}
            //var bodyMassIndex = await _context.BodyMassIndexes.FindAsync(id);
            var bodyMassIndex = await _unitOfWork.BodyMassIndexes.Get(q => q.Id == id);
            if (bodyMassIndex == null)
            {
                return NotFound();
            }

            // return Ok(bodyMassIndex);
            //_context.BodyMassIndexes.Remove(bodyMassIndex);
            //await _context.SaveChangesAsync();

            await _unitOfWork.BodyMassIndexes.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool BodyMassIndexExists(int id)
        private async Task<bool> BodyMassIndexExists(int id)
        {
            //return (_context.BodyMassIndexes?.Any(e => e.Id == id)).GetValueOrDefault();
            var bodyMassIndex = await _unitOfWork.BodyMassIndexes.Get(q => q.Id == id);
            return bodyMassIndex != null;
        }
    }
}
