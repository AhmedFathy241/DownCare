using DownCare.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.IServices
{
    public interface IFeedbackService
    {
        Task<int> CreateFeedbackAsync(string UserId, AddFeedbackOrArticleDTO feedback);
        Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllFeedbacksAsync();
    }
}
