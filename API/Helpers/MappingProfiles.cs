using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            // ^ Set ProductBrand and ProductType in Dto as ProductBrand.Name and ProductType.Name from Product object
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            // ^ resolving PictureUrl in ProductToReturnDto the way we created our ProductUrlResolver (adding localhost:5001/ before path)
            
        }
    }
}