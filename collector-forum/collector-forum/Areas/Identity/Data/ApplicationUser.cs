using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace collector_forum.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25, MinimumLength = 3)]
        public string Nickname { get; set; }
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString ="{0:DD.MMM.yyyy}")]
        public DateTime RegistrationDate { get; set; }
    }
}
