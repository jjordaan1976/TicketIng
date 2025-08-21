using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class StatusRepository
    {
        private readonly IDbConnection _db;
        public StatusRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Status";
            return await _db.QueryAsync<Status>(sql);
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Status WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Status>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Status entity)
        {
            const string sql = @"
                INSERT INTO dbo.Status (Name, IsFinal)
                VALUES (@Name, @IsFinal);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Status entity)
        {
            const string sql = "UPDATE dbo.Status SET Name=@Name, IsFinal=@IsFinal WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Status WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
