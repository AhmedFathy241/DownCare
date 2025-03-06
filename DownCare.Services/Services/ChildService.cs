using DownCare.Core.Entities;
using DownCare.Core.UnitOfWork;
using DownCare.Infrastructure.Data;
using DownCare.Services.DTOs;
using DownCare.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DownCare.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public ChildService(IUnitOfWork unitOfWork, AppDbContext context, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
        }
        public async Task<APIResponse> CreateChildAsync(string UserId, ChildDTO child)
        {
            if (string.IsNullOrEmpty(UserId))
                return new APIResponse { IsSuccess = false, Message = "You are Unauthorized, Login and try again" };
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                return new APIResponse { IsSuccess = false, Message = "User not found in database" };
            if (await _context.Children.AnyAsync(c => c.MomID == UserId))
                return new APIResponse { IsSuccess = false, Message = "Failed To Create Child, This mom already has a child you can't add another one" };
            Child newChild = new Child()
            {
                Name = child.ChildName,
                Age = child.Age,
                DiagnosisDate = child.DiagnosisDate,
                Gender = child.Gneder,
                MomID = UserId
            };
            await _unitOfWork.Children.CreateAsync(newChild);
            int res = await _unitOfWork.SaveAsync();
            if (res > 0)
                return new APIResponse { IsSuccess = true, Message = "Child Created Successfully" };
            return new APIResponse { IsSuccess = false, Message = "Failed To Create Article" };
        }
        //public async Task<ChildReportDTO> ReadChildReportAsync(string UserId)
        //{
        //    Mom MomThatHaveChild = await _unitOfWork.Moms.GetByIdAsync(UserId);
        //    Child childfromDb = MomThatHaveChild.Child;
        //    ChildReportDTO DisplayedChildReport = new ChildReportDTO
        //    {
        //        ChildName = childfromDb.Name,
        //        Age = childfromDb.Age,
        //        DiagnosisDate = childfromDb.DiagnosisDate,
        //        Gneder = childfromDb.Gender,
        //        CommunicationScore = childfromDb.CommunicationScore,
        //        LinguisticsScore = childfromDb.LinguisticsScore
        //    };
        //    return DisplayedChildReport;
        //}
    }
}
