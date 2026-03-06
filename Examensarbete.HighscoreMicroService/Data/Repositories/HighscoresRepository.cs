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

        try
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("highscoredb");
            _highScores = database.GetCollection<HighScoreEntry>("Highscores");

            // _highScores.InsertMany(_presetHighScores);
            _nextId = _presetHighScores.Count;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while connecting to MongoDB: {ex.Message}");
            throw;
        }
    }

    public async Task<List<HighScoreEntry>> GetHighScoresAsync()
    {
        Console.WriteLine("Highscore Microservice (Repository): Fetching high scores from MongoDB...");
        try
        { 
            var scores = await _highScores
            .Find(_ => true)
            .SortByDescending(h => h.Score)
            .ToListAsync();
            System.Console.WriteLine($"Highscore Microservice (Repository): Retrieved {scores.Count} high score entries from MongoDB.");

            var scoresWithEmpties = PopulateListWithEmptyEntries(scores);

            Console.WriteLine("Highscore Microservice (Repository): Returning high scores with empty entries added if needed.");

            return scoresWithEmpties;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while fetching high scores: {ex.Message}");
            throw;
        }
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
