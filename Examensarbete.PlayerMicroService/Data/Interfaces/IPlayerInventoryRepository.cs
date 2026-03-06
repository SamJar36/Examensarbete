using Examensarbete.PlayerMicroService.Shared.Responses;
using Examensarbete.PlayerMicroService.Shared.Requests;
using Examensarbete.PlayerMicroService.Data.Models;

namespace Examensarbete.PlayerMicroService.Data.Interfaces;
public interface IPlayerInventoryRepository
{
    Task<List<PlayerInventory>> GetPlayerInventoryAsync(Guid playerId);
    Task<PlayerInventory> GetInventoryAsync(Guid playerId);
    Task<PlayerInventory> CreateInventoryAsync(Guid playerId, CreatePlayerInventoryRequest request);
    Task<PlayerInventory> UpdateInventoryAsync(Guid playerId, UpdatePlauerInventoryRequest request);
    Task<bool> ResetInventoryAsync(Guid playerId);
    Task<bool> DeleteInventoryItemAsync(Guid playerId);
    Task<bool> UpdateCoinsAsync(Guid playerId, int coins);
    Task<bool> ResetCoinsAsync(Guid playerId);
}