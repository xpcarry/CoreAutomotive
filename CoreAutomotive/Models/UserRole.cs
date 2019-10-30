using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{

    public class UserRole : IdentityUserRole<int>
    {
        public UserData User { get; set; }
        public Role Role { get; set; }
    }
}
