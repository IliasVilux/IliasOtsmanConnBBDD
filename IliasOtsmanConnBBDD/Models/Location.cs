using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IliasOtsmanConnBBDD.Models
{
    internal class Location
    {
        private int locId;
        private string streetAddress;
        private string postalCode;
        private string city;
        private string stateProvince;
        private string countryId;

        public int LocId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int CountryId { get; set; }

        public Location(int locId, string streetAddress, string postalCode, string city, string stateProvince, string countryId)
        {
            this.locId = locId;
            this.streetAddress = streetAddress;
            this.PostalCode = postalCode;
            this.city = city;
            this.stateProvince = stateProvince;
            this.countryId = countryId;
        }

        public override string ToString()
        {
            return city;
        }
    }
}
