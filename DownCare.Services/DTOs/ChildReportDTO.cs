using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class ChildReportDTO
    {
        public string ChildName { get; set; }
        public int Age { get; set; }
        public DateOnly DiagnosisDate { get; set; }
        public string Gneder { get; set; }
        public int? LinguisticsScore { get; set; } = 0;
        public int? CommunicationScore { get; set; } = 0;
    }
}
