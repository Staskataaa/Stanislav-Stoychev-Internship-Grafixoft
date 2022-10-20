using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public Guid? AccountId { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? ReactId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual React? React { get; set; }
        public virtual Topic? Topic { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
