using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class AccountRole
    {
        public AccountRole()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid RoleId { get; set; }
        public string RoleDescription { get; set; } = null!;
        public int RolePriority { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
