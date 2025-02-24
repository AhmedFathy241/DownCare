using DownCare.Core.Entities;
using DownCare.Core.IServices;
using DownCare.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _config;
        public AccountController(UserManager<AppUser> userManager, IAccountService accountService, IConfiguration config)
        {
            _userManager = userManager;
            _accountService = accountService;
            _config = config;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser ([FromBody]RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _accountService.CreateUserAsync(registerDTO);
                if (result.Succeeded)
                {
                    return Ok("Account Created Successfully, please Check your mail to verify your account");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Error", item.Description);
                    return BadRequest(ModelState);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string email, [FromQuery]string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                return BadRequest("Invalid Email or Token");
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("User Not Found");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                var loginUrl = Url.Action("Login", "Account", null, Request.Scheme);
                return Ok(new { message = "Email Confirmed Successfully", loginUrl });
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("Error", item.Description);
                return BadRequest(ModelState);
            }
            return BadRequest("Failed to confirm email");
        }
        [HttpPost("ResendConfirmEmail")]
        public async Task<IActionResult> ResendConfirmEmail(string email)
        {
            bool IsDone = await _accountService.ResendConfirmEmail(email);
            if (!IsDone)
                return BadRequest("Incorrect email or user not found");
            return Ok("Please check your mail again to verify your account");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser userFromDb = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (userFromDb != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(userFromDb, loginDTO.Password);
                    if (found)
                    {
                        if (await _userManager.IsEmailConfirmedAsync(userFromDb))
                        {
                            List<Claim> UserClaims = new List<Claim>();
                            UserClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                            UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDb.Id));
                            UserClaims.Add(new Claim(ClaimTypes.Name, userFromDb.UserName));

                            SymmetricSecurityKey SingInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecritKey"]));
                            SigningCredentials signingCred = new SigningCredentials(SingInKey, SecurityAlgorithms.HmacSha256);
                            JwtSecurityToken MyToken = new JwtSecurityToken(
                                issuer: _config["JWT:IssuerIP"],
                                audience: "http://localhost:4200/",
                                expires: DateTime.Now.AddYears(1),
                                claims: UserClaims,
                                signingCredentials: signingCred);

                            return Ok(new{ token = new JwtSecurityTokenHandler().WriteToken(MyToken) });
                        }
                        ModelState.AddModelError("Error", "Email doesn't confirmed yet");
                        return BadRequest(ModelState);
                    }
                    ModelState.AddModelError("Error", "Wrong Password");
                    return BadRequest(ModelState);
                }
                ModelState.AddModelError("Error", "User Not Found");
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            bool IsDone = await _accountService.ForgetPasswordAsync(email);
            if (!IsDone)
                return BadRequest("Incorrect email or user not found");
            return Ok("Reset Password code has been sent to your email");
        }
        [HttpPost("verify-reset-code")]
        public async Task<IActionResult> VerifyResetCode([FromBody] VerifyResetCodeDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || user.PasswordResetCode != model.Code)
            {
                return BadRequest("Invalid reset code.");
            }
            return Ok(new { Message = "Code verified. You can now reset your password." });
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _accountService.ResetPasswordAsync(resetPassword);
            if (response.IsSuccess == false)
            {
                ModelState.AddModelError("Error", response.Message);
                return BadRequest(ModelState);
            }
            return Ok("Reset Password Successfully");
        }
    }
}