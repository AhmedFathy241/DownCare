﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownCare.Services.DTOs
{
    public class ChatRoomDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? RecipientUserId { get; set; }
    }
}
