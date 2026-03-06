using MongoDB.Driver;
using Examensarbete.HighscoreMicroService.Data.Models;
using Examensarbete.HighscoreMicroService.Data.Interfaces;
using System;

namespace Examensarbete.HighscoreMicroService.Data.Repositories;

public class HighScoresRepository : IHighScoresRepository
{
    private readonly IMongoCollection<HighScoreEntry> _highScores;
    private List<HighScoreEntry> _presetHighScores = new List<HighScoreEntry>
    {
        new HighScoreEntry { Id = Guid.NewGuid(), Name = "Alice", Score = 1000 },
        new HighScoreEntry { Id = Guid.NewGuid(), Name = "Bob", Score = 900 },
        new HighScoreEntry { Id = Guid.NewGuid(), Name = "Charlie", Score = 800 },
        new HighScoreEntry { Id = Guid.NewGuid(), Name = "Diana", Score = 700 },
        new HighScoreEntry { Id = Guid.NewGuid(), Name = "Eve", Score = 600 }
    };

    public HighScoresRepository(IConfiguration config)
    {
        try
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("highscoredb");
            _highScores = database.GetCollection<HighScoreEntry>("Highscores");

            // _highScores.InsertMany(_presetHighScores);
            var count = _highScores.CountDocuments(_ => true);
            if (count == 0)
            {
                Console.WriteLine("Highscore Microservice (Repository): No high scores found in MongoDB. Inserting preset high scores...");
                _highScores.InsertMany(_presetHighScores);
            }
            else
            {
                Console.WriteLine($"Highscore Microservice (Repository): Found {count} high score entries in MongoDB. Skipping preset insertion.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while connecting to MongoDB: {ex.Message}");
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
            Console.WriteLine($"Highscore Microservice (Repository): Retrieved {scores.Count} high score entries from MongoDB.");

            var scoresWithEmpties = PopulateListWithEmptyEntries(scores);

            Console.WriteLine("Highscore Microservice (Repository): Returning high scores with empty entries added if needed.");

            return scoresWithEmpties;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while fetching high scores: {ex.Message}");
            return new List<HighScoreEntry>();
        }
    }

    public async Task<HighScoreEntry> SubmitScoreAsync(HighScoreEntry entry)
    {
        try
        {
            entry.Id = Guid.NewGuid();
            await _highScores.InsertOneAsync(entry);
            return entry;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while submitting score: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        try
        {
            var deleteResult = await _highScores.DeleteManyAsync(_ => true);
            if (deleteResult.IsAcknowledged)
            {
                try
                {
                    await _highScores.InsertManyAsync(_presetHighScores);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Highscore Microservice (Repository): Error occurred while inserting preset high scores after reset: {ex.Message}");
                    throw;
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while resetting high scores: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteHighScoreEntryAsync(Guid id)
    {
        try
        {
            var deleteResult = await _highScores.DeleteOneAsync(h => h.Id == id);
            if (deleteResult.IsAcknowledged)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while deleting high score entry with ID {id}: {ex.Message}");
            return false;
        }
    }

    public async Task<HighScoreEntry> GetByIdAsync(Guid id)
    {
        try
        {
            return await _highScores.Find(h => h.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Repository): Error occurred while fetching high score entry with ID {id}: {ex.Message}");
            return null;
        }
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
                Name = "",
                Score = 0
            });
        }
        return scores;
    }
}
