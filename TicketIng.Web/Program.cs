using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TicketIng.Services;
using TicketIng.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure API base URL here (change to your API origin)
var apiBase = new Uri("https://localhost:7163/");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = apiBase });

// Register typed services
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<ReleaseService>();
builder.Services.AddScoped<IssueService>();

await builder.Build().RunAsync();
