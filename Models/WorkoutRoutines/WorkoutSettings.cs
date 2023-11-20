namespace WebApplication1.Models.WorkoutRoutines
{
    public class WorkoutSettings : IWorkoutSettings
    {
        public string MongoDbCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
