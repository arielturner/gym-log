using GymLog.UI.Models;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace GymLog.UI.Services;

public class BodyPartsService : IBodyPartsService
{
    private readonly GymLogContext _gymLogContext;
    private readonly IMemoryCache _memoryCache;

    public BodyPartsService(GymLogContext gymLogContext, IMemoryCache memoryCache)
    {
        _gymLogContext = gymLogContext;
        _memoryCache = memoryCache;
    }

    public BodyPart CreateBodyPart(BodyPart bodyPart)
    {
        try
        {
            _gymLogContext.BodyParts.Add(bodyPart);
            _gymLogContext.SaveChanges();

            _memoryCache.Remove(CacheKeys.BodyParts); // Invalidate cache after creating a new body part

            return bodyPart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while creating a body part: {BodyPartName}", bodyPart.BodyPartName);
            throw;
        }
    }

    public void DeleteBodyPart(int id)
    {
        try
        {
            var bodyPart = _gymLogContext.Find<BodyPart>(id);
            if (bodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {id} not found.");
            }

            var exercises = _gymLogContext.Entry(bodyPart).Collection(bp => bp.Exercises).Query().Count();
            if (exercises > 0)
            {
                throw new InvalidOperationException($"Cannot delete body part with id {id} because it is associated with {exercises} exercises.");
            }

            _gymLogContext.BodyParts.Remove(bodyPart);
            _gymLogContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while deleting the body part with id {Id}.", id);
            throw;
        }
    }

    public IEnumerable<BodyPart> GetAllBodyParts()
    {
        try
        {
            var cachedValue = _memoryCache.GetOrCreate(CacheKeys.BodyParts, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                
                var bodyParts = _gymLogContext.BodyParts;
                return bodyParts.ToList();
            });

            return cachedValue!;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving all body parts.");
            throw;
        }
    }

    public BodyPart GetBodyPartById(int id)
    {
        try
        {
            var bodyPart = _gymLogContext.Find<BodyPart>(id);
            if (bodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {id} not found.");
            }

            return bodyPart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving the body part with id {Id}.", id);
            throw;
        }
    }

    public BodyPart UpdateBodyPart(BodyPart bodyPart)
    {
        try
        {
            var existingBodyPart = _gymLogContext.Find<BodyPart>(bodyPart.BodyPartId);
            if (existingBodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {bodyPart.BodyPartId} not found.");
            }

            existingBodyPart.BodyPartName = bodyPart.BodyPartName;
            existingBodyPart.UpdatedBy = bodyPart.UpdatedBy;
            existingBodyPart.UpdatedAt = DateTime.UtcNow;

            _gymLogContext.SaveChanges();

            return bodyPart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while updating the body part with id {Id}.", bodyPart.BodyPartId);
            throw;
        }
    }
}
