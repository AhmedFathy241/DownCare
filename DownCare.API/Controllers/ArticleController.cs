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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }
        [Authorize]
        [HttpPost("AddArticle")]
        public async Task<IActionResult> CreateArticle(AddFeedbackOrArticleDTO Article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("You are Unauthorized, Login and try again");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found in the database.");
            int res = await _articleService.CreateArticleAsync(userId, Article);
            if (res > 0)
                return Ok("Article Created Successfully");
            return BadRequest("Failed To Create Article");

        }
        [Authorize]
        [HttpGet("GetArticles")]
        public async Task<IActionResult> ReadArticles()
        {
            return Ok(await _articleService.ReadAllArticlesAsync());
        }
    }
}
