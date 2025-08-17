using GymLog.BLL.Services;
using GymLog.Common.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GymLog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationsController : ControllerBase
    {
        private IOneRepMaxEstimator _oneRepMaxEstimator;

        public CalculationsController(IOneRepMaxEstimator oneRepMaxEstimator)
        {
            _oneRepMaxEstimator = oneRepMaxEstimator;
        }

        [HttpGet("one-rep-max")]
        public IActionResult GetOneRepMax(double weight, int reps, WeightUnit weightUnit)
        {
            if (reps is < 1 or > 10)
            {
                return BadRequest("Reps must be between 1 and 10");
            }

            if (weight <= 0)
            {
                return BadRequest("Weight must be positive");
            }

            var estimate = _oneRepMaxEstimator.GetEstimate(weight, reps, weightUnit);
            return Ok(estimate);
        }

    }
}
