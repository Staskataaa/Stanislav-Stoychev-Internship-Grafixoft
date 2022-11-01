using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Post
    {
        public Guid PostId { get; } = Guid.NewGuid();

        public string PostTitle { get; set; } = null!;

        public string PostDescription { get; set; } = null!;

        public Guid PostAccountId { get; set; }

        public Guid? PostTopicId { get; set; }

        public Guid PostReactId { get; set; }
    }
}
