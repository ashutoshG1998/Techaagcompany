using AutoMapper;
using Techkidda.BookShop.API.DTOs;
using Techkidda.BookShop.API.Entities;

namespace Techkidda.BookShop.API.Mappers
{
    public class BookShopMapper:Profile
    {
        public BookShopMapper() 
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreationDTO, Category>();
                
                
                }
    }
}
