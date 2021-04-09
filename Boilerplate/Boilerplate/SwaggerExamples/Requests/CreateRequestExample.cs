using Boilerplate.Contracts;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Requests
{
    public class CreateRequestExample : IExamplesProvider<CreateRequest>
    {
        public CreateRequest GetExamples()
        {
            return new CreateRequest
            {
                Name = "Sample name",
                Email = "email@email.com"
            };
        }
    }
}