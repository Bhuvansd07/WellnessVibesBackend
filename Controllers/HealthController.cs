using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.HealthAssess;
using WebApplication1.Services.HealthAssess;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService healthService;

        public HealthController(IHealthService healthService)
        {
            this.healthService = healthService;
        }

        // GET api/<HealthController>/5
        [HttpGet("{username}")]
        public ActionResult<HealthAssessment> Get(string username)
        {
            var assessment = healthService.Get(username);

            if(assessment == null)
            {
                return NotFound($"Health Assesment of user = {username} not found");
            }
            return assessment;
        }

        // POST api/<HealthController>
        [HttpPost]
        public ActionResult<HealthAssessment> Post([FromBody] HealthAssessment health_ass)
        {
            healthService.Create(health_ass);
            return CreatedAtAction(nameof(Get), new { username = health_ass.Username }, health_ass);
        }

    }
}
