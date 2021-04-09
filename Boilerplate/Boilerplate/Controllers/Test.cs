using Boilerplate.Cache;
using Boilerplate.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Controllers
{
    [Produces("application/json")] //for swagger response type selector
    public class Test : Controller
    {
        /// <summary>
        /// Documentation sample
        /// </summary>
        /// <response code="200">Success on creation</response>
        /// <response code="400">Invalid request data</response>
        [HttpPost("api/v1/test")]
        [ProducesResponseType(typeof(CreateResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [Cached(600)]
        public IActionResult Index([FromBody] CreateRequest request)
        {
            var response = new CreateResponse
            {
                Id = "H7I9#02",
                Name = request.Name,
                Email = request.Email
            };
            return Ok(response);
        }
    }
}