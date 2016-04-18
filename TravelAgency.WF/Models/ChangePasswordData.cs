using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.WF.Models
{
    public class ChangePasswordData
    {
        public ChangePasswordData(String email, String oldPassword, String newPassword, String newPassword2)
        {
            Email = email;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            NewPassword2 = newPassword2;
        }
        public String Email { get; private set; }
        public String OldPassword { get; private set; }
        public String NewPassword { get; private set; }
        public String NewPassword2 { get; private set; }
    }
}