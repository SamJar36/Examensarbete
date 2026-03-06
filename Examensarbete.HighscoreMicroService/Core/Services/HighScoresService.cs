using Examensarbete.HighscoreMicroService.Shared.Responses;
using Examensarbete.HighscoreMicroService.Shared.Requests;
using Examensarbete.HighscoreMicroService.Core.Interfaces;
using Examensarbete.HighscoreMicroService.Data.Models;
using Examensarbete.HighscoreMicroService.Data.Interfaces;

namespace Examensarbete.HighscoreMicroService.Core.Services;

public class HighScoresService : IHighScoresService
{
    private readonly IHighScoresRepository _highScoresRepository;

    public HighScoresService(IHighScoresRepository highScoresRepository)
    {
        _highScoresRepository = highScoresRepository;
    }
    public async Task<List<ScoreResponse>> GetHighScoresAsync()
    {
        Console.WriteLine("Highscore Microservice (Service): Fetching high scores from repository...");
        try
        {
            var highScores = await _highScoresRepository.GetHighScoresAsync();
            if (highScores == null || highScores.Count == 0)
            {
                Console.WriteLine("Highscore Microservice (Service): No high scores found in repository.");
                return new List<ScoreResponse>();
            }
            Console.WriteLine($"Highscore Microservice (Service): Retrieved {highScores.Count} high score entries from repository.");
            return ConvertModelListToResponseList(highScores);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Service): Error occurred while fetching high scores: {ex.Message}");
            return new List<ScoreResponse>();
        }
    }

    public async Task<ScoreResponse> SubmitScoreAsync(AddScoreRequest request)
    {
        try
        {
            var highScore = await _highScoresRepository.SubmitScoreAsync(ConvertAddScoreRequestToModel(request));
            return ConvertModelToResponse(highScore);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Service): Error occurred while submitting score: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> ResetHighScoresAsync()
    {
        try
        {
            return await _highScoresRepository.ResetHighScoresAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Highscore Microservice (Service): Error occurred while resetting high scores: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteHighscoreEntryAsync(Guid id)
    {
        try
        {
            return await _highScoresRepository.DeleteHighScoreEntryAsync(id);
        }
        catch
        {
            Console.WriteLine($"Highscore Microservice (Service): Error occurred while deleting high score entry with ID {id}.");
            return false;
        }
    }

    public async Task<ScoreResponse> GetByIdAsync(Guid id)
    {
        try
        {
            var highScore = await _highScoresRepository.GetByIdAsync(id);
            return ConvertModelToResponse(highScore);
        }
        catch
        {
            Console.WriteLine($"Highscore Microservice (Service): Error occurred while fetching high score entry with ID {id}.");
            return null;
        }
    }

    private List<ScoreResponse> ConvertModelListToResponseList(List<HighScoreEntry> highScores)
    {
        Console.WriteLine("Highscore Microservice (Service): Converting high score models to response format...");
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
        Console.WriteLine($"Highscore Microservice (Service): Conversion complete. {newList.Count} entries converted.");
        return newList;
    }

    private HighScoreEntry ConvertAddScoreRequestToModel(AddScoreRequest request)
    {
        HighScoreEntry entry = new HighScoreEntry
        {
            Name = request.Name,
            Score = request.Score
        };
        return entry;
    }

    private ScoreResponse ConvertModelToResponse(HighScoreEntry entry)
    {
        ScoreResponse response = new ScoreResponse
        {
            Name = entry.Name,
            Score = entry.Score
        };
        return response;
    }
}
