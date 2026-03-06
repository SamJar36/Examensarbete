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
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScoreAsync([FromBody] AddScoreRequest request)
    {
        try
        {
            var result = await _highScoresService.SubmitScoreAsync(request);
            return Created();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while submitting score: {ex.Message}");
            throw;
        }
    }

    [HttpDelete("reset")]
    public async Task<IActionResult> ResetHighScoresAsync()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while resetting high scores: {ex.Message}");
            throw;
        }
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteHighscoreEntryAsync(Guid id)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while deleting high score entry with ID {id}: {ex.Message}");
            throw;
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        try
        {
            ScoreResponse response = await _highScoresService.GetByIdAsync(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while fetching high score entry with ID {id}: {ex.Message}");
            throw;
        }
    }
}
