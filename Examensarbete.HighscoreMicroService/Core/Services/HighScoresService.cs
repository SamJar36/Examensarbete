using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Examensarbete.HighscoreMicroService.Data.Models;
using Examensarbete.HighscoreMicroService.Data.Interfaces;

namespace Examensarbete.HighscoreMicroService.Core.Services;

public class HighScoresService : IHighScoresService
{
    private readonly IHighScoresRepository _highScoresRepository;

    public HighScoresService(IHighScoresRepository highScoresRepository)
    {
        _highScoresRepository = highScoresRepository;
    }
    public async Task<List<ScoreResponse>> GetHighScoresAsync()
    {
        var highScores = await _highScoresRepository.GetHighScoresAsync();
        return ConvertModelListToResponseList(highScores);
    }

    public async Task<ScoreResponse> SubmitScoreAsync(AddScoreRequest request)
    {
        var highScore = await _highScoresRepository.SubmitScoreAsync(ConvertAddScoreRequestToModel(request));
        return ConvertModelToResponse(highScore);
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        return await _highScoresRepository.ResetHighScoresAsync();
    }

    public async Task<bool> DeleteHighscoreEntryAsync(int id)
    {
        return await _highScoresRepository.DeleteHighScoreEntryAsync(id);
    }

    public async Task<ScoreResponse> GetByIdAsync(int id)
    {
        var highScore = await _highScoresRepository.GetByIdAsync(id);
        return ConvertModelToResponse(highScore);
    }

    private List<ScoreResponse> ConvertModelListToResponseList(List<HighScoreEntry> highScores)
    {
        List<ScoreResponse> newList = new List<ScoreResponse>();
        foreach (var score in highScores)
        {
            ScoreResponse response = new ScoreResponse
            {
                Name = score.Name,
                Score = score.Score
            };
            newList.Add(response);
        }
        return newList;
    }

    private HighScoreEntry ConvertAddScoreRequestToModel(AddScoreRequest request)
    {
        HighScoreEntry entry = new HighScoreEntry
        {
            Name = request.Name,
            Score = request.Score
        };
        return entry;
    }

    private ScoreResponse ConvertModelToResponse(HighScoreEntry entry)
    {
        ScoreResponse response = new ScoreResponse
        {
            Name = entry.Name,
            Score = entry.Score
        };
        return response;
    }
}
