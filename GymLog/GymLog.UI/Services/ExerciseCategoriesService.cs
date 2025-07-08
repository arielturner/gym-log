using GymLog.UI.Models;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace GymLog.UI.Services;

public class ExerciseCategoriesService : IExerciseCategoriesService
{
    private readonly GymLogContext _gymLogContext;
    private readonly IMemoryCache _memoryCache;

    public ExerciseCategoriesService(GymLogContext gymLogContext, IMemoryCache memoryCache)
    {
        _gymLogContext = gymLogContext;
        _memoryCache = memoryCache;
    }

    public ExerciseCategory CreateExerciseCategory(ExerciseCategory exerciseCategory)
    {
        try
        {
            _gymLogContext.ExerciseCategories.Add(exerciseCategory);
            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.ExerciseCategories);

            return exerciseCategory;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while creating an exercise category: {ExerciseCategoryName}", exerciseCategory.ExerciseCategoryName);
            throw;
        }
    }

    public void DeleteExerciseCategory(int id)
    {
        try
        {
            var exerciseCategory = _gymLogContext.Find<ExerciseCategory>(id);
            if (exerciseCategory == null)
            {
                throw new KeyNotFoundException($"Exercise category with id {id} not found.");
            }

            var exercises = _gymLogContext.Entry(exerciseCategory).Collection(ec => ec.Exercises).Query().Count();
            if (exercises > 0)
            {
                throw new InvalidOperationException($"Cannot delete exercise category with id {id} because it is associated with {exercises} exercise(s).");
            }

            _gymLogContext.ExerciseCategories.Remove(exerciseCategory);
            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.ExerciseCategories);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while deleting the exercise category with id {Id}.", id);
            throw;
        }
    }

    public IEnumerable<ExerciseCategory> GetAllExerciseCategories()
    {
        try
        {
            var cachedValue = _memoryCache.GetOrCreate(CacheKeys.ExerciseCategories, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                var exerciseCategories = _gymLogContext.ExerciseCategories;
                return exerciseCategories.ToList();
            });

            return cachedValue!;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving all exercise categories.");
            throw;
        }
    }

    public ExerciseCategory GetExerciseCategoryById(int id)
    {
        try
        {
            var exerciseCategory = _gymLogContext.Find<ExerciseCategory>(id);
            if (exerciseCategory == null)
            {
                throw new KeyNotFoundException($"Exercise category with id {id} not found.");
            }

            return exerciseCategory;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving the exercise category with id {Id}.", id);
            throw;
        }
    }

    public ExerciseCategory UpdateExerciseCategory(ExerciseCategory exerciseCategory)
    {
        try
        {
            var existingExerciseCategory = _gymLogContext.Find<ExerciseCategory>(exerciseCategory.ExerciseCategoryId);
            if (existingExerciseCategory == null)
            {
                throw new KeyNotFoundException($"Exercise category with id {exerciseCategory.ExerciseCategoryId} not found.");
            }

            existingExerciseCategory.ExerciseCategoryName = exerciseCategory.ExerciseCategoryName;
            existingExerciseCategory.UpdatedBy = exerciseCategory.UpdatedBy;
            existingExerciseCategory.UpdatedAt = DateTime.UtcNow;

            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.ExerciseCategories);

            return exerciseCategory;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while updating the exercise category with id {Id}.", exerciseCategory.ExerciseCategoryId);
            throw;
        }
    }
}
