using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _userService.ChangePasswordAsync(userId, changePassword);
            if (res.IsSuccess == true)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ReadUserInfo()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var res = await _userService.ReadUserInfoAsync(baseUrl, userId);
            if (res.IsSuccess == true)
                return Ok(res.Model);
            return BadRequest(res.Message);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo([FromForm]UpdatedUserInfoDTO updatedInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _userService.UpdateUserInfoAsync(userId, updatedInfo);
            if (res.IsSuccess == false)
                return BadRequest(res.Message);
            IdentityResult result = (IdentityResult)res.Model;
            if (result.Succeeded)
                return Ok("User Info Updated Successfully");
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("Error", item.Description);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("Doctors")]
        public async Task<IActionResult> ReadDoctors()
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            return Ok(await _userService.ReadDoctorsAsync(baseUrl));
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchOnDoctors([FromQuery] string? search)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            return Ok(await _userService.SearchOnDoctorsAsync(baseUrl, search));
        }
    }
}
