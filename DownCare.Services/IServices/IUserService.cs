using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IUserService
    {
        Task<APIResponse> ChangePasswordAsync(ChangePasswordDTO changePassword);
        public Task<List<DoctorsDTO>> ReadDoctorsAsync(string? search=null);
        public Task DeleteUserAsync(string email, string passsword);
    }
}
