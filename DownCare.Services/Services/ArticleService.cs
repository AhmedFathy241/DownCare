using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<int> CreateArticleAsync(string UserId, AddFeedbackOrArticleDTO article)
        {
            Article newArticle = new Article();
            newArticle.Content = article.Content;
            newArticle.DocID = UserId;
            Article Model = await _unitOfWork.Articles.CreateAsync(newArticle);
            return await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllArticlesAsync()
        {
            List<Article> articles = (List<Article>)await _unitOfWork.Articles.GetAllAsync();
            List<GetFeedbacksOrArticlesDTO> DisplayedArticles = new List<GetFeedbacksOrArticlesDTO>();
            foreach (Article article in articles)
            {
                var user = await _userManager.FindByIdAsync(article.DocID);
                DisplayedArticles.Add(new GetFeedbacksOrArticlesDTO
                {
                    Email = user.Email,  
                    Content = article.Content,
                    DateTime = article.DateTime
                });
            }
            return DisplayedArticles;
        }
    }
}
