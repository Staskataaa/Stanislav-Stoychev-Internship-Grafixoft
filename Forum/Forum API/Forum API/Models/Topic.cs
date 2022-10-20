using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Posts = new HashSet<Post>();
        }

        public Guid Id { get; set; }
        public string TopicName { get; set; } = null!;
        public string TopicDescription { get; set; } = null!;
        public Guid? TopicOwner { get; set; }

        public virtual Account? TopicOwnerNavigation { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
