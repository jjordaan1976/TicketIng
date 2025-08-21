using System.Net.Http.Json;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http) => _http = http;

        public async Task<List<Category>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Category>>("api/categories");

        public async Task<Category> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Category>($"api/categories/{'{'}id{'}'}");

        public async Task<Category> CreateAsync(Category item)
        {
            var resp = await _http.PostAsJsonAsync("api/categories", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Category>();
        }

        public async Task UpdateAsync(int id, Category item)
        {
            var resp = await _http.PutAsJsonAsync($"api/categories/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/categories/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
