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
        public async Task<APIResponse> CreateFeedbackAsync(string UserId, string content)
        {
            if (string.IsNullOrEmpty(UserId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            if (string.IsNullOrWhiteSpace(content))
                return new APIResponse { IsSuccess = false, Message = "Contribute your opinion! Don't leave it blank" };
            Feedback newFeedback = new Feedback()
            {
                Content = content,
                MomID = UserId
            };
            await _unitOfWork.Feedbacks.CreateAsync(newFeedback);
            int res = await _unitOfWork.SaveAsync();
            if (res > 0)
                return new APIResponse { IsSuccess = true, Message = "Feedback Created Successfully" };
            return new APIResponse { IsSuccess = false, Message = "Failed To Create Feedback" };
        }
        public async Task<IEnumerable<GetFeedbacksOrArticlesDTO>> ReadAllFeedbacksAsync(string baseURL)
        {
            List<Feedback> feedbacks = (List<Feedback>) await _unitOfWork.Feedbacks.GetAllAsync();
            List<GetFeedbacksOrArticlesDTO> DisplayedFeedbacks = new List<GetFeedbacksOrArticlesDTO>();
            foreach (Feedback feedback in feedbacks)
            {
                var user = await _userManager.FindByIdAsync(feedback.MomID);
                DisplayedFeedbacks.Add(new GetFeedbacksOrArticlesDTO
                {
                    Id = feedback.Id,
                    Name = user.UserName,
                    Content = feedback.Content,
                    ImageUrl = string.IsNullOrEmpty(user.ImagePath) ? "" : baseURL + user.ImagePath,
                    DateTime = feedback.DateTime
                });
            }
            return DisplayedFeedbacks;
        }
    }
}
