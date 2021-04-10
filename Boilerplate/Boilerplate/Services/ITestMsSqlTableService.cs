using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Domain;

namespace Boilerplate.Services
{
    public interface ITestMsSqlTableService
    {
        Task<List<MsSqlTable>> GetAllAsync(PaginationFilter paginationFilter = null);
        
        Task<MsSqlTable> GetAsync(int id);

        Task<bool> CreateAsync(MsSqlTable data);
        
        Task<bool> UpdateAsync(MsSqlTable data);
        
        Task<bool> DeleteAsync(int id);
    }
}