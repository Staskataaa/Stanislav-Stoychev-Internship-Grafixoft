using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Comment : CommentRequest
    {
        public Comment(string commentContent)
        {
            CommentContent = commentContent;
        }

        public Guid CommentId { get; } 

        public Guid CommentPostId { get; set; } 

        public Guid CommentReactId { get; set; }

    }
}
