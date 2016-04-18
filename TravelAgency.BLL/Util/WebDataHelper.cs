using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Security;
using TravelAgency.BLL.BLL;
using TravelAgency.DAL.DAL;
using TravelAgency.DAL.Util;
using WebMatrix.WebData;

namespace TravelAgency.BLL.Util
{
    public class WebDataHelper
    {

        public const String ADMIN_ROLE = "Admin";

        public const String CLIENT_ROLE = "Client";

        public static void AddUserToRole(String userName)
        {
            var service = new TravelAgencyService();
            int? userid = service.GetClientId(userName);
            if (userid != null)
            {
                tOsoby person = service.GetPersonData(userid.Value);
                if (person != null)
                {
                    String roleName = person.bPracownik ? ADMIN_ROLE : CLIENT_ROLE;
                    if (!Roles.IsUserInRole(userName, roleName))
                    {
                        if (Roles.GetAllRoles().Where(r => r == roleName).FirstOrDefault() == null)
                        {
                            Roles.CreateRole(roleName);
                        }
                        Roles.AddUserToRole(userName, roleName);
                    }
                }
            }
        }

        public static bool CreateAccount(String email, String password, List<String> errorList)
        {
            try
            {
                WebSecurity.CreateUserAndAccount(email, password,
                    propertyValues: new { haslo = DataUtil.GetMd5Hash(password) });
                return true;
            }
            catch (MembershipCreateUserException e)
            {
                errorList.Add(ErrorCodeToString(e.StatusCode));

            }
            catch (Exception ex)
            {
                errorList.Add("Failed to save data: " + ex.Message);
            }
            return false;
        }


        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public static bool CreateAccount(string p, System.Web.UI.WebControls.TextBox textBox)
        {
            throw new NotImplementedException();
        }

        public static void DeleteUser(String userName)
        {
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(userName); // deletes record from webpages_Membership table
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(userName, true); // deletes record from UserProfile table
        }

        public static bool ChangePassword(String userName, String oldPassword, string newPassword, int clientId, List<String> errorList)
        {
            if (!String.IsNullOrEmpty(newPassword))
            {
                // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = WebSecurity.ChangePassword(userName, oldPassword, newPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (!changePasswordSucceeded)
                {
                    errorList.Add("The current password is incorrect or the new password is invalid.");
                }
                return changePasswordSucceeded;
            }
            return true;
        }

        public static bool CheckPasswords(String oldPassword, String newPassword, String newPassword2, 
            tKlient client, List<String> errorList)
        {
            bool isValid = true;
            if (!String.IsNullOrEmpty(newPassword)
                || !String.IsNullOrEmpty(oldPassword)
                || !String.IsNullOrEmpty(newPassword2))
            {
                if (newPassword != newPassword2)
                {
                    errorList.Add("Passwords do not match.");
                    isValid = false;
                }
                // Old password must not be chacked here since the WebSecurity carries about that.

                if (newPassword.Length < 8)
                {
                    errorList.Add("New password is too short.");
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}
