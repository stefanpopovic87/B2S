namespace B2S.Infrastructure.Pagination
{
    public class PaginationFilter
    {
        public PaginationFilter()
        {
            Page = 1;
            PageSize = 10;
        }

        public PaginationFilter(int page, int pageSize)
        {
            Page = page < 1 ? 1 : page;
            PageSize = pageSize < 5 ? 5 : pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}