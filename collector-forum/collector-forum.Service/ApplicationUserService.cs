using collector_forum.Data;
using collector_forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Service
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(
                user => user.Id == id);
        }

        public Task IncrementRating(string id, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
