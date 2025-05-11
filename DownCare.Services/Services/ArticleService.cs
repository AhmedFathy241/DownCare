using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace DownCare.Services.Services
{
    public class ArticleService : IArticleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<APIResponse> CreateArticleAsync(string UserId, string content)
        {
            if (string.IsNullOrEmpty(UserId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            if (string.IsNullOrWhiteSpace(content))
                return new APIResponse { IsSuccess = false, Message = "Contribute your opinion! Don't leave it blank" };
            Article newArticle = new Article()
            {
                Content = content,
                DocID = UserId
            };
            await _unitOfWork.Articles.CreateAsync(newArticle);
            int res = await _unitOfWork.SaveAsync();
            if (res > 0)
                return new APIResponse { IsSuccess = true, Message = "Article Created Successfully" };
            return new APIResponse { IsSuccess = false, Message = "Failed To Create Article" };
        }
        public async Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllArticlesAsync(string baseURL)
        {
            List<Article> articles = (List<Article>) await _unitOfWork.Articles.GetAllAsync();
            List<GetFeedbacksOrArticlesDTO> DisplayedArticles = new List<GetFeedbacksOrArticlesDTO>();
            foreach (Article article in articles)
            {
                var user = await _userManager.FindByIdAsync(article.DocID);
                DisplayedArticles.Add(new GetFeedbacksOrArticlesDTO
                {
                    Id = article.Id,
                    Name = user.UserName,  
                    Content = article.Content,
                    ImageUrl = string.IsNullOrEmpty(user.ImagePath) ? "" : baseURL + user.ImagePath,
                    DateTime = article.DateTime
                });
            }
            return DisplayedArticles;
        }
    }
}
