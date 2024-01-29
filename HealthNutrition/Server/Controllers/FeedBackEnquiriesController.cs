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
    public class FeedBackEnquiriesController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public FeedBackEnquiriesController(ApplicationDbContext context)
        public FeedBackEnquiriesController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/FeedBackEnquiries
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<FeedBackEnquiries>>> GetFeedBackEnquiries()
        public async Task<IActionResult> GetFeedBackEnquiries()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            // return NotFound();
            var feedbackenquiries = await _unitOfWork.FeedBackEnquiries.GetAll();
            return Ok(feedbackenquiries);
            //if (_context.FeedBackEnquiries == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.FeedBackEnquiries.ToListAsync();
        }

        // GET: api/FeedBackEnquiries/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<FeedBackEnquiry>> GetFeedBackEnquiry(int id)
        public async Task<IActionResult> GetFeedBackEnquiry(int id)
        {
            //if (_context.FeedBackEnquiries == null)
            //{
            //    return NotFound();
            //}
            //var feedbackEnquiry = await _context.FeedBackEnquiries.FindAsync(id);
            var feedbackEnquiry = await _unitOfWork.FeedBackEnquiries.Get(q => q.Id == id);

            if (feedbackEnquiry == null)
            {
                return NotFound();
            }

            //return feedbackEnquiry;
            return Ok(feedbackEnquiry);
        }

        // PUT: api/FeedBackEnquiries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBackEnquiry(int id, FeedBackEnquiry feedbackEnquiry)
        {
            if (id != feedbackEnquiry.Id)
            {
                return BadRequest();
            }

            // _context.EntryfeedbackEnquiry).State = EntityState.Modified;
            _unitOfWork.FeedBackEnquiries.Update(feedbackEnquiry);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!FeedBackEnquiryExists(id))
                if (!await FeedBackEnquiryExists(id))
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

        // POST: api/FeedBackEnquiries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedBackEnquiry>> PostFeedBackEnquiry(FeedBackEnquiry feedbackEnquiry)
        {
            //if (_context.FeedBackEnquiries == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.FeedBackEnquiries'  is null.");
            //}
            //  _context.FeedBackEnquiries.Add(feedbackEnquiry);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.FeedBackEnquiries.Insert(feedbackEnquiry);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFeedBackEnquiry", new { id = feedbackEnquiry.Id }, feedbackEnquiry);
        }

        // DELETE: api/FeedBackEnquiries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBackEnquiry(int id)
        {
            //if (_context.FeedBackEnquiries == null)
            //{
            //    return NotFound();
            //}
            //var feedbackEnquiry = await _context.FeedBackEnquiries.FindAsync(id);
            var feedbackEnquiry = await _unitOfWork.FeedBackEnquiries.Get(q => q.Id == id);
            if (feedbackEnquiry == null)
            {
                return NotFound();
            }

            // return Ok(feedbackEnquiry);
            //_context.FeedBackEnquiries.Remove(feedbackEnquiry);
            //await _context.SaveChangesAsync();

            await _unitOfWork.FeedBackEnquiries.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool FeedBackEnquiryExists(int id)
        private async Task<bool> FeedBackEnquiryExists(int id)
        {
            //return (_context.FeedBackEnquiries?.Any(e => e.Id == id)).GetValueOrDefault();
            var feedbackEnquiry = await _unitOfWork.FeedBackEnquiries.Get(q => q.Id == id);
            return feedbackEnquiry != null;
        }
    }
}
