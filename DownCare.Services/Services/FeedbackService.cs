using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace DownCare.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public FeedbackService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<int> CreateFeedbackAsync(string UserId, AddFeedbackOrArticleDTO feedback)
        {
            Feedback newFeedback = new Feedback();
            newFeedback.Content = feedback.Content;
            newFeedback.MomID = UserId;
            Feedback Model = await _unitOfWork.Feedbacks.CreateAsync(newFeedback);
            return await _unitOfWork.SaveAsync();
        }

        public async  Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllFeedbacksAsync()
        {
            List<Feedback> feedbacks = (List<Feedback>) await _unitOfWork.Feedbacks.GetAllAsync();
            List<GetFeedbacksOrArticlesDTO> DisplayedFeedbacks = new List<GetFeedbacksOrArticlesDTO>();
            foreach (Feedback feedback in feedbacks)
            {
                var user = await _userManager.FindByIdAsync(feedback.MomID);
                DisplayedFeedbacks.Add(new GetFeedbacksOrArticlesDTO
                {
                    Email = user.Email,
                    Content = feedback.Content,
                    DateTime = feedback.DateTime
                });
            }
            return DisplayedFeedbacks;
        }
    }
}
