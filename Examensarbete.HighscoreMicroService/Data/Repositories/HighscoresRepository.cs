using MongoDB.Driver;
using Examensarbete.HighscoreMicroService.Data.Models;

namespace Examensarbete.HighscoreMicroService.Data.Repositories;

public class HighscoresRepository
{
    private readonly IMongoCollection<HighscoreEntry> _highScores;
    private List<HighscoreEntry> _presetHighScores = new List<HighscoreEntry>
    {
        new HighscoreEntry { Name = "Alice", Score = 1000 },
        new HighscoreEntry { Name = "Bob", Score = 900 },
        new HighscoreEntry { Name = "Charlie", Score = 800 },
        new HighscoreEntry { Name = "Diana", Score = 700 },
        new HighscoreEntry { Name = "Eve", Score = 600 }
    };

    public HighscoresRepository(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var database = client.GetDatabase("highscoresdb");
        _highScores = database.GetCollection<HighscoreEntry>("Highscores");

        _highScores.InsertMany(_presetHighScores);
    }

    public async Task<List<HighscoreEntry>> GetHighScoresAsync()
    {
        return await _highScores.Find(_ => true).SortByDescending(h => h.Score).ToListAsync();
    }

    public async Task<HighscoreEntry> SubmitScoreAsync(HighscoreEntry entry)
    {
        await _highScores.InsertOneAsync(entry);
        return entry;
    }

    public async Task<bool> ResetHighscoresAsync()
    {
        var deleteResult = await _highScores.DeleteManyAsync(_ => true);
        if (deleteResult.IsAcknowledged)
        {
            await _highScores.InsertManyAsync(_presetHighScores);
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteHighscoreEntryAsync(int id)
    {
        var deleteResult = await _highScores.DeleteOneAsync(h => h.Id == id);
        
    }
}
