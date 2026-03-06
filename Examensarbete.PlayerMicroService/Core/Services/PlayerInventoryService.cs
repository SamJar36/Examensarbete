using Examensarbete.PlayerMicroService.Core.Interfaces;
using Examensarbete.PlayerMicroService.Shared.Requests;
using Examensarbete.PlayerMicroService.Shared.Responses;

namespace Examensarbete.PlayerMicroService.Core.Services;

public class PlayerInventoryService : IPlayerInventoryService
{
    public Task<List<PlayerInventoryResponse>> GetPlayerInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerInventoryResponse> GetInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerInventoryResponse> CreateInventoryAsync(Guid playerId, CreatePlayerInventoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerInventoryResponse> UpdateInventoryAsync(Guid playerId, UpdatePlauerInventoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteInventoryItemAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCoinsAsync(Guid playerId, int coins)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetCoinsAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }
}