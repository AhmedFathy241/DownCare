using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;


namespace DownCare.Services.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnv;
        public UserService(UserManager<AppUser> userManager, IWebHostEnvironment webHostEnv)
        {
            _userManager = userManager;
            _webHostEnv = webHostEnv;
        }
        public async Task<APIResponse> ChangePasswordAsync(string UserId, ChangePasswordDTO changePassword)
        {
            if (string.IsNullOrEmpty(UserId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            if(changePassword.CurrentPassword == changePassword.NewPassword)
                return new APIResponse { IsSuccess = false, Message = "New and old password cannot be the same!" };
            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            if(result.Succeeded)
                return new APIResponse { IsSuccess = true, Message = "Password changed Successfully" };
            return new APIResponse { IsSuccess = false, Message = "Password Doesn't Updated" };
        }
        public async Task<List<UserDTO>> SearchOnDoctorsAsync (string baseUrl, string? search = null)
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            if (string.IsNullOrEmpty(search))
                doctors = doctors.Where(d => d.EmailConfirmed == true).ToList();
            else
            {
                doctors = doctors
                    .Where(d => d.EmailConfirmed == true &&
                        (d.UserName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        (d.Governate != null && d.Governate.Contains(search, StringComparison.OrdinalIgnoreCase))))
                    .ToList();
            }
            List<UserDTO> DisplayedDoctors = new List<UserDTO>();
            foreach (var doctor in doctors)
            {
                DisplayedDoctors.Add(new UserDTO
                {
                    Id = doctor.Id,
                    Name = doctor.UserName,
                    Email = doctor.Email,
                    Phone = doctor.PhoneNumber,
                    Governate = doctor.Governate,
                    Specialization = doctor.Bio,
                    ImagePath = string.IsNullOrEmpty(doctor.ImagePath) ? "" : baseUrl + doctor.ImagePath
                });
            }
            return DisplayedDoctors;
        }
        public async Task<APIResponse> ReadUserInfoAsync(string baseUrl, string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            UserDTO userInfo = new UserDTO
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Governate = user.Governate,
                Specialization = user.Bio,
                ImagePath = string.IsNullOrEmpty(user.ImagePath) ? "" : baseUrl + user.ImagePath
            };
            return new APIResponse { IsSuccess = true, Model = userInfo };

        }
        public async Task<APIResponse> UpdateUserInfoAsync(string userId, UpdatedUserInfoDTO updatedInfo)
        {
            if (string.IsNullOrEmpty(userId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };

            if (updatedInfo.ImageFile != null)
            {
                List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
                string extension = Path.GetExtension(updatedInfo.ImageFile.FileName);
                if (!allowedExtensions.Contains(extension.ToLower()))
                    return new APIResponse { IsSuccess = false, Message = "Invalid image extension" };

                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    if (System.IO.File.Exists(user.ImagePath))
                        System.IO.File.Delete(user.ImagePath);
                }

                string path = _webHostEnv.WebRootPath + "\\ProfileImages\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + updatedInfo.ImageFile.FileName;
                string pathWithUniqueFileName = Path.Combine(path, uniqueFileName);

                using FileStream fileStream = new FileStream(pathWithUniqueFileName, FileMode.Create);
                await updatedInfo.ImageFile.CopyToAsync(fileStream);

                user.ImagePath = "/ProfileImages/" + uniqueFileName;
            }
            user.UserName = updatedInfo.Name;
            user.Email = updatedInfo.Email;
            user.PhoneNumber = updatedInfo.Phone;
            user.Governate = updatedInfo.Governate;
            user.Bio = updatedInfo.Specialization ?? "";
            var result = await _userManager.UpdateAsync(user);
            return new APIResponse { IsSuccess = true, Model = result };
        }
        public async Task<List<UserDTO>> ReadDoctorsAsync(string baseURL)
        {
            var doctors = await _userManager.GetUsersInRoleAsync("Doctor");
            doctors = doctors.Where(d => d.EmailConfirmed == true).ToList();
            List<UserDTO> DisplayedDoctors = new List<UserDTO>();
            foreach (var doctor in doctors)
            {
                DisplayedDoctors.Add(new UserDTO
                {
                    Id = doctor.Id,
                    Name = doctor.UserName,
                    Email = doctor.Email,
                    Phone = doctor.PhoneNumber,
                    Governate = doctor.Governate,
                    Specialization = doctor.Bio,
                    ImagePath = string.IsNullOrEmpty(doctor.ImagePath) ? "" : baseURL + doctor.ImagePath
                });
            }
            return DisplayedDoctors;
        }
    }
}
