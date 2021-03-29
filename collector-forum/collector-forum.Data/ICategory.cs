using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface ICategory
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();

        Task Create (Category category);
        Task Delete (int categoryId);
        Task UpdateCategoryTitle(int categoryId, string newTitle);
        Task UpdateCategoryDescription(int categoryId, string newDescription);
        IEnumerable<ApplicationUser> GetActiveUsers(int id);
        bool HasRecentPost(int id);
    }
}
