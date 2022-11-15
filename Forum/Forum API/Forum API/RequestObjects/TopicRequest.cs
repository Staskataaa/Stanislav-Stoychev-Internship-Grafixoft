using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class TopicRequest
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
