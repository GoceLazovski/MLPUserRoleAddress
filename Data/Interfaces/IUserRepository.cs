using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        void Insert(User user);       
        void Update(User user);
        void Delete(User user);

        User GetUserById(int id);
    }
}
