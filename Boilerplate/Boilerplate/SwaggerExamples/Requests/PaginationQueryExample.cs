using Boilerplate.Contracts.V1.Requests.Queries;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Requests
{
    public class PaginationQueryExample : IExamplesProvider<PaginationQuery>
    {
        public PaginationQuery GetExamples()
        {
            return new PaginationQuery
            {
                PageNumber = 1,
                PageSize = 2
            };
        }
    }
}