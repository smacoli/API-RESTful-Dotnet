using AutoMapper;
using Supermarket.Domain.Models;
using Supermarket.Resources;
using Supermarket.Domain.Models.Querys;

namespace Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile() 
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<ProductsQueryResource, ProductsQuery>();
        }
    }
}
