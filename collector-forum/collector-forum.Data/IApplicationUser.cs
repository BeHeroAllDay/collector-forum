using collector_forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task SetProfileImage(string id, Uri uri);
        Task IncrementRating(string id, Type type);
    }
}
