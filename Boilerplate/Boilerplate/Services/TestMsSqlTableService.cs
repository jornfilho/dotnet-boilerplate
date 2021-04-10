using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Data;
using Boilerplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Services
{
    public class TestMsSqlTableService : ITestMsSqlTableService
    {
        private readonly MsSqlDataContext _dataContext;

        public TestMsSqlTableService(MsSqlDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<MsSqlTable>> GetAllAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.MsSqlTable.AsQueryable();
            
            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }
            
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            
            var data = await _dataContext.MsSqlTable
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
            return data;
        }

        public async Task<MsSqlTable> GetAsync(int id)
        {
            var data = await _dataContext.MsSqlTable
                .FirstOrDefaultAsync(x=> x.Id == id);
            return data;
        }

        public async Task<bool> CreateAsync(MsSqlTable data)
        {
            await _dataContext.MsSqlTable.AddAsync(data);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateAsync(MsSqlTable data)
        {
            _dataContext.MsSqlTable.Update(data);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);

            if (item == null)
                return false;

            _dataContext.MsSqlTable.Remove(item);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}