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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        internal ModelContext _context;
        internal DbSet<User> _dbSet;

        public UserRepository(ModelContext _context) : base (_context)
        {
            this._context = _context;
            this._dbSet = _context.Set<User>();
        }

        public override IEnumerable<User> Get(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
        {
            var modelContext = _context.Users.Include(u => u.Role);
            
            return base.Get(filter, orderBy, includeProperties);
        }

        public override void Insert(User entity)
        {
            base.Insert(entity);
        }

        public override User GetById(int Id)
        {
            var modelContext = _context.Users.Include(u => u.Role);
            return base.GetById(Id);
        }

        public override void Delete(User entityToDelete)
        {
            var modelContext = _context.Users.Include(u => u.Role);
            base.Delete(entityToDelete);
        }

        public override void Update(User entityToUpdate)
        {
            var modelContext = _context.Users.Include(u => u.Role);
            base.Update(entityToUpdate);
        }
    }
}
