using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FeedbackController(IFeedbackService feedbackService, IHttpContextAccessor httpContextAccessor)
        {
            _feedbackService = feedbackService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFeedback (AddFeedbackOrArticleDTO feedback)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _feedbackService.CreateFeedbackAsync(userId, feedback.Content);
            if (Res.IsSuccess == true)
                return Ok(Res.Message);
            return BadRequest(Res.Message);
        }
        [HttpGet]
        public async Task<IActionResult> ReadAllFeedbacks()
        {
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            return Ok(await _feedbackService.ReadAllFeedbacksAsync(baseURL));
        }
    }
}
