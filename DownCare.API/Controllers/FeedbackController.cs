using DownCare.Core.Entities;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using DownCare.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly UserManager<AppUser> _userManager;
        public FeedbackController(IFeedbackService feedbackService, UserManager<AppUser> userManager)
        {
            _feedbackService = feedbackService;
            _userManager = userManager; 
        }
        [Authorize]
        [HttpPost("AddFeedback")]
        public async Task<IActionResult> CreateFeedback(AddFeedbackOrArticleDTO feedback)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("You are Unauthorized, Login and try again");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found in the database.");
            int res = await _feedbackService.CreateFeedbackAsync(userId, feedback);
            if (res > 0)
                return Ok("Feedback Created Successfully");
            return BadRequest("Failed To Create Feedback"); 
        }
        [Authorize]
        [HttpGet("GetFeedback")]
        public async Task<IActionResult> ReadFeedbacks()
        {
            return Ok(await _feedbackService.ReadAllFeedbacksAsync());
        }
    }
}
