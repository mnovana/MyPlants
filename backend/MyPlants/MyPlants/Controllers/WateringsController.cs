using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPlants.Interfaces;
using MyPlants.Models;

namespace MyPlants.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WateringsController : ControllerBase
    {
        private readonly IWateringService _wateringService;

        public WateringsController(IWateringService wateringService)
        {
            _wateringService = wateringService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostWatering(Watering watering)
        {
            return Ok(await _wateringService.AddAsync(watering));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> DeleteWatering(int plantId, DateTime date)
        {
            await _wateringService.DeleteAsync(plantId, date);

            return NoContent();
        }
    }
}
