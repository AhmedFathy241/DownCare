using System.ComponentModel.DataAnnotations.Schema;

namespace DownCare.Core.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public int Age { get; set; }
        public  string Gender { get; set; }
        public DateOnly DiagnosisDate { get; set; }
        public LinguisticsScore? LinguisticsScore { get; set; }
        public CommunicationScore? CommunicationScore { get; set; }

        // relation with mom 1:1
        [ForeignKey("Mom")]
        public string MomID { get; set; }
        public virtual Mom? Mom { get; set; }
    }
}
