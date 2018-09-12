using AES.Data.DataSources;
using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly IServiceContext _serviceContext;

        public ItemRepository(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
        public virtual async Task<Item> GetByIdAsync(int id)
        {
            var result = await this._serviceContext.GetItemByItemIdAsync(id);
            return result.FirstOrDefault();
        }

        public virtual Task<List<Item>> GetItemsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> SearchByTextAsync(string text)
        {
            throw new NotImplementedException();
        }
        public void Insert(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }
        public void Delete(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<Item> entities)
        {
            throw new NotImplementedException();
        }

       

        public IQueryable<Item> Table => throw new NotImplementedException();

    }
}
