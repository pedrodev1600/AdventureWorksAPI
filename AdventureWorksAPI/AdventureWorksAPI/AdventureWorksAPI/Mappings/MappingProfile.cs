using AdventureWorksAPI.Models;
using AdventureWorksAPI.Models.ViewModels;
using AutoMapper;
namespace AdventureWorksAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalesOrderHeader, SalesListItem>()
                .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => Enum.IsDefined(typeof(SalesOrderStatus), src.Status) ? (SalesOrderStatus)src.Status : SalesOrderStatus.InProcess));

            CreateMap<ProductListItem, Product>();

            CreateMap<Product, ProductListItem>();

            CreateMap<Product, ProductItem>();

            CreateMap<ProductItem, Product>();

        }
    }
}
