using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketIng.Models;

namespace TicketIng.Services
{
    public class ClientService
    {
        private readonly HttpClient _http;
        public ClientService(HttpClient http) => _http = http;

        public async Task<List<Client>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Client>>("api/clients");

        public async Task<Client> GetAsync(int id) =>
            await _http.GetFromJsonAsync<Client>($"api/clients/{'{'}id{'}'}");

        public async Task<Client> CreateAsync(Client item)
        {
            var resp = await _http.PostAsJsonAsync("api/clients", item);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<Client>();
        }

        public async Task UpdateAsync(int id, Client item)
        {
            var resp = await _http.PutAsJsonAsync($"api/clients/{'{'}id{'}'}", item);
            resp.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/clients/{'{'}id{'}'}");
            resp.EnsureSuccessStatusCode();
        }
    }
}
