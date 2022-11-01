using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class React
    {
        public Guid ReactId { get; } = Guid.NewGuid();

        public int ReactLikes { get; set; } = 0;

        public int ReactDislikes { get; set; } = 0;

        public virtual Guid PostId { get; set; } 
    }
}
