namespace Examensarbete.HighscoreMicroService.Data.Models;

public class HighScoreEntry
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}
