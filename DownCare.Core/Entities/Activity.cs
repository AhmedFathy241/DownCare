using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Core.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public int DifficultLevel { get; set; }

        // relation with child m:m
        public virtual ICollection<Child>? Children { get; set; }
    }
}
