﻿using System.ComponentModel.DataAnnotations;

namespace TesteCadastros.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
