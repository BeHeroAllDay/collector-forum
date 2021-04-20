using collector_forum.Data;
using collector_forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddReply(PostReplies reply)
        {
            _context.PostReplies.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = GetById(id);
            _context.Entry(post).State = EntityState.Deleted;
            //_context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Category);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Id == id)
                .Include(post => post.Category)
                .Include(post => post.User)
                .Include(post => post.Replies)
                .ThenInclude(reply => reply.User)
                .FirstOrDefault();
        }

        public IEnumerable<Post> GetFilteredPosts(int id, string searchQuery)
        {
            var category = _context.Categories.Find(id);

            return string.IsNullOrEmpty(searchQuery) 
                ? category.Posts 
                : category.Posts.Where(post => post.Title.Contains(searchQuery)
                || post.Content.Contains(searchQuery));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            var query = searchQuery.ToLower();

            return _context.Posts
                .Include(post => post.Category)
                .Include(post => post.User)
                .Include(post => post.Replies)
                .Where(post =>
                post.Title.ToLower().Contains(query)
                || post.Content.ToLower().Contains(query));
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(n);
        }

        public IEnumerable<Post> GetPostsByCategory(int id)
        {
            return _context.Categories
                .Where(category => category.Id == id).First()
                .Posts;
        }

        public string GetCategoryImageUrl(int id)
        {
            var post = GetById(id);
            return post.Category.ImageUrl;
        }

        public int GetReplyCount(int id)
        {
            return GetById(id).Replies.Count();
        }
    }
}
