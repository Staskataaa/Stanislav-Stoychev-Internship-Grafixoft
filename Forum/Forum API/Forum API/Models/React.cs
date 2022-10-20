using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class React
    {
        public React()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid Id { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }

        public virtual Post? Post { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
