using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Account
    {
        public Guid AccountId { get; } = Guid.NewGuid();

        public string AccountUsername { get; set; } = null!;

        public string AccountPassword { get; set; } = null!;

        public string AccountEmail { get; set; } = null!;

        public Guid AccountRoleId { get; set; } 

        public string? AccountProfilePicPath { get; set; }

        public int? AccountPoints { get; set; }
    }
}
