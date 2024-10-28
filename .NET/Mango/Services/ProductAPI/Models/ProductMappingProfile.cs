using AutoMapper;
using ProductAPI.DTO;

namespace ProductAPI.Models
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<Product,ProductDTO>();
            CreateMap<ProductDTO,Product>();
        }
    }
}
