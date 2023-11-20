using WebApplication1.Models.HealthAssess;

namespace WebApplication1.Services.HealthAssess
{
    public interface IHealthService
    {
        HealthAssessment Get(string username);

        HealthAssessment Create(HealthAssessment HealthAss);
    }
}
