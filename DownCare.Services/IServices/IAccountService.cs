using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using Microsoft.AspNetCore.Identity;

namespace DownCare.Core.IServices
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO);
        Task<bool> ResendConfirmEmail(string email);
        Task<bool> ForgetPasswordAsync(string email);
        Task<APIResponse> ResetPasswordAsync(ResetPasswordDTO ResetPasswordDTO);
    }
}
