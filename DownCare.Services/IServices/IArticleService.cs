using DownCare.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.IServices
{
    public interface IArticleService
    {
        Task<int> CreateArticleAsync(string UserId, AddFeedbackOrArticleDTO article);
        Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllArticlesAsync();
    }
}
