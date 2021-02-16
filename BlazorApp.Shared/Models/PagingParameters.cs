namespace BlazorApp.Shared
{
    public class PagingParameters
    {
        const int maxPageSize = 10;

        private int pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize ? maxPageSize : value);
            }
        }
    }
}