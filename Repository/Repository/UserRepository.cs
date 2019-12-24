using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Repository.Context;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository, IDisposable
    {
        internal ModelContext _context;
        internal DbSet<User> _dbSet;

        public UserRepository(ModelContext _context)
        {
            this._context = _context;
            this._dbSet = _context.Set<User>();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
        {
            IQueryable<User> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

            //throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
