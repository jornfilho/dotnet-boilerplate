using Boilerplate.Contracts;
using Boilerplate.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Boilerplate.SwaggerExamples.Responses
{
    public class ErrorResponseExample : IExamplesProvider<ErrorResponse>
    {
        public ErrorResponse GetExamples()
        {
            var error1 = new ErrorModel
            {
                FieldName = "field name 1",
                Message = "Error 1 description"
            };
            
            var error2 = new ErrorModel
            {
                FieldName = "field name 2",
                Message = "Error 2 description"
            };

            var response = new ErrorResponse().AddError(error1).AddError(error2);
            
            return response;
        }
    }
}