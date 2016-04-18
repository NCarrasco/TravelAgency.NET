using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using TravelAgency.DAL.DAL;
using TravelAgency.WF.Models;
using WebMatrix.WebData;

namespace TravelAgency.WF.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private TravelAgencyService service = new TravelAgencyService();

        private bool isPersonVisible;

        private bool isFirmVisible;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AssignData();
            }
            else
            {
                tOsoby person = GetPersonData();
                if (person != null)
                    IsPerson = true;
                else
                    IsFirm = GetFirmData() != null;
            }
            PersonData.Visible = IsPerson;
            FirmData.Visible = !IsPerson;
        }

        private void AssignData()
        {
            tOsoby person = GetPersonData();
            if (person != null)
            {
                IsPerson = true;
                PersonData.AssignData(person);
            }
            else
            {
                tFirmy firm = GetFirmData();
                if (firm != null)
                {
                    IsFirm = true;
                    FirmData.AssignData(firm);
                }
            }
        }

        /// <summary>
        /// Returns person data prior to the modification.
        /// </summary>
        /// <returns>the person data object</returns>
        private tOsoby GetPersonData()
        {
            int? userId = service.GetClientId(User.Identity.Name);
            if (userId.HasValue)
            {
                tOsoby person = service.GetPersonData(userId.Value);
                return person;
            }
            return null;
        }

        /// <summary>
        /// Returns firm data prior to the modification.
        /// </summary>
        /// <returns>the firm data object</returns>
        private tFirmy GetFirmData()
        {
            int? userId = service.GetClientId(User.Identity.Name);
            if (userId.HasValue)
            {
                tFirmy firm = service.GetFirmData(userId.Value);
                return firm;
            }
            return null;
        }

        /// <summary>
        /// Performs the data storage. Changes the user's password when is is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SaveData_Click(object sender, EventArgs e)
        {
            var pwdData = GetPasswordData();
            if (CheckPassword(pwdData, service.GetClient(ClientIdValue)))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (IsPerson)
                            service.ChangePersonData(GetNewPersonData());
                        else if (IsFirm)
                            service.ChangeFirmData(GetNewFirmData());
                        if (ChangePassword(pwdData.OldPassword, pwdData.NewPassword, ClientIdValue))
                        {
                            service.Save();
                            MessageLabel.Text = "Data saved successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Returns firm data object with updated values.
        /// </summary>
        /// <returns>the updated firm data object</returns>
        private tFirmy GetNewFirmData()
        {
            var f = GetFirmData();
            FirmData.UpdateFirm(f, service);
            return f;
        }


        /// <summary>
        /// Returns person data object with updated values.
        /// </summary>
        /// <returns>the updated person data object</returns>
        private tOsoby GetNewPersonData()
        {
            var p = GetPersonData();
            PersonData.UpdatePerson(p, service);
            return p;
        }

        public int ClientIdValue
        {
            get
            {
                if (IsPerson)
                    return PersonData.ClientIdValue;
                else
                    return FirmData.ClientIdValue;
            }
        }

        private bool ChangePassword(String oldPassword, string newPassword, int clientId)
        {
            if (ModelState.IsValid)
            {
                List<String> errorList = new List<String>(2);
                var res = WebDataHelper.ChangePassword(User.Identity.Name, oldPassword, newPassword, clientId, errorList);
                errorList.ForEach(e => ModelState.AddModelError("", e));
                return res;
            }
            return false;
        }

        private bool CheckPassword(ChangePasswordData cd, tKlient client)
        {
            List<String> errorList = new List<String>(2);
            var res = WebDataHelper.CheckPasswords(cd.OldPassword, cd.NewPassword, cd.NewPassword2, client, errorList);
            errorList.ForEach(e => ModelState.AddModelError("", e));
            return res;
        }

        private ChangePasswordData GetPasswordData()
        {
            if (IsPerson)
            {
                return PersonData.GetPasswordData();
            }
            else
            {
                return FirmData.GetPasswordData();
            }
        }


        public bool IsPerson
        {
            get
            {
                return isPersonVisible;
            }
            private set
            {
                isPersonVisible = value;
            }
        }

        public bool IsFirm
        {
            get
            {
                return isFirmVisible;
            }
            private set
            {
                isFirmVisible = value;
            }

        }

        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }
    }
}