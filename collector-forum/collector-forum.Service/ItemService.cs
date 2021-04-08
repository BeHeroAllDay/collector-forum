using collector_forum.Data;
using collector_forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collector_forum.Service
{
    public class ItemService : IItem
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = GetById(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        public Item GetById(int id)
        {
            return _context.Items.Where(item => item.Id == id)
                 .Include(item => item.User)
                 .FirstOrDefault();
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items
                .Include(item => item.User);
        }
    }
}
