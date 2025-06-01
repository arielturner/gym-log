using Microsoft.AspNetCore.Mvc;
using GymLog.BLL.Services;
using GymLog.Common.DTOs;
using GymLog.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace GymLog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BodyPartsController : ControllerBase
{
    private readonly IBodyPartsService _bodyPartService;
    private readonly ICurrentUserService _currentUserService;

    public BodyPartsController(IBodyPartsService bodyPartService, ICurrentUserService currentUserService)
    {
        _bodyPartService = bodyPartService;
        _currentUserService = currentUserService;
    }

    // GET: api/body-parts
    [HttpGet]
    public IActionResult GetAllBodyParts()
    {
        var bodyParts = _bodyPartService.GetAllBodyParts();
        return Ok(bodyParts);
    }

    // GET: api/body-parts/{id}
    [HttpGet("{id}")]
    public IActionResult GetBodyPartById(int id)
    {
        var bodyPart = _bodyPartService.GetBodyPartById(id);
        return Ok(bodyPart);
    }

    // POST: api/body-parts
    [HttpPost]
    public IActionResult CreateBodyPart([FromBody] BodyPartDto bodyPart)
    {
        // TODO having trouble with unauthorized error when making request from angular
        // have to allow anonymous authorization but this breaks getting username from swagger page
        bodyPart.CreatedBy = _currentUserService.UserName ?? "Ariel";
        bodyPart.UpdatedBy = _currentUserService.UserName ?? "Ariel";

        var createdBodyPart = _bodyPartService.CreateBodyPart(bodyPart);
        return CreatedAtAction(nameof(GetBodyPartById), new { id = createdBodyPart.BodyPartId }, createdBodyPart);
    }

    // PUT: api/body-parts/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateBodyPart(int id, [FromBody] BodyPartDto bodyPart)
    {
        if (id != bodyPart.BodyPartId)
        {
            return BadRequest("ID mismatch");
        }

        var updatedBodyPart = _bodyPartService.UpdateBodyPart(bodyPart);
        return Ok(updatedBodyPart);
    }

    // DELETE: api/body-parts/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteBodyPart(int id)
    {
        _bodyPartService.DeleteBodyPart(id);
        return NoContent();
    }
}
