using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Repository.Context;
using Microsoft.EntityFrameworkCore;

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
    }
}
