using AES.Domains.Service;
using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Service.Mappings
{
    public static class MappingExtensions
    {


        #region Product

        public static Product ToModel(this Item entity)
        {
            return new Product
            {
                ProductId = entity.itemId,
                ProductName = entity.name,
                Price = entity.salePrice,
                ShortDescription = entity.shortDescription,
                ThumbnailUri = entity.thumbnailImage
            };
        }




        #endregion

        #region SearchResult

        public static SearchResult ToModel(this ItemSearch entity)
        {
            return new SearchResult
            {
                SearchTerm = entity.query,
                SortOrder = entity.sort,
                TotalResult = entity.totalResults,
                Index = entity.start,
                ResultSize = entity.numItems,
                SearchProducts = entity.items.Select(a => new SearchProduct()
                {
                    ProductId = a.itemId
                }).ToList()
            };
        }



        #endregion

        #region Recommendation


        public static List<Recommendation> ToListModel(this List<ItemRecommendation> entities)
        {
            return entities.Select(e => new Recommendation()
            {
                ProductId = e.itemId,
                OfferType = e.offerType,
                IsTwoDayShippingEligible = e.isTwoDayShippingEligible
            }).ToList();
        }


        #endregion


    }
}
