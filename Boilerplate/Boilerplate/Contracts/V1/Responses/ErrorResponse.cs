using System.Collections.Generic;

namespace Boilerplate.Contracts.V1.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }
        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public ErrorResponse AddError(ErrorModel error)
        {
            Errors.Add(error);
            return this;
        }
    }
}