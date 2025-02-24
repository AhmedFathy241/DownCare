using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace DownCare.Services.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly APIResponse _response;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _response = new APIResponse();
        }
        public async Task<APIResponse> ChangePasswordAsync(ChangePasswordDTO changePassword)
        {
            var user = await _userManager.FindByEmailAsync(changePassword.Email);
            if (user == null) 
                return new APIResponse {IsSuccess = false, Message = "User Not Found" };
            if(changePassword.CurrentPassword == changePassword.NewPassword)
                return new APIResponse { IsSuccess = false, Message = "New and old password cannot be the same!" };
            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            if(!result.Succeeded)
                return new APIResponse { IsSuccess = false, Message = "Password Does't Updated" };
            return new APIResponse { IsSuccess = true, Message = "Password changed Successfully" };
        }
        public async Task<List<DoctorsDTO>> ReadDoctorsAsync(string? search = null)
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            if (doctors == null || !doctors.Any())
                return new List<DoctorsDTO>();
            if (!string.IsNullOrEmpty(search))
            {
                doctors = doctors.Where(d =>
                    d.UserName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (d.Governate != null && d.Governate.Contains(search, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }
            List<DoctorsDTO> DisplayedDoctors = new List<DoctorsDTO>();
            foreach (var doctor in doctors)
            {
                DisplayedDoctors.Add(new DoctorsDTO
                {
                    Name = doctor.UserName,
                    Email = doctor.Email,
                    Phone = doctor.PhoneNumber,
                    Governate = doctor.Governate,
                    Bio = doctor.Bio,
                    ImagePath = doctor.ImagePath
                });
            }
            return DisplayedDoctors;
        }
        public async Task DeleteUserAsync(string Email, string Passsword)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, Passsword))
                throw new Exception("User not found!");
            await _userManager.DeleteAsync(user);
        }
    }
}
