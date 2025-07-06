using GymLog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.UI.Services;

public interface IBodyPartsService
{
    /// <summary>
    /// Get all body parts
    /// </summary>
    /// <returns>List of body parts</returns>
    IEnumerable<BodyPart> GetAllBodyParts();
    
    /// <summary>
    /// Get a body part by id
    /// </summary>
    /// <param name="id">Id of the body part</param>
    /// <returns>Body part</returns>
    BodyPart GetBodyPartById(int id);
    
    /// <summary>
    /// Create a new body part
    /// </summary>
    /// <param name="bodyPart">Body part to create</param>
    /// <returns>Created body part</returns>
    BodyPart CreateBodyPart(BodyPart bodyPart);
    
    /// <summary>
    /// Update a body part
    /// </summary>
    /// <param name="bodyPart">Body part to update</param>
    /// <returns>Updated body part</returns>
    BodyPart UpdateBodyPart(BodyPart bodyPart);
    
    /// <summary>
    /// Delete a body part
    /// </summary>
    /// <param name="id">Id of the body part to delete</param>
    void DeleteBodyPart(int id);
}
