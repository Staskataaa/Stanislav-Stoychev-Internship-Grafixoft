using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Account
    {
        public Account()
        {
            Posts = new HashSet<Post>();
            Topics = new HashSet<Topic>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string AccountPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ProfilePicPath { get; set; } = null!;
        public int? Points { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
