using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Examensarbete.HighscoreMicroService.Data.Models;

public class HighScoreEntry
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}