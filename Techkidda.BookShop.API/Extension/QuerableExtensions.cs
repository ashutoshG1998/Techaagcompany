using Techkidda.BookShop.API.DTOs;

namespace Techkidda.BookShop.API.Extension
{
    public static class QuerableExtensions
    {
        public static IQueryable<T> ToPaging<T>(this IQueryable<T> querable,PaginationDto paginationDto)
        {
            return querable.Skip((paginationDto.page - 1) * paginationDto.RecordPerPage)
                .Take(paginationDto.RecordPerPage);
        }
    }
}
