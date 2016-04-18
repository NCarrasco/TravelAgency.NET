using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.DAL.DAL;
using TravelAgency.Repository;
using TravelAgency.WF.Models;
using TravelAgency.WF.Util;

namespace TravelAgency.WF.Account
{
    public partial class _FirmRegister : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public tFirmy Firm
        {
            get
            {
                return new tFirmy() { NazwaFirmy = Name.Text, NIP = NIP.Text, REGON = REGON.Text };
            }
        }

        public tAdresy GetAddressEntity(ITravelAgencyService service)
        {
            return Address.CreateAddress(service);
        }

        public String EmailString { get { return LoginData.EmailString; } }

        public string PasswordString { get { return LoginData.PasswordString; } }

        public int ClientIdValue { get { return int.Parse(ClientId.Value); } }

        public bool IsEditMode
        {
            get { return LoginData.IsEditMode; }
            set { LoginData.IsEditMode = value; }
        }
        public void AssignData(tFirmy firm)
        {
            ClientId.Value = firm.tKlient.IDKlienta.ToString();
            REGON.Text = firm.REGON;
            NIP.Text = firm.NIP;
            Name.Text = firm.NazwaFirmy;
            Address.AssignData(firm.tAdresy);
            LoginData.AssignData(firm.tKlient);
        }

        public ChangePasswordData GetPasswordData()
        {
            return LoginData.GetPasswordData();
        }

        public void UpdateFirm(tFirmy firm, ITravelAgencyService service)
        {
            firm.REGON = REGON.Text;
            firm.NIP = NIP.Text;
            firm.NazwaFirmy = Name.Text;
            Address.UpdateAddress(firm.tAdresy, service);
        }
    }
}