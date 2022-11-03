using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class PostRequest
    {
        [Required]
        [StringLength(64)]
        public string PostTitle { get; set; } = null!;

        [Required]
        public string PostDescription { get; set; } = null!;
    }
}
