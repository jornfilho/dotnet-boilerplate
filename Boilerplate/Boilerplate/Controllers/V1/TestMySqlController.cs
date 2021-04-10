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
    public class TestMySqlController : Controller
    {
        private readonly ITestMySqlTableService _mySqlService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public TestMySqlController(IUriService uriService, IMapper mapper, ITestMySqlTableService mySqlService)
        {
            _uriService = uriService;
            _mapper = mapper;
            _mySqlService = mySqlService;
        }
        
        [HttpGet(ApiRoutes.TestsMySql.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tests = await _mySqlService.GetAllAsync(pagination);
            var testsResponse = _mapper.Map<List<TestMySqlDocumentResponse>>(tests);
            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, testsResponse);

            return Ok(paginationResponse);
        }
        
        [HttpGet(ApiRoutes.TestsMySql.Get)]
        public async Task<IActionResult> Get([FromRoute]int testId)
        {
            var testData = await _mySqlService.GetAsync(testId);

            if (testData == null)
                return NotFound();
            
            var testsResponse = _mapper.Map<TestMySqlDocumentResponse>(testData);

            return Ok(testsResponse);
        }
        
        [HttpPost(ApiRoutes.TestsMySql.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMySqlRequest request)
        {
            var data = _mapper.Map<MySqlTable>(request);
            await _mySqlService.CreateAsync(data);

            var locationUri = _uriService.GetNewDocumentUri(
                ApiRoutes.TestsMySql.Get, "{testId}", data.Id.ToString());

            var resultData = _mapper.Map<TestMySqlDocumentResponse>(data);
            return Created(locationUri, new Response<TestMySqlDocumentResponse>(resultData));
        }
        
        [HttpPut(ApiRoutes.TestsMySql.Update)]
        public async Task<IActionResult> Update([FromRoute]int testId, [FromBody] UpdateRequest request)
        {
            var data = await _mySqlService.GetAsync(testId);
            data.Name = request.Name;
            data.Email = request.Email;

            var updated = await _mySqlService.UpdateAsync(data);

            if (updated)
            {
                var result = _mapper.Map<TestMySqlDocumentResponse>(data);
                return Ok(new Response<TestMySqlDocumentResponse>(result));
            }

            return NotFound();
        }
        
        [HttpDelete(ApiRoutes.TestsMySql.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int testId)
        {
            var deleted = await _mySqlService.DeleteAsync(testId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}