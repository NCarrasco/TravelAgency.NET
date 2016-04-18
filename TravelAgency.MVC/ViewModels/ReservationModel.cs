using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DAL.DAL;

namespace TravelAgency.MVC.ViewModels
{
    public class ReservationModel
    {
        public tOferta Offer { get; set; }

        public tAtrakcjeUslugi Attraction { get; set; }

        public tKlient ClientWithPersons { get; set; }

        public int PersonId { get; set; }
    }
}