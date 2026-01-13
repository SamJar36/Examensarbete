using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Shared.Responses;

namespace Examensarbete.HighscoreMicroService.Core.Interfaces
{
    public interface IHighScoresService
    {
        Task<bool> DeleteHighscoreEntryAsync(int id);
        Task DeleteHighscoresAsync();
        Task<PlayerResponse> GetByIdAsync(int id);
        Task<List<PlayerResponse>> GetHighScoresAsync();
        Task<bool> ResetHighScoresAsync();
        Task<PlayerResponse> SubmitScoreAsync(AddScoreRequest request);
    }
}