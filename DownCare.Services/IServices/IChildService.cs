using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IChildService
    {
        Task<APIResponse> CreateChildAsync(string userId, ChildDTO child);
        Task<APIResponse> CreateTestScoreAsync(string userId, TakeScoreDTO score);
        Task<APIResponse> ReadChildReportAsync (string userId);
        Task<APIResponse> ReadActivityDataAsync(string type, string baseUrl);
        Task<APIResponse> ReadTestDataAsync(string type, string baseUrl);
    }
}
