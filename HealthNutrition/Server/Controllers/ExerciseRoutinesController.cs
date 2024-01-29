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
    public class ExerciseRoutinesController : ControllerBase
    {
        // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public ExerciseRoutinesController(ApplicationDbContext context)
        public ExerciseRoutinesController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/ExerciseRoutines
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<ExerciseRoutine>>> GetExerciseRoutines()
        public async Task<IActionResult> GetExerciseRoutines()
        {
            // To Be Deleted or Comment After Testing Global Error Handling
            //return NotFound();
            var exerciseroutines = await _unitOfWork.ExerciseRoutines.GetAll();
            return Ok(exerciseroutines);
            //if (_context.ExerciseRoutines == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.ExerciseRoutines.ToListAsync();
        }

        // GET: api/ExerciseRoutines/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<ExerciseRoutine>> GetExerciseRoutine(int id)
        public async Task<IActionResult> GetExerciseRoutine(int id)
        {
            //if (_context.ExerciseRoutines == null)
            //{
            //    return NotFound();
            //}
            //var exerciseroutines = await _context.ExerciseRoutines.FindAsync(id);
            var exerciseRoutine = await _unitOfWork.ExerciseRoutines.Get(q => q.Id == id);

            if (exerciseRoutine == null)
            {
                return NotFound();
            }

            //return exerciseRoutine;
            return Ok(exerciseRoutine);
        }

        // PUT: api/ExerciseRoutines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseRoutine(int id, ExerciseRoutine exerciseRoutine)
        {
            if (id != exerciseRoutine.Id)
            {
                return BadRequest();
            }

            // _context.Entry(exerciseRoutine).State = EntityState.Modified;
            _unitOfWork.ExerciseRoutines.Update(exerciseRoutine);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                // if (!ExerciseRoutineExists(id))
                if (!await ExerciseRoutineExists(id))
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

        // POST: api/ExerciseRoutines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseRoutine>> PostExerciseRoutine(ExerciseRoutine exerciseRoutine)
        {
            //if (_context.ExerciseRoutines == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.ExerciseRoutines'  is null.");
            //}
            //  _context.ExerciseRoutines.Add(exerciseRoutine);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.ExerciseRoutines.Insert(exerciseRoutine);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetExerciseRoutine", new { id = exerciseRoutine.Id }, exerciseRoutine);
        }

        // DELETE: api/ExerciseRoutines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseRoutine(int id)
        {
            //if (_context.ExerciseRoutines == null)
            //{
            //    return NotFound();
            //}
            //var exerciseRoutine = await _context.ExerciseRoutines.FindAsync(id);
            var exerciseRoutine = await _unitOfWork.ExerciseRoutines.Get(q => q.Id == id);
            if (exerciseRoutine == null)
            {
                return NotFound();
            }

            // return Ok(exerciseRoutine);
            //_context.ExerciseRoutines.Remove(exerciseRoutine);

            await _unitOfWork.ExerciseRoutines.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        //private bool ExerciseRoutineExists(int id)
        private async Task<bool> ExerciseRoutineExists(int id)
        {
            //return (_context.ExerciseRoutines?.Any(e => e.Id == id)).GetValueOrDefault();
            var exerciseRoutine = await _unitOfWork.ExerciseRoutines.Get(q => q.Id == id);
            return exerciseRoutine != null;
        }
    }
}
