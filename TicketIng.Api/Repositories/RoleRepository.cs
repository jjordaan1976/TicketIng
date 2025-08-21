using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class RoleRepository
    {
        private readonly IDbConnection _db;
        public RoleRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Role";
            return await _db.QueryAsync<Role>(sql);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Role WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Role>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Role entity)
        {
            const string sql = @"
                INSERT INTO dbo.Role (Description, CreatedAt)
                VALUES (@Description, SYSUTCDATETIME());
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Role entity)
        {
            const string sql = "UPDATE dbo.Role SET Description=@Description WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Role WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
