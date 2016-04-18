using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL.BLL;

namespace TravelAgency.DAL.Tests
{
    [TestClass]
    public class OfferTest
    {
        private static TravelAgencyService service;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            service = new TravelAgencyService();
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            service.Dispose();
        }
        [TestMethod]
        public void ReserveOffer()
        {
            service.ClearReservationTables();
            service.Save();

            bool actual = service.IsOfferReserved(1, 1, 1);
            Assert.IsFalse(actual);

            // Reserve attraction
            service.ReserveOffer(1, 1, 1);
            actual = service.IsOfferReserved(1, 1, 1);
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void ReserveAttraction()
        {
            service.ClearReservationTables();
            service.Save();

            bool actual = service.IsAttractionReserved(1, 1, 1);
            Assert.IsFalse(actual);

            service.ReserveOffer(19, 1, 1);
            // Reserve attraction
            service.ReserveAttraction(1, 1, 1);
            actual = service.IsAttractionReserved(1, 1, 1);
            Assert.IsTrue(actual);
        }

    }
}
