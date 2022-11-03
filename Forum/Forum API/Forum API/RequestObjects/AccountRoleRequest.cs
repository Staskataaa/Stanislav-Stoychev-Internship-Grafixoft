using System.ComponentModel.DataAnnotations;

namespace Forum_API.RequestObjects
{
    public class AccountRoleRequest
    {

        [Required]
        [Range(1, 10)]
        public int RolePriority { get; set; }


        [Required]
        [StringLength(32)]
        public string RoleDescription { get; set; } = null!;

    }
}
