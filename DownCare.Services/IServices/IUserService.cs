using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IUserService
    {
        Task<APIResponse> ChangePasswordAsync(string userId, ChangePasswordDTO changePassword);
        Task<List<DoctorsDTO>> SearchOnDoctorsAsync(string? search=null);
        //Task<List<DoctorsDTO>> ReadDoctorsAsync();
        //Task DeleteUserAsync(string email, string passsword);
    }
}
