﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ViewModelUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        //public Role Role { get; set; }

        //public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
