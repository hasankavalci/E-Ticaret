using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaret.Models.DataModel
{
    public class BaseUser
    {
        public int BaseUserID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
    }
}