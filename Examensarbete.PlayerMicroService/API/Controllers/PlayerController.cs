using Microsoft.AspNetCore.Mvc;

namespace Examensarbete.PlayerMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync()
        {
           return Ok(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerByIdAsync(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerAsync([FromBody] object request)
        {
            return Created("", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerAsync(Guid id, [FromBody] object request)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerAsync(Guid id)
        {
            return NoContent();
        }

        [HttpDelete("reset")]
        public async Task<IActionResult> ResetPlayersAsync()
        {
            return NoContent();
        }
    }
}
