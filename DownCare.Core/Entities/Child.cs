using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public int Age { get; set; }
        public  string Gender { get; set; }
        public DateOnly DiagnosisDate { get; set; }
        public int? LinguisticsScore {  get; set; }
        public int? CommunicationScore { get; set; }

        // relation with mom 1:1
        [ForeignKey("Mom")]
        public string MomID { get; set; }
        public virtual Mom? Mom { get; set; }

        // relation with activity m:m
        public virtual ICollection<Activity>? Activities { get; set; }
    }
}
