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
        IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "");
        User GetById(int Id);
        void Insert(User user);
        void Get(int Id);
        void Update(User user);
        void Delete(User user);
    }
}
