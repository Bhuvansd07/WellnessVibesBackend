using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models.Reviews
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("rating")]
        public double Rating { get; set; }

        [BsonElement("feedback_message")]
        public string FeedMessage { get; set; } = string.Empty;

        [BsonElement("suggestion_message")]
        public string SuggMessage { get; set; } = string.Empty;

        [BsonElement("report_message")]
        public string ReportMessage { get; set; } = string.Empty;

        [BsonElement("created_at")]
        public string CreatedAt { get; set; } = string.Empty;
    }
}
