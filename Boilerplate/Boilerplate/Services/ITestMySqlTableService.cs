using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Domain;

namespace Boilerplate.Services
{
    public interface ITestMySqlTableService
    {
        Task<List<MySqlTable>> GetAllAsync(PaginationFilter paginationFilter = null);
        
        Task<MySqlTable> GetAsync(int id);

        Task<bool> CreateAsync(MySqlTable data);
        
        Task<bool> UpdateAsync(MySqlTable data);
        
        Task<bool> DeleteAsync(int id);
    }
}