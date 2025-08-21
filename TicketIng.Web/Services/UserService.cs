using System.Net.Http.Json;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http) => _http = http;

        public async Task<List<User>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<User>>("api/users");

        public async Task<User> GetAsync(int id) =>
            await _http.GetFromJsonAsync<User>($"api/users/{'{'}id{'}'}");

        public async Task<User> CreateAsync(User item)
        {
            var resp = await _http.PostAsJsonAsync("api/users", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<User>();
        }

        public async Task UpdateAsync(int id, User item)
        {
            var resp = await _http.PutAsJsonAsync($"api/users/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/users/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
