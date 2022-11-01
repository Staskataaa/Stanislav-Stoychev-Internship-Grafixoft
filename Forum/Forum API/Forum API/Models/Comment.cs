using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Comment
    {
        public Guid CommentId { get; } = Guid.NewGuid();

        public string CommentContent { get; set; } = null!;

        public Guid CommentPostId { get; set; } 

        public Guid CommentReactId { get; set; }

    }
}
