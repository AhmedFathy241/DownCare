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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost("AddFeedback")]
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
        [HttpGet("GetAllFeedbacks")]
        public async Task<IActionResult> ReadAllFeedbacks()
        {
            return Ok(await _feedbackService.ReadAllFeedbacksAsync());
        }
    }
}
