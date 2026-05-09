using System.Linq.Expressions;
using LibrarySystem.Backend.Data;
using LibrarySystem.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Backend.Repositories.Interface;

namespace LibrarySystem.Backend.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetLisAsync()
        {
            try
            {
                return await _context.books.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Book> GetAsync(Expression<Func<Book, bool>> filtro = null)
        {
            try
            {
                return await _context.books.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<Book>> CheckAsync(Expression<Func<Book, bool>> filtro = null)
        {
            IQueryable<Book> queryEntidad = filtro == null ? _context.books : _context.books.Where(filtro);
            return queryEntidad;
        }

        public async Task<Book> CreateAsync(Book bookENT)
        {
            try
            {
                _context.Set<Book>().Add(bookENT);
                await _context.SaveChangesAsync();
                return bookENT;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Book bookENT)
        {
            try
            {
                _context.Set<Book>().Update(bookENT);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(Book bookENT)
        {
            try
            {
                _context.books.Remove(bookENT);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

       
   
    }
}