using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChildController(IChildService childService, IHttpContextAccessor httpContextAccessor)
        {
            _childService = childService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost]
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
        [Authorize]
        [HttpPost("Score")]
        public async Task<IActionResult> CreateTestScoreAsync(TakeScoreDTO score)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _childService.CreateTestScoreAsync(userId, score);
            if (Res.IsSuccess == true)
                return Ok(Res.Message);
            return BadRequest(Res.Message);
        }
        [Authorize]
        [HttpGet("Report")]
        public async Task<IActionResult> ReadChildReport()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _childService.ReadChildReportAsync(userId);
            if (Res.IsSuccess == true)
                return Ok(Res.Model);
            return BadRequest(Res.Message);
        }
        [HttpGet("ActivityData")]
        public async Task<IActionResult> ReadActivityData([FromQuery] string level)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var Res = await _childService.ReadActivityDataAsync(level, baseUrl);
            if (Res.IsSuccess == true)
                return Ok(Res.Model);
            return BadRequest(Res.Message);
        }
        [HttpGet("TestData")]
        public async Task<IActionResult> ReadTestData([FromQuery] string level)
        {
            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            var Res = await _childService.ReadTestDataAsync(level, baseUrl);
            if (Res.IsSuccess == true)
                return Ok(Res.Model);
            return BadRequest(Res.Message);
        }
    }
}
