using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class ReleaseRepository
    {
        private readonly IDbConnection _db;
        public ReleaseRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Release>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Release";
            return await _db.QueryAsync<Release>(sql);
        }

        public async Task<Release> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Release WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Release>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Release entity)
        {
            const string sql = @"
                INSERT INTO dbo.Release (Version, ReleaseDate, Notes)
                VALUES (@Version, @ReleaseDate, @Notes);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Release entity)
        {
            const string sql = "UPDATE dbo.Release SET Version=@Version, ReleaseDate=@ReleaseDate, Notes=@Notes WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Release WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
