using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using WebMatrix.WebData;

namespace TravelAgency.WF.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdatePanelVisibility();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    TravelAgencyService service = new TravelAgencyService();
                    try
                    {
                        if (FirmPanel.Visible)
                        {
                            CreateUser(FirmData.EmailString, FirmData.PasswordString, service, () =>
                            {
                                service.CreateFirm(FirmData.Firm, FirmData.GetAddressEntity(service), FirmData.EmailString);
                            });

                        }
                        else if (PersonPanel.Visible)
                        {
                            CreateUser(PersonData.EmailString, PersonData.PasswordString, service, () =>
                            {
                                service.CreatePerson(PersonData.Person, PersonData.GetAddressEntity(service), PersonData.EmailString);
                            });
                        }
                    }
                    finally
                    {
                        service.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
        }

        private void CreateUser(String email, String password, TravelAgencyService service, Action createUser)
        {
            List<String> errorList = new List<string>(1);
            bool isSuccess = false;
            // Attempt to register the user
            if (WebDataHelper.CreateAccount(email, password, errorList))
            {
                try
                {
                    createUser();
                    service.Save();
                    WebSecurity.Login(email, password);
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    HandleRegistrationError(email, ex);
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail is already in use.");
            }
            // Warning: Redirect to URL throws special exception which must not be handled.
            // Whne it is handled in above try then the newly created account is deleted.
            if (isSuccess)
                RedirectHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        private void HandleRegistrationError(String email, Exception ex)
        {
            try
            {
                WebDataHelper.DeleteUser(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            ModelState.AddModelError("", ex.Message);
        }

        protected void UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePanelVisibility();
        }

        private void UpdatePanelVisibility()
        {
            PersonPanel.Visible = UserType.SelectedValue == "p";
            FirmPanel.Visible = UserType.SelectedValue == "f";
            ButtonPanel.Visible = PersonPanel.Visible || FirmPanel.Visible;
        }


    }
}