using GymLog.Common.DTOs;

namespace GymLog.BLL;

public class BodyPartLogic : IBodyPartLogic
{
    public BodyPartLogic()
    {
    }

    public Task<BodyPartDto> CreateBodyPartAsync(BodyPartDto bodyPart)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBodyPartAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BodyPartDto>> GetAllBodyPartsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BodyPartDto> GetBodyPartByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BodyPartDto> UpdateBodyPartAsync(BodyPartDto bodyPart)
    {
        throw new NotImplementedException();
    }
}
