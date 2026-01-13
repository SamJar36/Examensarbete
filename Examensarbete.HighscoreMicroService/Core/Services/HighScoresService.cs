using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Core.Interfaces;

namespace Examensarbete.HighscoreMicroService.Core.Services;

public class HighScoresService : IHighScoresService
{
    public async Task<List<PlayerResponse>> GetHighScoresAsync()
    {
        return new List<PlayerResponse>();
    }

    public async Task<PlayerResponse> SubmitScoreAsync(AddScoreRequest request)
    {
        return new PlayerResponse();
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        DeleteAllScores();
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

    public async Task DeleteHighscoresAsync()
    {
        DeleteAllScores();
    }

    public async Task<PlayerResponse> GetByIdAsync(int id)
    {
        return new PlayerResponse();
    }

    private void DeleteAllScores()
    {
        // do the thing
    }
}
