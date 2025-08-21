using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class IssueService
    {
        private readonly HttpClient _http;
        public IssueService(HttpClient http) => _http = http;

        public async Task<List<Issue>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Issue>>("api/issues");

        public async Task<Issue> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Issue>($"api/issues/{'{'}id{'}'}");

        public async Task<Issue> CreateAsync(Issue item)
        {
            var resp = await _http.PostAsJsonAsync("api/issues", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Issue>();
        }

        public async Task UpdateAsync(int id, Issue item)
        {
            var resp = await _http.PutAsJsonAsync($"api/issues/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/issues/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
