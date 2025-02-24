using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;
        private readonly UserManager<AppUser> _userManager;
        public ChildController(IChildService childService, UserManager<AppUser> userManager)
        {
            _childService = childService;
            _userManager = userManager;
        }
        
        [HttpPost("AddChild")]
        public async Task<IActionResult> CreateChild (ChildDTO child)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("You are Unauthorized, Login and try again");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found in the database.");
            bool IsDone = await _childService.CreateChildAsync(userId, child);
            if(IsDone)
                return Ok("Child Created Successfully");
            return BadRequest("Failed To Create Child, This mom already has a child you can't add another one");
        }
        //[HttpGet("GetChild")]
        //public async Task<IActionResult> ReadChild()
        //{
        //    var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (string.IsNullOrEmpty(userId))
        //        return Unauthorized("You are Unauthorized, Login and try again");
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        return NotFound("User not found in the database.");
        //}
    }
}
