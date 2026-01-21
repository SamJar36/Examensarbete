using MongoDB.Driver;
using Examensarbete.HighscoreMicroService.Data.Models;
using Examensarbete.HighscoreMicroService.Data.Interfaces;

namespace Examensarbete.HighscoreMicroService.Data.Repositories;

public class HighScoresRepository : IHighScoresRepository
{
    private readonly IMongoCollection<HighScoreEntry> _highScores;
    private int _nextId = 0;
    private List<HighScoreEntry> _presetHighScores = new List<HighScoreEntry>
    {
        new HighScoreEntry { Id = 1, Name = "Alice", Score = 1000 },
        new HighScoreEntry { Id = 2, Name = "Bob", Score = 900 },
        new HighScoreEntry { Id = 3, Name = "Charlie", Score = 800 },
        new HighScoreEntry { Id = 4, Name = "Diana", Score = 700 },
        new HighScoreEntry { Id = 5, Name = "Eve", Score = 600 }
    };

    public HighScoresRepository(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var database = client.GetDatabase("highscoredb");
        _highScores = database.GetCollection<HighScoreEntry>("Highscores");

        _highScores.InsertMany(_presetHighScores);
        _nextId = _presetHighScores.Count;
    }

    public async Task<List<HighScoreEntry>> GetHighScoresAsync()
    {
        var scores = await _highScores
        .Find(_ => true)
        .SortByDescending(h => h.Score)
        .ToListAsync();

        var scoresWithEmpties = PopulateListWithEmptyEntries(scores);

        return scoresWithEmpties;
    }

    public async Task<HighScoreEntry> SubmitScoreAsync(HighScoreEntry entry)
    {
        entry.Id = _nextId++;
        await _highScores.InsertOneAsync(entry);
        return entry;
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        var deleteResult = await _highScores.DeleteManyAsync(_ => true);
        if (deleteResult.IsAcknowledged)
        {
            await _highScores.InsertManyAsync(_presetHighScores);
            _nextId = _presetHighScores.Count;
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

    private List<HighScoreEntry> PopulateListWithEmptyEntries(List<HighScoreEntry> scores)
    {
        int needed = 14 - scores.Count;
        if (needed <= 0)
        {
            return scores;
        }
        for (int i = 0; i < needed; i++)
        {
            scores.Add(new HighScoreEntry
            {
                Name = "None",
                Score = 0
            });
        }
        return scores;
    }
}
