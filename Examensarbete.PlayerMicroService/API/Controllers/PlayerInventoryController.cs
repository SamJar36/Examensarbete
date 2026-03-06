using Microsoft.AspNetCore.Mvc;

namespace Examensarbete.PlayerMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerInventoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetInventoriesAsync()
        {
            return Ok();
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetInventoryAsync(Guid playerId)
        {
            return Ok();
        }

        [HttpPost("{playerId}")]
        public async Task<IActionResult> CreateInventoryAsync(Guid playerId, [FromBody] object request)
        {
            return Created("", null);
        }

        [HttpPut("{playerId}")]
        public async Task<IActionResult> UpdateInventoryAsync(Guid playerId, [FromBody] object request)
        {
            return NoContent();
        }

        [HttpDelete("{playerId}/reset")]
        public async Task<IActionResult> ResetInventoryAsync(Guid playerId)
        {
            return NoContent();
        }

        [HttpDelete("{playerId}/item/{itemName}")]
        public async Task<IActionResult> DeleteInventoryItemAsync(Guid playerId, string itemName)
        {
            return NoContent();
        }

        [HttpPut("{playerId}/coins/{amount}")]
        public async Task<IActionResult> UpdateCoinsAsync(Guid playerId, int amount)
        {
            return NoContent();
        }

        [HttpDelete("{playerId}/coins/reset")]
        public async Task<IActionResult> ResetCoinsAsync(Guid playerId)
        {
            return NoContent();
        }
    }
}
