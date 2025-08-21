using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class ReleaseService
    {
        private readonly HttpClient _http;
        public ReleaseService(HttpClient http) => _http = http;

        public async Task<List<Release>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Release>>("api/releases");

        public async Task<Release> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Release>($"api/releases/{'{'}id{'}'}");

        public async Task<Release> CreateAsync(Release item)
        {
            var resp = await _http.PostAsJsonAsync("api/releases", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Release>();
        }

        public async Task UpdateAsync(int id, Release item)
        {
            var resp = await _http.PutAsJsonAsync($"api/releases/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/releases/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
