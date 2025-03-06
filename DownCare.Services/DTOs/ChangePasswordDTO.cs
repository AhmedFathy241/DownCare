﻿using System.ComponentModel.DataAnnotations;

namespace DownCare.Services.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}