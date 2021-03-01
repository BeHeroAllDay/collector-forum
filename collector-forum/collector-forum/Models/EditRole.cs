using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace collector_forum.Models
{
    public class EditRole
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Enter the new Name: ")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
