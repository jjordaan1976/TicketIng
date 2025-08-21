using Microsoft.Data.SqlClient;
using System.Data;
using TicketIng.Api.Repositories;

namespace TicketIng.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ClientRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<StatusRepository>();
            services.AddScoped<ReleaseRepository>();
            services.AddScoped<IssueRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
