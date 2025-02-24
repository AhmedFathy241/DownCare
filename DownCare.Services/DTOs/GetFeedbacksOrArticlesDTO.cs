using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class GetFeedbacksOrArticlesDTO
    {
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
    }
}
