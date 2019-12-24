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
        IEnumerable<Address> Get(Expression<Func<Address, bool>> filter = null, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null, string includeProperties = "");
        Address GetById(int Id);
        void Insert(Address address);
        void Delete(int Id);
        void Update(Address address);
    }
}
