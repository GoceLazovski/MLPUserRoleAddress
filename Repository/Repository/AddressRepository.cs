using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class AddressRepository: GenericRepository<Address>, IAddressRepository
    {
        internal ModelContext _context;
        internal DbSet<Address> _dbSet;

        public AddressRepository(ModelContext _context) : base(_context)
        {
            this._context = _context;
            this._dbSet = _context.Set<Address>();
        }

        public Address GetAddressByIdWithItsUsers(int id)
        {
            var address = _context.Addresses.Include(a => a.UserAddresses).ToList().FirstOrDefault(a => a.Id == id);
            return address;
        }

    }
}
