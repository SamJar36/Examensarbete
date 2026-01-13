using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Shared.Responses;

namespace Examensarbete.HighscoreMicroService.Core.Interfaces
{
    public interface IHighScoresService
    {
        Task<bool> DeleteHighscoreEntryAsync(int id);
        Task<ScoreResponse> GetByIdAsync(int id);
        Task<List<ScoreResponse>> GetHighScoresAsync();
        Task<bool> ResetHighScoresAsync();
        Task<ScoreResponse> SubmitScoreAsync(AddScoreRequest request);
    }
}