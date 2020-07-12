using ItemAPI.Data;
using ItemAPI.Models;
using ItemAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAPI.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;
        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateItem(Item item)
        {
            _db.Items.Add(item);
            return Save();
        }

        public bool DeleteItem(Item item)
        {
            _db.Items.Remove(item);
            return Save();
        }

        public Item GetItem(int itemId)
        {
            return _db.Items.FirstOrDefault(a => a.ItemId == itemId);
        }

        public ICollection<Item> GetItems()
        {
            return _db.Items.OrderBy(a => a.Title).ToList();
        }

        public bool ItemExists(string name)
        {
            bool value = _db.Items.Any(a => a.Title.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ItemExists(int id)
        {
            return _db.Items.Any(a => a.ItemId == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateItem(Item item)
        {
            _db.Items.Update(item);
            return Save();
        }
    }
}
