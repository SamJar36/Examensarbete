using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Core.Interfaces;

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
        return Ok();
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
