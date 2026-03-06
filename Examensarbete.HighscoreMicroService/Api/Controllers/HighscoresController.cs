using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examensarbete.HighscoreMicroService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HighScoresController : ControllerBase
{
    private readonly IHighScoresService _highScoresService;
    public HighScoresController(IHighScoresService highScoresService)
    {
        _highScoresService = highScoresService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHighScoresAsync()
    {
        Console.WriteLine("Highscore Microservice (API): Fetching high scores...");
        try
        {
            List<ScoreResponse> highScores = await _highScoresService.GetHighScoresAsync();
            System.Console.WriteLine($"Highscore Microservice (API): Retrieved {highScores.Count} high score entries.");
            if (highScores == null || highScores.Count == 0)
            {
                Console.WriteLine("Highscore Microservice (API): No high scores found.");
                return Ok(new List<ScoreResponse>());
            }
            return Ok(highScores);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while fetching high scores: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching high scores.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScoreAsync([FromBody] AddScoreRequest request)
    {
        var result = await _highScoresService.SubmitScoreAsync(request);
        return Created();
    }

    [HttpDelete("reset")]
    public async Task<IActionResult> ResetHighScoresAsync()
    {
        bool isReset = await _highScoresService.ResetHighScoresAsync();
        if (isReset == false)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to reset high scores.");
        }
        else
        {
            return Ok();
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

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        ScoreResponse response = await _highScoresService.GetByIdAsync(id);
        return Ok(response);
    }
}
