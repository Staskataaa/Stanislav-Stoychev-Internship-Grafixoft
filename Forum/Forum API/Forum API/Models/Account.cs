using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Account : AccountRequest
    {
        public Account(string accountUsername, string password, string email)
        {
            Username = accountUsername;
            Password = password;
            Email = email;
        }

        public Account()
        { 
        }

        public Guid Id { get; }

        public Guid RoleId { get; set; }

        public int Points { get; set; } = 0;

        public string? ProfilePicPath { get; set; } = null;
    }
}
