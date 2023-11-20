using MongoDB.Driver;
using WebApplication1.Models.HealthAssess;

namespace WebApplication1.Services.HealthAssess
{
    public class HealthService : IHealthService
    {
        private readonly IMongoCollection<HealthAssessment> _health;

        public HealthService(IHealthSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _health = database.GetCollection<HealthAssessment>(settings.MongoDbCollectionName);
        }
        public HealthAssessment Create(HealthAssessment HealthAss)
        {
            _health.InsertOne(HealthAss);
            return HealthAss;
        }

        public HealthAssessment Get(string username)
        {
            var health = _health.Find(HealthAss => HealthAss.Username == username).FirstOrDefault();
            HealthAssessment healthNew = health;
            return healthNew;
        }
    }
}
