using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.Api.Shared.Responses;
using Examensarbete.Api.Shared.Requests;

namespace Examensarbete.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HighscoreController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetHighScoresAsync()
    {
        List<ScoreResponse> highScores = new List<ScoreResponse>
        {
            new ScoreResponse { Name = "ALICE", Score = 1500 },
            new ScoreResponse { Name = "BOB", Score = 1200 },
            new ScoreResponse { Name = "CHARLIE", Score = 1000 }
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

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok();
    }
}
