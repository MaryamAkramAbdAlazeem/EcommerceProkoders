using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProkoders.Core.Entities
{
    public class User : IdentityUser
    {
        
       
        public ICollection<Order>? Orders { get; set; }
    }
}
