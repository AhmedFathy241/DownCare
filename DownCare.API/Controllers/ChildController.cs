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
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;
        public ChildController(IChildService childService)
        {
            _childService = childService;
        }
        [HttpPost("AddChild")]
        public async Task<IActionResult> CreateChild (ChildDTO child)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _childService.CreateChildAsync(userId, child);
            if (Res.IsSuccess == true)
                return Ok(Res.Message);
            return BadRequest(Res.Message);
        }
        //[HttpGet("GetChildReport")]
        //public async Task<IActionResult> ReadChildReport()
        //{
        //    var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    if (string.IsNullOrEmpty(userId))
        //        return Unauthorized("You are Unauthorized, Login and try again");
        //    ChildReportDTO childReport = await _childService.ReadChildAsync(userId);
        //    return Ok(childReport);
        //}
    }
}
