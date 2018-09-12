using AES.Domains.Service;
using AES.Domains.WalmartApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES.Service.Mappings
{
    //TODO : uncomment this code for automapper


    //public class MappingProfile : Profile
    //{

    //    public MappingProfile()
    //    {
    //        CreateMap<Item, Product>()
    //            .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.itemId))
    //            .ForMember(dest => dest.ProductName, opts => opts.MapFrom(src => src.name))
    //            .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.salePrice))
    //            .ForMember(dest => dest.ShortDescription, opts => opts.MapFrom(src => src.shortDescription))
    //            .ForMember(dest => dest.ThumbnailUri, opts => opts.MapFrom(src => src.thumbnailImage))
    //            .ReverseMap();


    //        CreateMap<ItemSearch, SearchResult>()
    //            .ForMember(dest => dest.SearchTerm, opts => opts.MapFrom(src => src.query))
    //            .ForMember(dest => dest.SortOrder, opts => opts.MapFrom(src => src.sort))
    //            .ForMember(dest => dest.TotalResult, opts => opts.MapFrom(src => src.totalResults))
    //            .ForMember(dest => dest.Index, opts => opts.MapFrom(src => src.start))
    //            .ForMember(dest => dest.ResultSize, opts => opts.MapFrom(src => src.numItems))
    //            .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src.items))
    //            .ReverseMap();

    //        CreateMap<ItemRecommendation, Recommendation>()
    //            .IncludeBase<Item, Product>()
    //            .ForMember(dest => dest.OfferType, opts => opts.MapFrom(src => src.offerType))
    //            .ForMember(dest => dest.IsTwoDayShippingEligible, opts => opts.MapFrom(src => src.isTwoDayShippingEligible))
    //            .ReverseMap();
    //    }
       
    //}
}
