using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository.Repository
{
    public class RoleRepository: GenericRepository<Role>, IRoleRepository
    {
        internal ModelContext _context;
        internal DbSet<Role> _dbSet;

        public RoleRepository(ModelContext _context) : base(_context)
        {
            this._context = _context;
            this._dbSet = _context.Set<Role>();
        }

        public Role GetRoleWithItsUsersById(int id)
        {
            var role = _context.Roles.Include(r => r.Users).ToList().FirstOrDefault(r => r.Id == id);
            return role;
        }
    }
}
