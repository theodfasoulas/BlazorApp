using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class CustomerList
    {
        public int CurrentPage { get; internal set; }
        public int TotalPages { get; internal set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<CustomerViewModel> Items { get; set; }
    }
}
