using System.Linq.Expressions;
using LibrarySystem.Shared.Entities;

namespace LibrarySystem.Backend.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetLisAsync();
        Task<Book> GetAsync(Expression<Func<Book, bool>> filtro = null);
        Task<IQueryable<Book>> CheckAsync(Expression<Func<Book, bool>> filtro = null);
        Task<Book> CreateAsync(Book bookENT);
        Task<bool> UpdateAsync(Book bookENT);
        Task<bool> DeleteAsync(Book bookENT );
      
    }
}