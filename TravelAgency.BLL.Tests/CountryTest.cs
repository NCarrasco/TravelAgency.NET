using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.DAL.DAL;
using System.Linq;

namespace TravelAgency.DAL.Tests
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void CountryDataCheck()
        {
            TravelAgencyContext context = new TravelAgencyContext();
            Assert.IsTrue(context.tPanstwa.ToList().Count > 5);
        }
    }
}
