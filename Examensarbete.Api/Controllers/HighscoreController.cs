using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.Api.Shared.Responses;
using Examensarbete.Api.Shared.Requests;

namespace Examensarbete.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHighScoresAsync()
        {
            List<PlayerResponse> highScores = new List<PlayerResponse>
            {
                new PlayerResponse { Name = "ALICE", Score = 1500 },
                new PlayerResponse { Name = "BOB", Score = 1200 },
                new PlayerResponse { Name = "CHARLIE", Score = 1000 }
            };
            return Ok(highScores);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitScoreAsync([FromBody] AddScoreRequest request)
        {
            return Created();
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetHighScoresAsync()
        {
            return Created();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteHighscoreEntryAsync(int id)
        {
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHighscoresAsync()
        {
            return NoContent();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok();
        }
    }
}
