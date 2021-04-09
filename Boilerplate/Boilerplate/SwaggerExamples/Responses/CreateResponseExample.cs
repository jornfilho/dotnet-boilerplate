using Boilerplate.Contracts;
using Boilerplate.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Responses
{
    public class CreateResponseExample : IExamplesProvider<TestDocumentResponse>
    {
        public TestDocumentResponse GetExamples()
        {
            return new TestDocumentResponse
            {
                Id = "A8G4)u&",
                Name = "Sample name",
                Email = "email@email.com"
            };
        }
    }
}