using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL.DAL;

namespace TravelAgency.DAL.Models
{
    public class ClientData
    {

        public ClientData(int clientId, String role, string display, tAdresy tAdresy, String password)
        {
            this.ClientId = clientId;
            this.DisplayName = display;
            this.Address = tAdresy;
            this.Role = role;
            this.UserName = role;
            this.Password = password;
        }
        public int ClientId { get; set; }

        public tAdresy Address { get; set; }

        public String DisplayName { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
