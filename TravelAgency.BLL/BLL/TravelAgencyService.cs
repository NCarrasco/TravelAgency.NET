using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using TravelAgency.DAL.DAL;
using TravelAgency.DAL.Models;
using TravelAgency.DAL.Util;
using TravelAgency.Repository;

namespace TravelAgency.BLL.BLL
{
    public class TravelAgencyService : ITravelAgencyService
    {
        private class DisposableAgencyService : IDisposable
        {

            private TravelAgencyService s;
            public DisposableAgencyService(TravelAgencyService s)
            {
                this.s = s;
            }
            public void Dispose()
            {
                s.Dispose();
            }
        }
        private UnitOfWork unitOfWork;

        public TravelAgencyService()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool TryLogin(string login, string password, out ClientData clientData)
        {
            clientData = null;
            tKlient single = unitOfWork.ClientRepository.Get(c => c.email == login, null).SingleOrDefault();
            if (single != null)
            {
                string encoded = DataUtil.GetMd5Hash(password);
                if (encoded.Equals(single.haslo))
                {
                    clientData = GetClientData(single.IDKlienta.ToString());
                    if (clientData != null)
                        return true;
                }
            }
            return false;
        }

        public tKlient GetClient(int clientId)
        {
            return unitOfWork.GetClient(clientId);
        }

        public tKlient GetClientWithPersons(int clientId)
        {
            return unitOfWork.GetClientWithPersons(clientId);
        }
        public ClientData GetClientData(String clientId)
        {
            ClientData data = null;
            int intId;
            if (!int.TryParse(clientId, out intId))
            {
                return null;
            }
            tKlient single = unitOfWork.ClientRepository.Get(c => c.IDKlienta == intId, null, "tFirmy,tOsoby").SingleOrDefault();
            var person = single.tOsoby.SingleOrDefault();
            if (person != null)
            {
                String dispaly = String.Format("{0} {1} ({2}", person.Imie, person.Nazwisko, single.email);
                String role = person.bPracownik ? "Admin" : "User";
                data = new ClientData(intId, role, dispaly, person.tAdresy, single.haslo);
            }
            else
            {
                var firm = single.tFirmy.SingleOrDefault();
                if (firm != null)
                {
                    String dispaly = String.Format("{0} ({1}", firm.NazwaFirmy, single.email);
                    data = new ClientData(intId, "User", dispaly, firm.tAdresy, single.haslo);
                }
            }
            return data;
        }

        public tFirmy GetFirmData(int userId)
        {
            return unitOfWork.GetFirm(userId);
        }

        public tOsoby GetPersonData(int userId)
        {
            return unitOfWork.GetPerson(userId);
        }

        public void ChangeFirmData(tFirmy firm)
        {
            unitOfWork.ChangeFirmData(firm);
        }

        public void ChangePersonData(tOsoby person)
        {
            unitOfWork.ChangePersonData(person);
        }

        public void ChangePassword(String newPassword, int clientId)
        {
            unitOfWork.ChangePassword(newPassword, clientId);
        }
        public void Save()
        {
            unitOfWork.Save();
        }

