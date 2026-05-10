using LibrarySystem.Shared.Entities;
using System.Threading.Tasks;

namespace LibrarySystem.Backend.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetListAsync();
    }
}
