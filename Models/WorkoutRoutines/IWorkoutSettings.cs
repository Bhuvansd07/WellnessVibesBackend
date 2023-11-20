namespace WebApplication1.Models.WorkoutRoutines
{
    public interface IWorkoutSettings
    {
        string MongoDbCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
