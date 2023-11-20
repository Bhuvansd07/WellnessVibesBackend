using MongoDB.Driver;
using WebApplication1.Models.WorkoutRoutines;

namespace WebApplication1.Services.WorkoutRoutine
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IMongoCollection<Workout> _workout;

        public WorkoutService(IWorkoutSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _workout = database.GetCollection<Workout>(settings.MongoDbCollectionName);
        }

        public Workout Create(Workout workout)
        {
            _workout.InsertOne(workout); 
            return workout;
        }

        public Workout Get(string username)
        {
            var work = _workout.Find(workout => workout.Username == username).FirstOrDefault();
            Workout newWork = work;
            return newWork;
        }

        public void Remove(string username)
        {
            _workout.DeleteOne(workout => workout.Username == username);
        }

        public void Update(string username, Workout workout)
        {
            _workout.ReplaceOne(workout => workout.Username == username, workout);
        }
    }
}
