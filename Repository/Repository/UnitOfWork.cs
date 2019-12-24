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
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private AddressRepository addressRepository;

        public UserRepository UserRepository
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

        public RoleRepository RoleRepository
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

        public AddressRepository AddressRepository
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
