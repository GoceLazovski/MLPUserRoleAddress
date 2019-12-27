using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> Get();
        Address GetById(int Id);
        void Insert(Address address);        
        void Update(Address address);
        void Delete(Address address);

        Address GetAddressByIdWithItsUsers(int id);
    }
}
