using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class AccountRole
    { 
        public Guid RoleId { get; set; } = Guid.NewGuid();

        public string RoleDescription { get; set; } = null!;

        public int RolePriority { get; set; }
    }
}
