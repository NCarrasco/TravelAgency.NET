using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.DAL.DAL;
using TravelAgency.Repository;

namespace TravelAgency.WF.Account
{
    public partial class AddressControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        internal tAdresy CreateAddress(ITravelAgencyService service)
        {
            var country = service.GetCounty(Country.Text);
            if (country == null)
            {
                throw new ArgumentException("Country name is invalid.");
            }
            var a= new tAdresy()
            {
                Adres = Address.Text,
                Panstwo = country.IDPanstwa,
                Miasto = City.Text,
                Region = Region.Text,
                Kod = ZipCode.Text,
                Faks = Fax.Text,
                Telefon = Phone.Text
            };
            if (!String.IsNullOrWhiteSpace(AddressId.Value))
            {
                a.IDAdresu = int.Parse(AddressId.Value);
            }
            return a;
        }

        internal void AssignData(tAdresy obj)
        {
            AddressId.Value = obj.IDAdresu.ToString();
            Address.Text = obj.Adres;
            Country.Text = obj.tPanstwa.NazwaPanstwa;
            City.Text = obj.Miasto;
            Region.Text = obj.Region;
            ZipCode.Text = obj.Kod;
            Fax.Text = obj.Faks;
            Phone.Text = obj.Telefon;
        }

        public void UpdateAddress(tAdresy obj, ITravelAgencyService service)
        {
            var country = service.GetCounty(Country.Text);
            if (country == null)
            {
                throw new ArgumentException("Country name is invalid.");
            }
            obj.Adres = Address.Text;
            obj.tPanstwa = country;
            obj.Miasto = City.Text;
            obj.Region = Region.Text;
            obj.Kod = ZipCode.Text;
            obj.Faks = Fax.Text;
            obj.Telefon = Phone.Text;
        }
    }
}