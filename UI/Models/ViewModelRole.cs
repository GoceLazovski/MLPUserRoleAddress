﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ViewModelRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ViewModelUser> Users { get; set; }
    }
}
