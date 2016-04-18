using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DAL.DAL;

namespace TravelAgency.MVC.ViewModels
{
    public class PersonChecked
    {
        public tOsoby Person { get; set; }

        public bool Checked { get; set; }
    }
}