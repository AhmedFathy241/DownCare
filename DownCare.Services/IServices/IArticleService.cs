using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IArticleService
    {
        Task<APIResponse> CreateArticleAsync(string UserId, string content);
        Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllArticlesAsync(string baseURL);
    }
}