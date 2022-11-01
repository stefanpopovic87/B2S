using B2S.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;

namespace B2S.Infrastructure.EntityFrameworkCore
{
    public static class IQueryableExtensions
    {
        public static async Task<PagedResult<T>> GetPagedResultAsync<T>(
            this IQueryable<T> query,
            int? page,
            int? pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = !page.HasValue || page.Value == 0 ? 1 : page.Value;
            result.PageSize = pageSize ?? int.MaxValue;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / result.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.Results = await query.Skip(skip).Take(result.PageSize).ToListAsync();

            return result;
        }
    }
}