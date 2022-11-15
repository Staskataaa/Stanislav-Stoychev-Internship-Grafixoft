using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class React
    {
        public Guid Id { get; }

        public Guid ValueId { get; set; }

        public Guid AccountId { get; set; }

        public Guid PostId { get; set; }

        public Guid CommentId { get; set; }
    }
}
