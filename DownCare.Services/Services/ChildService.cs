using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace DownCare.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public ChildService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async Task<APIResponse> CreateChildAsync(string userId, ChildDTO child)
        {
            if (string.IsNullOrEmpty(userId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            if (await _unitOfWork.Children.AnyAsync(c => c.MomID == userId))
                return new APIResponse { IsSuccess = false, Message = "Failed To Create Child, This mom already has a child you can't add another one" };
            Child newChild = new Child()
            {
                Name = child.ChildName,
                Age = child.Age,
                DiagnosisDate = child.DiagnosisDate,
                Gender = child.Gneder,
                MomID = userId
            };
            await _unitOfWork.Children.CreateAsync(newChild);
            int res = await _unitOfWork.SaveAsync();
            if (res > 0)
                return new APIResponse { IsSuccess = true, Message = "Child Created Successfully" };
            return new APIResponse { IsSuccess = false, Message = "Child Doesn't Created " };
        }
        public async Task<APIResponse> CreateTestScoreAsync(string userId, TakeScoreDTO score)
        {
            if (string.IsNullOrEmpty(userId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            Child child = await _unitOfWork.Children.FirstOrDefaultAsync(c => c.MomID == userId);
            if (child == null)
                return new APIResponse { IsSuccess = false, Message = "This mom doesn't have a child yet" };

            if (score.Type.Equals("Linguistics", StringComparison.OrdinalIgnoreCase))
            {
                var existingScore = await _unitOfWork.LinguisticsScore.FirstOrDefaultAsync(ls => ls.ChildId == child.Id);
                if (existingScore == null)
                {
                    existingScore = new LinguisticsScore { ChildId = child.Id };
                    await _unitOfWork.LinguisticsScore.CreateAsync(existingScore);
                }
                switch (score.Level.ToLowerInvariant())
                {
                    case "oneword": existingScore.OneWord = score.Score; break;
                    case "twoword": existingScore.TwoWord = score.Score; break;
                    case "threeword": existingScore.ThreeWord = score.Score; break;
                    case "fourword": existingScore.FourWord = score.Score; break;
                    case "fiveword": existingScore.FiveWord = score.Score; break;
                }
                await _unitOfWork.SaveAsync();
                return new APIResponse { IsSuccess = true, Message = $"{score.Level} score updated to {score.Score}" };
                //return await _unitOfWork.SaveAsync() > 0
                //    ? new APIResponse { IsSuccess = true, Message = $"{score.Level} score updated to {score.Score}" }
                //    : new APIResponse { IsSuccess = false, Message = "Failed to update score" };
            }
            if (score.Type.Equals("Communication", StringComparison.OrdinalIgnoreCase))
            {
                var existingScore = await _unitOfWork.CommunicationScore.FirstOrDefaultAsync(ls => ls.ChildId == child.Id);
                if (existingScore == null)
                {
                    existingScore = new CommunicationScore { ChildId = child.Id };
                    await _unitOfWork.CommunicationScore.CreateAsync(existingScore);
                }
                switch (score.Level.ToLowerInvariant())
                {
                    case "oneword": existingScore.OneWord = score.Score; break;
                    case "twoword": existingScore.TwoWord = score.Score; break;
                    case "threeword": existingScore.ThreeWord = score.Score; break;
                    case "fourword": existingScore.FourWord = score.Score; break;
                    case "fiveword": existingScore.FiveWord = score.Score; break;
                }
                return await _unitOfWork.SaveAsync() > 0
                    ? new APIResponse { IsSuccess = true, Message = $"{score.Level} score updated to {score.Score}" }
                    : new APIResponse { IsSuccess = true, Message = $"{score.Level} is already {score.Score}"};
            }
            return new APIResponse { IsSuccess = false, Message = "Invalid Type" };
        }
        public async Task<APIResponse> ReadChildReportAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            Child child = await _unitOfWork.Children.FirstOrDefaultAsync(c => c.MomID == userId);
            if (child == null)
                return new APIResponse { IsSuccess = false, Message = "This mom doesn't have a child yet" };
            LinguisticsScore Linguisticsscore = await _unitOfWork.LinguisticsScore.FirstOrDefaultAsync(s => s.ChildId == child.Id);
            CommunicationScore communicationScore = await _unitOfWork.CommunicationScore.FirstOrDefaultAsync(s => s.ChildId == child.Id);
            ChildReportDTO DisplayedChildReport = new ChildReportDTO
            {
                ChildName = child.Name,
                Age = child.Age,
                DiagnosisDate = child.DiagnosisDate,
                Gneder = child.Gender,
                LinguisticsScore = new ScoreDTO
                {
                    OneWord = Linguisticsscore?.OneWord ?? 0,
                    TwoWord = Linguisticsscore?.TwoWord ?? 0,
                    ThreeWord = Linguisticsscore?.ThreeWord ?? 0,
                    FourWord = Linguisticsscore?.FourWord ?? 0,  
                    FiveWord = Linguisticsscore?.FiveWord ?? 0
                },
                CommunicationScore = new ScoreDTO
                {
                    OneWord = communicationScore?.OneWord ?? 0,
                    TwoWord = communicationScore?.TwoWord ?? 0,
                    ThreeWord = communicationScore?.ThreeWord ?? 0,
                    FourWord = communicationScore?.FourWord ?? 0,
                    FiveWord = communicationScore?.FiveWord ?? 0
                },
            };
            return new APIResponse { IsSuccess = true, Model = DisplayedChildReport };
        }
        public async Task<APIResponse> ReadActivityDataAsync(string level, string baseUrl)
        {
            var validTypes = new[] { "OneWord", "TwoWord", "ThreeWord", "FourWord", "FiveWord" };
            if (!validTypes.Contains(level))
                return new APIResponse { IsSuccess = false, Message = $"Invalid type. Valid types are: {string.Join(", ", validTypes)}" };

            var activities = (await _unitOfWork.ActivityData.GetAllAsync())
                .Where(a => a.Type == level)
                .Select (a => new
                {
                    a.Id,
                    a.Type,
                    a.Label,
                    ImagePath = baseUrl + a.ImagePath,
                    SoundPath = baseUrl + a.SoundPath,
                })
                .ToList();
            return new APIResponse { IsSuccess = true, Model = activities};
        }
        public async Task<APIResponse> ReadTestDataAsync(string level, string baseUrl)
        {
            var validTypes = new[] { "OneWord", "TwoWord", "ThreeWord", "FourWord", "FiveWord" };
            if (!validTypes.Contains(level))
                return new APIResponse { IsSuccess = false, Message = $"Invalid type. Valid types are: {string.Join(", ", validTypes)}" };
            
            var activities = (await _unitOfWork.ActivityData.GetAllAsync())
                .Where(a => a.Type == level)
                .ToList();

            var random = new Random();
            var tests = activities
                .OrderBy(a => random.Next())
                .Take(10)
                .Select(activity => new TestDTO
                {
                    ImagePath = baseUrl + activity.ImagePath,
                    CorrectAnswer = activity.Label,
                    Choices = GetRandomChoices(activity.Label, activities, random)
                })
                .ToList();
            return new APIResponse { IsSuccess = true, Model = tests };
        }
        private static List<string> GetRandomChoices(string correctAnswer, List<ActivityData> allActivities, Random random)
        {
            var choices = new List<string> { correctAnswer };
            var wrongChoices = allActivities
                .Where(a => a.Label != correctAnswer)
                .Select(a => a.Label)
                .Distinct()
                .OrderBy(_ => random.Next())
                .Take(3);
            choices.AddRange(wrongChoices);
            return choices.OrderBy(a => random.Next()).ToList();
        }
    }
}
