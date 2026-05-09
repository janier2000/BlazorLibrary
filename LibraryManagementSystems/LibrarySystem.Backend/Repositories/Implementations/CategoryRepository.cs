using LibrarySystem.Backend.Data;
using LibrarySystem.Backend.Repositories.Interface;
using LibrarySystem.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Backend.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<List<Category>> GetList()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
