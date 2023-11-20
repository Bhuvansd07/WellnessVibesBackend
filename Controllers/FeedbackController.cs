using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Reviews;
using WebApplication1.Services.Review;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServicee feedbackService;

        public FeedbackController(IFeedbackServicee feedbackService)
        {
            this.feedbackService = feedbackService;
        }
        // GET: api/<FeedbackController>
        [HttpGet]
        public ActionResult<List<Feedback>> Get()
        {
            return feedbackService.Get();
        }

        // POST api/<FeedbackController>
        [HttpPost]
        public ActionResult<Feedback> Post([FromBody] Feedback feed_back)
        {
            feedbackService.Create(feed_back);
            return CreatedAtAction(nameof(Get), new { username = feed_back.Username}, feed_back);
        }
    }
}
