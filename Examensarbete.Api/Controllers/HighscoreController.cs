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
        var client = _httpClientFactory.CreateClient("HighscoreMicroservice");
        var highScores = await client.GetFromJsonAsync<List<ScoreResponse>>("api/highscores");
        return Ok(highScores);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScoreAsync([FromBody] AddScoreRequest request)
    {
        var client = _httpClientFactory.CreateClient("HighscoreMicroservice");
        var response = await client.PostAsJsonAsync("api/highscores", request);
        return Created("", response);
    }

    [HttpDelete("reset")]
    public async Task<IActionResult> ResetHighScoresAsync()
    {
        var client = _httpClientFactory.CreateClient("HighscoreMicroservice");
        var response = await client.DeleteAsync("api/highscores/reset");
        if (response.IsSuccessStatusCode == false)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to reset high scores.");
        }
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteHighscoreEntryAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("HighscoreMicroservice");
        var response = await client.DeleteAsync($"api/highscores/{id}");
        if (response.IsSuccessStatusCode == false)
        {
            return NotFound($"Highscore entry with ID {id} not found.");
        }
        return NoContent();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("HighscoreMicroservice");
        var response = await client.GetFromJsonAsync<ScoreResponse>($"api/highscores/{id}");
        return Ok(response);
    }
}
