using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;

namespace LibrarySystem.Frontend.Services.Interface
{
    public interface ICategoryServices
    {
        Task<ResponseDTO<List<Category>>> GetList();
    }
}
