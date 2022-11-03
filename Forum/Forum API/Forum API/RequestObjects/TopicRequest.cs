using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class TopicRequest
    {
        [Required]
        [StringLength(64)]
        public string TopicName { get; set; } = null!;

        [Required]
        public string TopicDescription { get; set; } = null!;

    }
}
