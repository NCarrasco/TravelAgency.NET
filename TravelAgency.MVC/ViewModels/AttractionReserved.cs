using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.MVC.ViewModels
{
    public class AttractionReserved
    {
        private IDictionary<int, bool> attractionToReservedMap;

        public AttractionReserved(IDictionary<int, bool> attrToReservedMap)
        {
            this.attractionToReservedMap = attrToReservedMap;
        }
        public bool IsReserved(int attractionId)
        {
            bool value;
            if (attractionToReservedMap.TryGetValue(attractionId, out value))
                return value;
            return false;
        }
    }
}