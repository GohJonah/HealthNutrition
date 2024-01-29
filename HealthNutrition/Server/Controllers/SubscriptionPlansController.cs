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
    public class SubscriptionPlansController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public  SubscriptionPlansController(ApplicationDbContext context)
        public SubscriptionPlansController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/SubscriptionPlans
        [HttpGet]
        // public async Task<ActionResult<IEnumerable< SubscriptionPlan>>> GetSubscriptionPlans()
        public async Task<IActionResult> GetSubscriptionPlans()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            // return NotFound();
            var subscriptionplans = await _unitOfWork.SubscriptionPlans.GetAll();
            return Ok(subscriptionplans);
            //if (_context.SubscriptionPlans == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.SubscriptionPlans.ToListAsync();
        }

        // GET: api/SubscriptionPlans/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<SubscriptionPlan>> GetSubscriptionPlan(int id)
        public async Task<IActionResult> GetSubscriptionPlan(int id)
        {
            //if (_context.SubscriptionPlan == null)
            //{
            //    return NotFound();
            //}
            //var subscriptionPlan = await _context.SubscriptionPlans.FindAsync(id);
            var subscriptionPlan = await _unitOfWork.SubscriptionPlans.Get(q => q.Id == id);

            if (subscriptionPlan == null)
            {
                return NotFound();
            }

            //return subscriptionPlan;
            return Ok(subscriptionPlan);
        }

        // PUT: api/SubscriptionPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionPlan(int id, SubscriptionPlan subscriptionPlan)
        {
            if (id != subscriptionPlan.Id)
            {
                return BadRequest();
            }

            // _context.Entry(subscriptionPlan).State = EntityState.Modified;
            _unitOfWork.SubscriptionPlans.Update(subscriptionPlan);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!SubscriptionPlanExists(id))
                if (!await SubscriptionPlanExists(id))
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

        // POST: api/SubscriptionPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionPlan>> PostSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            //if (_context.SubscriptionPlans == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.SubscriptionPlans'  is null.");
            //}
            //  _context.SubscriptionPlans.Add(subscriptionPlan);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.SubscriptionPlans.Insert(subscriptionPlan);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSubscriptionPlan", new { id =subscriptionPlan.Id }, subscriptionPlan);
        }

        // DELETE: api/SubscriptionPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(int id)
        {
            //if (_context.SubscriptionPlans == null)
            //{
            //    return NotFound();
            //}
            //var subscriptionPlan = await _context.SubscriptionPlans.FindAsync(id);
            var subscriptionPlan = await _unitOfWork.SubscriptionPlans.Get(q => q.Id == id);
            if (subscriptionPlan == null)
            {
                return NotFound();
            }

            // return Ok(subscriptionPlan);
            //_context.SubscriptionPlans.Remove(subscriptionPlan);
            //await _context.SaveChangesAsync();

            await _unitOfWork.SubscriptionPlans.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool SubscriptionPlanExists(int id)
        private async Task<bool> SubscriptionPlanExists(int id)
        {
            //return (_context.SubscriptionPlans?.Any(e => e.Id == id)).GetValueOrDefault();
            var subscriptionPlan = await _unitOfWork.SubscriptionPlans.Get(q => q.Id == id);
            return subscriptionPlan != null;
        }
    }
}
