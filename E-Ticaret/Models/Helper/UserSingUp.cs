using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace E_Ticaret.Models.Helper
{
    public class UserSingUp
    {
        [Required(ErrorMessage ="Lütfen İsminizi Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string SurName { get; set; }

        [
            EmailAddress(ErrorMessage ="E-Posta Formatında Giriniz"),
            Required(ErrorMessage ="Lütfen E-Postanızı Giriniz")           
        ]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Şifre 3 Karakterden Az Olamaz", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [StringLength(100, ErrorMessage = "Şifre 3 Karakterden Az Olamaz", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen Şifreinizi Tekrar Giriniz")]
        public string PasswordAgain { get; set; }

        [Required(ErrorMessage ="Lüften Kullanım Koşullarını Kabul Ediniz")]
        public bool TermAndConditions { get; set; }
    }
}