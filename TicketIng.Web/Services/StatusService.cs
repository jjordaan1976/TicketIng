using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class StatusService
    {
        private readonly HttpClient _http;
        public StatusService(HttpClient http) => _http = http;

        public async Task<List<Status>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Status>>("api/statuses");

        public async Task<Status> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Status>($"api/statuses/{'{'}id{'}'}");

        public async Task<Status> CreateAsync(Status item)
        {
            var resp = await _http.PostAsJsonAsync("api/statuses", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Status>();
        }

        public async Task UpdateAsync(int id, Status item)
        {
            var resp = await _http.PutAsJsonAsync($"api/statuses/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/statuses/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
