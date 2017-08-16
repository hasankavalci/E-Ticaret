using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.Helper
{
    public class UserPassword
    {
        public int UserID { get; set; }

        [StringLength(100,ErrorMessage ="Şifre 3 Karakterden Az Olamaz",MinimumLength =3)]
        [DataType(DataType.Password)]
        [Display(Name ="Eski Şifrenizi Giriniz")]       
        public string OldPassword { get; set; }

        [StringLength(100, ErrorMessage = "Şifre 3 Karakterden Az Olamaz", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifrenizi Giriniz")]
        public string NewPassword { get; set; }

        [StringLength(100, ErrorMessage = "Şifre 3 Karakterden Az Olamaz", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifrenizi Tekrar Giriniz")]
        public string NewPasswordAgain { get; set; }
    }
}