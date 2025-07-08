using GymLog.UI.Models;

namespace GymLog.UI.Services
{
    public interface IExerciseCategoriesService
    {
        ExerciseCategory CreateExerciseCategory(ExerciseCategory exerciseCategory);
        void DeleteExerciseCategory(int id);
        IEnumerable<ExerciseCategory> GetAllExerciseCategories();
        ExerciseCategory GetExerciseCategoryById(int id);
        ExerciseCategory UpdateExerciseCategory(ExerciseCategory exerciseCategory);
    }
}