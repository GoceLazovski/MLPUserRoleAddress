using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ViewModelUserAddresses
    {
        public int UserId { get; set; }
        public ViewModelUser User { get; set; }

        public int AddressId { get; set; }
        public ViewModelAddress Address { get; set; }
    }
}
