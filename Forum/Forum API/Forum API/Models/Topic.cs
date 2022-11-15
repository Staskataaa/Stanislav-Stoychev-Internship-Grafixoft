using Forum_API.RequestObjects;
using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class Topic : TopicRequest
    {
        public Topic(string topicName, string topicDescription)
        {
            Name = topicName;
            Description = topicDescription;
        }

        public Topic()
        {
        }

        public Guid Id { get; }

        public Guid? Owner { get; set; }
    }
}
