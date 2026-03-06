using System.Runtime.InteropServices;

namespace Examensarbete.PlayerMicroService.Data.Models;

public class Player
{
    public Guid Id { get; set; }
    public string PlayerName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Level { get; set; }
    public int CurrentScore { get; set; }
}