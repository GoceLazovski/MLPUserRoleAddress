using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUserRepository: IDisposable
    {
        IEnumerable<User> Get(,,);
        User GetUserById(int Id);
        void Insert(User user);
        void Delete(int Id);
        void Update(User user);
        void Save();
    }
}
