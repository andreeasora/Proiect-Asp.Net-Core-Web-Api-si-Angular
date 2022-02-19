using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
