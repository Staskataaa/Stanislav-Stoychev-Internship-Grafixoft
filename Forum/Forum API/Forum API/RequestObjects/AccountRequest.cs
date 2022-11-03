using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class AccountRequest
    {
        [Required]
        [StringLength(32)]
        public string AccountUsername { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string AccountPassword { get; set; } = null!;

        [Required]
        [StringLength(64)]
        public string AccountEmail { get; set; } = null!;
    }
}
