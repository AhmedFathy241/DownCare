using DownCare.Core.Entities;
using DownCare.Services.DTOs;

namespace DownCare.Services.IServices
{
    public interface IChildService
    {
        Task<APIResponse> CreateChildAsync(string UserId, ChildDTO child);
        //Task<ChildReportDTO> ReadChildReportAsync (string UserId);
    }
}
