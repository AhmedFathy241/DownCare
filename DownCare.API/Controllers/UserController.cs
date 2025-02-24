using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        public UserController(UserManager<AppUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _userService.ChangePasswordAsync(changePassword);
            if (response.IsSuccess == false)
                return BadRequest(response.Message);
            return Ok(response.Message);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> ReadDoctors([FromQuery]string? search)
        {
            return Ok(await _userService.ReadDoctorsAsync(search));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAccount(LoginDTO loginDTO)
        //{
        //    try
        //    {
        //        await _userService.DeleteUserAsync(loginDTO.Email, loginDTO.Password);
        //        _response.IsSuccess = true;
        //        _response.StatusCode = HttpStatusCode.OK;
        //        _response.Result = loginDTO.Email;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.StatusCode = HttpStatusCode.Unauthorized;
        //        _response.Errors.Add("User is not authenticated");
        //        return Unauthorized(_response);
        //    }
        //}
    }
}
