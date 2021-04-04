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
        private readonly IPost _postService;

        public CategoryService(ApplicationDbContext context, IPost postService)
        {
            _context = context;
            _postService = postService;
        }

        public async Task Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = GetById(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public Task Edit(int id)
        {
            throw new NotImplementedException();
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
                .Include(category => category.Posts);
        }

        public Category GetById(int id)
        {
            var category = _context.Categories
                .Where(c => c.Id == id)
                .Include(c => c.Posts)
                .ThenInclude(c => c.User)
                .Include(c => c.Posts)
                .ThenInclude(c => c.Replies)
                .ThenInclude(r => r.User)
                .FirstOrDefault();

            if (category.Posts == null)
            {
                category.Posts = new List<Post>();
            }

            return category;
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            return _postService.GetFilteredPosts(searchQuery);
        }

        public IEnumerable<Post> GetFilteredPosts(int categoryId, string searchQuery)
        {
            if (categoryId == 0) return _postService.GetFilteredPosts(searchQuery);

            var category = GetById(categoryId);

            return string.IsNullOrEmpty(searchQuery)
                ? category.Posts
                : category.Posts.Where(post
                    => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
        }

        public Post GetLatestPost(int categoryId)
        {
            var posts = GetById(categoryId).Posts;

            if(posts != null)
            {
                return GetById(categoryId).Posts
                    .OrderByDescending(post => post.Created)
                    .FirstOrDefault();
            }

            return new Post();
        }

        public bool HasRecentPost(int id)
        {
            const int hoursAgo = 2;
            var window = DateTime.Now.AddHours(-hoursAgo);
            return GetById(id).Posts.Any(post => post.Created > window);
        }
    }
}
