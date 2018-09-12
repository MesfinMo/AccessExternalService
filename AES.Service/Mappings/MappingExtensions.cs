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
        //public static TDestination MapTo<TSource, TDestination>(this TSource source)
        //{
        //    return Mapper.Map<TSource, TDestination>(source);
        //}

        //public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        //{
        //    return Mapper.Map(source, destination);
        //}


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


        //public static Item ToEntity(this Product model)
        //{
        //    return model.MapTo<Product, Item>();
        //}


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
                Products = entity.items.Select(a => new Product()
                {
                    ProductId = a.itemId,
                    ProductName = a.name,
                    Price = a.salePrice,
                    ShortDescription = a.shortDescription,
                    ThumbnailUri = a.thumbnailImage
                }).ToList()
            };
        }


        //public static ItemSearch ToEntity(this SearchResult model)
        //{
        //    return model.MapTo<SearchResult, ItemSearch>();
        //}


        #endregion

        #region Recommendation

        //public static Recommendation ToModel(this ItemRecommendation entity)
        //{
        //    return entity.MapTo<ItemRecommendation, Recommendation>();
        //}

        public static List<Recommendation> ToListModel(this List<ItemRecommendation> entities)
        {
            return entities.Select(e => new Recommendation()
            {
                ProductId = e.itemId,
                ProductName = e.name,
                Price = e.salePrice,
                ShortDescription = e.shortDescription,
                ThumbnailUri = e.thumbnailImage,
                OfferType = e.offerType,
                IsTwoDayShippingEligible = e.isTwoDayShippingEligible
            }).ToList();
        }


        //public static ItemRecommendation ToEntity(this Recommendation model)
        //{
        //    return model.MapTo<Recommendation, ItemRecommendation>();
        //}


        #endregion


    }
}
