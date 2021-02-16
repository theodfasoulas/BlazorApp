using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp.Shared
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; internal set; }
        public int TotalPages { get; internal set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Items { get; set; } = new List<T>();
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            Items.AddRange(items);
        }
    }
}