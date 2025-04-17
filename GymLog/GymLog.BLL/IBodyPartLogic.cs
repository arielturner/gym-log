using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Common.DTOs;

namespace GymLog.BLL;

public interface IBodyPartLogic
{
    /// <summary>
    /// Get all body parts
    /// </summary>
    /// <returns>List of body parts</returns>
    Task<IEnumerable<BodyPartDto>> GetAllBodyPartsAsync();
    
    /// <summary>
    /// Get a body part by id
    /// </summary>
    /// <param name="id">Id of the body part</param>
    /// <returns>Body part</returns>
    Task<BodyPartDto> GetBodyPartByIdAsync(int id);
    
    /// <summary>
    /// Create a new body part
    /// </summary>
    /// <param name="bodyPart">Body part to create</param>
    /// <returns>Created body part</returns>
    Task<BodyPartDto> CreateBodyPartAsync(BodyPartDto bodyPart);
    
    /// <summary>
    /// Update a body part
    /// </summary>
    /// <param name="bodyPart">Body part to update</param>
    /// <returns>Updated body part</returns>
    Task<BodyPartDto> UpdateBodyPartAsync(BodyPartDto bodyPart);
    
    /// <summary>
    /// Delete a body part
    /// </summary>
    /// <param name="id">Id of the body part to delete</param>
    Task DeleteBodyPartAsync(int id);
}
