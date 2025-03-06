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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpPost("AddArticle")]
        public async Task<IActionResult> CreateArticle(AddFeedbackOrArticleDTO article)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Res = await _articleService.CreateArticleAsync(userId, article.Content);
            if (Res.IsSuccess == true)
                return Ok(Res.Message);
            return BadRequest(Res.Message);
        }
        [HttpGet("GetAllArticles")]
        public async Task<IActionResult> ReadArticles()
        {
            return Ok(await _articleService.ReadAllArticlesAsync());
        }
    }
}
