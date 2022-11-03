using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Topic : TopicRequest
    {
        public Topic(string topicName, string topicDescription)
        {
            TopicName = topicName;
            TopicDescription = topicDescription;
        }

        public Topic()
        {
            
        }

        public Guid TopicId { get; } = Guid.NewGuid();

        public Guid? TopicOwner { get; set; }
    }
}
