using GymLog.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace GymLog.BLL.Services;

public class BodyPartsService : IBodyPartsService
{
    private readonly GymLogContext _gymLogContext;
    private readonly IMemoryCache _memoryCache;

    public BodyPartsService(GymLogContext gymLogContext, IMemoryCache memoryCache)
    {
        _gymLogContext = gymLogContext;
        _memoryCache = memoryCache;
    }

    public async Task<BodyPartDto> CreateBodyPartAsync(BodyPartDto bodyPart)
    {
        try
        {
            var newBodyPart = new BodyPart
            {
                BodyPartName = bodyPart.BodyPartName,
                CreatedBy = bodyPart.CreatedBy,
                UpdatedBy = bodyPart.UpdatedBy,
            };

            _gymLogContext.BodyParts.Add(newBodyPart);
            await _gymLogContext.SaveChangesAsync();

            _memoryCache.Remove(CacheKeys.BodyParts); // Invalidate cache after creating a new body part

            return new BodyPartDto
            {
                BodyPartId = newBodyPart.BodyPartId,
                BodyPartName = newBodyPart.BodyPartName,
            };
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while creating a body part: {BodyPartName}", bodyPart.BodyPartName);
            throw;
        }
    }

    public async Task DeleteBodyPartAsync(int id)
    {
        try
        {
            var bodyPart = await _gymLogContext.FindAsync<BodyPart>(id);
            if (bodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {id} not found.");
            }

            var exercises = await _gymLogContext.Entry(bodyPart).Collection(bp => bp.Exercises).Query().CountAsync();
            if (exercises > 0)
            {
                throw new InvalidOperationException($"Cannot delete body part with id {id} because it is associated with {exercises} exercises.");
            }

            _gymLogContext.BodyParts.Remove(bodyPart);
            await _gymLogContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while deleting the body part with id {Id}.", id);
            throw;
        }
    }

    public async Task<IEnumerable<BodyPartDto>> GetAllBodyPartsAsync()
    {
        try
        {
            var cachedValue = await _memoryCache.GetOrCreateAsync(CacheKeys.BodyParts, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                
                var bodyParts = _gymLogContext.BodyParts.Select(bp => new BodyPartDto
                {
                    BodyPartId = bp.BodyPartId,
                    BodyPartName = bp.BodyPartName
                }).ToListAsync();

                return bodyParts;
            });

            return cachedValue!;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving all body parts.");
            throw;
        }
    }

    public async Task<BodyPartDto> GetBodyPartByIdAsync(int id)
    {
        try
        {
            var bodyPart = await _gymLogContext.FindAsync<BodyPart>(id);
            if (bodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {id} not found.");
            }

            return new BodyPartDto
            {
                BodyPartId = bodyPart.BodyPartId,
                BodyPartName = bodyPart.BodyPartName,
            };
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving the body part with id {Id}.", id);
            throw;
        }
    }

    public async Task<BodyPartDto> UpdateBodyPartAsync(BodyPartDto bodyPart)
    {
        try
        {
            var existingBodyPart = await _gymLogContext.FindAsync<BodyPart>(bodyPart.BodyPartId);
            if (existingBodyPart == null)
            {
                throw new KeyNotFoundException($"Body part with id {bodyPart.BodyPartId} not found.");
            }

            existingBodyPart.BodyPartName = bodyPart.BodyPartName;
            existingBodyPart.UpdatedBy = bodyPart.UpdatedBy;
            existingBodyPart.UpdatedAt = DateTime.UtcNow;

            await _gymLogContext.SaveChangesAsync();

            return new BodyPartDto
            {
                BodyPartId = existingBodyPart.BodyPartId,
                BodyPartName = existingBodyPart.BodyPartName,
            };
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while updating the body part with id {Id}.", bodyPart.BodyPartId);
            throw;
        }
    }
}
