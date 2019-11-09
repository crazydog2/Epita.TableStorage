﻿using System.ComponentModel.DataAnnotations;

namespace Epita.TableStorage.Gateway.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}