using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class CommentRequest
    {
        [Required]
        public string CommentContent { get; set; } = null!;
    }
}
