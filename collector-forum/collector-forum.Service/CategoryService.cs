using collector_forum.Data;
using collector_forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int categoryId)
        {
            var category = GetById(categoryId);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers(int id)
        {
            var posts = GetById(id).Posts;

            if (posts != null || !posts.Any())
            {
                var postUsers = posts.Select(p => p.User);
                var replyUsers = posts.SelectMany(p => p.Replies).Select(r => r.User);

                return postUsers.Union(replyUsers).Distinct();
            }

            return new List<ApplicationUser>();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                .Include(categories => categories.Posts);
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Where(c => c.Id == id)
                .Include(c => c.Posts).ThenInclude(p => p.User)
                .Include(c => c.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();
            return category;
        }

        public bool HasRecentPost(int id)
        {
            const int hoursAgo = 12;
            var window = DateTime.Now.AddHours(-hoursAgo);
            return GetById(id).Posts.Any(post => post.Created > window);
        }

        public Task UpdateCategoryDescription(int categoryId, string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCategoryTitle(int categoryId, string newTitle)
        {
            throw new System.NotImplementedException();
        }
    }
}
