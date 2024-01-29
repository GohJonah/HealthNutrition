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
    public class HealthNutritionBenefitsController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public HealthNutritionBenefitsController(ApplicationDbContext context)
        public HealthNutritionBenefitsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/HealthNutritionBenefits
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<HealthNutritionBenefit>>> GetHealthNutritionBenefits()
        public async Task<IActionResult> GetHealthNutritionBenefits()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            //return NotFound();
            var healthnutritionbenefits = await _unitOfWork.HealthNutritionBenefits.GetAll();
            return Ok(healthnutritionbenefits);
          //if (_context.HealthNutritionBenefits == null)
          //{
          //    return NotFound();
          //}
          //  return await _context.HealthNutritionBenefits.ToListAsync();
        }

        // GET: api/HealthNutritionBenefits/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<HealthNutritionBenefit>> GetHealthNutritionBenefit(int id)
        public async Task<IActionResult> GetHealthNutritionBenefit(int id)
        {
            //if (_context.HealthNutritionBenefits == null)
            //{
            //    return NotFound();
            //}
            //var healthNutritionBenefit = await _context.HealthNutritionBenefits.FindAsync(id);
            var healthNutritionBenefit = await _unitOfWork.HealthNutritionBenefits.Get(q => q.Id == id);

            if (healthNutritionBenefit == null)
            {
                return NotFound();
            }

            //return healthNutritionBenefit;
            return Ok(healthNutritionBenefit);
        }

        // PUT: api/HealthNutritionBenefits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthNutritionBenefit(int id, HealthNutritionBenefit healthNutritionBenefit)
        {
            if (id != healthNutritionBenefit.Id)
            {
                return BadRequest();
            }

            // _context.Entry(healthNutritionBenefit).State = EntityState.Modified;
            _unitOfWork.HealthNutritionBenefits.Update(healthNutritionBenefit);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!HealthNutritionBenefitExists(id))
                if (!await HealthNutritionBenefitExists(id))
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

        // POST: api/HealthNutritionBenefits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HealthNutritionBenefit>> PostHealthNutritionBenefit(HealthNutritionBenefit healthNutritionBenefit)
        {
            //if (_context.HealthNutritionBenefits == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.HealthNutritionBenefits'  is null.");
            //}
            //  _context.HealthNutritionBenefits.Add(healthNutritionBenefit);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.HealthNutritionBenefits.Insert(healthNutritionBenefit);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetHealthNutritionBenefit", new { id = healthNutritionBenefit.Id }, healthNutritionBenefit);
        }

        // DELETE: api/HealthNutritionBenefits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthNutritionBenefit(int id)
        {
            //if (_context.HealthNutritionBenefits == null)
            //{
            //    return NotFound();
            //}
            //var healthNutritionBenefit = await _context.HealthNutritionBenefits.FindAsync(id);
            var healthNutritionBenefit = await _unitOfWork.HealthNutritionBenefits.Get(q => q.Id == id);
            if (healthNutritionBenefit == null)
            {
                return NotFound();
            }

            // return Ok(healthNutritionBenefit);
            //_context.HealthNutritionBenefits.Remove(healthNutritionBenefit);
            //await _context.SaveChangesAsync();

            await _unitOfWork.HealthNutritionBenefits.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool HealthNutritionBenefitExists(int id)
        private async Task<bool> HealthNutritionBenefitExists (int  id)
        {
            //return (_context.HealthNutritionBenefits?.Any(e => e.Id == id)).GetValueOrDefault();
            var healthNutritionBenefit = await _unitOfWork.HealthNutritionBenefits.Get(q => q.Id == id);
            return healthNutritionBenefit != null;
        }
    }
} 
