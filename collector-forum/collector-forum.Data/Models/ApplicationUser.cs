using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace collector_forum.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25, MinimumLength = 3)]
        public string Nickname { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{0:DD.MMM.yyyy}")]
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Rating { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
