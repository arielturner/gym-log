using GymLog.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExercisesService _exerciseService;

        public ExercisesController(IExercisesService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        // GET: api/exercises?bodyPartId={bodyPartId}
        [HttpGet]
        public IActionResult GetExercisesByBodyPartId([FromQuery] int bodyPartId)
        {
            var exercises = _exerciseService.GetExercisesByBodyPartId(bodyPartId);
            return Ok(exercises);
        }
    }
}
