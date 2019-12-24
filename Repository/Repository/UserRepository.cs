﻿using Data.Models;
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
    }
}
