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
    public async Task<IActionResult> GetAllBodyParts()
    {
        var bodyParts = await _bodyPartService.GetAllBodyPartsAsync();
        return Ok(bodyParts);
    }

    // GET: api/body-parts/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBodyPartById(int id)
    {
        var bodyPart = await _bodyPartService.GetBodyPartByIdAsync(id);
        return Ok(bodyPart);
    }

    // POST: api/body-parts
    [HttpPost]
    public async Task<IActionResult> CreateBodyPart([FromBody] BodyPartDto bodyPart)
    {
        // TODO having trouble with unauthorized error when making request from angular
        // have to allow anonymous authorization but this breaks getting username from swagger page
        bodyPart.CreatedBy = _currentUserService.UserName ?? "Ariel";
        bodyPart.UpdatedBy = _currentUserService.UserName ?? "Ariel";

        var createdBodyPart = await _bodyPartService.CreateBodyPartAsync(bodyPart);
        return CreatedAtAction(nameof(GetBodyPartById), new { id = createdBodyPart.BodyPartId }, createdBodyPart);
    }

    // PUT: api/body-parts/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBodyPart(int id, [FromBody] BodyPartDto bodyPart)
    {
        if (id != bodyPart.BodyPartId)
        {
            return BadRequest("ID mismatch");
        }

        var updatedBodyPart = await _bodyPartService.UpdateBodyPartAsync(bodyPart);
        return Ok(updatedBodyPart);
    }

    // DELETE: api/body-parts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBodyPart(int id)
    {
        await _bodyPartService.DeleteBodyPartAsync(id);
        return NoContent();
    }
}
