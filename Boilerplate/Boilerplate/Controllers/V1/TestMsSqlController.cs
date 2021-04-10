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
    public class TestMsSqlController : Controller
    {
        private readonly ITestMsSqlTableService _msSqlService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public TestMsSqlController(IUriService uriService, IMapper mapper, ITestMsSqlTableService msSqlService)
        {
            _uriService = uriService;
            _mapper = mapper;
            _msSqlService = msSqlService;
        }
        
        [HttpGet(ApiRoutes.TestsMsSql.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tests = await _msSqlService.GetAllAsync(pagination);
            var testsResponse = _mapper.Map<List<TestMsSqlDocumentResponse>>(tests);
            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, testsResponse);

            return Ok(paginationResponse);
        }
        
        [HttpGet(ApiRoutes.TestsMsSql.Get)]
        public async Task<IActionResult> Get([FromRoute]int testId)
        {
            var testData = await _msSqlService.GetAsync(testId);

            if (testData == null)
                return NotFound();
            
            var testsResponse = _mapper.Map<TestMsSqlDocumentResponse>(testData);

            return Ok(testsResponse);
        }
        
        [HttpPost(ApiRoutes.TestsMsSql.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMsSqlRequest request)
        {
            var data = _mapper.Map<MsSqlTable>(request);
            await _msSqlService.CreateAsync(data);

            var locationUri = _uriService.GetNewDocumentUri(
                ApiRoutes.TestsMsSql.Get, "{testId}", data.Id.ToString());

            var resultData = _mapper.Map<TestMsSqlDocumentResponse>(data);
            return Created(locationUri, new Response<TestMsSqlDocumentResponse>(resultData));
        }
        
        [HttpPut(ApiRoutes.TestsMsSql.Update)]
        public async Task<IActionResult> Update([FromRoute]int testId, [FromBody] UpdateRequest request)
        {
            var data = await _msSqlService.GetAsync(testId);
            data.Name = request.Name;
            data.Email = request.Email;

            var updated = await _msSqlService.UpdateAsync(data);

            if (updated)
            {
                var result = _mapper.Map<TestMsSqlDocumentResponse>(data);
                return Ok(new Response<TestMsSqlDocumentResponse>(result));
            }

            return NotFound();
        }
        
        [HttpDelete(ApiRoutes.TestsMsSql.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int testId)
        {
            var deleted = await _msSqlService.DeleteAsync(testId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}