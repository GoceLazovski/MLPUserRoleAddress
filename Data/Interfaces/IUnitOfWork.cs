using Data.Interfaces;
using Data.Models;
using System;

namespace Repository.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}