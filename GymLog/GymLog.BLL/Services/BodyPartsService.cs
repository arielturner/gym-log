using GymLog.Common.DTOs;
using Serilog;

namespace GymLog.BLL.Services;

public class BodyPartsService : IBodyPartsService
{
    private readonly GymLogContext _gymLogContext;

    public BodyPartsService(GymLogContext gymLogContext)
    {
        _gymLogContext = gymLogContext;
    }

    public BodyPartDto CreateBodyPart(BodyPartDto bodyPart)
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
            _gymLogContext.SaveChanges();

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

    public IEnumerable<BodyPartDto> GetAllBodyParts()
    {
        try
        {
            var bodyParts = _gymLogContext.BodyParts;

            return bodyParts.Select(bp => new BodyPartDto
            {
                BodyPartId = bp.BodyPartId,
                BodyPartName = bp.BodyPartName
            });
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while retrieving all body parts.");
            throw;
        }
    }

    public BodyPartDto GetBodyPartById(int id)
    {
        try
        {
            var bodyPart = _gymLogContext.Find<BodyPart>(id);
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

    public BodyPartDto UpdateBodyPart(BodyPartDto bodyPart)
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
