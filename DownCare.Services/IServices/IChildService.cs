using DownCare.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.IServices
{
    public interface IChildService
    {
        Task<bool> CreateChildAsync(string UserId, ChildDTO child);
    }
}
