using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Common.DTOs;

namespace GymLog.BLL.Services;

public interface IBodyPartService
{
    /// <summary>
    /// Get all body parts
    /// </summary>
    /// <returns>List of body parts</returns>
    IEnumerable<BodyPartDto> GetAllBodyParts();
    
    /// <summary>
    /// Get a body part by id
    /// </summary>
    /// <param name="id">Id of the body part</param>
    /// <returns>Body part</returns>
    BodyPartDto GetBodyPartById(int id);
    
    /// <summary>
    /// Create a new body part
    /// </summary>
    /// <param name="bodyPart">Body part to create</param>
    /// <returns>Created body part</returns>
    BodyPartDto CreateBodyPart(BodyPartDto bodyPart);
    
    /// <summary>
    /// Update a body part
    /// </summary>
    /// <param name="bodyPart">Body part to update</param>
    /// <returns>Updated body part</returns>
    BodyPartDto UpdateBodyPart(BodyPartDto bodyPart);
    
    /// <summary>
    /// Delete a body part
    /// </summary>
    /// <param name="id">Id of the body part to delete</param>
    void DeleteBodyPart(int id);
}
