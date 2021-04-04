using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(int id, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByCategory(int id);
        IEnumerable<Post> GetLatestPosts(int n);


        Task Add(Post post);
        Task Delete(int id);
        void UpdateP(Post post);

        Task AddReply(PostReply reply);
    }
}
