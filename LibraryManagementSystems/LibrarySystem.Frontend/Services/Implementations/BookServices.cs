using System.Net.Http.Json;
using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;
using LibrarySystem.Frontend.Services.Interface;

namespace LibrarySystem.Frontend.Services.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient _http;
        public BookServices(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<Book>> CreateAsync(Book bookENT)
        {
            var result = await _http.PostAsJsonAsync("api/Book/Create", bookENT);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<Book>>();
            return response!;
        }
        public async Task<bool> UpdateAsync(Book bookENT)
        {
            var result = await _http.PutAsJsonAsync("api/Book/Edit", bookENT);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<Book>>();
            return response!.status;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _http.DeleteAsync($"api/Book/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }
        public async Task<ResponseDTO<List<Book>>> GetFullList()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<Book>>>("api/Book/GetFullList");
            return result!;
        }
        public async Task<ResponseDTO<Book>> GetAsync(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<Book>>($"api/Book/Get/{id}");
            return result!;
        }
        public async Task<ResponseDTO<List<Book>>> CheckAsync(string value)
        {
            var result = await _http
                .GetFromJsonAsync<ResponseDTO<List<Book>>>($"api/Book/Check?value={value}");
            return result!;

        }
    }
}
