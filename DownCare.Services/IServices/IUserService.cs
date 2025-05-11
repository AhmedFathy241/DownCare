using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IUserService
    {
        Task<APIResponse> ChangePasswordAsync(string userId, ChangePasswordDTO changePassword);
        Task<List<UserDTO>> SearchOnDoctorsAsync(string baseUrl, string? search=null);
        Task<APIResponse> ReadUserInfoAsync(string baseUrl, string userId);
        Task<APIResponse> UpdateUserInfoAsync(string userId, UpdatedUserInfoDTO updatedInfo);
        Task<List<UserDTO>> ReadDoctorsAsync(string baseURL);
    }
}
