using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Account : AccountRequest
    {
        public Account(string accountUsername, string password, string email)
        {
            AccountUsername = accountUsername;
            AccountPassword = password;
            AccountEmail = email;
        }

        public Account()
        {
            
        }

        public Guid AccountId { get; } = Guid.NewGuid();

        public Guid AccountRoleId { get; set; }

        public int AccountPoints { get; set; } = 0;

        public string? AccountProfilePicPath { get; set; } = null;
    }
}
