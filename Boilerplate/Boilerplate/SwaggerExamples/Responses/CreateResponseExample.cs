using Boilerplate.Contracts;
using Boilerplate.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Responses
{
    public class CreateResponseExample : IExamplesProvider<CreateResponse>
    {
        public CreateResponse GetExamples()
        {
            return new CreateResponse
            {
                Id = "A8G4)u&",
                Name = "Sample name",
                Email = "email@email.com"
            };
        }
    }
}