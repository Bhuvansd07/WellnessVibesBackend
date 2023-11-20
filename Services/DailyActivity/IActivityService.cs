using WebApplication1.Models.DailyActivities;

namespace WebApplication1.Services.DailyActivity
{
    public interface IActivityService
    {
        List<DailyActivities> Get(string username);

        DailyActivities Create(DailyActivities activity);

        void Update(string username, DailyActivities activity);
    }
}
