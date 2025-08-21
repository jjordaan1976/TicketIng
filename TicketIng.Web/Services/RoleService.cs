using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class RoleService
    {
        private readonly HttpClient _http;
        public RoleService(HttpClient http) => _http = http;

        public async Task<List<Role>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Role>>("api/roles");

        public async Task<Role> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Role>($"api/roles/{'{'}id{'}'}");

        public async Task<Role> CreateAsync(Role item)
        {
            var resp = await _http.PostAsJsonAsync("api/roles", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Role>();
        }

        public async Task UpdateAsync(int id, Role item)
        {
            var resp = await _http.PutAsJsonAsync($"api/roles/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/roles/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
