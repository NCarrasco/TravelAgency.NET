using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DAL.DAL;

namespace TravelAgency.MVC.ViewModels
{
    public class RegistrationModel
    {
        public tAdresy Address { get; set; }
        public RegisterModel RegisterData { get; set; }
        public tOsoby Person { get; set; }
        public tFirmy Firm { get; set; }

        internal int? GetSelectedCountry()
        {
            return Address != null ? (int?)Address.Panstwo : null;
        }
    }

}