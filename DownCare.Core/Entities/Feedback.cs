﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DownCare.Core.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        // relation with Mom 1:m
        [ForeignKey("Mom")]
        public string MomID { get; set; }
        public Mom? Mom { get; set; }
    }
}
