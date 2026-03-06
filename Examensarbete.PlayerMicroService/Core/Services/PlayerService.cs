using Examensarbete.PlayerMicroService.Core.Interfaces;
using Examensarbete.PlayerMicroService.Shared.Requests;
using Examensarbete.PlayerMicroService.Shared.Responses;

namespace Examensarbete.PlayerMicroService.Core.Services;

public class PlayerService : IPlayerService
{
    public async Task<List<PlayerResponse>> GetAllPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerResponse> GetPlayerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerResponse> CreatePlayerAsync(CreatePlayerRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerResponse> UpdatePlayerAsync(Guid id, UpdatePlayerRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeletePlayerAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ResetPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerResponse> UpdatePlayerLevelAsync(Guid id, int level)
    {
        throw new NotImplementedException();
    }
}
