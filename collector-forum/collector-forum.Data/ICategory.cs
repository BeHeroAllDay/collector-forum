using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface ICategory
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create (Category category);
        Task Delete (int categoryId);
        Task UpdateForumTitle(int categoryId, string newTitle);
        Task UpdateForumDescription(int categoryId, string newDescription);
    }
}
