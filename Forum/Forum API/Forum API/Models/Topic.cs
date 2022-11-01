using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Topic
    {
        public Guid TopicId { get; } = Guid.NewGuid();

        public string TopicName { get; set; } = null!;

        public string TopicDescription { get; set; } = null!;

        public Guid? TopicOwner { get; set; }
    }
}
