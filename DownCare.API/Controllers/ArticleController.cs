using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DownCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticleController(IArticleService articleService, IHttpContextAccessor httpContextAccessor)
        {
            _articleService = articleService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpPost]
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
        [HttpGet]
        public async Task<IActionResult> ReadArticles()
        {
            var baseURL = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            return Ok(await _articleService.ReadAllArticlesAsync(baseURL));
        }
    }
}
