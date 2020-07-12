using ItemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAPI.Repository.IRepository
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
        Item GetItem(int itemId);
        bool ItemExists(string name);
        bool ItemExists(int id);
        bool CreateItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(Item item);
        bool Save();
    }
}
