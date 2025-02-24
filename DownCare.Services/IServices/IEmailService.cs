using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.IServices
{
    public interface IEmailService
    {
        public Task SendEmailVerificationAsync(string email, string userId, string confirmLink);
        public Task SendResetPasswordVerificationAsync(string email, string userId, string confirmLink);
    }
}
