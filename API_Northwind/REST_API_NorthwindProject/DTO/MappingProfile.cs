using AutoMapper;
using REST_API_NorthwindProject.Models;

namespace REST_API_NorthwindProject.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
