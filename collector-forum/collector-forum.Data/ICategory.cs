using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
        IEnumerable<ApplicationUser> GetActiveUsers(int id);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetFilteredPosts(int categoryId, string modelSearchQuery);

        Category GetById(int id);

        Task Create(Category category);
        Task Delete(int categoryId);
        Task Edit(int id);
        bool HasRecentPost(int id);
        Post GetLatestPost(int categoryId);
    }
}
