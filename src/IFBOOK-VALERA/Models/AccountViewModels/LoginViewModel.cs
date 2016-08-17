﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK_VALERA.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira seu login!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira sua senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim?")]
        public bool RememberMe { get; set; }
    }
}
