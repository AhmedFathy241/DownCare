
namespace DownCare.Core.Entities
{
    public class CommunicationScore
    {
        public int Id { get; set; }
        public int OneWord { get; set; }
        public int TwoWord { get; set; }
        public int ThreeWord { get; set; }
        public int FourWord { get; set; }
        public int FiveWord { get; set; }
        //relation with child 1:1
        public int ChildId { get; set; }
        public virtual Child? Child { get; set; }
    }
}
