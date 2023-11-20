using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.WorkoutRoutines;
using WebApplication1.Services.WorkoutRoutine;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        // GET api/<WorkoutController>/5
        [HttpGet("{username}")]
        public ActionResult<Workout> Get(string username)
        {
            var workout = workoutService.Get(username);

            if(workout == null)
            {
                return NotFound($"Workout Routine of user = {username} not found");
            }
            return workout;
        }

        // POST api/<WorkoutController>
        [HttpPost]
        public ActionResult<Workout> Post([FromBody] Workout workout)
        {
            workoutService.Create(workout);
            return CreatedAtAction(nameof(Get), new { username = workout.Username }, workout);
        }

        // PUT api/<WorkoutController>/5
        [HttpPut("{username}")]
        public ActionResult Put(string  username, [FromBody] Workout workout)
        {
            var existingWorkout = workoutService.Get(username); 
            if(existingWorkout == null)
            {
                return NotFound($"Workout Routine of user = {username} not found");
            }
            workoutService.Update(username, workout);
            return NoContent();
        }

        // DELETE api/<WorkoutController>/5
        [HttpDelete("{username}")]
        public ActionResult Delete(string username)
        {
            var working = workoutService.Get(username);
            if(working == null)
            {
                return NotFound($"Workout Routine of user = {username} not found");
            }
            workoutService.Remove(working.Username);
            return Ok($"Workout Routine of user = {username} deleted");
        }
    }
}
