using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class VerifyResetCodeDTO
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
