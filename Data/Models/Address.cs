using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Address
    {
        public Address()
        {
            UserAddresses = new HashSet<UserAddress>();
        }

        public int Id { get; set; }
        public string AddressStreetAndNumber { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
