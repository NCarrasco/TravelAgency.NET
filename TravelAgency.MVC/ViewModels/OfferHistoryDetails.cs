using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DAL.DAL;

namespace TravelAgency.MVC.ViewModels
{
    public class OfferHistoryDetails
    {
        public tKlienciOfertyHistoria History { get; set; }

        public IQueryable<tKlienciAtrakcjeHistoria> Attractions { get; set; }
    }
}