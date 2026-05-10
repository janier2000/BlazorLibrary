using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;
using System.Linq.Expressions;

namespace LibrarySystem.Frontend.Services.Interface
{
    public interface IBookServices
    {
        Task<ResponseDTO<Book>> CreateAsync(Book bookENT);
        Task<bool> UpdateAsync(Book bookENT);
        Task<bool> DeleteAsync(int id);
        Task<ResponseDTO<List<Book>>> GetFullList();
        Task<ResponseDTO<Book>> GetAsync(int id);
        Task<ResponseDTO<List<Book>>> CheckAsync(string value);

    }
}
