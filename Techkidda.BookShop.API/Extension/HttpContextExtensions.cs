using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Techkidda.BookShop.API.Extension
{
    public static class HttpContextExtensions
    {
        public async static Task SetResponseHeader<T>(this HttpContext httpContext, IQueryable<T> querable)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(HttpContext));
            }

            int count = await querable.CountAsync();
            httpContext.Response.Headers.Add("Total Amount of record", count.ToString());
        }
    }
}
