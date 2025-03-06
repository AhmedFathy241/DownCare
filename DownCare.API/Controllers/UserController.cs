using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePassword)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _userService.ChangePasswordAsync(userId, changePassword);
            if (Res.IsSuccess == true)
                return Ok(Res.Message);
            return BadRequest(Res.Message);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> SearchOnDoctors([FromQuery]string? search)
        {
            return Ok(await _userService.SearchOnDoctorsAsync(search));
        }
        //[HttpGet("GetAllDoctors")]
        //public async Task<IActionResult> ReadDoctors()
        //{
        //    return Ok(await _userService.ReadDoctorsAsync());
        //}

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
