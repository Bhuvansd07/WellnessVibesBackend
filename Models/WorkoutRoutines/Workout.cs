using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models.WorkoutRoutines
{
    public class Workout
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("fitnessLevel")]
        public string FitnessLevel { get; set; } = string.Empty;

        [BsonElement("goal")]
        public string Goal { get; set; } = string.Empty;

        [BsonElement("total_duration")]
        public int TDuration {  get; set; }

        [BsonElement("exercises")]
        public List<Exercises> Exercises { get; set; } = new List<Exercises>();

    }

    public class Exercises
    {
        public string exerciseType { get; set; } = string.Empty;

        public int duration {  get; set; }

        public string intensity { get; set; } = string.Empty;
    }
}
