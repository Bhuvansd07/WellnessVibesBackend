using WebApplication1.Models.WorkoutRoutines;

namespace WebApplication1.Services.WorkoutRoutine
{
    public interface IWorkoutService
    {
        Workout Get(string username);

        Workout Create(Workout workout);

        void Update(string username, Workout workout);

        void Remove(string username);
    }
}
