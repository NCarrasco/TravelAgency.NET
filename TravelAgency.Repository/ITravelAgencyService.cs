using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.DAL;

namespace TravelAgency.Repository
{
    /// <summary>
    /// Interface for classes which provide access to data repository. Provides methods
    /// leverated by controlers. 
    /// </summary>
    public interface ITravelAgencyService
    {
        int? GetClientId(String email);

        tOsoby GetPersonData(int clientId);

        List<tPanstwa> GetCountries();

        void Save();

        void CreatePerson(tOsoby person, tAdresy address, string email);

        void CreateFirm(tFirmy firm, tAdresy address, string email);

        tFirmy GetFirmData(int clientId);

        tKlient GetClient(int clientId);

        void ChangeFirmData(tFirmy firm);

        void ChangePersonData(tOsoby person);

        void Dispose();

        tPanstwa GetCounty(string name);
    }
}
