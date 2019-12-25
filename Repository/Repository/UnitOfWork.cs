using Data.Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;

namespace Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext context = new ModelContext();
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IAddressRepository addressRepository;

        //private GenericRepository<User> userRepository;

        public /*GenericRepository<User>*/ IUserRepository UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if(this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(context);
                }
                return roleRepository;
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                if(this.addressRepository == null)
                {
                    this.addressRepository = new AddressRepository(context);
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
