using Data.Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ModelContext context = new ModelContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<Address> addressRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if(this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(context);
                }
                return roleRepository;
            }
        }

        public GenericRepository<Address> AddressRepository
        {
            get
            {
                if(this.addressRepository == null)
                {
                    this.addressRepository = new GenericRepository<Address>(context);
                }
                return addressRepository;
            }
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
    }
}
