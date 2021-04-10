using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    public class TestMongoController : Controller
    {
        private readonly ITestMongoTableService _mongoService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public TestMongoController(IUriService uriService, IMapper mapper, ITestMongoTableService mongoService)
        {
            _uriService = uriService;
            _mapper = mapper;
            _mongoService = mongoService;
        }
        
        [HttpGet(ApiRoutes.TestsMongo.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tests = await _mongoService.GetAllAsync(pagination);
            var testsResponse = _mapper.Map<List<TestMongoDocumentResponse>>(tests);
            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, testsResponse);

            return Ok(paginationResponse);
        }
        
        [HttpGet(ApiRoutes.TestsMongo.Get)]
        public async Task<IActionResult> Get([FromRoute]string testId)
        {
            var testData = await _mongoService.GetAsync(testId);

            if (testData == null)
                return NotFound();
            
            var testsResponse = _mapper.Map<TestMongoDocumentResponse>(testData);

            return Ok(testsResponse);
        }
        
        [HttpPost(ApiRoutes.TestsMongo.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMongoRequest request)
        {
            var data = _mapper.Map<MongoTable>(request);
            await _mongoService.CreateAsync(data);

            var locationUri = _uriService.GetNewDocumentUri(
                ApiRoutes.TestsMongo.Get, "{testId}", data.Id.ToString());

            var resultData = _mapper.Map<TestMongoDocumentResponse>(data);
            return Created(locationUri, new Response<TestMongoDocumentResponse>(resultData));
        }
        
        [HttpPut(ApiRoutes.TestsMongo.Update)]
        public async Task<IActionResult> Update([FromRoute]string testId, [FromBody] UpdateRequest request)
        {
            var data = await _mongoService.GetAsync(testId);
            if (data == null)
                return NotFound();

            data.Name = request.Name;
            data.Email = request.Email;

            var updated = await _mongoService.UpdateAsync(data);

            if (!updated)
                return NotFound();
            
            var result = _mapper.Map<TestMongoDocumentResponse>(data);
            return Ok(new Response<TestMongoDocumentResponse>(result));
        }
        
        [HttpDelete(ApiRoutes.TestsMongo.Delete)]
        public async Task<IActionResult> Delete([FromRoute]string testId)
        {
            var deleted = await _mongoService.DeleteAsync(testId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}