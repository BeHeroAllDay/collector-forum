using collector_forum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace collector_forum.Data
{
    public interface IItem
    {
        Item GetById(int id);
        IEnumerable<Item> GetAll();

        Task Add(Item item);
        Task Delete(int id);
        Task Update(Item item);
    }
}
