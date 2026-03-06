using Examensarbete.PlayerMicroService.Shared.Requests;
using Examensarbete.PlayerMicroService.Shared.Responses;

public interface IPlayerService
{
    Task<List<PlayerResponse>> GetAllPlayersAsync();
    Task<PlayerResponse> GetPlayerByIdAsync(Guid id);
    Task<PlayerResponse> CreatePlayerAsync(CreatePlayerRequest request);
    Task<PlayerResponse> UpdatePlayerAsync(Guid id, UpdatePlayerRequest request);
    Task<bool> DeletePlayerAsync(Guid id);
    Task<bool> ResetPlayersAsync();
    Task<PlayerResponse> UpdatePlayerLevelAsync(Guid id, int level);
}