using Examensarbete.PlayerMicroService.Data.Models;
using Examensarbete.PlayerMicroService.Data.Interfaces;
using Examensarbete.PlayerMicroService.Shared.Requests;

namespace Examensarbete.PlayerMicroService.Data.Repositories;

public class PlayerInventoryRepository : IPlayerInventoryRepository
{
    public Task<PlayerInventory> CreateInventoryAsync(Guid playerId, CreatePlayerInventoryRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteInventoryItemAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerInventory> GetInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<PlayerInventory>> GetPlayerInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetCoinsAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetInventoryAsync(Guid playerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCoinsAsync(Guid playerId, int coins)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerInventory> UpdateInventoryAsync(Guid playerId, UpdatePlauerInventoryRequest request)
    {
        throw new NotImplementedException();
    }
}