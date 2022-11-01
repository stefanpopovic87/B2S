using B2S.Infrastructure.Pagination;

namespace B2S.Contract.Courses
{
    public class SearchCourseDto : PaginationFilter
    {
        public string Term { get; set; }
    }
}
