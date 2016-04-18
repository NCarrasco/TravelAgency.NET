using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.WF.Models;

namespace TravelAgency.WF.Account
{
    public partial class _LoginDataControl : System.Web.UI.UserControl
    {
        private bool isEditMode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool IsEditMode
        {
            get
            {
                return isEditMode;
            }
            set
            {
                isEditMode = value;
            }
        }

        public String EmailString { get { return Email.Text; } }

        public string PasswordString { get { return Password.Text; } }

        internal void AssignData(DAL.DAL.tKlient tKlient)
        {
            if (IsEditMode)
            {
                EmailLabel.Text = tKlient.email;
            }
            else
            {
                Email.Text = tKlient.email;
            }
        }
        public ChangePasswordData GetPasswordData()
        {
            if (IsEditMode)
            {
                return new ChangePasswordData(EmailLabel.Text, OldPassword.Text, NewPassword.Text, ConfirmNewPassword.Text);
            }
            throw new InvalidOperationException("edit mode expected");
        }
    }
}