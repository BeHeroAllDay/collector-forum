using collector_forum.Data;
using collector_forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Service
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Category categories)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                .Include(categories => categories.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new System.NotImplementedException();
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id)
                .Include(c => c.Posts).ThenInclude(p => p.User)
                .Include(c => c.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();
            return category;
        }

        public Task UpdateForumDescription(int categoryId, string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumTitle(int categoryId, string newTitle)
        {
            throw new System.NotImplementedException();
        }
    }
}
