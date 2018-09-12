using AES.Data.DataSources;
using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.Repositories
{
    public class SearchRepository : IRepository<ItemSearch>
    {
        private readonly IServiceContext _serviceContext;
        public SearchRepository(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public virtual Task<ItemSearch> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<ItemSearch>> GetItemsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ItemSearch> SearchByTextAsync(string text)
        {
            var result = await this._serviceContext.SearchItemByTextAsync(text);
            return result;
        }

        public void Insert(ItemSearch entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<ItemSearch> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemSearch entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<ItemSearch> entities)
        {
            throw new NotImplementedException();
        }
        public void Delete(ItemSearch entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ItemSearch> entities)
        {
            throw new NotImplementedException();
        }
        public IQueryable<ItemSearch> Table => throw new NotImplementedException();

    }
}
