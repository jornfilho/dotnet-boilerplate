namespace Boilerplate.Contracts.V1.Requests.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = DefaultPageNumber;
            PageSize = DefaultPageSize;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        private const int DefaultPageSize = 100;
        private const int DefaultPageNumber = 1;

        public int GetDefaultPageSize()
        {
            return DefaultPageSize;
        }
        
        public int GetDefaultPageNumber()
        {
            return DefaultPageNumber;
        }
    }
}