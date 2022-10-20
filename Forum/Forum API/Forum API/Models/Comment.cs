using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid? PostId { get; set; }
        public Guid? ReactId { get; set; }

        public virtual Post? Post { get; set; }
        public virtual React? React { get; set; }
    }
}
