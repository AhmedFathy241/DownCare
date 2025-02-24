using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        // relation with mom 1:1
        [ForeignKey("Mom")]
        public string MomID { get; set; }
        public virtual Mom? Mom { get; set; }

    }
}
