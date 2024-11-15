﻿using System.ComponentModel.DataAnnotations;

namespace PatikaPratikJwt.Models
{
    public class RegisterRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
