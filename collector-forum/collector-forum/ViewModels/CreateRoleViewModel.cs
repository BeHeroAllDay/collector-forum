using System.ComponentModel.DataAnnotations;

namespace collector_forum.ViewModels
{
    public class CreateRoleViewModel
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}