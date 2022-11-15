using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class PostRequest
    {
        [Required]
        [StringLength(64)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;
    }
}
