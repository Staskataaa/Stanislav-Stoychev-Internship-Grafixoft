using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class React
    {
        public Guid ReactId { get; }

        public Guid ReactValueId { get; set; }

        public Guid ReactAccountId { get; set; }

        public Guid ReactPostId { get; set; }

        public Guid ReactCommentId { get; set; }
    }
}
