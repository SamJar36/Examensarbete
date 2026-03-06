using Examensarbete.PlayerMicroService.Data.Interfaces;
using Examensarbete.PlayerMicroService.Data.Models;
using Examensarbete.PlayerMicroService.Shared.Requests;

namespace Examensarbete.PlayerMicroService.Data.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public Task<Player> CreatePlayerAsync(CreatePlayerRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePlayerAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Player>> GetAllPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Player> GetPlayerByIdAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Player> UpdatePlayerAsync(Guid playerId, UpdatePlayerRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Player> UpdatePlayerLevelAsync(Guid playerId, int level)
    {
        throw new NotImplementedException();
    }
}