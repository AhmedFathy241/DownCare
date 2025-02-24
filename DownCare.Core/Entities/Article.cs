using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        // relation with doctor 1:m
        [ForeignKey("Doctor")]
        public string DocID { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
