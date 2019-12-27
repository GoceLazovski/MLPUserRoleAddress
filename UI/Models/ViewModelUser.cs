using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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
        public ViewModelRole Role { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        public ICollection<ViewModelUserAddresses> UserAddresses { get; set; }
    }
}