        public IQueryable<tOferta> GetOffers()
        {
            return unitOfWork.GetOffers();
        }
        public List<tOferta> GetSubsetOfOffers(int startRows, int maxRows,
            DateTime? minDepartureDate, DateTime? maxDepartureDate, decimal? minPrice, decimal? maxPrice,
            int minStayTimeInDays, int maxStayTimeInDays, String city, String country)
        {
            var q = getOfferQueryable(minDepartureDate, maxDepartureDate, minPrice, maxPrice, minStayTimeInDays, maxStayTimeInDays, city, country);
            q = q.Skip(startRows).Take(maxRows);
            return unitOfWork.AddIncludeToOffers(q).ToList();
        }
        private IQueryable<tOferta> getOfferQueryable(DateTime? minDepartureDate, DateTime? maxDepartureDate, decimal? minPrice, decimal? maxPrice,
            int minStayTimeInDays, int maxStayTimeInDays, String city, String country)
        {
            IQueryable<DAL.DAL.tOferta> q = unitOfWork.GetOrderedOffers();
            IQueryable<DAL.DAL.tOferta> result = q;
            if (city != null)
            {
                result = result.Where(o => o.Miasto.Equals(city));
            }
            if (country != null)
            {
                result = result.Where(o => o.tPanstwa.NazwaPanstwa.Equals(country));
            }
            if (minStayTimeInDays > 0)
            {
                result = result.Where(o => o.LiczbaDniTrwania >= minStayTimeInDays);
            }
            if (maxStayTimeInDays > 0)
            {
                result = result.Where(o => o.LiczbaDniTrwania <= maxStayTimeInDays);
            }
            if (minPrice.HasValue)
            {
                result = result.Where(o => o.mCena >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                result = result.Where(o => o.mCena <= maxPrice.Value);
            }
            if (minDepartureDate.HasValue)
            {
                result = result.Where(o => o.DataWyjazdu >= minDepartureDate.Value);
            }

            if (maxDepartureDate.HasValue)
            {
                result = result.Where(o => o.DataWyjazdu <= maxDepartureDate.Value);
            }
            return result;
        }

        public int GetOfferCount(DateTime? minDepartureDate, DateTime? maxDepartureDate, decimal? minPrice, decimal? maxPrice,
            int minStayTimeInDays, int maxStayTimeInDays, String city, String country)
        {
            // Cache cannot be used since all offers are not provided when filtering is leveraged.
            var q = getOfferQueryable(minDepartureDate, maxDepartureDate, minPrice, maxPrice, minStayTimeInDays, maxStayTimeInDays, city, country);
            int offerCount = q.Count();
            return offerCount;

        }
        public tOferta FindOffer(int? id)
        {
            if (!id.HasValue)
                return null;
            return unitOfWork.OfferRepository.GetByID(id.Value);
        }

        public IDisposable ToDisposable()
        {
            return new DisposableAgencyService(this);
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public void ReserveOffer(int offerId, int personId, int clientId)
        {
            unitOfWork.ReserveOffer(offerId, personId, clientId);
        }

        public bool IsOfferReserved(int offerId, int personId, int clientId)
        {
            return unitOfWork.IsOfferReserved(offerId, personId, clientId);
        }

        public void ReserveAttraction(int attrId, int personId, int clientId)
        {
            unitOfWork.ReserveAttraction(attrId, personId, clientId);
        }

        public bool IsAttractionReserved(int attractionId, int personId, int clientId)
        {
            return unitOfWork.IsAttractionReserved(attractionId, personId, clientId);
        }

        public tAtrakcjeUslugi FindAttraction(int attractionId)
        {
            return unitOfWork.FindAttraction(attractionId);
        }

        public bool IsOfferReserved(int offerId, object sessionUserId)
        {
            int? userId = sessionUserId as int?;
            if (userId == null)
                return false;
            tKlient client = GetClientWithPersons(userId.Value);
            return IsOfferReserved(offerId, client.tOsoby.First().IDOsoby, userId.Value);
        }

        public bool IsAttractionReserved(int attractionId, object sessionUserId)
        {
            int? userId = sessionUserId as int?;
            if (userId == null)
                return false;
            tKlient client = GetClientWithPersons(userId.Value);
            return IsAttractionReserved(attractionId, client.tOsoby.First().IDOsoby, userId.Value);
        }

        public IDictionary<int, bool> GetOfferIdToReservedMap(object sessionUserId)
        {
            int? userId = sessionUserId as int?;
            if (userId == null)
                return new Dictionary<int, bool>(0);
            var map = new Dictionary<int, bool>(0);
            return unitOfWork.GetOfferIdToReservedMap(userId.Value);
        }

        public IQueryable<tAtrakcjeUslugi> GetAttractions(int offerId)
        {
            return unitOfWork.GetAttractions(offerId);
        }

        public IDictionary<int, bool> GetAttractionIdToReservedMap(object sessionUserId)
        {
            int? userId = sessionUserId as int?;
            if (userId == null)
                return new Dictionary<int, bool>(0);
            var map = new Dictionary<int, bool>(0);
            return unitOfWork.GetAttractionIdToReservedMap(userId.Value);
        }

        public IQueryable<tKlienciOfertyHistoria> GetOfferHistory(int userId)
        {
            return unitOfWork.GetOfferHistory(userId);
        }

        public tKlienciOfertyHistoria GetOfferHistory(int userId, int offerId)
        {
            return unitOfWork.GetOfferHistory(userId, offerId);
        }

        public IQueryable<tKlienciAtrakcjeHistoria> GetAttractionHistoryList(int userId, int offerId)
        {
            return unitOfWork.GetAttractionHistoryList(userId, offerId);
        }

        public tKlienciAtrakcjeHistoria GetAttractionHistory(int userId, int attractionId)
        {
            return unitOfWork.GetAttractionHistory(userId, attractionId);
        }

        public void ClearReservationTables()
        {
            unitOfWork.ClearReservationTables();
        }

        public List<tPanstwa> GetCountries()
        {
            return unitOfWork.GetCountries();
        }

        public void CreatePerson(tOsoby person, tAdresy address, string email)
        {
            unitOfWork.CreatePerson(person, address, email);
        }

        public void CreateFirm(tFirmy firm, tAdresy address, string email)
        {
            unitOfWork.CreateFirm(firm, address, email);
        }

        public bool IsClientAdded(string email)
        {
            return unitOfWork.IsClientAdded(email);
        }

        public int? GetClientId(string email)
        {
            return unitOfWork.GetClientId(email);
        }

        public tPanstwa GetCounty(string name)
        {
            return unitOfWork.GetCountry(name);
        }

        public int? GetOfferHistoryIdByAttractionId(int aid)
        {
            return unitOfWork.GetOfferHistoryIdByAttractionId(aid);
        }


        public int? GetOfferIdByAttractionId(int aid)
        {
            return unitOfWork.GetOfferIdByAttractionId(aid);
        }
    }
}
