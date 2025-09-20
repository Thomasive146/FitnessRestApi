using FitnessRestApi.Data;
using FitnessRestApi.Models;
using FitnessRestApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessRestApi.Controllers
{
    [ApiController]
    [Route("exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly FitnessContext _context;

        public ExerciseController(FitnessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetAllExercises(int pageNumber = 1, int pageSize = 1)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            var exercises = await _context.Exercises
                .OrderBy(e => e.Id) // Ensure consistent ordering
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise([FromBody] ExerciseDto dto)
        {
            var exercise = new Exercise
            {
                Name = dto.Name,
                Description = dto.Description
            };
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
                return NotFound();

            return Ok(exercise);
        }

    }
}
