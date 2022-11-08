using System;
using System.Collections.Generic;

namespace Forum_API.Models
{
    public partial class ReactValue
    {
        public Guid ReactValueId { get; set; }
        public string ReactDescription { get; set; } = null!;
    }
}
