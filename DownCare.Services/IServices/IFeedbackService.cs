using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IFeedbackService
    {
        Task<APIResponse> CreateFeedbackAsync(string UserId, string content);
        Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllFeedbacksAsync();
    }
}
