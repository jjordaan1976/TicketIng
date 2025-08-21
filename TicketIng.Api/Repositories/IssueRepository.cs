using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class IssueRepository
    {
        private readonly IDbConnection _db;
        public IssueRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.Issue";
            return await _db.QueryAsync<Issue>(sql);
        }

        public async Task<Issue> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.Issue WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<Issue>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(Issue entity)
        {
            const string sql = @"
                INSERT INTO dbo.Issue (Title, Description, CreatedByUserId, AssignedToUserId, ClientId, CategoryId, StatusId, ReleaseId, CreatedAt, UpdatedAt)
                VALUES (@Title, @Description, @CreatedByUserId, @AssignedToUserId, @ClientId, @CategoryId, @StatusId, @ReleaseId, SYSUTCDATETIME(), @UpdatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(Issue entity)
        {
            const string sql = "UPDATE dbo.Issue SET Title=@Title, Description=@Description, AssignedToUserId=@AssignedToUserId, ClientId=@ClientId, CategoryId=@CategoryId, StatusId=@StatusId, ReleaseId=@ReleaseId, UpdatedAt=@UpdatedAt WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.Issue WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
