using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgency.DAL.DAL;

namespace TravelAgency.MVC.ViewModels
{
    public class OffersViewModel
    {

        public OffersViewModel(IPagedList<tOferta> pagedList, FilteringData filtering, IDictionary<int, bool> offerToReservedMap)
        {
            this.PagedOffers = pagedList;
            RawOffers = PagedOffers.ToList();
            this.Filtering = filtering;
            this.OfferToReservedMap = offerToReservedMap;
        }

        public bool IsOfferReserved(int offerId)
        {
            bool value;
            if (OfferToReservedMap.TryGetValue(offerId, out value))
                return value;
            return false;
        }

        public IDictionary<int, bool> OfferToReservedMap { get; set; }

        public IPagedList<tOferta> PagedOffers { get; set; }

        public IEnumerable<tOferta> RawOffers { get; set; }

        public FilteringData Filtering { get; set; }
    }
}