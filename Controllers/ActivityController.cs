using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DailyActivities;
using WebApplication1.Services.DailyActivity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }
        // GET: api/<ActivityController>
        [HttpGet("{username}")]
        public ActionResult<List<DailyActivities>> Get(string username)
        {
            var activity = activityService.Get(username);
            if(activity == null)
            {
                return NotFound($"No Daily Activity od user = {username} not found");
            }
            return activity;
        }


        // POST api/<ActivityController>
        [HttpPost]
        public ActionResult<DailyActivities> Post([FromBody] DailyActivities activities)
        {
            activityService.Create(activities);
            return CreatedAtAction(nameof(Get), new { username = activities.Username }, activities);
        }

        // PUT api/<ActivityController>/5
        [HttpPut("{username}")]
        public ActionResult Put(string username, [FromBody] DailyActivities activities)
        {
            var existingActivity = activityService.Get(username);
            if(existingActivity == null)
            {
                return NotFound($"No Daily Activity of user = {username} not found");
            }
            activityService.Update(username, activities);
            return NoContent();
        }

    }
}
