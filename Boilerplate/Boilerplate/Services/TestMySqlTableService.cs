using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Data;
using Boilerplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Services
{
    public class TestMySqlTableService : ITestMySqlTableService
    {
        private readonly MySqlDataContext _dataContext;

        public TestMySqlTableService(MySqlDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<MySqlTable>> GetAllAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.MySqlTable.AsQueryable();
            
            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }
            
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            
            var data = await _dataContext.MySqlTable
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            return data;
        }

        public async Task<MySqlTable> GetAsync(int id)
        {
            var data = await _dataContext.MySqlTable
                .FirstOrDefaultAsync(x=> x.Id == id);
            return data;
        }

        public async Task<bool> CreateAsync(MySqlTable data)
        {
            await _dataContext.MySqlTable.AddAsync(data);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateAsync(MySqlTable data)
        {
            _dataContext.MySqlTable.Update(data);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);

            if (item == null)
                return false;

            _dataContext.MySqlTable.Remove(item);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}