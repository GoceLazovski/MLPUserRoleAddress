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
        IEnumerable<Role> Get();        
        void Insert(Role role);        
        void Update(Role role);
        void Delete(Role role);
        Role GetById(int Id);

        Role GetRoleWithItsUsersById(int id);
    }
}
