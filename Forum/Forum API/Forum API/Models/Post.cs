using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Post : PostRequest
    {
        public Post(string postTitle, string postDescription)
        {
            PostTitle = postTitle;
            PostDescription = postDescription;
        }

        public Post()
        {
            
        }

        public Guid PostId { get; } = Guid.NewGuid();

        public Guid PostAccountId { get; set; }

        public Guid? PostTopicId { get; set; }

        public Guid PostReactId { get; set; }
    }
}
