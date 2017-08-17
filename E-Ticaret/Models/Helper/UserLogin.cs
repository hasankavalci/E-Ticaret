using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Helper
{
    public class UserLogin
    {
        [
            EmailAddress(ErrorMessage = "E-Posta Formatında Giriniz"),
            Required(ErrorMessage = "Lütfen E-Postanızı Giriniz")
        ]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Şifre 3 Karakterden Az Olamaz", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }
    }
}