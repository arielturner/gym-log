using GymLog.UI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace GymLog.UI.Services;

public class ExercisesService : IExercisesService
{
    private readonly GymLogContext _gymLogContext;
    private readonly IMemoryCache _memoryCache;

    public ExercisesService(GymLogContext gymLogContext, IMemoryCache memoryCache)
    {
        _gymLogContext = gymLogContext;
        _memoryCache = memoryCache;
    }

    public Exercise CreateExercise(Exercise exercise)
    {
        try
        {
            _gymLogContext.Add(exercise);
            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.Exercises);

            return exercise;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while creating an exercise: {ExerciseName}", exercise.ExerciseName);
            throw;
        }
    }

    public void DeleteExercise(int id)
    {
        try
        {
            var exercise = _gymLogContext.Find<Exercise>(id);
            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with id {id} not found.");
            }

            var templateCount = _gymLogContext.Entry(exercise).Collection(e => e.WorkoutTemplateExercises).Query().Count();
            if (templateCount > 0)
            {
                throw new InvalidOperationException($"Cannot delete exercise with id {id} because it is associated with {templateCount} workout template(s).");
            }

            _gymLogContext.Remove(exercise);
            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.Exercises);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while deleting the exercise with id {Id}.", id);
            throw;
        }
    }

    public IEnumerable<Exercise> GetAllExercises()
    {
        try
        {
            var cachedValue = _memoryCache.GetOrCreate(CacheKeys.Exercises, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                var exercises = _gymLogContext.Exercises
                    .Include(e => e.BodyPart)
                    .Include(e => e.ExerciseCategory)
                    .ToList();
                return exercises.ToList();
            });

            return cachedValue!;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving all exercises.");
            throw;
        }
    }

    public Exercise GetExerciseById(int id)
    {
        try
        {
            var exercise = _gymLogContext.Find<Exercise>(id);
            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with id {id} not found.");
            }

            return exercise;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving the exercise with id {Id}.", id);
            throw;
        }
    }

    public Exercise UpdateExercise(Exercise exercise)
    {
        try
        {
            var existingExercise = _gymLogContext.Find<Exercise>(exercise.ExerciseId);
            if (existingExercise == null)
            {
                throw new KeyNotFoundException($"Exercise with id {exercise.ExerciseId} not found.");
            }

            existingExercise.ExerciseName = exercise.ExerciseName;
            existingExercise.BodyPartId = exercise.BodyPartId;
            existingExercise.ExerciseCategoryId = exercise.ExerciseCategoryId;
            existingExercise.EstimatedOneRepMax = exercise.EstimatedOneRepMax;
            // Add any additional fields to update as needed

            _gymLogContext.SaveChanges();
            _memoryCache.Remove(CacheKeys.Exercises);

            return exercise;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while updating the exercise with id {Id}.", exercise.ExerciseId);
            throw;
        }
    }
}
