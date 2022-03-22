﻿namespace Nxm.Conan.Users.Application.Responses
{
    public class PagedResponse<T>
    {

        public PagedResponse()
        {

        }

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public int? TotalCount { get; set; }

        public int? TotalPages { get; set; }

        public bool NextPage { get; set; }

        public bool PreviousPage { get; set; }

        public IEnumerable<T> Data { get; set; }

    }
}
