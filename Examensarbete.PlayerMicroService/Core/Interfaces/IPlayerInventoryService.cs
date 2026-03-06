using Examensarbete.PlayerMicroService.Shared.Responses;
using Examensarbete.PlayerMicroService.Shared.Requests;

namespace Examensarbete.PlayerMicroService.Core.Interfaces;
public interface IPlayerInventoryService
{
    Task<List<PlayerInventoryResponse>> GetPlayerInventoryAsync(Guid playerId);
    Task<PlayerInventoryResponse> GetInventoryAsync(Guid playerId);
    Task<PlayerInventoryResponse> CreateInventoryAsync(Guid playerId, CreatePlayerInventoryRequest request);
    Task<PlayerInventoryResponse> UpdateInventoryAsync(Guid playerId, UpdatePlauerInventoryRequest request);
    Task<bool> ResetInventoryAsync(Guid playerId);
    Task<bool> DeleteInventoryItemAsync(Guid playerId);
    Task<bool> UpdateCoinsAsync(Guid playerId, int coins);
    Task<bool> ResetCoinsAsync(Guid playerId);
}