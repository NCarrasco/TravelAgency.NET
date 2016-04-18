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
    public partial class _PersonRegister : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string EmailString { get { return LoginData.EmailString; } }

        public String PasswordString { get { return LoginData.PasswordString; } }

        public int ClientIdValue { get { return int.Parse(ClientId.Value); } }

        internal tAdresy GetAddressEntity(ITravelAgencyService service)
        {
            return Address.CreateAddress(service);
        }

        public tOsoby Person
        {
            get
            {
                return new tOsoby()
                {
                    Imie = FirstName.Text,
                    Nazwisko = Surname.Text,
                    NIP = NIP.Text
                };
            }

        }

        public ChangePasswordData GetPasswordData()
        {
            return LoginData.GetPasswordData();
        }
        public bool IsEditMode
        {
            get { return LoginData.IsEditMode; }
            set { LoginData.IsEditMode = value; }
        }

        public void AssignData(tOsoby person)
        {
            ClientId.Value = person.tKlient.IDKlienta.ToString();
            NIP.Text = person.NIP;
            FirstName.Text = person.Imie;
            Surname.Text = person.Nazwisko;
            Address.AssignData(person.tAdresy);
            LoginData.AssignData(person.tKlient);
        }

        public void UpdatePerson(tOsoby person, ITravelAgencyService service)
        {
            person.NIP = NIP.Text ;
            person.Imie = FirstName.Text;
            person.Nazwisko = Surname.Text;
            Address.UpdateAddress(person.tAdresy, service);
        }
    }
}