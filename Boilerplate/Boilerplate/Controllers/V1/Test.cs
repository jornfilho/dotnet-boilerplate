using Boilerplate.Cache;
using Boilerplate.Contracts.V1;
using Boilerplate.Contracts.V1.Requests;
using Boilerplate.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Controllers.V1
{
    [Produces("application/json")] //for swagger response type selector
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public class Test : Controller
    {
        [HttpGet(ApiRoutes.Tests.GetAll)]
        [Cached(15)]
        public IActionResult GetAll()
        {
            return Ok();
        }
        
        [HttpGet(ApiRoutes.Tests.Get)]
        [Cached(600)]
        public IActionResult Get([FromRoute]string testId)
        {
            return Ok();
        }
        
        /// <summary>
        /// Documentation sample
        /// </summary>
        /// <response code="200">Success on creation</response>
        /// <response code="400">Invalid request data</response>
        [HttpPost(ApiRoutes.Tests.Create)]
        [ProducesResponseType(typeof(CreateResponse), 200)]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            var response = new CreateResponse
            {
                Id = "H7I9#02",
                Name = request.Name,
                Email = request.Email
            };
            return Ok(response);
        }
        
        [HttpPut(ApiRoutes.Tests.Update)]
        public IActionResult Update([FromRoute]string testId, [FromBody] UpdateRequest request)
        {
            return Ok();
        }
        
        [HttpDelete(ApiRoutes.Tests.Delete)]
        public IActionResult Delete([FromRoute]string testId)
        {
            return Ok();
        }
    }
}