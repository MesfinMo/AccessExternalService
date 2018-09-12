using AES.Data.DataSources;
using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Data.Repositories
{
    public class RecommendationRepository : IRepository<ItemRecommendation>
    {
        private readonly IServiceContext _serviceContext;
        public RecommendationRepository(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
       

        public virtual Task<ItemRecommendation> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<ItemRecommendation>> GetItemsByIdAsync(int id)
        {
            var result = await this._serviceContext.GetItemRecommendationByItemIdAsync(id);
            return result;
        }

        public virtual  Task<ItemRecommendation> SearchByTextAsync(string text)
        {
            throw new NotImplementedException();
        }

        public void Insert(ItemRecommendation entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<ItemRecommendation> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemRecommendation entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<ItemRecommendation> entities)
        {
            throw new NotImplementedException();
        }
        public void Delete(ItemRecommendation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<ItemRecommendation> entities)
        {
            throw new NotImplementedException();
        }
        public IQueryable<ItemRecommendation> Table => throw new NotImplementedException();

    }
}
