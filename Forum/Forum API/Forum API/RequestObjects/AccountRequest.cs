using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class AccountRequest
    {
        [Required]
        [StringLength(32)]
        public string Username { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(64)]
        public string Email { get; set; } = null!;
    }
}
