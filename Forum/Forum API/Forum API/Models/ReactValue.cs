using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class ReactValue
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
    }
}
