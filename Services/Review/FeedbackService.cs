using MongoDB.Driver;
using WebApplication1.Models.Reviews;

namespace WebApplication1.Services.Review
{
    public class FeedbackService : IFeedbackServicee
    {
        private readonly IMongoCollection<Feedback> _review;

        public FeedbackService(IFeedbackSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _review = database.GetCollection<Feedback>(settings.MongoDbCollectionName);
        }

        public Feedback Create(Feedback feedback)
        {
            _review.InsertOne(feedback);
            return feedback;
        }

        public List<Feedback> Get()
        {
            var rev = _review.Find(review => true).ToList();
            List<Feedback> newRev = rev;
            return newRev;
        }
    }
}
