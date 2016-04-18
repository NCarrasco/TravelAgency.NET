using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.MVC.Util;

namespace TravelAgency.DAL.DAL
{
    public partial class tKlienciAtrakcjeHistoria
    {
        public string SposobZaplatyText { get { return ModelUtil.GetPaymentManner(SposobZaplaty); } }
    }
}
