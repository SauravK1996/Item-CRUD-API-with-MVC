using ItemCRUDWeb.Models;
using ItemCRUDWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItemCRUDWeb.Repository
{
    public class ItemRepository : Repository<Item>,IItemRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public ItemRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
