﻿using System.ComponentModel.DataAnnotations;

namespace LibraryMVC1.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }  // За запаметяване на сесията при вход
    }
}
