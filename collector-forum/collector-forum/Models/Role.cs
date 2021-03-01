using System.ComponentModel.DataAnnotations;

namespace collector_forum.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
