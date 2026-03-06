using Examensarbete.HighscoreMicroService.Data.Models;

namespace Examensarbete.HighscoreMicroService.Data.Interfaces
{
    public interface IHighScoresRepository
    {
        Task<bool> DeleteHighScoreEntryAsync(Guid id);
        Task<HighScoreEntry> GetByIdAsync(Guid id);
        Task<List<HighScoreEntry>> GetHighScoresAsync();
        Task<bool> ResetHighScoresAsync();
        Task<HighScoreEntry> SubmitScoreAsync(HighScoreEntry entry);
    }
}