using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(Category category, string searchQuery);
        IEnumerable<Post> GetPostsByCategory(int id);
        IEnumerable<Post> GetLatestPosts(int n);


        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
    }
}
