using GymLog.UI.Models;

namespace GymLog.UI.Services
{
    public interface IExercisesService
    {
        Exercise CreateExercise(Exercise exercise);
        void DeleteExercise(int id);
        IEnumerable<Exercise> GetAllExercises();
        Exercise GetExerciseById(int id);
        Exercise UpdateExercise(Exercise exercise);
    }
}