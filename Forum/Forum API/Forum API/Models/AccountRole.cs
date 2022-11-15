using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class AccountRole : AccountRoleRequest
    {
        public Guid Id { get; }

        public AccountRole(int rolePriority, string roleDescription)
        {
            Description = roleDescription;
            Priority = rolePriority;
        }

        public AccountRole()
        {
            
        }
    }
}
