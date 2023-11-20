using MongoDB.Driver;
using WebApplication1.Models.DailyActivities;

namespace WebApplication1.Services.DailyActivity
{
    public class ActivityService : IActivityService
    {
        private readonly IMongoCollection<DailyActivities> _activity;

        public ActivityService(IActivities settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _activity = database.GetCollection<DailyActivities>(settings.MongoDbCollectionName);
        }
        public DailyActivities Create(DailyActivities activity)
        {
            _activity.InsertOne(activity);
            return activity;
        }

        public List<DailyActivities> Get(string username)
        {
            var act = _activity.Find(activity => activity.Username == username).ToList();
            List<DailyActivities> actNew = act;
            return actNew;
        }

        public void Update(string username, DailyActivities activity)
        {
            _activity.ReplaceOne(activity => activity.Username == username, activity);
        }
    }
}
