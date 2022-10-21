using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class React
    {
        public Guid ReactId { get; set; }
        public int ReactLikes { get; set; }
        public int ReactDislikes { get; set; }

        public virtual Post? Post { get; set; }
    }
}
