using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace DownCare.Core.IServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(UserManager<AppUser> userManager,
            IEmailService emailService, IUrlHelperFactory urlHelperFactory, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterDTO registerDTO)
        {
            AppUser user = new AppUser();
            user.UserName = registerDTO.UserName;
            user.Email = registerDTO.Email;
            user.PhoneNumber = registerDTO.Phone;
            user.Governate = registerDTO.Governate;
            user.Role = registerDTO.Role;
            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, user.Role);
                var EmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext
                (_httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor()));
                var ConfirmLink = urlHelper.Action("ConfirmEmail", "Account", new
                { email = user.Email, token = EmailToken }, _httpContextAccessor.HttpContext.Request.Scheme);
                await _emailService.SendEmailVerificationAsync(user.Email, user.UserName, ConfirmLink);
            }
            return result;
        }
        public async Task<bool> ResendConfirmEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            var EmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext
            (_httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor()));
            var ConfirmLink = urlHelper.Action("ConfirmEmail", "Account", new
            { email = user.Email, token = EmailToken }, _httpContextAccessor.HttpContext.Request.Scheme);
            await _emailService.SendEmailVerificationAsync(user.Email, user.UserName, ConfirmLink);
            return true;
        }
        public async Task<bool> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            var resetCode = new Random().Next(100000, 999999).ToString();
            user.PasswordResetCode = resetCode;
            await _userManager.UpdateAsync(user);
            //var ResetPasswordtoken = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext
                //(_httpContextAccessor.HttpContext, new RouteData(), new ActionDescriptor()));
            //var resetLink = urlHelper.Action("ResetPassword", "Account", new
            //{ userId = user.Id, code = resetCode }, _httpContextAccessor.HttpContext.Request.Scheme);
            await _emailService.SendResetPasswordVerificationAsync(user.Email, user.UserName, resetCode);
            return true;
        }
        public async Task<APIResponse> ResetPasswordAsync(ResetPasswordDTO ResetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(ResetPasswordDTO.email);
            if (user == null || user.PasswordResetCode != ResetPasswordDTO.code)
                return new APIResponse { IsSuccess = false, Message = "User Not Found Or Invalid reset code." };
            //var result = await _userManager.VerifyUserTokenAsync(user,
            //    _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
            //if (!result)
            //    return new APIResponse { IsSuccess = false, Message = "Tokenv is invalid" };
            var ResetPasswordtoken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, ResetPasswordtoken, ResetPasswordDTO.Password);
            if (resetPasswordResult.Succeeded)
            {
                user.PasswordResetCode = null;
                await _userManager.UpdateAsync(user);
                return new APIResponse { IsSuccess = true, Message = "Reset Password Successfully" };
            }
            return new APIResponse { IsSuccess = false, Message = "Failed Process ! Try Again" };
            
        }
    }
}
