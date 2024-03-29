﻿using System;
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
    public class PaymentMethodsController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public PaymentMethodsController(ApplicationDbContext context)
        public PaymentMethodsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        public async Task<IActionResult> GetPaymentMethods()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            // return NotFound();
            var paymentmethods = await _unitOfWork.PaymentMethods.GetAll(includes: q => q.Include(x => x.SubscriptionPlan));
            return Ok(paymentmethods);
            //if (_context.PaymentMethods == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.PaymentMethods.ToListAsync();
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        public async Task<IActionResult> GetPaymentMethod(int id)
        {
            //if (_context.PaymentMethods == null)
            //{
            //    return NotFound();
            //}
            //var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            var paymentMethod = await _unitOfWork.PaymentMethods.Get(q => q.Id == id);

            if (paymentMethod == null)
            {
                return NotFound();
            }

            //return paymentMetho;
            return Ok(paymentMethod);
        }

        // PUT: api/PaymentMethods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethods(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest();
            }

            // _context.Entry(paymentMethod).State = EntityState.Modified;
            _unitOfWork.PaymentMethods.Update(paymentMethod);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!PaymentMethodExists(id))
                if (!await PaymentMethodExists(id))
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

        // POST: api/PaymentMethods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethod paymentMethod)
        {
            //if (_context.PaymentMethods == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.PaymentMethods'  is null.");
            //}
            //  _context.PaymentMethods.Add(paymentMethod);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.PaymentMethods.Insert(paymentMethod);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPaymentMethod", new { id = paymentMethod.Id }, paymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            //if (_context.PaymentMethods == null)
            //{
            //    return NotFound();
            //}
            //var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            var paymentMethod = await _unitOfWork.PaymentMethods.Get(q => q.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            // return Ok(paymentMethod);
            //_context.PaymentMethods.Remove(paymentMethod);
            //await _context.SaveChangesAsync();

            await _unitOfWork.PaymentMethods.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool PaymentMethodExists(int id)
        private async Task<bool> PaymentMethodExists(int id)
        {
            //return (_context.PaymentMethods?.Any(e => e.Id == id)).GetValueOrDefault();
            var paymentMethod = await _unitOfWork.PaymentMethods.Get(q => q.Id == id);
            return paymentMethod != null;
        }
    }
}
