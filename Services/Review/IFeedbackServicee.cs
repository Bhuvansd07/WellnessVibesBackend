using WebApplication1.Models.Reviews;

namespace WebApplication1.Services.Review
{
    public interface IFeedbackServicee
    {
        List<Feedback> Get();
        Feedback Create(Feedback feedback);

    }
}
