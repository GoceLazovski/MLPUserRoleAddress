using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Get(Expression<Func<Role, bool>> filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>> orderBy = null, string includeProperties = "");
        Role GetById(int Id);
        void Insert(Role role);
        void Delete(int Id);
        void Update(Role role);
    }
}
