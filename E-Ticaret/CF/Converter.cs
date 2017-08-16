using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Ticaret.Models.Helper;

namespace E_Ticaret.CF
{
    public class Converter
    {
        public static UserNameSurname ToUserNameSurName(dynamic ToConvert)
        {
            UserNameSurname ToSend = new UserNameSurname();
            ToSend.ID = ToConvert.BaseUserID;
            ToSend.Name = ToConvert.Name;
            ToSend.SurName = ToConvert.SurName;
            return ToSend;
        }
    }
}