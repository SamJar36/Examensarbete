using MongoDB.Driver;
using Examensarbete.HighscoreMicroService.Data.Models;
using Examensarbete.HighscoreMicroService.Data.Interfaces;

namespace Examensarbete.HighscoreMicroService.Data.Repositories;

public class HighScoresRepository : IHighScoresRepository
{
    private readonly IMongoCollection<HighScoreEntry> _highScores;
    private List<HighScoreEntry> _presetHighScores = new List<HighScoreEntry>
    {
        new HighScoreEntry { Name = "Alice", Score = 1000 },
        new HighScoreEntry { Name = "Bob", Score = 900 },
        new HighScoreEntry { Name = "Charlie", Score = 800 },
        new HighScoreEntry { Name = "Diana", Score = 700 },
        new HighScoreEntry { Name = "Eve", Score = 600 }
    };

    public HighScoresRepository(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var database = client.GetDatabase("highscoresdb");
        _highScores = database.GetCollection<HighScoreEntry>("Highscores");

        _highScores.InsertMany(_presetHighScores);
    }

    public async Task<List<HighScoreEntry>> GetHighScoresAsync()
    {
        return await _highScores.Find(_ => true).SortByDescending(h => h.Score).ToListAsync();
    }

    public async Task<HighScoreEntry> SubmitScoreAsync(HighScoreEntry entry)
    {
        await _highScores.InsertOneAsync(entry);
        return entry;
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        var deleteResult = await _highScores.DeleteManyAsync(_ => true);
        if (deleteResult.IsAcknowledged)
        {
            await _highScores.InsertManyAsync(_presetHighScores);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteHighScoreEntryAsync(int id)
    {
        var deleteResult = await _highScores.DeleteOneAsync(h => h.Id == id);
        if (deleteResult.IsAcknowledged)
        {
            return true;
        }
        return false;
    }

    public async Task<HighScoreEntry> GetByIdAsync(int id)
    {
        return await _highScores.Find(h => h.Id == id).FirstOrDefaultAsync();
    }
}
