using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Examensarbete.HighscoreMicroService.Data.Models;

namespace Examensarbete.HighscoreMicroService.Core.Services;

public class HighScoresService : IHighScoresService
{
    public async Task<List<ScoreResponse>> GetHighScoresAsync()
    {
        return new List<ScoreResponse>();
    }

    public async Task<ScoreResponse> SubmitScoreAsync(AddScoreRequest request)
    {
        return new ScoreResponse();
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        //then populate list with preset scores
        //if successful, return true
        bool result = true;
        return result;
    }

    public async Task<bool> DeleteHighscoreEntryAsync(int id)
    {
        bool result = true;
        return result;
    }

    public async Task<ScoreResponse> GetByIdAsync(int id)
    {
        return new ScoreResponse();
    }

    private List<ScoreResponse> ConvertFromModelListToResponseList(List<HighscoreEntry> highScores)
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
}
