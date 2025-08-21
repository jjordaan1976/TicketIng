using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class ClientRepository
    {
        private readonly IDbConnection _db;
        public ClientRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Client";
            return await _db.QueryAsync<Client>(sql);
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Client WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Client>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Client entity)
        {
            const string sql = @"
                INSERT INTO dbo.Client (Name, ContactEmail, CreatedAt)
                VALUES (@Name, @ContactEmail, SYSUTCDATETIME());
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Client entity)
        {
            const string sql = "UPDATE dbo.Client SET Name=@Name, ContactEmail=@ContactEmail WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Client WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
