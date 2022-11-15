using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Post : PostRequest
    {
        public Post(string postTitle, string postDescription)
        {
            Title = postTitle;
            Description = postDescription;
        }

        public Post()
        {
        }

        public Guid Id { get; } 

        public Guid AccountId { get; set; }

        public Guid? TopicId { get; set; }

        public Guid ReactId { get; set; }
    }
}
