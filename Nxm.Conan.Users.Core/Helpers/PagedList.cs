using Nxm.Conan.Users.Application.Responses;

namespace Nxm.Conan.Users.Core.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            AddRange(items);
        }
        public static PagedResponse<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PagedResponse<T>()
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = source.Count(),
                TotalPages = source.Count() / pageSize,
                NextPage = source.Count() / pageSize > pageNumber,
                PreviousPage = 1 < pageNumber,
                Data = new PagedList<T>(items, count, pageNumber, pageSize)
            };
        }
    }
}
