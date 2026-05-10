using System.Net.Http.Json;
using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;
using LibrarySystem.Frontend.Services.Interface;

namespace LibrarySystem.Frontend.Services.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        private readonly HttpClient _http;
        public CategoryServices(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<Category>>> GetList()
        {
            var result = await _http
                .GetFromJsonAsync<ResponseDTO<List<Category>>>("api/Category/GetList");
            return result!;
        }
    }
}