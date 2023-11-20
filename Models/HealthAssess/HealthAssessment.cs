using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models.HealthAssess
{
    public class HealthAssessment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("height")]
        public double Height { get; set; }

        [BsonElement("weight")]
        public int Weight { get; set; }

        [BsonElement("BMI")]
        public double BMI { get; set; }

        [BsonElement("systolic")]
        public int Systolic { get; set; }
        
        [BsonElement("diastolic")]
        public int Diastolic { get; set; }

        [BsonElement("chronic_illness")]
        public string ChronicIllness { get; set; } = string.Empty;

        [BsonElement("sleep_patterns")]
        public int SleepPattern { get; set; }

        [BsonElement("mental_illness")x]
        public string MentalIll { get; set; } = string.Empty;


        [BsonElement("emotional_state")]
        public string EmotionalState { get; set; } = string.Empty;
    }


}
