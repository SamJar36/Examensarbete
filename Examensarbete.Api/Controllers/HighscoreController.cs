using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.Api.Shared.Responses;
using Examensarbete.Api.Shared.Requests;

namespace Examensarbete.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HighscoreController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HighscoreController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetHighScoresAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("HighscoreMicroService");
            Console.WriteLine("API: Calling Highscore Microservice...");
            var highScores = await client.GetFromJsonAsync<List<ScoreResponse>>("api/highscores");
            Console.WriteLine($"API: Returning high scores... {highScores.Count} entries found.");
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
        try
        {
            var client = _httpClientFactory.CreateClient("HighscoreMicroService");
            var response = await client.PostAsJsonAsync("api/highscores", request);
            return Created("", response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while submitting score: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while submitting the score.");
        }
    }

    [HttpDelete("reset")]
    public async Task<IActionResult> ResetHighScoresAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("HighscoreMicroService");
            var response = await client.DeleteAsync("api/highscores/reset");
            if (response.IsSuccessStatusCode == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to reset high scores.");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while resetting high scores: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while resetting high scores.");
        }
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteHighscoreEntryAsync(Guid id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("HighscoreMicroService");
            var response = await client.DeleteAsync($"api/highscores/{id}");
            if (response.IsSuccessStatusCode == false)
            {
                return NotFound($"Highscore entry with ID {id} not found.");
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while deleting high score entry: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting high score entry with ID {id}.");
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("HighscoreMicroService");
            var response = await client.GetFromJsonAsync<ScoreResponse>($"api/highscores/{id}");
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (API): Error occurred while fetching high score entry: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while fetching high score entry with ID {id}.");
        }
    }
}
