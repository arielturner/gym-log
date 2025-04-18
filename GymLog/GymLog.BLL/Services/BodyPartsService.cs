using GymLog.Common.DTOs;

namespace GymLog.BLL.Services;

public class BodyPartsService(GymLogContext gymLogContext) : IBodyPartsService
{
    public BodyPartDto CreateBodyPart(BodyPartDto bodyPart)
    {
        var newBodyPart = new BodyPart
        {
            BodyPartName = bodyPart.BodyPartName,
            CreatedBy = bodyPart.CreatedBy,
            UpdatedBy = bodyPart.UpdatedBy,
        };

        gymLogContext.BodyParts.Add(newBodyPart);
        gymLogContext.SaveChanges();

        return new BodyPartDto
        {
            BodyPartId = newBodyPart.BodyPartId,
            BodyPartName = newBodyPart.BodyPartName,
        };
    }

    public void DeleteBodyPart(int id)
    {
        var bodyPart = gymLogContext.Find<BodyPart>(id);
        if (bodyPart == null)
        {
            throw new KeyNotFoundException($"Body part with id {id} not found.");
        }

        var exercises = gymLogContext.Entry(bodyPart).Collection(bp => bp.Exercises).Query().Count();
        if (exercises > 0)
        {
            throw new InvalidOperationException($"Cannot delete body part with id {id} because it is associated with {exercises} exercises.");
        }

        gymLogContext.BodyParts.Remove(bodyPart);
        gymLogContext.SaveChanges();
    }

    public IEnumerable<BodyPartDto> GetAllBodyParts()
    {
        var bodyParts = gymLogContext.BodyParts;

        return bodyParts.Select(bp => new BodyPartDto
        {
            BodyPartId = bp.BodyPartId,
            BodyPartName = bp.BodyPartName
        });
    }

    public BodyPartDto GetBodyPartById(int id)
    {
        var bodyPart = gymLogContext.Find<BodyPart>(id);
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

    public BodyPartDto UpdateBodyPart(BodyPartDto bodyPart)
    {
        var existingBodyPart = gymLogContext.Find<BodyPart>(bodyPart.BodyPartId);
        if (existingBodyPart == null)
        {
            throw new KeyNotFoundException($"Body part with id {bodyPart.BodyPartId} not found.");
        }
        
        existingBodyPart.BodyPartName = bodyPart.BodyPartName;
        existingBodyPart.UpdatedBy = bodyPart.UpdatedBy;
        existingBodyPart.UpdatedAt = DateTime.UtcNow;
        
        gymLogContext.SaveChanges();
        
        return new BodyPartDto
        {
            BodyPartId = existingBodyPart.BodyPartId,
            BodyPartName = existingBodyPart.BodyPartName,
        };
    }
}
