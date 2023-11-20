using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models.DailyActivities
{
    public class DailyActivities
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = string.Empty;

        [BsonElement("exerciseRoutine")]
        public List<ExerciseRoutine> ExerciseRoutines { get; set; } = new List<ExerciseRoutine>();

        [BsonElement("meals")]
        public List<Meals> Meals { get; set; } = new List<Meals>();

        [BsonElement("waterIntake")]
        public int WaterIntake { get; set; }

        [BsonElement("calorieIntake")]
        public int CalorieIntake { get; set; }

        [BsonElement("mood")]
        public string Mood { get; set; } = string.Empty;
    }

    public class ExerciseRoutine
    {
        public string? exerciseType { get; set; }
        public int duration { get; set; }
        public string? intensity { get; set; }

    }

    public class Meals
    {
        public string mealType { get; set; } = string.Empty;
        public List<string> foodItems { get; set;} = new List<string>();

    }
}
