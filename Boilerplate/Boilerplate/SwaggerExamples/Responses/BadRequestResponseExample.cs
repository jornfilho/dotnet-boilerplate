using Boilerplate.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Responses
{
    public class BadRequestResponseExample : IExamplesProvider<BadRequestResponse>
    {
        public BadRequestResponse GetExamples()
        {
            return new BadRequestResponse
            {
                ErrorName = "Error name",
                ErrorDescription = "Error description message"
            };
        }
    }
}