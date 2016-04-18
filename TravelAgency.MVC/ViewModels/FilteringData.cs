using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.MVC.Util;

namespace TravelAgency.MVC.ViewModels
{
    public class FilteringData
    {

        public FilteringData()
        {

        }
        public FilteringData(NameValueCollection query, ModelStateDictionary modelState)
        {
            int pageSizeTmp;
            if (int.TryParse(query["Filtering.ItemsOnPage"], out pageSizeTmp))
                ItemsOnPage = pageSizeTmp;
            else
                ItemsOnPage = 20;
            if (!String.IsNullOrWhiteSpace(query["Filtering.City"]))
            {
                City = query["Filtering.City"];
            }

            if (!String.IsNullOrWhiteSpace(query["Filtering.Country"]))
            {
                Country = query["Filtering.Country"];
            }
            int tmpVal;
            if (int.TryParse(query["Filtering.StayTimeInDays"], out tmpVal))
            {
                StayTimeInDays = tmpVal;
            }
            else if (!String.IsNullOrWhiteSpace(query["Filtering.StayTimeInDays"]))
            {
                modelState.AddModelError("Filtering.StayTimeInDays", "Stay time is an invalid number.");
            }

            DateTime tmpdt;
            if (DateTime.TryParse(query["Filtering.MinDepartureDate"], out tmpdt))
            {
                MinDepartureDate = tmpdt;
            }
            else if (!String.IsNullOrWhiteSpace(query["Filtering.MinDepartureDate"]))
            {
                modelState.AddModelError("Filtering.MinDepartureDate", "Minimum departure date is invalid.");
            }

            if (DateTime.TryParse(query["Filtering.MaxDepartureDate"], out tmpdt))
            {
                MaxDepartureDate = tmpdt;
            }
            else if (!String.IsNullOrWhiteSpace(query["Filtering.MaxDepartureDate"]))
            {
                modelState.AddModelError("Filtering.MaxDepartureDate", "Maximum departure date is invalid.");
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "MinDepartureDate", ResourceType = typeof(MvcStrings))]
        public DateTime? MinDepartureDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "MaxDepartureDate", ResourceType = typeof(MvcStrings))]
        public DateTime? MaxDepartureDate { get; set; }

        [Display(Name = "City", ResourceType = typeof(MvcStrings))]
        public String City { get; set; }

        [Display(Name = "Country", ResourceType = typeof(MvcStrings))]
        public String Country { get; set; }

        [Display(Name = "StayTimeInDays", ResourceType = typeof(MvcStrings))]
        public int StayTimeInDays { get; set; }

        [Display(Name = "ItemsOnPage", ResourceType = typeof(MvcStrings))]
        public int ItemsOnPage { get; set; }

        internal IQueryable<DAL.DAL.tOferta> Apply(IQueryable<DAL.DAL.tOferta> tOferta)
        {
            IQueryable<DAL.DAL.tOferta> result = tOferta;
            if (City != null)
            {
                result = tOferta.Where(o => o.Miasto.Equals(City));
            }
            if (Country != null)
            {
                result = tOferta.Where(o => o.tPanstwa.NazwaPanstwa.Equals(Country));
            }
            if (StayTimeInDays > 0)
            {
                result = tOferta.Where(o => o.LiczbaDniTrwania == StayTimeInDays);
            }

            if (MinDepartureDate.HasValue)
            {
                result = tOferta.Where(o => o.DataWyjazdu >= MinDepartureDate);
            }

            if (MaxDepartureDate.HasValue)
            {
                result = tOferta.Where(o => o.DataWyjazdu <= MaxDepartureDate);
            }
            return result;
        }
    }
}