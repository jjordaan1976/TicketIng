using Dapper;
using System.Data;
using TicketIng.Models;

namespace TicketIng.Api.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection _db;
        public UserRepository(IDbConnection db) => _db = db;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            const string sql = "SELECT * FROM dbo.User";
            return await _db.QueryAsync<User>(sql);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM dbo.User WHERE Id = @Id";
            return await _db.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<int> InsertAsync(User entity)
        {
            const string sql = @"
                INSERT INTO dbo.User (ClientId, UserName, Email, RoleId, CreatedAt)
                VALUES (@ClientId, @UserName, @Email, @RoleId, SYSUTCDATETIME());
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, entity);
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            const string sql = "UPDATE dbo.User SET ClientId=@ClientId, UserName=@UserName, Email=@Email, RoleId=@RoleId WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, entity);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM dbo.User WHERE Id = @Id";
            var rows = await _db.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
