using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Comment : CommentRequest
    {
        public Comment(string commentContent)
        {
            Content = commentContent;
        }

        public Comment()
        {
            
        }

        public Guid Id { get; } 

        public Guid PostId { get; set; } 

        public Guid ReactId { get; set; }

    }
}
