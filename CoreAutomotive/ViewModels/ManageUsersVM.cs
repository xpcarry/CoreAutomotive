using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class UsersWithRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }

    }

    public class ManageUsersVM
    {

        public List<UsersWithRoles> UsersWithRoles { get; set; }
        public List<Role> Roles { get; set; }
    }
}
