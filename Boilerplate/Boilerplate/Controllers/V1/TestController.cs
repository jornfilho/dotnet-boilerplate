using System.Collections.Generic;
using AutoMapper;
using Boilerplate.Cache;
using Boilerplate.Contracts.V1;
using Boilerplate.Contracts.V1.Requests;
using Boilerplate.Contracts.V1.Requests.Queries;
using Boilerplate.Contracts.V1.Responses;
using Boilerplate.Domain;
using Boilerplate.Helpers;
using Boilerplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Controllers.V1
{
    [Produces("application/json")] //for swagger response type selector
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    public class Test : Controller
    {
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public Test(IUriService uriService, IMapper mapper)
        {
            _uriService = uriService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Documentation sample
        /// </summary>
        [HttpGet(ApiRoutes.Tests.GetAll)]
        [ProducesResponseType(typeof(PagedResponse<List<TestDocumentResponse>>), 200)]
        [Cached(15)]
        public IActionResult GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);

            var result = new List<TestDocumentResponse>();
            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, result);

            return Ok(paginationResponse);
        }
        
        /// <summary>
        /// Documentation sample
        /// </summary>
        /// <response code="201">Success on creation</response>
        [HttpPost(ApiRoutes.Tests.Create)]
        [ProducesResponseType(typeof(TestDocumentResponse), 201)]
        public IActionResult Create([FromBody] CreateRequest request)
        {
            var id = "H7I9#02";
            var response = new TestDocumentResponse
            {
                Id = id,
                Name = request.Name,
                Email = request.Email
            };

            var locationUri = _uriService.GetNewDocumentUri(ApiRoutes.Tests.Get, "{testId}", id);
            var result = new Response<TestDocumentResponse>(_mapper.Map<TestDocumentResponse>(response));
            
            return Created(locationUri, result);
        }
    }
}