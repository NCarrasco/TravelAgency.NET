using System;
using System.Linq;
using System.Data.Entity;
using TravelAgency.DAL.DAL;
using TravelAgency.DAL.Util;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TravelAgency.BLL.BLL
{
    public class UnitOfWork : IDisposable
    {
        private TravelAgencyContext context = new TravelAgencyContext();
        private GenericRepository<tOferta> offerRepository;
        private GenericRepository<tPanstwa> countryRepository;

        private GenericRepository<tKlient> clientRepository;

        public GenericRepository<tOferta> OfferRepository
        {
            get
            {
                return offerRepository ?? (offerRepository = new GenericRepository<tOferta>(context));
            }
        }

        public GenericRepository<tKlient> ClientRepository
        {
            get
            {
                return clientRepository ?? (clientRepository = new GenericRepository<tKlient>(context));
            }
        }

        public GenericRepository<tPanstwa> CountryRepository
        {
            get
            {
                return countryRepository ?? (countryRepository = new GenericRepository<tPanstwa>(context));
            }
        }

        public tFirmy GetFirm(int id)
        {
            return context.tFirmy.Where(f => f.IDKlienta == id)
                .Include(f => f.tAdresy)
                .SingleOrDefault();
        }

        public tOsoby GetPerson(int id)
        {
            return context.tOsoby.Where(f => f.IDKlienta == id)
                .Include(f => f.tAdresy)
                .SingleOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ChangePersonData(tOsoby person)
        {
            context.tOsoby.Attach(person);
            context.Entry(person).State = EntityState.Modified;
            context.Entry(person.tAdresy).State = EntityState.Modified;
        }

        public void ChangeFirmData(tFirmy firm)
        {
            context.tFirmy.Attach(firm);
            context.Entry(firm).State = EntityState.Modified;
            context.Entry(firm.tAdresy).State = EntityState.Modified;
        }

        public void ChangePassword(string newPassword, int clientId)
        {
            if (!String.IsNullOrEmpty(newPassword))
            {
                var client = context.tKlient.Find(clientId);
                if (client != null)
                {
                    client.haslo = DataUtil.GetMd5Hash(newPassword);
                    context.Entry(client).State = EntityState.Modified;
                }
            }
        }

        public tKlient GetClient(int clientId)
        {
            return context.tKlient.Find(clientId);
        }
        public tKlient GetClientWithPersons(int clientId)
        {
            return context.tKlient.Include(t => t.tOsoby).Where(t => t.IDKlienta == clientId).SingleOrDefault();
        }

        public IQueryable<tOferta> GetOffers()
        {
            return context.tOferta.Include(t => t.tPanstwa).Include(t => t.tAtrakcjeUslugi);
        }

        public IQueryable<tOferta> GetOrderedOffers()
        {
            return context.tOferta.OrderBy(o => o.DataWyjazdu);
        }

        public IQueryable<tOferta> AddIncludeToOffers(IQueryable<tOferta> q)
        {
            return q.Include(t => t.tPanstwa).Include(t => t.tAtrakcjeUslugi);
        }

        public IQueryable<tOferta> GetOffers(int startRows, int maxRows)
        {
            return context.tOferta.OrderBy(o => o.DataWyjazdu).Skip(startRows).Take(maxRows).Include(t => t.tPanstwa).Include(t => t.tAtrakcjeUslugi);
        }

        public void ReserveOffer(int offerId, int personId, int clientId)
        {
            context.Database.ExecuteSqlCommand("EXECUTE spRezerwujOferteKlient @offerId, @clientId, @personId",
                new SqlParameter("@offerId", offerId),
                new SqlParameter("@clientId", clientId),
                new SqlParameter("@personId", personId));
        }
        public bool IsOfferReserved(int offerId, int personId, int clientId)
        {
            return context.tKlienciOferty
                .Where(o => o.IDKlienta == clientId && o.IDOferty == offerId && o.IDOsobyImprezy == personId)
                .FirstOrDefault() != null;
        }

        public bool IsAttractionReserved(int attrId, int personId, int clientId)
        {
            return context.tKlienciAtrakcje
                .Where(o => o.IDKlienta == clientId && o.IDAtrakcjiUslugi == attrId && o.IDOsobyAtrakcji == personId)
                .FirstOrDefault() != null;
        }

        public void ReserveAttraction(int attrId, int personId, int clientId)
        {
            context.Database.ExecuteSqlCommand("EXECUTE spRezerwujAtrakcjeKlient @clientId, @attrId, @personId",
                new SqlParameter("@attrId", attrId),
                new SqlParameter("@clientId", clientId),
                new SqlParameter("@personId", personId));
        }

        public tAtrakcjeUslugi FindAttraction(int attractionId)
        {
            return context.tAtrakcjeUslugi.Where(a => a.IDAtrakcjiUslugi == attractionId).SingleOrDefault();
        }

        public IDictionary<int, bool> GetOfferIdToReservedMap(int clientId)
        {
            return context.tKlienciOferty
                .Where(t => t.IDKlienta == clientId)
                .ToDictionary(t => t.IDOferty, t => t.IDKlienta == clientId);
        }

        public IQueryable<tAtrakcjeUslugi> GetAttractions(int offerId)
        {
            return context.tOferta
                .Join(context.tAtrakcjeUslugi, o => o.IDOferty, a => a.IDOferty, (o, a) => a)
                .Where(t => t.IDOferty == offerId);
        }

        public IDictionary<int, bool> GetAttractionIdToReservedMap(int clientId)
        {
            return context.tKlienciAtrakcje
                .Where(t => t.IDKlienta == clientId)
                .ToDictionary(t => t.IDAtrakcjiUslugi, t => t.IDKlienta == clientId);
        }

        public IQueryable<tKlienciOfertyHistoria> GetOfferHistory(int userId)
        {
            return context.tKlienciOfertyHistoria.Where(t => t.IDKlienta == userId)
                .Include(t => t.tHistoriaOfert)
                .Include(t => t.tOsoby)
                .Include(t => t.tKlient)
                .Include(t => t.tHistoriaOfert.tPanstwa);
        }

        public tKlienciOfertyHistoria GetOfferHistory(int userId, int offerId)
        {
            return context.tKlienciOfertyHistoria.Where(t => t.IDOferty == offerId && t.IDKlienta == userId)
                .Include(t => t.tHistoriaOfert)
                .Include(t => t.tHistoriaOfert.tAtrakcjeHistoria)
                .Include(t => t.tOsoby)
                .Include(t => t.tKlient)
                .Include(t => t.tHistoriaOfert.tPanstwa).SingleOrDefault();
        }

        public IQueryable<tKlienciAtrakcjeHistoria> GetAttractionHistoryList(int userId, int offerId)
        {
            return context.tKlienciAtrakcjeHistoria
                .Include(t => t.tAtrakcjeHistoria)
                .Include(t => t.tOsoby)
                .Include(t => t.tKlient)
                .Where(t => t.IDKlienta == userId && t.tAtrakcjeHistoria.IDOferty == offerId);
        }

        public tKlienciAtrakcjeHistoria GetAttractionHistory(int userId, int attractionId)
        {
            return context.tKlienciAtrakcjeHistoria.Where(t => t.IDAtrakcjiUslugi == attractionId && t.IDKlienta == userId)
                .Include(t => t.tAtrakcjeHistoria)
                .Include(t => t.tKlient)
                .Include(t => t.tOsoby).SingleOrDefault();
        }

        public void ClearReservationTables()
        {
            context.tKlienciOferty.RemoveRange(context.tKlienciOferty.ToList());
            context.tKlienciAtrakcje.RemoveRange(context.tKlienciAtrakcje.ToList());
        }

        public List<tPanstwa> GetCountries()
        {
            return context.tPanstwa.ToList();
        }

        private tKlient GetNonNullClientId(string email)
        {
            var client = context.tKlient.Where(t => t.email == email).SingleOrDefault();
            if (client == null)
                throw new ArgumentException("client was not added");
            return client;
        }

        public void CreatePerson(tOsoby person, tAdresy address, string email)
        {
            var client = GetNonNullClientId(email);
            person.IDKlienta = client.IDKlienta;
            person.tKlient = client;
            person.tAdresy = address;
            context.tOsoby.Add(person);
        }

        public void CreateFirm(tFirmy firm, tAdresy address, string email)
        {
            var client = GetNonNullClientId(email);
            firm.IDKlienta = client.IDKlienta;
            firm.tKlient = client;
            firm.tAdresy = address;
            context.tFirmy.Add(firm);
        }

        public bool IsClientAdded(string email)
        {
            var client = GetNonNullClientId(email);
            return client != null;
        }

        public int? GetClientId(string email)
        {
            var client = context.tKlient.Where(t => t.email == email).AsNoTracking().SingleOrDefault();
            if (client != null)
                return client.IDKlienta;
            return null;
        }

        public tPanstwa GetCountry(string name)
        {
            return context.tPanstwa.Where(p => p.NazwaPanstwa == name).SingleOrDefault();
        }

        public int? GetOfferHistoryIdByAttractionId(int aid)
        {
            return context.tAtrakcjeHistoria
                .Where(a => a.IDAtrakcjiUslugi == aid)
                .Select(a => a.IDOferty).SingleOrDefault();
        }


        public int? GetOfferIdByAttractionId(int aid)
        {
            return context.tAtrakcjeUslugi
                .Where(a => a.IDAtrakcjiUslugi == aid)
                .Select(a => a.IDOferty).SingleOrDefault();
        }
    }
}
