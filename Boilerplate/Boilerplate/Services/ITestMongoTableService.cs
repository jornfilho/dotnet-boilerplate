using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Domain;

namespace Boilerplate.Services
{
    public interface ITestMongoTableService
    {
        Task<List<MongoTable>> GetAllAsync(PaginationFilter paginationFilter = null);
        
        Task<MongoTable> GetAsync(string id);

        Task<bool> CreateAsync(MongoTable data);
        
        Task<bool> UpdateAsync(MongoTable data);
        
        Task<bool> DeleteAsync(string id);
    }
}