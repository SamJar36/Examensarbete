using Examensarbete.PlayerMicroService.Data.Interfaces;
using Examensarbete.PlayerMicroService.Data.Models;
using Examensarbete.PlayerMicroService.Shared.Requests;

namespace Examensarbete.PlayerMicroService.Data.Interfaces;
public interface IPlayerRepository
{
    Task<List<Player>> GetAllPlayersAsync();
    Task<Player> GetPlayerByIdAsync(Guid playerId);
    Task<Player> CreatePlayerAsync(CreatePlayerRequest request);
    Task<Player> UpdatePlayerAsync(Guid playerId, UpdatePlayerRequest request);
    Task<bool> DeletePlayerAsync(Guid playerId);
    Task<bool> ResetPlayersAsync();
    Task<Player> UpdatePlayerLevelAsync(Guid playerId, int level);
}