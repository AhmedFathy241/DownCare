using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class APIResponse
    {
        public bool? IsSuccess { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; } = new List<string>();
        public object? Result { get; set; } = null;
    }
}
