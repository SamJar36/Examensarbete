using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examensarbete.HighscoreMicroService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HighscoresController : ControllerBase
{
    private readonly IHighScoresService _highScoresService;
    public HighscoresController(IHighScoresService highScoresService)
    {
        _highScoresService = highScoresService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHighScoresAsync()
    {
        List<PlayerResponse> highScores = await _highScoresService.GetHighScoresAsync();
        if (highScores == null || highScores.Count == 0)
        {
            return Ok(new List<PlayerResponse>());
        }
        return Ok(highScores);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScoreAsync([FromBody] AddScoreRequest request)
    {
        var result = await _highScoresService.SubmitScoreAsync(request);
        return Created();
    }

    [HttpPost("reset")]
    public async Task<IActionResult> ResetHighScoresAsync()
    {
        bool isReset = await _highScoresService.ResetHighScoresAsync();
        if (isReset == false)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to reset high scores.");
        }
        else
        {
            return Created();
        }
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteHighscoreEntryAsync(int id)
    {
        bool isDeleted = await _highScoresService.DeleteHighscoreEntryAsync(id);
        if (isDeleted == false)
        {
            return NotFound($"Highscore entry with ID {id} not found.");
        }
        else
        {
            return NoContent();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteHighscoresAsync()
    {
        return NoContent();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        PlayerResponse response = await _highScoresService.GetByIdAsync(id);
        return Ok(response);
    }
}
